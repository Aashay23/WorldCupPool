using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorldCupPool.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorldCupPool.Controllers
{
    public class PoolController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Teams([FromQuery] string id)
        {
            Team arg = new Team("Argentina", 40);
            Team aus = new Team("Australia", 1);

            List<Team> teams = new List<Team>()
            {
                arg,
                aus
            };

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
            Bet aashay = new Bet("Aashay", new List<string>()
            {
                "Brazil",
                "Portugal"
            });
            Bet adit = new Bet("Adit", new List<string>()
            {
                "Belgium",
                "Germany"
            });

            List<Bet> bets = new List<Bet>()
            {
                aashay,
                adit
            };

            return View("Bets", bets);
        }

        public IActionResult Standings([FromQuery] string id)
        {
            Bet aashay = new Bet("Aashay", new List<string>()
            {
                "Brazil",
                "Portugal"
            }, 2);
            Bet adit = new Bet("Adit", new List<string>()
            {
                "Belgium",
                "Germany"
            }, 3);

            List<Bet> bets = new List<Bet>()
            {
                aashay,
                adit
            };

            var standings = bets.OrderByDescending(b => b.TotalPoints).ToList();

            dynamic model = new ExpandoObject();
            model.Standings = standings;

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
