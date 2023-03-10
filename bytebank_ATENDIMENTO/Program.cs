using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Atendimento;
using bytebank_ATENDIMENTO.bytebank.Util;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

#region Exemplos Arrays em C#
//TestaArrayInt();
//TestaBuscarPalavra();

void TestaArrayInt()
{
    int[] idades = new int[5];
    idades[0] = 30;
    idades[1] = 40;
    idades[2] = 17;
    idades[3] = 21;
    idades[4] = 18;

    Console.WriteLine($"Tamanho do Array {idades.Length}");

    int acumulador = 0;
    for (int i = 0; i < idades.Length; i++)
    {
        int idade = idades[i];
        Console.WriteLine($"índice [{i}] = {idade}");
        acumulador += idade;
    }

    int media = acumulador / idades.Length;
    Console.WriteLine($"Média de idades = {media}");
}

void TestaBuscarPalavra()
{
    string[] arrayDePalavras = new string[5];

    for (int i = 0; i < arrayDePalavras.Length; i++)
    {
        Console.Write($"Digite {i + 1}ª Palavra: ");
        arrayDePalavras[i] = Console.ReadLine();
    }

    Console.Write("Digite palavara a ser encontrada: ");
    var busca = Console.ReadLine();

    foreach (string palavra in arrayDePalavras)
    {
        if (palavra.Equals(busca))
        {
            Console.WriteLine($"Palavra encontrada = {busca}.");
            break;
        }
    }

}

Array amostra = new double[5];
amostra.SetValue(5.9, 0);
amostra.SetValue(1.8, 1);
amostra.SetValue(7.1, 2);
amostra.SetValue(10, 3);
amostra.SetValue(6.9, 4);

//[5,9][1,8][7,1][10][6,9]
//TestaMediana(amostra);

void TestaMediana(Array array)
{
    if ((array == null) || (array.Length == 0))
    {
        Console.WriteLine("Array para cálculo da mediana está vazio ou nulo.");
    }

    double[] numerosOrdenados = (double[])array.Clone();
    Array.Sort(numerosOrdenados);
    //[1,8][5,9][6,9][7,1][10]

    int tamanho = numerosOrdenados.Length;
    int meio = tamanho / 2;
    double mediana = (tamanho % 2 != 0) ? numerosOrdenados[meio] :
                                   (numerosOrdenados[meio] + numerosOrdenados[meio - 1]) / 2;
    Console.WriteLine($"Com base na amostra a mediana = {mediana}");
}

int[] valores = { 10, 58, 36, 47, 11 };
//for (int i = 0; i < valores.Length; i++)
//{
//    Console.WriteLine(valores[i]);
//}
void TestaArrayDeContasCorrente()
{
    ListaDeContasCorrentes listaDeContas = new ListaDeContasCorrentes();
    listaDeContas.Adicionar(new ContaCorrente(845, "1234-X"));
    listaDeContas.Adicionar(new ContaCorrente(845, "1232-X"));
    listaDeContas.Adicionar(new ContaCorrente(845, "1233-X"));
    listaDeContas.Adicionar(new ContaCorrente(845, "1252-X"));
    listaDeContas.Adicionar(new ContaCorrente(845, "1277-X"));

    ContaCorrente contaDoAndre = new ContaCorrente(292, "1234-B");

    listaDeContas.Adicionar(contaDoAndre);
 
    //listaDeContas.ExibeLista();
    //Console.WriteLine("===================");
    //listaDeContas.Remover(contaDoAndre);
    //listaDeContas.ExibeLista();

    for (int i = 0; i < listaDeContas.Tamanho; i++) //Não usa o Length pq o obj em questão não é indexavel. Por isso foi criado um meio de exibir como lista de indices
    {
        ContaCorrente conta = listaDeContas[i]; //Lista de contas agora pode ser acessada com indice
        Console.WriteLine($"Indice [{i}] - Agencia: {conta.Nome_Agencia} / Conta: {conta.Conta}");
    }


}
//TestaArrayDeContasCorrente();
#endregion

#region Teste lista generica
//Generica<int> teste1 = new Generica<int>();
//teste1.MostrarMensagem(11);

//Generica<string> teste2 = new Generica<string>();
//teste2.MostrarMensagem("ola mundo");

//public class Generica<T>
//{
//    public void MostrarMensagem(T t)
//    {
//        Console.WriteLine($"Exibindo {t}");
//    }
//}

//AtendimentoCliente();
#endregion

new ByteBankAtendimento().AtendimentoCliente();