using System;
using System.Collections.Generic;
using MongoDB.Driver;
using WorldCupPool.Models;

namespace WorldCupPool.Services
{
    public class DataAccess
    {
        MongoClient _client;
        IMongoCollection<Team> _teams;
        IMongoDatabase _database;

        public DataAccess()
        {
            string mongoConnectionString = "mongodb://aashayS:Potatohead23@purduepool-shard-00-00-untvh.mongodb.net:27017,purduepool-shard-00-01-untvh.mongodb.net:27017,purduepool-shard-00-02-untvh.mongodb.net:27017/admin?replicaSet=PurduePool-shard-0&ssl=true";
            _client = new MongoClient(mongoConnectionString);

            _database = _client.GetDatabase("WCPool");
            _teams = _database.GetCollection<Team>("Teams");
        }

        public IMongoDatabase GetDatabase()
        {
            return _database;
        }
    }
}
