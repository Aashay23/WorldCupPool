using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorldCupPool.Models;
using WorldCupPool.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorldCupPool.Controllers
{
    public class PoolServiceController : Controller
    {
        // GET: /<controller>/
        public Team AddTeamPerformance(string teamName, string performance)
        {
            TeamService teamService = new TeamService();
            var updatedTeam = teamService.UpdateTeamPerformance(teamName, performance);

            return updatedTeam;
        }
    }
}
