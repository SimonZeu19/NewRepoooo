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
        public string nome { get; set; }

        [Display(Name = "Cognome")]
        [Required(ErrorMessage = "Cognome richiesto")]
        [MinLength(4, ErrorMessage = "Il cognome non può essere più corto di {1} caratteri")]
        [MaxLength(254, ErrorMessage = "Il cognome non può essere più lungo di {1} caratteri")]
        public string cognome { get; set; }

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

        [Display(Name = "Il numero di cellulare")]
        [Required(ErrorMessage = "Il numero di cellulare richiesto")]
        [MinLength(4, ErrorMessage = " Il numero di cellulare non può essere più corto di {1} caratteri")]
        [MaxLength(254, ErrorMessage = "Il numero di cellulare non può essere più lungo di {1} caratteri")]
        public string Numero_cellulare { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username richiesto")]
        [MinLength(4, ErrorMessage = "Lo username non può essere più corto di {1} caratteri")]
        [MaxLength(254, ErrorMessage = "Lo username non può essere più lungo di {1} caratteri")]
        public string username { get; set; }

        [Display(Name = "Indirizzo E-mail")]
        [Required(ErrorMessage = "Indirizzo e-mail richiesto")]
        [EmailAddress(ErrorMessage = "Indirizzo e-mail non valido")]
        public string email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password richiesta")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "La password non può essere più corta di {1} caratteri")]
        [MaxLength(254, ErrorMessage = "La password non può essere più lunga di {1} caratteri")]
        public string password { get; set; }

        [Display(Name = "Ripeti Password")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Le due password non corrispondono")]
        public string repeat_password { get; set; }

    }
}