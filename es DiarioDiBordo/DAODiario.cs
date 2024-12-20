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
            double cordinataX = ((Diario)entity).CordinataX;
            double cordinataY = ((Diario)entity).CordinataY;
            string luogo = ((Diario)entity).Luogo;
            string descrizione = ((Diario)entity).Descrizione;
            return db.UpdateDb($"INSERT INTO {tableName} (Data, CordinataX, CordinataY, Luogo, Descrizione) VALUES ('{date}', '{cordinataX}', '{cordinataY}', '{luogo}', '{descrizione}')");
        }


        public bool UpdateRecord(Entity entity)
        {
            int id = entity.Id;
            DateTime date = ((Diario)entity).Data;
            double cordinataX = ((Diario)entity).CordinataX;
            double cordinataY = ((Diario)entity).CordinataY;
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

        public List<Diario> SearchByUserDefinedPeriod()
        {
            // Creiamo una lista di Diario per restituire i record
            List<Diario> records = new List<Diario>();

            // Chiediamo all'utente di inserire la data di inizio
            Console.WriteLine("Inserisci la data di inizio (formato: yyyy-MM-dd): ");
            DateTime startDate;
            while (!DateTime.TryParse(Console.ReadLine(), out startDate))
            {
                Console.WriteLine("Formato data non valido. Riprova: ");
            }

            // Chiediamo all'utente di inserire la data di fine
            Console.WriteLine("Inserisci la data di fine (formato: yyyy-MM-dd): ");
            DateTime endDate;
            while (!DateTime.TryParse(Console.ReadLine(), out endDate))
            {
                Console.WriteLine("Formato data non valido. Riprova: ");
            }

            // Convertiamo le date in formato stringa per la query
            string start = startDate.ToString("yyyy-MM-dd");
            string end = endDate.ToString("yyyy-MM-dd");

            // Creiamo la query SQL per selezionare i record nel range di date
            string query = $"SELECT * FROM {tableName} WHERE Data >= '{start}' AND Data <= '{end}'";

            // Eseguiamo la lettura dei dati dal database
            List<Dictionary<string, string>>? result = db.ReadDb(query);

            if (result != null)
            {
                foreach (var line in result)
                {
                    Diario record = new Diario();
                    record.TypeSort(line); // Metodo che mappa il risultato della query agli attributi dell'oggetto Diario
                    records.Add(record);
                }
            }

            return records;
        }

        public List<Diario> SearchByDescriptionKeyword()
        {
            // Creiamo una lista di Diario per restituire i record
            List<Diario> records = new List<Diario>();

            // Chiediamo all'utente di inserire una parola chiave per la ricerca nella descrizione
            Console.WriteLine("Inserisci una parola chiave da cercare nella descrizione: ");
            string keyword = Console.ReadLine()?.Trim();  // Prendiamo la parola chiave e la rimuoviamo dagli spazi iniziali e finali

            if (string.IsNullOrEmpty(keyword))
            {
                Console.WriteLine("La parola chiave non può essere vuota.");
                return records; // Se la parola chiave è vuota, restituiamo una lista vuota
            }

            // Creiamo la query SQL per cercare la parola chiave nella descrizione
            // Utilizziamo 'LIKE' per trovare descrizioni che contengono la parola chiave
            string query = $"SELECT * FROM {tableName} WHERE Descrizione LIKE '%{keyword}%'";

            // Eseguiamo la lettura dei dati dal database
            List<Dictionary<string, string>>? result = db.ReadDb(query);

            if (result != null)
            {
                foreach (var line in result)
                {
                    Diario record = new Diario();
                    record.TypeSort(line); // Metodo che mappa il risultato della query agli attributi dell'oggetto Diario
                    records.Add(record);
                }
            }

            return records;
        }

        // Ricerca in base al luogo
        public List<Diario> RicercaInBaseAlLuogo(string luogo)
        {
            List<Diario> risultati = new();

            // Otteniamo tutti i record dal database
            List<Entity> records = GetRecords();

            // Convertiamo il luogo di ricerca in minuscolo per una ricerca case-insensitive
            string luogoLower = luogo.ToLower();

            // Filtriamo i record in base al luogo specificato
            foreach (var record in records)
            {
                Diario diario = (Diario)record;

                // Confrontiamo entrambe le stringhe in minuscolo
                if (diario.Luogo.ToLower() == luogoLower)
                {
                    risultati.Add(diario);
                }
            }

            // Stampiamo i risultati in console
            if (risultati.Count > 0)
            {
                Console.WriteLine($"Risultati trovati per il luogo '{luogo}':\n");
                foreach (var diario in risultati)
                {
                    Console.WriteLine(diario);
                }
            }
            else
            {
                Console.WriteLine($"Nessun risultato trovato per il luogo '{luogo}'.");
            }

            return risultati;
        }

        




    }

}


























