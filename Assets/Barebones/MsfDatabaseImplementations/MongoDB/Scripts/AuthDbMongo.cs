#if (!UNITY_WEBGL && !UNITY_IOS) || UNITY_EDITOR
using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Barebones.MasterServer
{
    /// <summary>
    /// MongoDB implementation of auth database
    /// http://mongodb.github.io/mongo-csharp-driver/1.11/getting_started/
    /// </summary>
    public class AuthDbMongo : IAuthDatabase
    {
        private MongoServer _server;
        private MongoDatabase _database;

        private MongoCollection<AccountDataMongo> _accountsCollection;
        private MongoCollection<PasswordResetData> _resetCodesCollection;
        private MongoCollection<EmailConfirmationData> _emailConfirmations;

        public const string EmailConfirmations = "emailConfirmations";

        public AuthDbMongo(string connectionString, string databaseName) 
            : this(new MongoClient(connectionString), databaseName)
        {
        }

        public AuthDbMongo(MongoClient client, string databaseName)
        {
            _server = client.GetServer();
            _database = _server.GetDatabase(databaseName);

            // Setup collections (a lot like tables in SQL databases)
            _accountsCollection = _database.GetCollection<AccountDataMongo>("accounts");
            _resetCodesCollection = _database.GetCollection<PasswordResetData>("pswResetCodes");
            _emailConfirmations = _database.GetCollection<EmailConfirmationData>("emailConfirmations");

            // Make usernames unique
            _accountsCollection.CreateIndex(IndexKeys<AccountDataMongo>.Ascending(e => e.Username), 
                new IndexOptionsBuilder().SetUnique(true));

            // Make emails unique
            _accountsCollection.CreateIndex(IndexKeys<AccountDataMongo>.Ascending(e => e.Email),
                new IndexOptionsBuilder().SetUnique(true));
        }

        public IAccountData CreateAccountObject()
        {
            return new AccountDataMongo();
        }

        public IAccountData GetAccount(string username)
        {
            var query = Query<AccountDataMongo>.EQ(e => e.Username, username);
            return _accountsCollection.FindOne(query);
        }

        public IAccountData GetAccountByToken(string token)
        {
            var query = Query<AccountDataMongo>.EQ(e => e.Token, token);
            return _accountsCollection.FindOne(query);
        }

        public IAccountData GetAccountByEmail(string email)
        {
            var query = Query<AccountDataMongo>.EQ(e => e.Email, email);
            return _accountsCollection.FindOne(query);
        }

        public void SavePasswordResetCode(IAccountData account, string code)
        {
            // Remove older entries
            var query = Query<PasswordResetData>.EQ(p => p.Email, account.Email);
            _resetCodesCollection.Remove(query);

            // Save a new one 
            _resetCodesCollection.Insert(new PasswordResetData()
            {
                Code = code,
                Email = account.Email
            });
        }

        public IPasswordResetData GetPasswordResetData(string email)
        {
            var query = Query<PasswordResetData>.EQ(p => p.Email, email);
            return _resetCodesCollection.FindOne(query);
        }

        public void SaveEmailConfirmationCode(string email, string code)
        {
            // Remove older entries
            var query = Query<EmailConfirmationData>.EQ(p => p.Email, email);
            _emailConfirmations.Remove(query);

            // Save a new one 
            _emailConfirmations.Insert(new EmailConfirmationData()
            {
                Code = code,
                Email = email
            });
        }

        public string GetEmailConfirmationCode(string email)
        {
            var query = Query<EmailConfirmationData>.EQ(e => e.Email, email);
            var result = _emailConfirmations.FindOne(query);
            return result != null ? result.Code : null;
        }

        public void UpdateAccount(IAccountData account)
        {
            _accountsCollection.Save(account as AccountDataMongo);
        }

        public void InsertNewAccount(IAccountData account)
        {
            _accountsCollection.Insert(account as AccountDataMongo);
        }

        public void InsertToken(IAccountData account, string token)
        {
            account.Token = token;
            UpdateAccount(account);
        }

        #region Concrete data schemes implementation

        private class EmailConfirmationData
        {
            // Necessary for each model
            public ObjectId Id { get; set; }

            public string Email { get; set; }
            public string Code { get; set; }
        }

        private class PasswordResetData : IPasswordResetData
        {
            // Necessary for each model
            public ObjectId Id { get; set; }

            public string Email { get; set; }
            public string Code { get; set; }
        }

        public class AccountDataMongo : IAccountData
        {
            // Necessary for each model
            public ObjectId Id { get; set; }

            public string Username { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
            public string Token { get; set; }
            public bool IsAdmin { get; set; }
            public bool IsGuest { get; set; }
            public bool IsEmailConfirmed { get; set; }
            public Dictionary<string, string> Properties { get; set; }
            public event Action<IAccountData> OnChange;

            public void MarkAsDirty()
            {
                if (OnChange != null)
                    OnChange.Invoke(this);
            }
        }

        #endregion
    }
}
#endif

