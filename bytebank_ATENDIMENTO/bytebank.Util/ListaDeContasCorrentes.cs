using bytebank.Modelos.Conta;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bytebank_ATENDIMENTO.bytebank.Util
{
    public class ListaDeContasCorrentes
    {
        private ContaCorrente[] _itens = null;
        private int _proximaPosicao = 0;

        public ListaDeContasCorrentes(int tamanhoInicial = 5)
        {
            _itens = new ContaCorrente[tamanhoInicial];
        }

        public void Adicionar (ContaCorrente item) //Recebe o item para adicionar na lista. Ex: Cria o abjeto LISTA, chamando esta classe. Em seguida chame o metodo Adicionar. Ex: listaDeContas.Adicionar(new ContaCorrente(123, "12354X"))
        {
            Console.WriteLine($"Adicionando item na posicao {_proximaPosicao}");
            VerificarCapacidade(_proximaPosicao + 1); //Vai verificar e adicionar mais um tamanho.
            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        }
        private void VerificarCapacidade(int tamanhoNecessario) //usado no metodo adiconar para verificar se precisa adicionar um novo index ou nao.
        {
            if (_itens.Length >= tamanhoNecessario)
            {
                return;
            }

            Console.WriteLine("AUMENTANDO CAPACIDADE DA LISTA! ");
            ContaCorrente[] novoArray = new ContaCorrente[tamanhoNecessario]; //Cria um array adicional para adicionar o novo elemento

            for (int i = 0; i < _itens.Length; i++)
            {
                novoArray[i] = _itens[i]; //Clona o array original para o novoArray
            }

            _itens = novoArray; //Aí o array com o novo obj adicionado vai pro _itens. 
        }

        public void Remover(ContaCorrente conta)
        {
            int indiceItem = -1; //crio indice negativo para diminuir

            Console.WriteLine($"Removendo Cliente de Agencia nº:{conta.Numero_agencia}, Conta nº {conta.Conta}");

            for (int i = 0; i < _proximaPosicao; i++)
            {
                ContaCorrente contaAtual = _itens[i]; 
                if(contaAtual == conta) //encontra a posição da conta
                {
                    indiceItem = i; //Quando chega na conta na lista, ele sai da verificacao com a conta selecionada
                    break;
                }                
            }

            for (int i = indiceItem; i < _proximaPosicao-1; i++) //pega o indice indicado e verifica se a posição dele é menor q a proxima posição -1
            {
                _itens[i] = _itens[i + 1]; //A conta q foi apagada sai, e a conta do indice posterior ocupa o lugar. _itens[i] vai receber o proximo item _itens[i + 1]; Ou seja: O item atual vai receber o valor do proximo.
            }
            _proximaPosicao--; //vai remover um indice da lista. Onde era 5, passa a ser 4
            _itens[_proximaPosicao] = null; //O ultimo indice passa a ser Null
        }

        public void ExibeLista()
        {
            for (int i = 0; i < _itens.Length; i++)
            {
                if(_itens[i] != null)
                {
                    var conta = _itens[i];
                    Console.WriteLine($"Indice [{i}] = " +
                        $"Conta {conta.Conta} - " +
                        $"Nº da Agencia = {conta.Numero_agencia} ");
                }
            }
        }

        public ContaCorrente RecuperarContaNoIndice(int indice) // Faz o objeto ser indexavel
        {
            if (indice < 0 || indice >= _proximaPosicao) //Se o indice for menor q 0 ou maior ou igual a proxima posição
            {
                throw new ArgumentOutOfRangeException(nameof(indice)); //gera erro de outofrange
            }

            return _itens[indice]; //retorna para o obj o indice
        }

        public int Tamanho //mesma funcao do Length
        {
            get
            {
                return _proximaPosicao; //O argumento tamanho retorna a proxima posição do indice
            }
        }

        public ContaCorrente this[int indice] //this retorna o conteudo para o OBJ ATUAL
        {
            get
            {
                return RecuperarContaNoIndice(indice); //O objeto atual vai receber a formula do metodo RecuperarContaNoIndice com o parametro INDICE [i]
            }
        }
    }
}
