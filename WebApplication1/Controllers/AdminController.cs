using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;


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

        public ActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
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
            var result = wcf.ViewUtenti();
            List<ListaUtenti> utenti = new List<ListaUtenti>();

            foreach (ConsoleApp1.Classi.Utenti utente in result)
            {
                utenti.Add(Models.ListaUtenti.fromClassi(utente));
            }
            return View("ListaUtenti", utenti);
        }

       

    }
}