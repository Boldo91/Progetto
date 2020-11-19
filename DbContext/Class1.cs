using Models;
using ProgettoCinema;
using ProgettoCinema.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbContext
{
    public class DbContext
    {
      
        public DbContext()
        {
            bigliettoSqlProvider = new BigliettoSqlProvider("connectionString" );
        }
        private readonly BigliettoSqlProvider bigliettoSqlProvider;
        private readonly SpettatoreSqlProvider spettatoreSqlProvider;
        private readonly FilmSqlProvider filmSqlProvider;
        private readonly SalaSqlProvider salaSqlProvider;
        public void AcquistaBiglietto(Spettatore spettatore)
        {
            var biglietto = bigliettoSqlProvider.Find(spettatore.IdBiglietto);
            var sala = salaSqlProvider.GetAll();
            
            var film = filmSqlProvider.Find(sala.IdFilm);
            if (biglietto == null^((film.Genere!="horror")&&(Convert.ToInt32(spettatore.DataDiNascita))<14))
            {
                spettatoreSqlProvider.Insert(spettatore);
            }
        }
        public Biglietto GestisciPrezzo(Biglietto biglietto, int eta)
        {
            biglietto.Prezzo = 10;
            return biglietto;
        }
    }
}
