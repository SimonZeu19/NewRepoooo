namespace WebApplication1.Models
{
    public class Ordina
    {
        public Attrezzi attrezzo { get; set; }
      
        public int quantita { get; set; }

        public string data { get; set; }

        public string indirizzoconsegna { get; set; }

        public int codicepromo { get; set; }

        public string cartacredito { get; set; }

        public float prezzo { get; set; }
    }
}