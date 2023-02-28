using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Login
    {
        [Display(Name = "Indirizzo E-mail")]
        [Required(ErrorMessage = "Indirizzo e-mail richiesto")]
        public string email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password richiesta")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}