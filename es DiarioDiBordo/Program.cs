using es_DiarioDiBordo;

using utility;


//Console.WriteLine("Dajie");



//List<Diario> keywordSearchResults = DAODiario.GetInstance().SearchByDescriptionKeyword();

//foreach (var record in keywordSearchResults)
//{
//    Console.WriteLine(record.ToString());
//}

// Chiedi all'utente di inserire il luogo da cercare
//Console.WriteLine("Inserisci il luogo da cercare:");
//string luogo = Console.ReadLine()?.Trim();

//// Chiamata alla ricerca in base al luogo
//List<Diario> risultati = DAODiario.GetInstance().RicercaInBaseAlLuogo(luogo);

bool exit = false;

while (!exit)
{
    Console.WriteLine("\n==============================");
    Console.WriteLine("       🌟 Menù del Diario 🌟       ");
    Console.WriteLine("==============================");
    Console.WriteLine("1. 📖 Aggiungi voce");
    Console.WriteLine("2. ✏️  Modifica voce");
    Console.WriteLine("3. 🗑️ Elimina voce");
    Console.WriteLine("4. 📚 Leggi diario");
    Console.WriteLine("5. 📅 Ricerca per data");
    Console.WriteLine("6. 📍 Ricerca per luogo");
    Console.WriteLine("7. 🔍 Ricerca per parola");
    Console.WriteLine("8. 🚪 Esci");
    Console.WriteLine("==============================");

    Console.Write("Seleziona un'opzione: ");
    string scelta = Console.ReadLine();

    switch (scelta)
    {
        case "1":
            //aggiungi 
            foreach (Entity e in DAODiario.GetInstance().GetRecords())
            {
                Console.WriteLine(e.ToString());
            }
            break;
        case "2":
            //modifica
            // Creare un'istanza di DAODiario
            DAODiario daoDiario = DAODiario.GetInstance();

            // Richiedere i dati all'utente
            Console.WriteLine("Inserisci i dati per aggiornare un record del diario:");

            Console.Write("ID del record da aggiornare: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Data (formato AAAA-MM-GG): ");
            DateTime data = DateTime.Parse(Console.ReadLine());

            Console.Write("Coordinata X: ");
            double cordinataX = double.Parse(Console.ReadLine());

            Console.Write("Coordinata Y: ");
            double cordinataY = double.Parse(Console.ReadLine());

            Console.Write("Luogo: ");
            string luogo = Console.ReadLine();

            Console.Write("Descrizione: ");
            string descrizione = Console.ReadLine();

            // Creare l'oggetto Diario
            Diario diario = new Diario
            {
                Id = id,
                Data = data,
                CordinataX = cordinataX,
                CordinataY = cordinataY,
                Luogo = luogo,
                Descrizione = descrizione
            };

            // Chiamare il metodo UpdateRecord
            bool success = daoDiario.UpdateRecord(diario);

            // Stampare il risultato
            if (success)
            {
                Console.WriteLine("Record aggiornato con successo.");
            }
            else
            {
                Console.WriteLine("Errore durante l'aggiornamento del record.");
            }
            break;
        case "3":
            //elimina

            DAODiario daoDiario1 = DAODiario.GetInstance();
            try
            {
                Console.Write("ID del record da eliminare: ");
                int id1 = int.Parse(Console.ReadLine());
                bool success1 = daoDiario1.DeleteRecord(id1);
                if (success1)
                {
                    Console.WriteLine("Record eliminato con successo.");
                }
                else
                {
                    Console.WriteLine("Errore durante l'eliminazione del record.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Errore: formato ID non valido. Assicurati di inserire un numero intero.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore inatteso: {ex.Message}");
            }
            break;
        case "4":
            //leggi
            break;
        case "5":
            //ricerca data
            break;
        case "6":
            //ricerca luogo
            break;
        case "7":
            //ricerca parola
            break;
        case "8":
            exit = true;
            break;
        default:
            Console.Clear();
            Console.WriteLine("[opzione non valida]");
            break;

    }
}



