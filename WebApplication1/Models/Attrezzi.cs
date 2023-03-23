using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Attrezzi
    {
        public static Attrezzi fromClassi(ConsoleApp1.Classi.Attrezzi source)
        {
            Attrezzi att = new Attrezzi()
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

            return att;
        }
        public int id_attrezzo { get; set; }

        public string img_url { get; set; }

        public string nome { get; set; }

        public string colore { get; set; }

        public string dimensione { get; set; }

        public string marchio { get; set; }

        public double peso { get; set; }

        public float prezzo { get; set; }

        public int quantita { get; set; }

        public string materiale { get; set; }



        public List<Attrezzi> Attrezzo { set; get; }
        

    }
}