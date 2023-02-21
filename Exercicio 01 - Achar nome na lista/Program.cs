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

Console.Write("Digite o nome para busca: ");
string nome = Console.ReadLine();

Console.WriteLine("======================");

bool NaLista()
{
    for (int i = 0; i < nomesDosEscolhidos.Count; i++)
    {
        if (nome.Equals(nomesDosEscolhidos[i]))
        {
            return true;
        }
    }
    return false;
}

if (NaLista())
{
    Console.WriteLine($"Nome {nome} esta na lista :)");
}
else
{
    Console.WriteLine($"Nome {nome} não está na lista :(");
}

Console.ReadLine();