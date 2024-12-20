﻿using es_DiarioDiBordo;


// Chiedi all'utente di inserire il luogo da cercare
Console.WriteLine("Inserisci il luogo da cercare:");
string luogo = Console.ReadLine()?.Trim();

// Chiamata alla ricerca in base al luogo
List<Diario> risultati = DAODiario.GetInstance().RicercaInBaseAlLuogo(luogo);

// In caso non vengano trovati risultati, visualizzeremo un messaggio
if (risultati.Count == 0)
{
    Console.WriteLine("Nessun risultato trovato.");
}