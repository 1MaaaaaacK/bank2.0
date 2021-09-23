using System;
using System.Collections.Generic;
using controleContas.Model;

namespace controleContas
{
    class Program
    {
        static Repositorio repositorio = new Repositorio();

        static IRepositorio rep = new Repositorio();

        static void Main(string[] args)
        {
            //ContaEspecial conta = new ContaEspecial();

            bool sair = false;
            String opcao;
            try
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Informe a ação a ser realizada: ");
                    Console.WriteLine("(1) Cadastrar Banco");
                    Console.WriteLine("(2) Cadastrar Agencia");
                    Console.WriteLine("(3) Cadastrar Cliente");
                    Console.WriteLine("(4) Criar Conta");
                    Console.WriteLine("(5) Listar Bancos");
                    Console.WriteLine("(6) Listar Agencias");
                    Console.WriteLine("(7) Listar Clientes");
                    Console.WriteLine("(8) Listar Contas");
                    Console.WriteLine("(9) Sacar");
                    Console.WriteLine("(10) Depositar");
                    Console.WriteLine("(11) Transferir");
                    Console.WriteLine("(12) Saldo Geral");
                    Console.WriteLine("(13) Encerrar aplicação");
                    opcao = Console.ReadLine();
                    switch (opcao)
                    {
                        case "1":
                            Console.WriteLine("CADASTRAR BANCO");
                            repositorio.CriarBanco();
                            break;
                        case "2":
                            Console.WriteLine("CADASTRAR AGENCIA");
                            repositorio.CriarAgencia();
                            break;
                        case "3":
                            Console.WriteLine("CADASTRAR CLIENTE");
                            repositorio.CriarCliente();
                            break;
                        case "4":
                            Console.WriteLine("CADASTRAR CONTA");
                            repositorio.CriarConta();
                            break;
                        case "5":
                            Console.WriteLine("LISTAR BANCOS");
                            repositorio.ListarBancos();
                            break;
                        case "6":
                            Console.WriteLine("LISTAR AGENCIAS");
                            repositorio.ListarAgencias();
                            break;
                        case "7":
                            Console.WriteLine("LISTAR CLIENTES");
                            repositorio.ListarClientes();
                            break;
                        case "8":
                            Console.WriteLine("LISTAR CONTAS");
                            repositorio.ListarContas();
                            break;
                        case "9":
                            Console.WriteLine("Iniciando o saque em conta...");
                            repositorio.Sacar();
                            break;
                        case "10":
                            Console.WriteLine("Iniciando depósito em conta...");
                            repositorio.Depositar();
                            break;
                        case "11":
                            Console.WriteLine("Iniciando Transferência entre contas...");
                            repositorio.Transferir();
                            break;
                        case "12":
                            Console.WriteLine("Exibindo o Saldo Total...");
                            repositorio.SaldoGeral();
                            break;
                        case "13":
                            Console.WriteLine("Você escolheu a opção 13");
                            sair = true;
                            break;
                        default:
                            Console.WriteLine("Escolha uma opção válida.");
                            break;
                    }
                    Console.WriteLine("Pressione uma tecla para continuar...");
                    Console.ReadLine();
                } while (!sair);
                Console.WriteLine("Fim do programa! Obrigado por utilizar!");
            }
            
            
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Pressione uma tecla para continuar...");
                Main(null);
            }
        }

        
    }
}
