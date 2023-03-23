using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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


        public ActionResult Attrezzi() {
            var result = wcf.FillListAttrezzi();
            List<Attrezzi> attrezzi = new List<Attrezzi>();
            foreach (ConsoleApp1.Classi.Attrezzi attrezzo in result) {
                attrezzi.Add(Models.Attrezzi.fromClassi(attrezzo));
            }
            return View("Attrezzi", attrezzi);
        }

        public ActionResult SpecificheAttrezzi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SpecificheAttrezzi(int id_attrezzo)
        {
          var wcf = new ServiceReference1.Service1Client();
          var result = wcf.viewSpecificheattrezzi(id_attrezzo);


          return View();

        }
        
    }
}
