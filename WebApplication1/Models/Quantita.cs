using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Quantita
    {
        public int id_attrezzo { get; set; }

        [Display(Name ="Quantità")]
        [Required(ErrorMessage ="Quntità richiesta")]
        public int quantità { get; set; }
    }
}