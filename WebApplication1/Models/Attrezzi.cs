using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Attrezzi
    {
        [Display(Name = "Id_attrezzo")]
        public int id_attrezzo { get; set; }

        [Display(Name = "Immagine")]
        [DataType(DataType.Upload)]
        public string img_url { get; set; }

        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Display(Name ="Colore")]
        public string colore { get; set; }

        [Display(Name ="Dimensione")]
        public string dimensione { get; set; }

        [Display(Name ="Marca")]
        public string marchio { get; set; }

        [Display(Name = "Peso")]
        public double peso { get; set; }

        [Display(Name = "prezzo")]
        public float prezzo { get; set; }

        [Display(Name = "Quantità")]
        public int quantita { get; set; }

        [Display(Name = "Materiale")]
        public string materiale { get; set; }

    }
}