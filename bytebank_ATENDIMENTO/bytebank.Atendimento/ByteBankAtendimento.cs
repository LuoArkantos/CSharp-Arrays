using bytebank.Modelos.Conta;
using static bytebank_ATENDIMENTO.bytebank.Exception.ByteBankException;

namespace bytebank_ATENDIMENTO.bytebank.Atendimento
{
    public class ByteBankAtendimento
    {

        private List<ContaCorrente> _listaDeContas = new List<ContaCorrente>() //Esse tipo de array define que tipo de item pode ser definido. Este só aceita itens do tipo ContaCorrente
        {
            new ContaCorrente(122, "021A"){Saldo = 100,Titular = new Cliente{Cpf = "11111", Nome = "Joao"}},  //Contas pre-definidas
            new ContaCorrente(123, "021J"){Saldo = 200,Titular = new Cliente{Cpf = "22222", Nome = "Pedro"}},
            new ContaCorrente(123, "021C"){Saldo = 150,Titular = new Cliente{Cpf = "33333", Nome = "Thais"}},
            new ContaCorrente(126, "021B"){Saldo = 50,Titular = new Cliente{Cpf = "44444", Nome = "Carlos"}}
        };

        public void AtendimentoCliente()
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
                    catch (BytebankException excecao)
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
                        case '4': //quando digitado 2, executará uma função especifica
                            OrdenarContas();
                            break;
                        case '5': //quando digitado 2, executará uma função especifica
                            PesquisarContas();
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

        private void cadastrarConta()
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
         
        private void listaDeContas()
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
                //Console.WriteLine("=== DADOS DA CONTA ===");
                //Console.WriteLine($"Número da agência: {item.Numero_agencia}");
                //Console.WriteLine($"Número da conta: {item.Conta}");
                //Console.WriteLine($"Titular da conta: {item.Titular.Nome}");
                //Console.WriteLine($"CPF do Titular: {item.Saldo}");
                //Console.WriteLine($"Profissão: {item.Titular.Profissao}");
                //Console.WriteLine($"Saldo da conta: {item.Saldo}");
                Console.WriteLine(item.ToString());
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\n");
                Console.ReadKey();
            }
        }
         
        private void excluirConta()
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
         
        private void OrdenarContas()
        {
            _listaDeContas.Sort();
            Console.WriteLine("... Lista de Contas ordenadas ...");
            Console.ReadKey();
        }
         
        private void PesquisarContas()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===    PESQUISAR CONTAS     ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            Console.Write("Selecione a opção de busca: \n (1) NUMERO DA CONTA \n (2)CPF TITULAR \n (3) N AGENCIA \n " +
                "Opção: ");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    {
                        Console.Write("Informe o número da Conta: ");
                        string _numeroConta = Console.ReadLine();
                        ContaCorrente consultaConta = ConsultaPorNumeroConta(_numeroConta);
                        Console.WriteLine(consultaConta.ToString());
                        Console.ReadKey();
                        break;
                    }
                case 2:
                    {
                        Console.Write("Informe o CPF do Titular: ");
                        string _cpf = Console.ReadLine();
                        ContaCorrente consultaCpf = ConsultaPorCPFTitular(_cpf);
                        Console.WriteLine(consultaCpf.ToString());
                        Console.ReadKey();
                        break;
                    }
                case 3:
                    {
                        Console.Write("Informe a agência buscada: ");
                        int numeroAgencia = int.Parse(Console.ReadLine());
                        var contasPorAgencia = ConsultaPorAgencia(numeroAgencia);
                        ExibirListaDeContas(contasPorAgencia);
                        Console.ReadKey();
                        break;
                    }
                default:
                    Console.WriteLine("Opção não implementada.");
                    break;
            }

        }
         
        private void ExibirListaDeContas(List<ContaCorrente> contasPorAgencia)
        {
            if (contasPorAgencia == null)
            {
                Console.WriteLine("... A Consulta não retornou dados ...");
            }
            else
            {
                foreach (var item in contasPorAgencia) //vai exibir a lista de contas da agencia selecionada
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
         
        private List<ContaCorrente> ConsultaPorAgencia(int numeroAgencia)
        {
            var consulta = (
            from conta in _listaDeContas //da conta em Lista de contas
            where conta.Numero_agencia == numeroAgencia //onde o numero da agencia passa for igual a agencia da conta
            select conta).ToList(); //vai selecionar a conta e listar.
            return consulta;
        }
         
        private ContaCorrente ConsultaPorCPFTitular(string? cpf)
        {
            //ContaCorrente conta = null;
            //for (int i = 0; i < _listaDeContas.Count; i++)
            //{
            //    if (_listaDeContas[i].Titular.Cpf.Equals(cpf))
            //    {
            //        conta = _listaDeContas[i];
            //    }
            //}
            //return conta;

            //usando lambda e metodo Where()
            return _listaDeContas.Where(conta => conta.Titular.Cpf == cpf).FirstOrDefault(); //Busca em conta, se tem um cpf igual ao cpf passado no paramentro.. Então retorna o Primeiro ou Default.
        }
         
        private ContaCorrente ConsultaPorNumeroConta(string? numeroConta)
        {
            //ContaCorrente conta = null;
            //for (int i = 0; i < _listaDeContas.Count; i++)
            //{
            //    if (_listaDeContas[i].Conta.Equals(numeroConta))
            //    {
            //        conta = _listaDeContas[i];
            //    }
            //}

            //return conta;

            return _listaDeContas.Where(conta => conta.Conta == numeroConta).FirstOrDefault();//Busca em conta, se tem uma conta igual a conta passado no paramentro.. Então retorna o Primeiro ou Default.
        }
    }
}
