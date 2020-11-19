using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCinema
{
    public class SalaSqlProvider : SqlProvider
    {
        public SalaSqlProvider(string conn) : base(conn)
        {
        }
        public Sala GetAll()   //Id,NumeroPosti,IdCinema,IdFilm
        {
            var listSala = new List<Sala>();
            Sala sala=new Sala();
            var query = @"SELECT [Id]   
                              ,[NumeroPosti]
                              ,[IdCinema]
                              ,[IdFilm]
                          FROM[dbo].[Sale]";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var sqlCommand = new SqlCommand(query, connection))
                {
                    var reader = sqlCommand.ExecuteReader();
                    if (reader.Read())
                    {
                         sala=new Sala()
                        {
                            Id=Convert.ToInt32(reader["Id"]),
                            NumeroPosti=Convert.ToInt32(reader["NumeroPosti"]),
                            IdCinema=Convert.ToInt32(reader["IdFilm"]),
                        };
                        
                    }
                }
            }
            return sala;
        }
        public void EditPosti(int id,int posti)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(@"UPDATE [dbo].[Sale]
                                              SET NumeroPostiOccupati = @Posti
                                             
                                              WHERE Id=@Id", conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@Posti", posti);
                cmd.Parameters.AddWithValue("@IdBoard", id);

                cmd.ExecuteNonQuery();
            }

        }

    }
}
