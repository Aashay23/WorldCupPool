using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using WorldCupPool.Models;

namespace WorldCupPool.Services
{
    public class BetService
    {
        MongoClient _client;
        IMongoCollection<Bet> _bets;
        IMongoDatabase _database;

        public BetService()
        {
            string mongoConnectionString = "mongodb://aashayS:Potatohead23@purduepool-shard-00-00-untvh.mongodb.net:27017,purduepool-shard-00-01-untvh.mongodb.net:27017,purduepool-shard-00-02-untvh.mongodb.net:27017/admin?replicaSet=PurduePool-shard-0&ssl=true";
            _client = new MongoClient(mongoConnectionString);

            _database = _client.GetDatabase("WCPool");

            _bets = _database.GetCollection<Bet>("Bets");
        }

        public List<Bet> GetBets()
        {
            var poolBets = _bets.Find(_ => true).ToList();

            return poolBets;
        }

        public void UpdateBets(string teamName, int newPoints)
        {
            var bets = GetBets();

            var affefctedBets = bets.Where(b => b.SelectedTeams.Contains(teamName)).ToList();

            affefctedBets.ForEach(bet =>
            {
                var updatedPoints = bet.TotalPoints + newPoints;

                var betUpdate = Builders<Bet>.Update.Set("TotalPoints", updatedPoints);

                _bets.UpdateOne(b => b.BetId == bet.BetId, betUpdate);
            });
        }

        public List<Bet> GetStandings()
        {
            var bets = GetBets();

            return bets.OrderByDescending(b => b.TotalPoints).ToList();
        }

    }
}
