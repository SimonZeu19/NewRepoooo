using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ListaUtenti
    {
        public int id_utente { get; set; }

        [Display(Name = "NomeUtente")]
        public string nomeutente { get; set; }

        [Display(Name = "Indireizzo E-mail")]
        public string email { get; set; }

        [Display (Name = "password")]
        public string password { get; set; }

        

    }
}