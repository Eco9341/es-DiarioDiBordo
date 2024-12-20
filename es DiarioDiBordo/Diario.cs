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

        public float CordinataX { get; set; }

        public float CordinataY { get; set; }

        public string Luogo { get; set; } = string.Empty;

        public string Descrizione { get; set; } = string.Empty;   


        public override string ToString()
        { 
            return base.ToString() +
                $"Data: {Data}, CordinataX: {CordinataX}, CordinataY: {CordinataY}, Luogo: {Luogo}, Descrizione: {Descrizione}";
        }
    }
}
