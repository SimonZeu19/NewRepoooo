using ConsoleApp1.Classi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Windows;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        public static ServiceReference1.Service1Client wcf = new ServiceReference1.Service1Client();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Registrazione()
        {
            ViewBag.Message = "Your Registration page.";

            return View();
        }
        [HttpPost]
        public ActionResult Registrazione(Models.Registrazione utenti)
        {
            try
            {
                //pagina nella quale l' utente inserisce i dati per la registrazione
                string l = "Regitrazione avvenuta con successo!";
                Utenti ut = new Utenti();
                
                ut.nome = utenti.Nome;
                ut.cognome = utenti.Cognome;
                ut.username = utenti.Username;
                ut.email = utenti.Email;
                ut.codicefiscale = utenti.Codicefiscale;
                ut.numerotelefono = utenti.Numero_cellulare;
                ut.indirizzoresidenza = utenti.Indirizzo_residenza;
                ut.indirizzoconsegna = utenti.Indirizzo_consegna;
                ut.password = utenti.Password;

                var risultato = wcf.Registrazione(ut);
                if (risultato == null) throw new Exception("Registrazione fallita");
                Session["utenteAttivo"] = risultato;
                MessageBox.Show(l);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("LogOnError", e.Message);
                return View();
            }
        }


        public ActionResult Login()
        {
            ViewBag.Message = "Your User Login page.";

            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.Login utenti)
        {
            try
            {
                
                //Pagina nel quale l' utente inserisce i dati per il login
                string h = "Login effettuato correttamente!";
                Utenti ut = new Utenti();
                ut.email = utenti.email;
                ut.password = utenti.password;
                var risultato = wcf.LoginUtente(ut);
                Session["utenteAttivo"] = risultato;
                if (risultato == null)
                {
                    throw new Exception("Login fallito");
                }
                else
                {
                    if (risultato.isAdmin == false)
                    {
                        MessageBox.Show(h);
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        MessageBox.Show(h);
                        return RedirectToAction("Index", "Utente");
                    }

                }
                //MessageBox.Show(h);
                //return RedirectToAction("Index", utenti);


            }
            catch (Exception e)
            {
                ModelState.AddModelError("LogOnError", e.Message);
                return View();
            }
            //if (ModelState.IsValid)
            //{
            //    var wcf = new ServiceReference1.Service1Client();



            //    var login = wcf.LoginUtente(new Utenti()
            //    {
            //        email = utenti.email,
            //        password = utenti.password,
            //        admin = false
            //    });
            //    if (login.email == "0" & login.password=="0")
            //    {
            //        ModelState.AddModelError("CustomErrorLogin", "Error insert email or password!");
            //        return View("Login");
            //    }


            //}

        }

      

        public ActionResult Testing()
        {
            ViewBag.Message = "Your Admin Login page.";

            return View();
        }

    }
}