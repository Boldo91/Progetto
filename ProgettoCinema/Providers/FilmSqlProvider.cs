using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCinema.Providers
{
    public class FilmSqlProvider : SqlProvider
    {
        public FilmSqlProvider(string conn) : base(conn)
        {
        }

        public IList<Film> GetAll()   //Id,NomeFilm,Produttore,Genere,Data
        {
            var listFilm = new List<Film>();

            var query = @"SELECT [Id]   
                              ,[NomeFilm]
                              ,[Produttore]
                              ,[Genere]
                              ,[Data]
                          FROM[dbo].[Film]";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var sqlCommand = new SqlCommand(query, connection))
                {
                    var reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        var film = new Film()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            NomeFilm=(reader["NomeFilm"]).ToString(),
                            Produttore=(reader["Produttore"]).ToString(),
                            Genere=(reader["Genere"]).ToString(),
                            Data=reader["Data"].ToString()

                        };
                        listFilm.Add(film);
                    }
                }
            }
            return listFilm;
        }
        public Film Find(int Id)
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
                        return new Film()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            NomeFilm = (reader["NomeFilm"]).ToString(),
                            Produttore = (reader["Produttore"]).ToString(),
                            Genere = (reader["Genere"]).ToString(),
                            Data = reader["Data"].ToString()
                        };
                    }
                }
            }
            return null;
        }
    }
}
