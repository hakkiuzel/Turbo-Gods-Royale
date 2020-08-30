#if (!UNITY_WEBGL && !UNITY_IOS) || UNITY_EDITOR
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using UnityEngine;

namespace Barebones.MasterServer
{
    /// <summary>
    /// MongoDB implementation of auth database
    /// http://mongodb.github.io/mongo-csharp-driver/1.11/getting_started/
    /// </summary>
    public class ProfilesDbMongo : IProfilesDatabase
    {
        private MongoServer _server;
        private MongoDatabase _database;

        private MongoCollection<ProfileDataMongo> _profilesCollection;

        public ProfilesDbMongo(MongoClient client, string databaseName)
        {
            _server = client.GetServer();
            _database = _server.GetDatabase(databaseName);

            // Setup collections
            _profilesCollection = _database.GetCollection<ProfileDataMongo>("profiles");

            // Make usernames unique
            _profilesCollection.CreateIndex(IndexKeys<ProfileDataMongo>.Ascending(e => e.Username),
                new IndexOptionsBuilder().SetUnique(true));
        }

        /// <summary>
        /// Should restore all values of the given profile, 
        /// or not change them, if there's no entry in the database
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public void RestoreProfile(ObservableServerProfile profile)
        {
            var data = FindOrCreateData(profile);
            profile.FromStrings(data.Data);
        }

        private ProfileDataMongo FindOrCreateData(ObservableServerProfile profile)
        {
            var query = Query<ProfileDataMongo>.EQ(e => e.Username, profile.Username);
            var result = _profilesCollection.FindOne(query);

            if (result == null)
            {
                result = new ProfileDataMongo()
                {
                    Username = profile.Username,
                    Data = profile.ToStringsDictionary()
                };

                _profilesCollection.Insert(result);
            }
            return result;
        }

        /// <summary>
        /// Should save updated profile into database
        /// </summary>
        /// <param name="profile"></param>
        public void UpdateProfile(ObservableServerProfile profile)
        {
            var data = FindOrCreateData(profile);
            data.Data = profile.ToStringsDictionary();

            _profilesCollection.Save(data);
        }

        /// <summary>
        /// Represents a structure of profile in the database
        /// </summary>
        private class ProfileDataMongo
        {
            // Necessary for each model
            public ObjectId Id { get; set; }

            public string Username { get; set; }
            public Dictionary<short, string> Data { get; set; }
        }
    }
}
#endif

