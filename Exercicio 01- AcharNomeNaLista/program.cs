using System;

List<string> nomesDosEscolhidos = new List<string>()
{
    "Bruce Wayne",
    "Carlos Vilagran",
    "Richard Grayson",
    "Bob Kane",
    "Will Farrel",
    "Lois Lane",
    "General Welling",
    "Perla Letícia",
    "Uxas",
    "Diana Prince",
    "Elisabeth Romanova",
    "Anakin Wayne"
};

void BuscarNome()
{
    string nomeBuscado = Console.Readline();
    string nomeEncontrado = nomeDosEscolhidos.Where(nomeBuscado).ToString;
    Console.WriteLine(nomeEncontrado);
    Console.WriteLine();

}
BuscarNome();
Console.Readline();