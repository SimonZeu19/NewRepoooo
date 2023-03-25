using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        public static ServiceReference1.Service1Client wcf = new ServiceReference1.Service1Client();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Attrezzi()
        {
            var result = wcf.FillListAttrezzi();
            List<Attrezzi> attrezzi = new List<Attrezzi>();

            foreach (ConsoleApp1.Classi.Attrezzi attrezzo in result)
            {
                attrezzi.Add(Models.Attrezzi.fromClassi(attrezzo));
            }
            return View("Attrezzi", attrezzi);
        }

        public ActionResult SpecificheAttrezzi(int id_attrezzo)
        {

            var result = wcf.viewSpecificheattrezzi(id_attrezzo);
            // Attrezzi att = new Attrezzi();
            if (result != null)
            {

                return View("SpecificheAttrezzi", Models.SpecificheAttrezzi.fromClassi(result));
            }

            else return HttpNotFound();
        }

        public ActionResult AddAttrezzi()
        {


            return View();
        }


        public ActionResult AddAttrezzi(AddAttrezzi attrezzi)
        {

            ConsoleApp1.Classi.Attrezzi at = attrezzi.toInternalAttrezzi();
            if (at == null)
            {
                ModelState.AddModelError("", "Si è verificato un errore durante la creazione dell' attrezzo");
                return View();


            }

            var attre = wcf.AddAttrezzi(at);
            if (attre.Equals(-1))
            {

                return View(attre);
            }
            return View("Attrezzi", "Admin");



        }




    }
}