using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace WorldCupPool.Models
{
    public class Bet
    {
        [BsonId]
        public ObjectId BetId { get; set; }
        public string Name { get; set; }
        public List<string> SelectedTeams { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int TotalPoints { get; set; }

        public Bet(string name, List<string> teams, int points = 0)
        {
            Name = name;
            SelectedTeams = teams;
            TotalPoints = points;
        }
    }
}
