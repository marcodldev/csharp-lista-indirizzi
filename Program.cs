
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



//StreamReader file = File.OpenText("C:\\Users\\Marco D\\source\\repos\\csharp-lista-indirizzi\\addresses.csv"); ---> // apre, legge e chiude

//    while (!file.EndOfStream)
//{
//    string riga = file.ReadLine();
//    Console.WriteLine(riga);
//}

//file.Close();



using var file1 = File.Open("csharp-lista-indirizzi\\bin\\Debug\\addresses.csv", FileMode.Open); // Stessa cosa di sopra, approccio diverso 

string nomeFile = "Indirizzi.txt";
string pathFile = Path.Combine(Directory.GetCurrentDirectory(), nomeFile); //Path.Combine -> unisce directory corrente + nome del file

if (!File.Exists(pathFile))   // controlla se il file esiste già nella directory corrente, in modo da evitare di sovrascriverlo accidentalmente
{
    using (StreamWriter writer = File.CreateText(pathFile))   // createtext crea un nuovo file di testo, using è utilizzato come prima, per aprire, leggere e chiudere
    {
        writer.WriteLine("test test");
        
    }
}