using ConsoleApp1.Classi;
using MySql.Data.MySqlClient;
using MySql.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;



namespace ConsoleApp1
{
    // NOTA: è possibile utilizzare il comando "Rinomina" del menu "Refactoring" per modificare il nome di classe "Service1" nel codice e nel file di configurazione contemporaneamente.
    public class Service1 : IService1
    {
        
         private static string connection_string = "datasource=localhost;port=3306;username=root;password=;database=shoppale;";
        public Utenti Registrazione(Utenti utente)
        {
            MySqlConnection conn = new MySqlConnection(connection_string);
            try
            {
                conn.Open();
                Utenti newUtente = new Utenti();
                using (MySqlCommand command = new MySqlCommand($"SELECT email FROM utenti WHERE email = '{utente.email}' LIMIT 1;", conn))
                {
                    using (MySqlDataReader resultSet = command.ExecuteReader())
                    {
                        if (resultSet.Read())
                        {
                            throw new Exception("Utente gia registrato");
                            
                        }
                    }
                    
                }
                using (MySqlCommand command = new MySqlCommand($"INSERT INTO utenti (email,password,username,nome,cognome,codicefiscale,indirizzoconsegna,indirizzoresidenza) VALUES ('{utente.email}','{utente.password}','{utente.username}','{utente.nome}','{utente.cognome}','{utente.codicefiscale}','{utente.indirizzoconsegna}','{utente.indirizzoresidenza}');", conn))
                {
                    if (command.ExecuteNonQuery()>0)
                    {
                        Console.WriteLine("registrazione ok");
                        conn.Close();
                        return utente;
                    }
                    else
                    {
                        throw new Exception("registrazione fallita");
                    }
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
            
        }
        public Utenti LoginUtente(Utenti utente)
        {
            Utenti ret = null;
            string ret2 = "";
            MySqlConnection conn = new MySqlConnection(connection_string);
           // Console.WriteLine("a");

            try
            {
                conn.Open();
                using (MySqlCommand command = new MySqlCommand($"SELECT * FROM utenti WHERE email='{utente.email}'AND password='{utente.password}' Limit 1;", conn))
                {
                    using (MySqlDataReader resultSet = command.ExecuteReader())
                    {
                        if (resultSet.Read())
                        {
                            ret = new Utenti
                            {
                                id_utente = (int)resultSet.GetUInt32(0),
                                nome = resultSet.GetString(1),
                                cognome = resultSet.GetString(2),
                                codicefiscale = resultSet.GetString(3),
                                email = resultSet.GetString(4),
                                username = resultSet.GetString(5),
                                password = resultSet.GetString(6),
                                indirizzoresidenza = resultSet.GetString(7),
                                indirizzoconsegna = resultSet.GetString(8),
                                numerotelefono = resultSet.GetInt64(9),
                                datanascita= resultSet.GetDateTime(10),
                                isAdmin = resultSet.GetBoolean(11),


                            };
                            //Console.WriteLine("login ok");
                            //conn.Close();
                            //return utente;
                            
                        }
                        else
                        {
                            throw new Exception("dati inseriti sbagliati");
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                ret2 = e.Message;
            }
            finally
            {
                if(conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return ret;
           
        }
        public Utenti LoginAdmin(Utenti utente)
        {

            MySqlConnection conn = new MySqlConnection(connection_string);

            try
            {
                conn.Open();
                using (MySqlCommand command = new MySqlCommand($"SELECT * FROM utenti WHERE email='{utente.username}'AND password='{utente.password}' Limit 1;", conn))
                {
                    using (MySqlDataReader resultSet = command.ExecuteReader())
                    {
                        if (resultSet.Read())
                        {
                            Console.WriteLine("login ok");
                            conn.Close();
                            return utente;
                        }
                        else
                        {
                            throw new Exception("dati inseriti sbagliati");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }


        
    }
        public (int, string) Addattrezzi(Attrezzi attrezzi)
        {
            int ret = -1;
            string ret2 = "";
            MySqlConnection conn = new MySqlConnection(connection_string);
            try
            {
                conn.Open();

                using(MySqlCommand command =new MySqlCommand($"INSERT INTO attrezzi(nome, colore, dimensione, quantita, peso, prezzo, marchio, materiale) VALUES ('{attrezzi.nome}','{attrezzi.colore}', '{attrezzi.dimensione}','{attrezzi.prezzo}','{attrezzi.quantita}','{attrezzi.materiale}',{attrezzi.marchio}','{attrezzi.peso}');", conn))
                {
                    if(command.ExecuteNonQuery()>0)
                    {
                        ret = (int)command.LastInsertedId;
                    }
                    else
                    {
                        throw new Exception("Aggiunta prodotto fallita");
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                ret2 = e.Message;
            }
            finally
            {
                if(conn.State==ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return (ret, ret2);
            
        }
        public (List<Attrezzi>, string) listaAttrezzi(int id_attrezzo)
        {
            List<Attrezzi> ret1 = new List<Attrezzi>();
            string ret2 = "";
            //string clause = "";
            
            MySqlConnection conn = new MySqlConnection(connection_string);
            try
            {
                conn.Open();
                using (MySqlCommand command = new MySqlCommand($"SELECT * FROM attrezzi ORDER BY id_attrezzo('{id_attrezzo}');"))
                {
                    using(MySqlDataReader resultSet = command.ExecuteReader())
                    {
                        while(resultSet.Read())
                        {
                            Attrezzi attrezzi = new Attrezzi()
                            {
                                id_attrezzo = (int)resultSet.GetUInt32(0),
                                nome = resultSet.GetString(1),
                                colore = resultSet.GetString(3),
                                dimensione = resultSet.GetString(4),
                                peso = resultSet.GetDouble(5),
                                prezzo = resultSet.GetFloat(6),
                                quantita = (int)resultSet.GetUInt32(7),
                                marchio = resultSet.GetString(8),
                                materiale = resultSet.GetString(9),
                            };
                            ret1.Add(attrezzi);
                        }
                    }
                }
                if(ret1.Count == 0)
                {
                    throw new Exception("Nessun prodotto dispo");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                ret2 = e.Message;
            }
            finally
            {
                if(conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return (ret1, ret2);
           
        }
        public (Attrezzi, string) viewSpecificheattrezzi(int id_attrezzo)
        {
            Attrezzi ret = null;
            string ret2 = "";
            //connexion au database
            MySqlConnection conn = new MySqlConnection(connection_string);
            try
            {
                conn.Open();
                //trouver un produit à travers l'id et l'imprimer
                using(MySqlCommand command = new MySqlCommand($"SELECT * FROM attrezzi WHERE id_attrezzo= '{id_attrezzo}'LIMIT 1;",conn))
                {
                    using(MySqlDataReader resultSet = command.ExecuteReader())
                    {
                        if(resultSet.Read())
                        {
                            ret =new Attrezzi
                            {
                                id_attrezzo = (int)resultSet.GetUInt32(0),
                                nome = resultSet.GetString(1),
                                colore = resultSet.GetString(2),
                                dimensione = resultSet.GetString(3),
                                peso = resultSet.GetDouble(4),
                                prezzo = resultSet.GetFloat(5),
                                quantita = (int)resultSet.GetUInt32(6),
                                marchio = resultSet.GetString(7),
                                materiale = resultSet.GetString(8),
                            };
                            
                            
                        }
                        else
                        {
                            throw new Exception("Atrrezzo non trovato");
                        }
                        
                        
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                ret2 = e.Message;
            }
            finally
            {
                if(conn.State==ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return (ret, ret2);

            
        }
        public (bool, string) Removeattrezzi(int id_attrezzo)
        {
            bool ret = false;
            string ret2 = "";

            MySqlConnection conn = new MySqlConnection(connection_string);
            try
            {
                conn.Open();

                using (MySqlCommand command = new MySqlCommand($"DELETE FROM attrezzi WHERE id_attrezzo= '{id_attrezzo}';", conn))
                {
                    ret = Convert.ToBoolean(command.ExecuteNonQuery());
                    if(!ret)
                    {
                        throw new Exception("Rimozione degli attrezzi fallita");
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                ret2 = e.Message;
            }
            finally
            {
                if(conn.State==ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return (ret, ret2);
        }

        public (bool, string) crearecarrello(int id_attrezzo, int id_utente, int quntita)
        {
            bool ret = false;
            string ret2 = "";
            int available = 0, id_carrello = -1;
            bool create_new = true;

            MySqlConnection conn = new MySqlConnection(connection_string);
            try
            {
                conn.Open();
                using(MySqlCommand command = new MySqlCommand($"SELECT id, quantita FROM attrezzi WHERE id='{id_attrezzo}'LIMIT 1;",conn))
                {
                    using (MySqlDataReader resultSet = command.ExecuteReader())
                    {
                        if(resultSet.Read())
                        {
                            available = (int)resultSet.GetUInt32(1);
                            if(quntita>available)
                            {
                                throw new Exception("La quantita suppera i numero di pessi disponibile");
                            }
                            
                        }
                        else
                        {
                             throw new Exception("il prodotto selezionato non esite");
                        }
                    }
                    
                }
                if(create_new)
                {
                    using(MySqlCommand command = new MySqlCommand($"INSERT INTO carrello(id_utente, id_attrezzo, quantita) VALUES ('{id_utente}','{id_attrezzo}','{quntita}');",conn))
                    {
                        if(command.ExecuteNonQuery()>0)
                        {
                            ret = true;
                        }
                        else
                        {
                            throw new Exception("Aggiunta al carrello fallito");
                        }
                    }
                }
                else
                {
                    using(MySqlCommand command = new MySqlCommand($"UPDATE carrello SET quantita='{quntita}' WHERE id_carrello = '{id_carrello}';", conn))
                    {
                        if(command.ExecuteNonQuery()>0)
                        {
                            ret = true;
                        }
                        else
                        {
                            throw new Exception("Aggiunta al carrello fallito");
                        }
                    }
                }
                

            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                ret2 = e.Message;
            }
            finally
            {
                if(conn.State==ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return (ret, ret2);
        }

        public (List<Carrello>, string) ViewCarrello(int id_utente)
        {
            List<Carrello> ret = new List<Carrello>();
            string ret2 = "";

            MySqlConnection conn = new MySqlConnection(connection_string);
            try
            {
                conn.Open();
                using(MySqlCommand command = new MySqlCommand($"SELECT * FROM carrello WHERE id_utente = '{id_utente}';",conn))
                {
                    using (MySqlDataReader resultSet = command.ExecuteReader())
                    {
                        while(resultSet.Read())
                        {
                            Carrello carrello = new Carrello()
                            {
                                id_carrello = (int)resultSet.GetUInt32(0),
                                quantita = (int)resultSet.GetUInt32(3),
                                id_attrezzo = (int)resultSet.GetUInt32(2)
                            };
                            ret.Add(carrello);
                        }
                    }
                }
                if(ret.Count==0)
                {
                    throw new Exception("nessun prodotto nel carrello");

                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                ret2 = e.Message;
            }
            finally
            {
                if(conn.State==ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return (ret, ret2);
            
        }
        public (bool, string) Removecarrello(int id_carrello)
        {
            bool ret = false;
            string ret2 = "";

            MySqlConnection conn = new MySqlConnection(connection_string);
            try
            {
                conn.Open();
                using (MySqlCommand command =new MySqlCommand($"DELETE FROM carrello WHERE id_carrello = '{id_carrello}';",conn))
                {
                    ret = Convert.ToBoolean(command.ExecuteNonQuery());
                    if(!ret)
                    {
                        throw new Exception("Rimozione del carrello fallito");
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                ret2 = e.Message;
            }
            finally
            {
                if(conn.State==ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return (ret, ret2);
        }

       

        public (List<Utenti>, string) ViewUtenti(int id_utente)
        {
            List<Utenti> ret = new List<Utenti>();
            string ret2 = "";

            MySqlConnection conn = new MySqlConnection(connection_string);
            try
            {
                conn.Open();

                using(MySqlCommand command = new MySqlCommand($"SELECT * FROM utenti ORDER BY id WHERE id_utente= '{id_utente}';",conn))
                {
                    using (MySqlDataReader resultSet = command.ExecuteReader())
                    {
                        while (resultSet.Read())
                        {
                            Utenti utente = new Utenti()
                            {
                                id_utente = (int)resultSet.GetUInt32(0),
                                username = resultSet.GetString(1),
                                password = "",
                                email = resultSet.GetString(2),
                                nome = resultSet.GetString(3),
                                cognome = resultSet.GetString(4),
                                codicefiscale = resultSet.GetString(5),
                                indirizzoresidenza = resultSet.GetString(6),
                                numerotelefono = (int)resultSet.GetUInt32(7),
                                isAdmin = resultSet.GetBoolean(8),
                                datanascita = resultSet.GetDateTime(9),
                            };
                            ret.Add(utente);

                        }
                    }
                }
                if(ret.Count==0)
                {
                    throw new Exception("nessun utente trovato");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                ret2 = e.Message;
            }
            finally
            {
                if(conn.State==ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return (ret, ret2);
        }

        public (List<Vendite>, string) ViewVendite(int id_utente)
        {
            List<Vendite> ret = new List<Vendite>();
            string ret2 = "";

            MySqlConnection conn = new MySqlConnection(connection_string);
            try
            {
                conn.Open();

                using (MySqlCommand command = new MySqlCommand($"SELECT * FROM vendite WHERE id_utente = '{id_utente}';", conn))
                {
                    using (MySqlDataReader resultSet = command.ExecuteReader())
                    {
                        while (resultSet.Read())
                        {
                            Vendite vendite = new Vendite()
                            {
                                id_vendita = (int)resultSet.GetUInt32(0),
                                id_utente = (int)resultSet.GetUInt32(1),
                                id_attrezzo = (int)resultSet.GetUInt32(2),
                                cartacredito = resultSet.GetString(3),
                                codicepromo = (int)resultSet.GetUInt32(4),
                                prezzo = (int)resultSet.GetUInt32(5),
                                nome = resultSet.GetString(6),
                                data = resultSet.GetDateTime(7),
                                indirizzoconsegna = resultSet.GetString(8),
                                quantita = (int)resultSet.GetUInt32(9),
                            };
                            ret.Add(vendite);
                        }
                    }
                }
                if (ret.Count == 0)
                {
                    throw new Exception("nessun ordine effettuato");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                ret2 = e.Message;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return (ret, ret2);
        }

        public (bool, string) Buy(int id_utente, string indirizzoresidenza, string codicepromo, string cartacredoto)
        {
            bool ret = false;
            string ret2 = "";


            var result = ViewCarrello(id_utente);

            if(result.Item1.Count > 0)
            {
                MySqlConnection conn = new MySqlConnection(connection_string);
                try
                {
                    conn.Open();

                    using(MySqlTransaction trans= conn.BeginTransaction())
                    {

                        using(MySqlCommand command = new MySqlCommand($"DELETE FROM carrello WHERE id_user = '{id_utente}';",conn,trans))
                        {
                            if(command.ExecuteNonQuery()==0)
                            {
                                throw new Exception("Rimozione dal carrello fallito");
                            }
                        }

                        foreach(Carrello carrello in result.Item1)
                        {
                            using (MySqlCommand command = new MySqlCommand($"SELECT id_attrezzi, quantita FROM attrezzi WHERE id_attrezzo = '{carrello.id_attrezzo}' LIMIT 1;",conn,trans))
                            {
                                using (MySqlDataReader resultSet = command.ExecuteReader())
                                {
                                    if(resultSet.Read())
                                    {
                                        int available = (int)resultSet.GetUInt32(1);
                                        if(carrello.quantita>available)
                                        {
                                            throw new Exception("la quantita selezionata suppera i pezzi disponibili");
                                        }
                                    }
                                    else
                                    {
                                        throw new Exception("prodotto non trovato");
                                    }
                                }
                            }
                            using (MySqlCommand command = new MySqlCommand($"UPDATE attrezzi SET quantita = quantita-{carrello.quantita} WHERE id_atrrezzo= '{carrello.id_attrezzo}';",conn,trans))
                            {
                                if(command.ExecuteNonQuery()==0)
                                {
                                    throw new Exception("aggiornamento quantita fallito");
                                }
                            }

                            using(MySqlCommand command= new MySqlCommand($"INSERT INTO vendite(id_attrezzo, id_utente,quantita, indirizzoconsegna,codicepromo,cartacredito) VALUES ('{carrello.id_attrezzo}','{id_utente}','{carrello.quantita}','{indirizzoresidenza}','{codicepromo},'{cartacredoto}');",conn,trans))
                            {
                                if(command.ExecuteNonQuery()==0)
                                {
                                    throw new Exception("Aggiunta vendita fallita");
                                }
                            }
                        }

                        trans.Commit();
                        ret = true;
                        
                       
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                    ret2 = e.Message;
                }
                finally
                {
                    if(conn.State==ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            else
            {
                ret2 = result.Item2;
            }
            return (ret, ret2);
        }
    }
}
