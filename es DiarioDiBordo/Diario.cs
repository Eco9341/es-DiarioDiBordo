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


        




    }
}
