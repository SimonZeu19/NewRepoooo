using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1.Classi
{
   public class Attrezzi
    {
        [Key]
        public int id_attrezzo { get; set; }

        [Display(Name = "Product Picture URL")]
        public string img_url { get; set; }

        public string nome { get; set; }

        public string colore { get; set; }

        public string dimensione { get; set; }

        public string marchio { get; set; }

        public double peso { get; set; }

        public float prezzo { get; set; }

        public int quantita { get; set; }

        public string materiale { get; set; }
    }
}