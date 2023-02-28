using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class AddAttrezzi
    {

        [Display(Name = "Immagine")]
        [Required(ErrorMessage = "Immagine richiesta")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase image_file { get; set; }

        [Display(Name = "Marca")]
        [Required(ErrorMessage = "Marca richiesta")]
        [MaxLength(254, ErrorMessage = "La marca non può essere più lunga di {1} caratteri")]
        public string brand { get; set; }

        [Display(Name = "Modello")]
        [Required(ErrorMessage = "Modello richiesto")]
        [MaxLength(254, ErrorMessage = "Il modello non può essere più lungo di {1} caratteri")]
        public string model { get; set; }

        [Display(Name = "Colore")]
        [Required(ErrorMessage = "Colore attrezzo richiesta")]
        public double display { get; set; }

        [Display(Name = "Peso")]
        [Required(ErrorMessage = "Peso attrezzo richiesto")]
        public int sim_count { get; set; }

        [Display(Name = "Prezzo")]
        [Required(ErrorMessage = "Prezzo richiesto")]
        public decimal price { get; set; }

        [Display(Name = "Pezzi Disponibili")]
        [Required(ErrorMessage = "Numero pezzi richiesto")]
        public int quantity { get; set; }

    }
}