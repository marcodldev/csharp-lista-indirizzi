
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

//using var file1 = File.Open("addresses.csv", FileMode.Open); Stessa cosa di sotto, approccio diverso

StreamReader file = File.OpenText("C:\\Users\\Marco D\\source\\repos\\csharp-lista-indirizzi\\addresses.csv");  // apre, legge e chiude

    while (!file.EndOfStream)
{
    string riga = file.ReadLine();
    Console.WriteLine(riga);
}

file.Close();