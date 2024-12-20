using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04_Utility;

namespace es_DiarioDiBordo
{
    internal class DAODiario : IDAO
    {
        private IDatabase db;

        public DAODiario()
        {
            db = new Database("DiarioDiBordo");
        }
        private static DAODiario instance = null;

        public static DAODiario GetInstance()
        {
            if (instance == null)
                instance = new DAODiario();
            return instance;
        }

        public bool CreateRecord(Entity e)
        {
            return db.Update($"INSERT INTO Diario (Data, CordinataX, CordinataY, Luogo, Descrizione) " +
                 $"VALUES" +
                 $"('{((Diario)e).Data:yyyy-MM-dd}', " +
                 $"{((Diario)e).CordinataX}, " +
                 $"{((Diario)e).CordinataY}, " +
                 $"'{((Diario)e).Luogo}', " +
                 $"'{((Diario)e).Descrizione}');");
        }

        public List<Entity> FindRecord()    
        {
            List<Entity> ris = new();

            List<Dictionary<string, string>> righe = db.ReadDb("SELECT * FROM Diario;");

            foreach (Dictionary<string, string> riga in righe)
            {
                Entity e = new Diario();

                e.FromDictionary(riga);

                ris.Add(e);
            }

            return ris;
        }

        public bool UpdateRecord(Entity e)
        {
            return db.UpdateDb($"UPDATE Prodotti SET " +
                             $"Data = '{((Diario)e).Data:yyyy-MM-dd}', " +
                             $"CordinataX = {((Diario)e).CordinataX}, " +
                             $"CordinataY = {((Diario)e).CordinataY}, " +
                             $"Luogo = '{((Diario)e).Luogo}', " +
                             $"Descrizione = '{((Diario)e).Descrizione}' " +
                             $"WHERE id = {((Diario)e).Id};");
        }

        public bool DeleteRecord(int id)
        {
            return db.UpdateDb($"DELETE FROM Diario WHERE id = {id};");
        }

        public Entity FindRecord(int id)
        {
            var riga = db.ReadOneDb($"SELECT * FROM Diario WHERE id = {id}");

            if (riga != null)
            {
                Entity e = new Diario();
                e.FromDictionary(riga);

                return e;
            }
            else
                return null;
        }
    }

}


























