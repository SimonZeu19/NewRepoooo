using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Classi
{
    public class Vendite
    {
        public int id_vendita { get; set; }

        public int id_utente { get; set; }

        public int id_attrezzo { get; set; }
        public string nome { get; set; }

        public int quantita { get; set; }

        public System.DateTime data { get; set; }

        public string indirizzoconsegna { get; set; }

        public int codicepromo { get; set; }

        public string cartacredito { get; set; }

        public float prezzo { get; set; }
    }
}
