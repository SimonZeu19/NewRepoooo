
using System.Collections.Generic;


namespace WebApplication1.Models
{
    public class Attrezzi
    {
        public static Attrezzi fromClassi(ConsoleApp1.Classi.Attrezzi source)
        {
            Attrezzi att = new Attrezzi()
            {
                id_attrezzo = source.id_attrezzo,
                prodotto = $"/Images/{source.id_attrezzo}.jpg",
                nome = source.nome,
                colore = source.colore,
                dimensione = source.dimensione,
                marchio = source.marchio,
                peso = source.peso,
                prezzo = (decimal)source.prezzo,
                quantita = source.quantita,
                materiale = source.materiale,

            };

            return att;
        }
        public int id_attrezzo { get; set; }
        public string prodotto { get; set; }
        public string nome { get; set; }

        public string colore { get; set; }

        public string dimensione { get; set; }

        public string marchio { get; set; }

        public double peso { get; set; }

        public decimal prezzo { get; set; }

        public int quantita { get; set; }

        public string materiale { get; set; }

        public List<Attrezzi> Attrezzo { set; get; }
        

    }
}