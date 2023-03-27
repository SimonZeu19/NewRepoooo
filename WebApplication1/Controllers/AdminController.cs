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

        public ActionResult SpecificheAttrezzi()
        {
            return View();
        }

       [HttpGet]
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


        public ActionResult CancellAttrezzi()
        {
            int id_attrezzo = Convert.ToInt32(Session["Id_attrezzo"]);
            var result = wcf.viewSpecificheattrezzi(id_attrezzo);
            

            if (result != null)
            {   
                return View("CancellAttrezzi", Models.CancellAttrezzi.fromClassi(result));
            }

            else
            {
                return RedirectToAction("Attrezzi");
            }
        }

        [HttpPost]
        public ActionResult CancellAttrezzi(int id_attrezzo)
        {
            var result2 = wcf.Removeattrezzi(id_attrezzo);
            if (result2 != null)
            {
                return RedirectToAction("Attrezzi");
            }
            else
            {
                return RedirectToAction("Attrezzi");
            }
        }
        public ActionResult ListaUtenti()
        {


            return View("ListaUtenti");
        }

        [HttpPost]
        public ActionResult ListaUtenti(int id_utente)
        {
            var result = wcf.ViewUtenti();
            List<ListaUtenti> utente = new List<ListaUtenti>();

            foreach (ConsoleApp1.Classi.Utenti utenti in result)
            {
                utente.Add(Models.ListaUtenti.fromClassi(utenti));
                return View(id_utente);
            }
            return View("ListaUtente", utente);
            
        }

    }
}