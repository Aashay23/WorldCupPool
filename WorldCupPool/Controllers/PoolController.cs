using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorldCupPool.Models;
using WorldCupPool.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorldCupPool.Controllers
{
    public class PoolController : Controller
    {
        DataAccess dataAccess = new DataAccess();
        TeamService teamService = new TeamService();
        BetService betService = new BetService();

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Teams([FromQuery] string id)
        {
            
            var teams = teamService.GetTeams();

            dynamic model = new ExpandoObject();
            model.Teams = teams;

            if (id == "2312")
            {
                model.isAdmin = true;
            }else
            {
                model.isAdmin = false;
            }

            model.PerformanceRules = (List<string>)Enum.GetNames(typeof(RulesEnum)).ToList();

            return View("Teams", model);
        }

        public IActionResult Bets()
        {
            var bets = betService.GetBets();
            return View("Bets", bets);
        }

        public IActionResult Standings([FromQuery] string id)
        {
            dynamic model = new ExpandoObject();
            model.Standings = betService.GetStandings();

            if (id == "2312")
            {
                model.isAdmin = true;
            }
            else
            {
                model.isAdmin = false;
            }

            return View("Standings", model);
        }
    }
}
