#if (!UNITY_WEBGL && !UNITY_IOS) || UNITY_EDITOR
using MongoDB.Driver;
#endif
using UnityEngine;

namespace Barebones.MasterServer
{
    public class MongoDbFactory : MonoBehaviour
    {
        [Header("MongoDB related")]
        public string DefaultConnectionString = "mongodb://localhost";
        public string DatabaseName = "masterServer";

#if (!UNITY_WEBGL && !UNITY_IOS) || UNITY_EDITOR
        private MongoClient _client;
#endif
        protected virtual void Awake()
        {
#if (!UNITY_WEBGL && !UNITY_IOS) || UNITY_EDITOR

            var connectionString = Msf.Args.IsProvided(Msf.Args.Names.DbConnectionString)
                    ? Msf.Args.DbConnectionString
                    : DefaultConnectionString;

            _client = new MongoClient(connectionString);

            Msf.Server.DbAccessors.SetAccessor<IAuthDatabase>(new AuthDbMongo(_client, DatabaseName));
            Msf.Server.DbAccessors.SetAccessor<IProfilesDatabase>(new ProfilesDbMongo(_client, DatabaseName));
#endif
        }
    }
}

