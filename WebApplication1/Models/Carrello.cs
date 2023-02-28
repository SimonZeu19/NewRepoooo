using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Carrello
    {
        public int id_carrello { get; set; }

        public int id_attrezzo { get; set; }

        public int id_utente { get; set; }

        public int quantita { get; set; }
    }
}