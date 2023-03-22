using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Classi
{
   public class Attrezzi
    {
        public int id_attrezzo { get; set; }

        public string nome { get; set; }

        public string colore { get; set; }

        public string dimensione { get; set; }

        public string marchio { get; set; }

        public double peso { get; set; }

        public float prezzo { get; set; }

        public int quantita { get; set; }

        public string materiale { get; set; }
        public List<Attrezzi> listattrezzi { get; set; }
        // List<Attrezzi> listattrezzi { get; set; }


    }
}
