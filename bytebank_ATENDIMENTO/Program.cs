using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Exception;
using bytebank_ATENDIMENTO.bytebank.Util;
using System.Collections;
using static bytebank_ATENDIMENTO.bytebank.Exception.ByteBankException;

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

List<ContaCorrente> _listaDeContas = new List<ContaCorrente>() //Esse tipo de array define que tipo de item pode ser definido. Este só aceita itens do tipo ContaCorrente
{
    new ContaCorrente(122, "021A"){Saldo = 100},  //Contas pre-definidas
    new ContaCorrente(123, "021B"){Saldo = 200},
    new ContaCorrente(125, "021C"){Saldo = 150},
    new ContaCorrente(126, "021D"){Saldo = 50 }
};

void AtendimentoCliente()
{
    try
    {
        char opcao = '0';
        while (opcao != '6')
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===       Atendimento       ===");
            Console.WriteLine("===1 - Cadastrar Conta      ===");
            Console.WriteLine("===2 - Listar Contas        ===");
            Console.WriteLine("===3 - Remover Conta        ===");
            Console.WriteLine("===4 - Ordenar Contas       ===");
            Console.WriteLine("===5 - Pesquisar Conta      ===");
            Console.WriteLine("===6 - Sair do Sistema      ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n\n");
            Console.Write("Digite a opção desejada: ");


            try
            {
                opcao = Console.ReadLine()[0];

            }
            catch (Exception excecao)
            {

                throw new BytebankException(excecao.Message);
            }

            switch (opcao)
            { //Switch = Alterar a var do parametro
                case '1': //quando digitado 1, executará uma função especifica
                    cadastrarConta();
                    break;
                case '2': //quando digitado 2, executará uma função especifica
                    listaDeContas();
                    break;
                case '3': //quando digitado 2, executará uma função especifica
                    excluirConta();
                    break;
                default:
                    Console.WriteLine("Opção não implementada");
                    break;
            }
        } 
    }
    catch (BytebankException excecao)
    {

        Console.WriteLine($"{excecao.Message}"); ;
    }
 }

void cadastrarConta()
{
    Console.Clear(); //vai limpar a tela pra não printar abaixo da tela anterior
    Console.WriteLine("===============================");
    Console.WriteLine("===   CADASTRO DE CONTAS    ===");
    Console.WriteLine("===============================");
    Console.WriteLine("\n");
    Console.WriteLine("=== Informe dados da conta ===");
    
    Console.Write("Número da conta: ");
    string numeroConta = Console.ReadLine(); //Define numero da conta

    Console.Write("Número da Agência: ");
    int numeroAgencia = int.Parse(Console.ReadLine()); //parse Pega o numero digitado e converte de string para numero

    ContaCorrente conta = new ContaCorrente(numeroAgencia, numeroConta);

    Console.Write("Informe o saldo inicial: ");
    conta.Saldo = double.Parse(Console.ReadLine());

    Console.Write("Infome nome do Titular: ");
    conta.Titular.Nome = Console.ReadLine();

    Console.Write("Infome CPF do Titular: ");
    conta.Titular.Cpf = Console.ReadLine();

    Console.Write("Infome Profissão do Titular: ");
    conta.Titular.Profissao = Console.ReadLine();

    _listaDeContas.Add(conta);
    Console.WriteLine("... Conta cadastrada com sucesso! ...");
    Console.ReadKey();
}

void listaDeContas()
{
    Console.Clear();
    Console.WriteLine("===============================");
    Console.WriteLine("===     LISTA DE CONTAS     ===");
    Console.WriteLine("===============================");
    Console.WriteLine("\n");

    if (_listaDeContas.Count <= 0)
    {
        Console.WriteLine("...Não há contas cadastradas...");
        Console.ReadKey(); //ReadKey aguarda que uma tecla seja pressionada
        return;
          
    }

    foreach (ContaCorrente item in _listaDeContas)
    {
        Console.WriteLine("=== DADOS DA CONTA ===");
        Console.WriteLine($"Número da agência: {item.Numero_agencia}");
        Console.WriteLine($"Número da conta: {item.Conta}");
        Console.WriteLine($"Titular da conta: {item.Titular.Nome}");
        Console.WriteLine($"CPF do Titular: {item.Saldo}");
        Console.WriteLine($"Profissão: {item.Titular.Profissao}");
        Console.WriteLine($"Saldo da conta: {item.Saldo}");
        Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\n");
        Console.ReadKey();
    }
} 

void excluirConta() 
{
    Console.Clear();
    Console.WriteLine("===============================");
    Console.WriteLine("===      REMOVER CONTAS     ===");
    Console.WriteLine("===============================");
    Console.WriteLine("\n");
    Console.Write("Informe o número da Conta: ");
    string numeroConta = Console.ReadLine();
    ContaCorrente conta = null;
    foreach (var item in _listaDeContas)
    {
        if (item.Conta.Equals(numeroConta))
        {
            conta = item;
        }
    }
    if (conta != null)
    {
        _listaDeContas.Remove(conta);
        Console.WriteLine("... Conta removida da lista! ...");
    }
    else
    {
        Console.WriteLine(" ... Conta para remoção não encontrada ...");
    }
    Console.ReadKey();
}

AtendimentoCliente();