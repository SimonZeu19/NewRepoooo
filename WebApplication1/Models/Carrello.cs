namespace WebApplication1.Models
{
    public class Carrello
    {

        // Conversion helper function
        public static Carrello fromClassi(ConsoleApp1.Classi.Carrello src)
        {
            return new Carrello()
            {
                cart_id = src.id_carrello,
                attrezzo = Attrezzi.fromClassi( src.attrezzo),
                quantity = src.quantita
            };
        }

        public int cart_id { get; set; }

        public Attrezzi attrezzo { get; set; }

        public int quantity { get; set; }
    }
}