using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    
    public class SpecificheAttrezzi
    {
        public static SpecificheAttrezzi fromClassi(ConsoleApp1.Classi.Attrezzi source)
        {
            SpecificheAttrezzi att_Details = new SpecificheAttrezzi()
            {
                id_attrezzo = source.id_attrezzo,

                img_url = $"/Images/{source.id_attrezzo}.jpg",
                nome = source.nome,
                colore = source.colore,
                dimensione = source.dimensione,
                marchio = source.marchio,
                peso = source.peso,
                prezzo = source.prezzo,
                quantita = source.quantita,
                materiale = source.materiale,

            };

            return att_Details;
        }
        public int id_attrezzo { get; set; }

        public string img_url { get; set; }

        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Display(Name = "Colore")]
        public string colore { get; set; }

        [Display(Name = "Dimensione")]
        public string dimensione { get; set; }

        [Display(Name = "Marca")]
        public string marchio { get; set; }

        [Display(Name = "Peso")]
        public double peso { get; set; }

        [Display(Name = "prezzo")]
        public float prezzo { get; set; }

        [Display(Name = "Quantità")]
        public int quantita { get; set; }

        [Display(Name = "Materiale")]
        public string materiale { get; set; }

        public List<Attrezzi> Attrezzo { set; get; }
    }
}