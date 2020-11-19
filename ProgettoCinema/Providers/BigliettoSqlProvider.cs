using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCinema.Providers
{
    public class BigliettoSqlProvider:SqlProvider
    {
        private SalaSqlProvider prov;
        public BigliettoSqlProvider(string conn) : base(conn)
        {
            prov = new SalaSqlProvider(conn);
        }

        public void Insert(Biglietto biglietto)
        {
           
                using (var connection = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(@"INSERT INTO [dbo].[Biglietto] (IdSala, Prezzo, Posto)
                                              VALUES (@IdSala, @IdPrezzo, @Posto)", connection))

                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdSala", biglietto.Id);
                    cmd.Parameters.AddWithValue("@IdPrezzo", biglietto.IdSala);
                    cmd.Parameters.AddWithValue("@Posto", biglietto.Prezzo);
                    

                    cmd.ExecuteNonQuery();
                }
            }
        public IList<Biglietto> GetAll()   //Id,NomeFilm,Produttore,Genere,Data
        {
            var biglietti = new List<Biglietto>();

            var query = @"SELECT [Id]   
                              ,[IdSala]
                              ,[Prezzo]
                              ,[Posto]
                              
                          FROM[dbo].[Biglietti]";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var sqlCommand = new SqlCommand(query, connection))
                {
                    var reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        var biglietto = new Biglietto()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            IdSala = Convert.ToInt32(reader["NomeFilm"]),
                            Prezzo= Convert.ToDouble(reader["NomeFilm"]),
                            Posto=Convert.ToInt32(reader["Posto"])






                        };
                        biglietti.Add(biglietto);
                    }
                }
            }
            return biglietti;
        }
        public Biglietto Find(int Id)
        {
            var query = @"SELECT[Id], [NomeFilm], [Produttore], [Genere],[Data] FROM [dbo].[Film] WHERE Id =@Id";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new Biglietto()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            IdSala = Convert.ToInt32(reader["NomeFilm"]),
                            Prezzo = Convert.ToDouble(reader["NomeFilm"]),
                            Posto = Convert.ToInt32(reader["Posto"])
                        };
                    }
                }
            }
            return null;
        }
        public void InserisciBiglietti()
        {
            for(int i=0;i<prov.GetAll().NumeroPosti;i++)
            {
                Insert(new Biglietto() { Id = i, Posto = i, Prezzo = 5, IdSala = prov.GetAll().Id });
            }
        }
    }
}
