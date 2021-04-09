using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace SimonaPolizia
{
    static class Polizia
    {
        static string _connectionString = ConfigurationManager.ConnectionStrings["SimonaPolizia"].ConnectionString;


        //Mostrare tutti gli agenti
        static public List<Agente> ElencoAgenti(bool conAree = false)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("Select * from Agenti", conn))
            {
                List<Agente> agenti = new List<Agente>();

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                    agenti.Add(new Agente((int)reader["IdAgente"], reader ["CF"].ToString () ,reader["Nome"].ToString(), reader["Cognome"].ToString(), (int)reader["AnniServizio"]));

                if (conAree)
                    foreach (Agente a in agenti)
                        RecuperaAree(a);

                return agenti;
            }
        }

         //recupera le aree metropolitane e le aggiunge alla sua lista aree
         static public void RecuperaAree(Agente agente)
         {
             using (SqlConnection conn = new SqlConnection(_connectionString))
             using (SqlCommand cmd = new SqlCommand("Select * from Assegnazione where IdAgente = @idAgente", conn))
             {

                 cmd.Parameters.AddWithValue("@idAgente", agente.IdAgente);

                 conn.Open();

                 SqlDataReader reader = cmd.ExecuteReader(); //per farmi ritornare il valore uso un reader per leggere il record del db

                 while (reader.Read())
                     agente.Assegnazioni.Add(new Assegnazione((int)reader["IdAssegnazione"], (int)reader["IdArea"], (int)reader["IdAgente"]));

             }
         }


        //Mostrare gli agenti assegnati ad una determinata area
        /*public static Agente RecuperaAgente(string codiceArea, bool conAree = false)
        {
            //ho fatto una stored procedure
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("RecuperaAgente", conn))
            {
                
                //dico che è una stored precedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@codiceArea", codiceArea);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader(); 

                if (!reader.Read()) 
                    return null;

                Agente a = new Agente((int)reader["IdAgente"], reader["CF"].ToString(), reader["Nome"].ToString(), reader["Cognome"].ToString(), (int)reader["AnniServizio"]);

                conn.Close();

                if (conAree)
                    RecuperaAree(a);

                return a;

            }
        }*/


        //Mostrare gli agenti con anni di servizio >= a..
        static public Agente ElencoAgentiAnni(int anniServizio, bool conAree = false)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("RecuperaAgentiAnni", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@anniServizio", anniServizio);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.Read())
                    return null;

                Agente a = new Agente((int)reader["IdAgente"], reader["CF"].ToString(), reader["Nome"].ToString(), reader["Cognome"].ToString(), (int)reader["AnniServizio"]);

                conn.Close();

                if (conAree)
                    RecuperaAree(a);

                return a;

            }
        }

        //Inserire record di agente (Modalità disconnessa)
        public static Agente InserisciAgente(string cf, string nome, string cognome, int anniServizio)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlDataAdapter da = new SqlDataAdapter("Select * from Agenti", conn))
            {

                //creo il DataSet
                DataSet ds = new DataSet();

                da.Fill(ds, "Agenti");

                DataTable tabellaAgenti = ds.Tables["Agenti"]; //recupero datatable da ds

                //vado ad inserire gli agenti
                tabellaAgenti.Rows.Add(0, cf, nome, cognome, anniServizio);

                new SqlCommandBuilder(da);

                //faccio l'update
                conn.Open();
                da.Update(tabellaAgenti);
                SqlCommand cmd = new SqlCommand("Select @@identity", conn);

                int id = (int)(decimal)cmd.ExecuteScalar();

                conn.Close();

                return new Agente(id, cf, nome, cognome, anniServizio);

               
            }
        }
    }

}


