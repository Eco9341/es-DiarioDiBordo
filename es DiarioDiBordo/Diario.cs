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

        public string Luogo { get; set; } = string.Empty;

        public string Descrizione { get; set; } = string.Empty;


        public override string ToString()
        {
            return base.ToString() +
                $"Data: {Data}\n" +
                $"CordinataX: {CordinataX}\n" +
                $"CordinataY: {CordinataY}\n" +
                $"Luogo: {Luogo}\n" +
                $"Descrizione: {Descrizione}\n" +
                $"--------------------------------";
        }

        public static List<DiarioEntry> CercaPerPeriodo(List<DiarioEntry> dati, Date inizio, Date fine)
        {
            // Filtra i dati in base al periodo specificato
            return dati.Where(entry => entry.Data >= inizio && entry.Data <= fine).ToString();
        }

    }

}
