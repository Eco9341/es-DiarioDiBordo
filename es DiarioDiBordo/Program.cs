using es_DiarioDiBordo;
using _04_Utility;


//Console.WriteLine("Dajie");



List<Diario> keywordSearchResults = DAODiario.GetInstance().SearchByDescriptionKeyword();

foreach (var record in keywordSearchResults)
{
    Console.WriteLine(record.ToString());
}