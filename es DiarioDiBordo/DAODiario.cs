using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utility;

namespace es_DiarioDiBordo
{
    internal class DAODiario : IDAO
    {
        private readonly Database db;
        private readonly string tableName = "Diario";
        private DAODiario()
        {
            db = new Database("DiarioDiBordo");
        }
        private static DAODiario? instance = null;
        public static DAODiario GetInstance()
        {
            return instance ??= new DAODiario();
        }
        public List<Entity> GetRecords()
        {
            List<Entity> records = [];
            List<Dictionary<string, string>>? result = db.ReadDb($"SELECT * FROM {tableName}");
            if (result != null)
            {
                foreach (var line in result)
                {
                    Diario record = new();
                    record.TypeSort(line);
                    records.Add(record);
                }
            }
            return records;
        }

        public bool CreateRecord(Entity entity)
        {
            DateTime date = ((Diario)entity).Data;
            float cordinataX = ((Diario)entity).CordinataX;
            float cordinataY = ((Diario)entity).CordinataY;
            string luogo = ((Diario)entity).Luogo;
            string descrizione = ((Diario)entity).Descrizione;
            return db.UpdateDb($"INSERT INTO {tableName} (Data, CordinataX, CordinataY, Luogo, Descrizione) VALUES ('{date}', '{cordinataX}', '{cordinataY}', '{luogo}', '{descrizione}')");
        }


        public bool UpdateRecord(Entity entity)
        {
            int id = entity.Id;
            DateTime date = ((Diario)entity).Data;
            float cordinataX = ((Diario)entity).CordinataX;
            float cordinataY = ((Diario)entity).CordinataY;
            string luogo = ((Diario)entity).Luogo;
            string descrizione = ((Diario)entity).Descrizione;
            return db.UpdateDb($"UPDATE {tableName} SET Data = '{date}', CordinataX = '{cordinataX}', CordinataY = '{cordinataY}', Luogo = '{luogo}', Descrizione = '{descrizione}' WHERE Id = {id}");
        }

        public bool DeleteRecord(int recordId)
        {
            return db.UpdateDb($"DELETE FROM {tableName} WHERE id = {recordId};");
        }

        public Entity? FindRecord(int recordId)
        {
            Dictionary<string, string>? result = db.ReadDb($"SELECT * FROM {tableName} WHERE id = {recordId}").FirstOrDefault();
            if (result != null)
            {
                Diario record = new();
                record.TypeSort(result);
                return record;
            }
            return null;
        }

    }

}


























