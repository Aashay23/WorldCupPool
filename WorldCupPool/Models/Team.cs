using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace WorldCupPool.Models
{
    public class Team
    {
        [BsonId]
        public ObjectId TeamId { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Performance { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int Points { get; set; }

        public Team(string name, int cost)
        {
            Name = name;
            Cost = cost;
            Performance = new List<string>();
            Points = 0;
        }

        public void AddPerformance(string teamName, RulesEnum performance)
        {
            
        }
    }
}
