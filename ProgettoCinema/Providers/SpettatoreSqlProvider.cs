using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCinema.Providers
{
    public class SpettatoreSqlProvider : SqlProvider
    {
        public SpettatoreSqlProvider(string conn) : base(conn)
        {
            sqlBigliettoProvider = new BigliettoSqlProvider(conn);
            filmSqlProvider = new FilmSqlProvider(conn);
        }
        private BigliettoSqlProvider sqlBigliettoProvider;
        private FilmSqlProvider filmSqlProvider;
        public IList<Spettatore> GetAll()   //Id,NomeFilm,Produttore,Genere,Data
        {
            var spettatori = new List<Spettatore>();

            var query = @"SELECT [Id]   
                              ,[Nome]
                              ,[Cognome]
                              ,[DataDiNascita]
                              ,[IdBiglietto]
                              
                          FROM[dbo].[Biglietti]";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var sqlCommand = new SqlCommand(query, connection))
                {
                    var reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        var spettatore = new Spettatore()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nome = Convert.ToString(reader["Nome"]),
                            Cognome = Convert.ToString(reader["Cognome"]),

                            DataDiNascita = Convert.ToString(reader["DataDiNascita"]),
                            IdBiglietto = Convert.ToInt32(reader["Id"])
                        };
                        spettatori.Add(spettatore);
                    }
                    
                }
            }
            return spettatori;
        }
        public void Insert(Spettatore spettatore)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(@"INSERT INTO [dbo].[Biglietto] (Nome, Cognome, DataNascita,IdBiglietto)
                                              VALUES (@Id, @Nome, @Cognome,@DataNascita,@IdBiglietto)", connection))

            {
                connection.Open();
                cmd.Parameters.AddWithValue("@Id", spettatore.Id);
                cmd.Parameters.AddWithValue("@Nome", spettatore.Nome);
                cmd.Parameters.AddWithValue("@Cognome", spettatore.Cognome);
                cmd.Parameters.AddWithValue("@DataNascita", spettatore.DataDiNascita);
                cmd.Parameters.AddWithValue("IdBiglietto", spettatore.IdBiglietto);


                cmd.ExecuteNonQuery();
            }
        }
        

    }
}




 