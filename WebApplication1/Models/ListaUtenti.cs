
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace WebApplication1.Models
{
    public class ListaUtenti
    {
        public static ListaUtenti fromClassi(ConsoleApp1.Classi.Utenti source)
        {
            ListaUtenti ut = new ListaUtenti()
            {
                id_utente = source.id_utente,

               // img_url = $"/Images/{source.id_attrezzo}.jpg",
                nomeutente = source.nome,
                email = source.email,
                password = source.password,
                

            };

            return ut;
        }
        public int id_utente { get; set; }

        [Display(Name = "NomeUtente")]
        public string nomeutente { get; set; }

        [Display(Name = "Indireizzo E-mail")]
        public string email { get; set; }

        [Display (Name = "password")]
        public string password { get; set; }

        public List<ListaUtenti> utente { get; set; }

    }
}