using ConsoleApp1.Classi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ConsoleApp1
{
    // NOTA: è possibile utilizzare il comando "Rinomina" del menu "Refactoring" per modificare il nome di interfaccia "IService1" nel codice e nel file di configurazione contemporaneamente.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        //string Registrazione(string nome, string cognome, string codicefiscale, System.DateTime datanascita,string email,string username, string password);
        Utenti Registrazione(Utenti utente);
        [OperationContract]
        Utenti LoginUtente(Utenti utente);
        [OperationContract]
        Utenti LoginAdmin(Utenti utenti);
        [OperationContract]
        //(List<Attrezzi>, string) ListaAttrezzi(int id_attrezzo);
        //[OperationContract]
        
        Attrezzi FillListAttrezzi();
        [OperationContract]
        (int ,string) Addattrezzi(Attrezzi attrezzi);
        [OperationContract]
        (Attrezzi, string) viewSpecificheattrezzi(int id_attrezzo);
        [OperationContract]
        (bool, string) crearecarrello(int id_attrezzo, int id_utente, int quntita);
        [OperationContract]
        (bool, string) Removeattrezzi(int id_attrezzo);
        [OperationContract]
        (List<Carrello>, string) ViewCarrello(int id_utente);
        [OperationContract]
        (bool, string) Removecarrello(int id_carrello);
        [OperationContract]
        (List<Utenti>, string) ViewUtenti(int id_utente);
       
        [OperationContract]
        (List<Vendite>, string) ViewVendite(int id_utente);

        [OperationContract]
        (bool, string) Buy(int id_utente, string indirizzoresidenza, string codicepromo, string cartacredoto);


    }
}
