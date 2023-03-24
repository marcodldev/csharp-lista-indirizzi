
/*
 * 
 * Oggi esercitazione sui file, ossia vi chiedo di prendere dimestichezza con quanto appena visto sui file in classe,
 * in particolare nel live-coding di oggi.
In questo esercizio dovrete leggere un file CSV, che cambia poco da quanto appena visto nel live-coding in classe, e salvare tutti gli indirizzi 
contenuti al sul interno all’interno di una lista di oggetti istanziati a partire dalla classe Indirizzo.
*Attenzione:* gli ultimi 3 indirizzi presentano dei possibili “casi particolari” che possono accadere a questo genere di file: vi chiedo di pensarci e
*di gestire come meglio crediate queste casistiche.
* 
    *Name,Surname,Street,City,Province,ZIP
    John,Doe,120 jefferson st.,Riverside,NJ,08075
    Jack,McGinnis,220 hobo Av.,Phila,PA,09119
    John Da Man,Repici,120 Jefferson St.,Riverside,NJ,08075
    Stephen,Tyler,7452 Terrace "At the Plaza" road,SomeTown,SD,91234
    Joan,Anne,Jet,9th at Terrace plc,Desert City,CO,00123
    ,Blankman,,New York, NY, 100101
    Joan,SomeTown, SD, 00298

 * */


using csharp_lista_indirizzi;
using System.IO;



//StreamReader file = File.OpenText("..\\..\\..\\addresses.csv "); ---> // apre, legge e chiude

//    while (!file.EndOfStream)
//{
//    string riga = file.ReadLine();
//    Console.WriteLine(riga);
//}

//file.Close();



using var file1 = File.Open("..\\..\\..\\addresses.csv ", FileMode.Open); // Stessa cosa di sopra, approccio diverso 

string nomeFile = "Indirizzi.txt";
string pathFile = Path.Combine(Directory.GetCurrentDirectory(), nomeFile); //Path.Combine -> unisce directory corrente + nome del file

List<Indirizzo> indirizzi = new List<Indirizzo>();  // lista di indirizzi vuota

if (!File.Exists(pathFile))   // controlla se il file esiste già nella directory corrente, in modo da evitare di sovrascriverlo accidentalmente
{
    using (StreamWriter writer = File.CreateText(pathFile))   // createtext crea un nuovo file di testo, using è utilizzato come prima, per aprire, leggere e chiudere
    {
        using (StreamReader reader = new StreamReader(file1))
        {
            reader.ReadLine(); // legge la prima riga e la ignora, non scrive nulla perchè il writeline sta sotto


            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                var pezzi = line.Split(',');

                if (pezzi.Length == 6)
                { 
                    var indirizzo = new Indirizzo
                    {
                        Nome = pezzi[0],
                        Cognome = pezzi[1],
                        Via = pezzi[2],
                        Citta = pezzi[3],
                        Provincia = pezzi[4],
                        Cap = pezzi[5],
                       
                    };
                    indirizzi.Add(indirizzo);
                }
                else if (pezzi.Length == 7)
                {
                    var indirizzo = new Indirizzo
                    {
                        Nome = pezzi[0],
                        SecondoNome = pezzi[1],
                        Cognome = pezzi[2],
                        Via = pezzi[3],
                        Citta = pezzi[4],
                        Provincia = pezzi[5],
                        Cap = pezzi[6],
                       
                    };
                    indirizzi.Add(indirizzo);
                }
                else if (pezzi.Length == 4)
                {
                    var indirizzo = new Indirizzo
                    {
                        Nome = pezzi[0],                              
                        Citta = pezzi[1],
                        Provincia = pezzi[2],
                        Cap = pezzi[3],


                    };
                    indirizzi.Add(indirizzo);
                }
               // indirizzi.Add(indirizzo);
                    writer.WriteLine(line);
                
            }
        }

        foreach (var indirizzo in indirizzi)
        {
            writer.WriteLine($"Nome: {indirizzo.Nome}");
            writer.WriteLine($"Secondo Nome: {indirizzo.SecondoNome}");
            writer.WriteLine($"Cognome: {indirizzo.Cognome}");
            writer.WriteLine($"Via: {indirizzo.Via}");
            writer.WriteLine($"Città: {indirizzo.Citta}");
            writer.WriteLine($"Provincia: {indirizzo.Provincia}");
            writer.WriteLine($"Cap: {indirizzo.Cap}");
           
            writer.WriteLine();
        }

    }
}

/*
Altre note
StreamWriter scrive, in questo caso ho scritto di scrivere in un nuovo file con path indicato sopra
SteamReader legge il file che gli passiamo come parametro

using si usa sempre prima di utilizzare questi metodi
*/