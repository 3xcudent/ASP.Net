using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL.Models;
using WebApplication1.DAL.Contexts;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly DziekanatContext bazaDanychDziekanatu;

        public HomeController( DziekanatContext bazaDanychDziekanatu)
        {
            this.bazaDanychDziekanatu = bazaDanychDziekanatu;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

     

        [HttpGet]
        public IActionResult PlanZajec()
        {
            //List<Zajecia> planZajec = bazaDanychDziekanatu.Zajecia.ToList();
            List<Zajecia> planZajec = bazaDanychDziekanatu.Zajecia.ToList();
            List<Zajecia> planZajec2 = (List<Zajecia>)(from word in bazaDanychDziekanatu.Zajecia where word.NazwaZajec.StartsWith("Prog") select word).ToList();
            List<Zajecia> planZajec3 = (List<Zajecia>)(from word in bazaDanychDziekanatu.Zajecia where word.NazwaZajec.Contains("J") select word).ToList();
            List<Zajecia> planZajec4 = (List<Zajecia>)(from word in bazaDanychDziekanatu.Zajecia where !word.NazwaZajec.Contains(" ") select word).ToList();
            List<Zajecia> planZajec5 = (List<Zajecia>)(from word in bazaDanychDziekanatu.Zajecia select new Zajecia() {ID = word.ID, NazwaZajec = word.NazwaZajec.Substring(0, 3), TerminZajec= word.TerminZajec}).ToList();

            return View(planZajec5);
        }


        [HttpGet]
        public IActionResult Student()
        {
            List<Student> students = (List<Student>)bazaDanychDziekanatu.Student.ToList();
            return View(students);
        }


        [HttpPost]
        [Route("{controller}/DodajDoPlanu/{nazwa?}")]
        public IActionResult DodajDoPlanu(string nazwa = null)
        {
            int id = new Random().Next();
            string komunikat = $"Zajęcia o nazwie {nazwa} zostały dodane do planu pod Id {id}";
            Console.WriteLine(komunikat);
            return Ok(new { komunikat = komunikat });
        }
    }
}
