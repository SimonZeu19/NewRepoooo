using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Registrazione
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome richiesto")]
        [MinLength(4, ErrorMessage = "Il nome  non può essere più corto di {1} caratteri")]
        [MaxLength(254, ErrorMessage = "Il nome non può essere più lungo di {1} caratteri")]
        public string Nome { get; set; }

        [Display(Name = "Cognome")]
        [Required(ErrorMessage = "Cognome richiesto")]
        [MinLength(4, ErrorMessage = "Il cognome non può essere più corto di {1} caratteri")]
        [MaxLength(254, ErrorMessage = "Il cognome non può essere più lungo di {1} caratteri")]
        public string Cognome { get; set; }

        [Display(Name = "Codice fiscale")]
        [Required(ErrorMessage = "Codice fiscale richiesto")]
        [MinLength(4, ErrorMessage = "Il codice fiscale non può essere più corto di {1} caratteri")]
        [MaxLength(254, ErrorMessage = "Il codice fiscale non può essere più lungo di {1} caratteri")]
        public string Codicefiscale  { get; set; }

        [Display(Name = "Indirizzo di residenza")]
        [Required(ErrorMessage = "L'Indirizzo di residenza richiesto")]
        [MinLength(4, ErrorMessage = " Indirizzo di residenza non può essere più corto di {1} caratteri")]
        [MaxLength(254, ErrorMessage = "L'Indirizzo di residenza non può essere più lungo di {1} caratteri")]
        public string Indirizzo_residenza { get; set; }

        [Display(Name = "Indirizzo di consegna")]
        [Required(ErrorMessage = "L'Indirizzo di consegna richiesto")]
        [MinLength(4, ErrorMessage = " Indirizzo di consegna non può essere più corto di {1} caratteri")]
        [MaxLength(254, ErrorMessage = "L'Indirizzo di consegna non può essere più lungo di {1} caratteri")]
        public string Indirizzo_consegna { get; set; }

        [Display(Name = "Il numero di cellulare")]
        [Required(ErrorMessage = "Il numero di cellulare richiesto")]
        public long Numero_cellulare { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username richiesto")]
        [MinLength(4, ErrorMessage = "Lo username non può essere più corto di {1} caratteri")]
        [MaxLength(254, ErrorMessage = "Lo username non può essere più lungo di {1} caratteri")]
        public string Username { get; set; }

        [Display(Name = "Indirizzo E-mail")]
        [Required(ErrorMessage = "Indirizzo e-mail richiesto")]
        [EmailAddress(ErrorMessage = "Indirizzo e-mail non valido")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password richiesta")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "La password non può essere più corta di {1} caratteri")]
        [MaxLength(254, ErrorMessage = "La password non può essere più lunga di {1} caratteri")]
        public string Password { get; set; }

        [Display(Name = "Ripeti Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Le due password non corrispondono")]
        public string Repeat_password { get; set; }

    }
}