using System;
using System.Collections.Generic;

namespace WorldCupPool.Models
{
    public class Team
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public List<RulesEnum> Performance { get; set; }
        public int Points { get; set; }

        public Team(string name, int cost)
        {
            Name = name;
            Cost = cost;
            Performance = new List<RulesEnum>()
            {
                RulesEnum.GMW,
                RulesEnum.GMW
            };
            Points = 9;
        }

        public void AddPerformance(string teamName, RulesEnum performance)
        {
            
        }
    }
}
