using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class TimeController : Controller
    {
        private static List<TimeModel> times;
        // GET: Time
        public TimeController()
        {
            times = new List<TimeModel>()
            {
                new TimeModel()
                {
                    Nome="Palmeiras",
                    Id=1,
                    Titulos = 13,
                    Cidade = "São Paulo"
                },
                new TimeModel()
                {
                    Nome="Santos",
                    Id=2,
                    Titulos = 10,
                    Cidade = "Santos"
                }
            };
        }

        // GET: ProfessorController
        public ActionResult Index()
        {
            return View(times);
        }

        // GET: ProfessorController/Details/5
        public ActionResult Details(int id)
        {
            var tim = times.Find(e => e.Id == id);
            return View(tim);
        }

        // GET: ProfessorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfessorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var tim = new TimeModel();
                tim.Nome = collection["Nome"];
                tim.Titulos = int.Parse(collection["Titulos"]);
                tim.Cidade = collection["Cidade"];
                tim.Id = times.Count + 1;
                times.Add(tim);
                return View("Index", times);
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfessorController/Edit/5
        public ActionResult Edit(int id)
        {
            var tim = times.Find(e => e.Id == id);
            return View(tim);
        }

        // POST: ProfessorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var prof = times.Find(e => e.Id == id);
                prof.Titulos = int.Parse(collection["Titulo"]);
                prof.Cidade = collection["Cidade"];
                return View("Index", times);
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfessorController/Delete/5
        public ActionResult Delete(int id)
        {
            var tim = times.Find(e => e.Id == id);
            return View(tim);
        }

        // POST: ProfessorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var tim = times.Find(e => e.Id == id);
                times.Remove(tim);

                return View("Index", times);
            }
            catch
            {
                return View();
            }
        }
    }
}