using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04_Utility;

namespace es_DiarioDiBordo
{
    internal class Diario : Entity
    {
        public DateTime Data { get; set; }

        public float CordinataX { get; set; }

        public float CordinataY { get; set; }

        public string Luogo {  get; set; }

        public string Descrizione { get; set; }


        public Diario(int id, DateTime data, float cordinataX, float cordinataY, string luogo, string descrizione)
            : base(id)
        {
            Data = data;
            CordinataX = cordinataX;
            CordinataY = cordinataY;
            Luogo = luogo;
            Descrizione = descrizione;
        }

        public string ToString()
        {
            return "Data: " + Data + " CordinataX: " + CordinataX + " CordinataY: " + CordinataY + " Luogo: " + Luogo + " Descrizione: " + Descrizione;
        }


        /*
            Ricerca in base a un periodo di tempo (Esempio: tra 01-01-2019 e 01-01-2020)
            Ricerca in base al luogo
            Ricerca in base a una parte della descrizione
        */

        public static List<DiarioEntry> CercaPerPeriodo(List<DiarioEntry> dati, DateTime inizio, DateTime fine)
        {
            // Filtra i dati in base al periodo specificato
            return dati.Where(entry => entry.Data >= inizio && entry.Data <= fine).ToString();
        }



    }
}
