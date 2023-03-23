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


        public ActionResult Attrezzi() {
            var result = wcf.FillListAttrezzi();
            List<Attrezzi> attrezzi = new List<Attrezzi>();
            foreach (ConsoleApp1.Classi.Attrezzi attrezzo in result) {
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

            ViewBag.Message = "Your User Login page.";
            return View();
        }

        [HttpPost]
        public ActionResult AddAttrezzi(AddAttrezzi attrezzi)
        {
        //    try
        //    {
        //        //pagina nella quale l' utente inserisce i dati per la registrazione
        //        string l = "Aggiunta Attrezzo avvenuta con successo!";
        //        Attrezzi ut = new Attrezzi();

        //        ut.id_attrezzo =attrezzi.id_attrezzo;
        //        ut.nome = attrezzi.nome;
        //        ut.colore = attrezzi.colore;
        //        ut.dimensione = attrezzi.dimensione;
        //        ut.marchio = attrezzi.marchio;
        //        ut.peso = attrezzi.peso;
        //        ut.prezzo = attrezzi.prezzo;
        //        ut.quantita = attrezzi.quantita;
        //        ut.materiale = attrezzi.materiale;

        //        var risultato = wcf.Addattrezzi(ut);
        //        if (risultato == null) throw new Exception("Registrazione fallita");
        //        Session["utenteAttivo"] = risultato;
        //        MessageBox.Show(l);
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception e)
        //    {
        //        ModelState.AddModelError("LogOnError", e.Message);
        //        return View();
        //    }
        //}
        var result = wcf.Addattrezzi(attrezzi.toClassi());
            return RedirectToAction("Attrezzi",result);
        }
        
    }
}
