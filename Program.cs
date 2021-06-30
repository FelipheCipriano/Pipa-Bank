using System;
using System.Collections.Generic;

namespace Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper()!="X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.WriteLine("Digitw o numero da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o numero da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o numero da cotna Contas: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("DIgite o valor a ser sacado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o numero da cotna Contas: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("DIgite o valor a ser sacado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorDeposito);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");
            
            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for (int i=0; i< listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.WriteLine("#{0} - ",i);
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.WriteLine("Digite 1 para conta Fidica ou 2 para Juridica: ");
            int entrdaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Nome do Cliente: ");
            String entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Credito: ");
            double entradaCredito = double.Parse(Console.ReadLine());
            
            Conta novaConta = new Conta(tipoConta: (TipoConta)entrdaTipoConta,
                                                    saldo: entradaSaldo,
                                                    credito: entradaCredito,
                                                    nome: entradaNome);
            listContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Pipa Bank a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
