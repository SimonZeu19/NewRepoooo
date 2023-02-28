using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Classi
{
    public class Utenti
    {
        public int id_utente { get; set; }

        public string nome { get; set; }

        public string cognome { get; set; }

        public string codicefiscale { get; set; }

        public string email { get; set; }
        public string username { get; set; }

        public string password { get; set; }

        public int numerotelefono { get; set; }

        public string indirizzoresidenza { get; set; }
        public System.DateTime datanascita { get; set; }

        public bool admin { get; set; }
    }
}
