using System;
using System.Collections.Generic;

namespace WorldCupPool.Models
{
    public class Bet
    {
        public string Name { get; set; }
        public List<string> SelectedTeams { get; set; }
        public int TotalPoints { get; set; }

        public Bet(string name, List<string> teams, int points = 0)
        {
            Name = name;
            SelectedTeams = teams;
            TotalPoints = points;
        }
    }
}
