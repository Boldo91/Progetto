
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgettoCinemaWeb.Models
{
    public class BigliettoView
    {
        public int Id;
        public int IdSala;
        public double Prezzo;
        public int Posto;
        public BigliettoView(Biglietto biglietto)
        {
            Id = biglietto.Id;
            IdSala = biglietto.IdSala;
            Prezzo = biglietto.Prezzo;
            Posto = biglietto.Posto;

        }
    }
   
}