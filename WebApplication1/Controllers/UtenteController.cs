using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UtenteController : Controller
    {

        public static ServiceReference1.Service1Client wcf = new ServiceReference1.Service1Client();
        

        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult Products()
        {
            return View();
        }

        public ActionResult Carrello()
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

        public ActionResult Logout()
        {
            return RedirectToAction("Index","Home");
        }

    }
}


