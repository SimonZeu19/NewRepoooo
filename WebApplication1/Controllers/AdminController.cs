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

        //public ActionResult Admin_Dashboard()
        //{
        //    ViewBag.Message = "Your Admin Dashboard page.";

        //    return View();
        //}

        //public ActionResult Admin_Login()
        //{
        //    ViewBag.Message = "Your Admin Login page.";

        //    return View();
        //}
        //public ActionResult Attrezzi(int id_attrezzo)
        //{
        //    var wcf = new ServiceReference1.Service1Client();
        //    var lista = wcf.ListaAttrezzi(id_attrezzo);
        //    return View("lista attrezzi", lista);

    //}
        public ActionResult Attrezzi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Attrezzi(int id_attrezzo)
        {
            var wcf = new ServiceReference1.Service1Client();
            var listattrezzi = wcf.listaAttrezzi(id_attrezzo);
           
            return View("Attrezzi",listattrezzi);
        }

        public ActionResult SpecificheAttrzzi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SpecificheAttrezzi(int id_attrezzo)
        {
            var wcf = new ServiceReference1.Service1Client();
            var attrezzi = wcf.viewSpecificheattrezzi(id_attrezzo);

            return View("SpecificheAttrezzi",Attrezzi);
            
        }
    }
}
