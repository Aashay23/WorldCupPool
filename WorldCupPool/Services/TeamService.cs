using System;
using System.Collections.Generic;
using MongoDB.Driver;
using WorldCupPool.Models;

namespace WorldCupPool.Services
{
    public class TeamService
    {
        MongoClient _client;
        IMongoCollection<Team> _teams;
        IMongoDatabase _database;
        BetService betService = new BetService();

        public TeamService()
        {
            string mongoConnectionString = "mongodb://aashayS:Potatohead23@purduepool-shard-00-00-untvh.mongodb.net:27017,purduepool-shard-00-01-untvh.mongodb.net:27017,purduepool-shard-00-02-untvh.mongodb.net:27017/admin?replicaSet=PurduePool-shard-0&ssl=true";
            _client = new MongoClient(mongoConnectionString);

            _database = _client.GetDatabase("WCPool");

            _teams = _database.GetCollection<Team>("Teams");
        }

        public List<Team> GetTeams()
        {
            var wcTeams = _teams.Find(_ => true).ToList();

            return wcTeams;
        }

        public Team UpdateTeamPerformance(string teamName, string performance)
        {
            var gameResult = (RulesEnum)Enum.Parse(typeof(RulesEnum), performance);

            var team = _teams.Find(t => t.Name == teamName).FirstOrDefault();

            team.Points += (int)gameResult;
            team.Performance.Add(performance);

            var updates = Builders<Team>.Update.Set("Points", team.Points).Push("Performance", performance);

            _teams.UpdateOne(t => t.TeamId == team.TeamId, updates);

            betService.UpdateBets(team.Name, (int)gameResult);

            return team;
        }
    }
}
