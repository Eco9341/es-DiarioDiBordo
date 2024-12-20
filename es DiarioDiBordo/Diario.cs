using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utility;

namespace es_DiarioDiBordo
{

    internal class Diario : Entity
    {
        public DateTime Data { get; set; }

        public double CordinataX { get; set; }

        public double CordinataY { get; set; }

        public string Luogo { get; set; } = string.Empty;


        public string Descrizione { get; set; } = string.Empty;



     

        public override string ToString()
        {
            return base.ToString() +
                $"Data: {Data.ToString("yyyy-MM-dd")}\n" +
                $"CordinataX: {CordinataX}\n" +
                $"CordinataY: {CordinataY}\n" +
                $"Luogo: {Luogo}\n" +
                $"Descrizione: {Descrizione}\n" +
                $"--------------------------------";

        }

        
        

    }

}
