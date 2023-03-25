using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class AddAttrezzi
    {
        public ConsoleApp1.Classi.Attrezzi toInternalAttrezzi()
        {
            try
            {

                return new ConsoleApp1.Classi.Attrezzi()
                {
                    id_attrezzo = id_attrezzo,
                    nome = nome,
                    colore = colore,
                    dimensione = dimensione,
                    marchio = marchio,
                    peso = peso,
                    prezzo = prezzo,
                    quantita = quantita,
                    materiale = materiale,
                };
                

             }
            catch
            {
                return null;
            }
          
        
        
           
        }


        //[Display(Name = "Immagine")]
        //[Required(ErrorMessage = "Immagine richiesta")]
        //[DataType(DataType.Upload)]
        //public HttpPostedFileBase image_file { get; set; }

        [Display(Name = "Id")]
        [Required(ErrorMessage = "id richiesta")]
       
        public int id_attrezzo { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome richiesto")]
       
        public string nome { get; set; }

        [Display(Name = "Colore")]
        [Required(ErrorMessage = "Colore attrezzo richiesta")]
        public string colore { get; set; }

        [Display(Name = "Dimensione")]
        [Required(ErrorMessage = "Dimensione attrezzo richiesto")]
        public string dimensione { get; set; }

        [Display(Name = "Marchio")]
        [Required(ErrorMessage = "marchio richiesto")]
        public string marchio { get; set; }

        [Display(Name = "Peso")]
        [Required(ErrorMessage = "peso richiesto")]
        public double peso { get; set; }

        [Display(Name = "Prezzo")]
        [Required(ErrorMessage = "prezzo richiesto")]
        public float prezzo { get; set; }

        [Display(Name = "quantità")]
        [Required(ErrorMessage = "quantita richiesta")]
        public int quantita{ get; set; }

        [Display(Name = "Materiale")]
        [Required(ErrorMessage = "materiale richiesto")]
        public string materiale { get; set; }

    }
}