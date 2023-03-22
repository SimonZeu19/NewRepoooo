using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Attrezzi
    {
        

        public int id_attrezzo { get; set; }

      //  public string img_url { get; set; }

        public string nome { get; set; }

        public string marchio { get; set; }

        public double peso { get; set; }

        public float prezzo { get; set; }

        public int quantita { get; set; }

        public List<Attrezzi> attrezzi { set; get; }
        

    }
}