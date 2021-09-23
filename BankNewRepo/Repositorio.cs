using System;
using System.Collections;
using System.Collections.Generic;

namespace controleContas
{
    public class Repositorio : IRepositorio
    {
        private  List<Cliente> clientes = new List<Cliente>();
        private  List<Conta> contas = new List<Conta>();
        private  List<Banco> bancos = new List<Banco>();
        private  List<Agencia> agencias = new List<Agencia>();
        public Repositorio()
        {
        }
        public  void CriarBanco()
        {
            int numero;
            String nome;
            Console.WriteLine("Informe o número do banco: ");
            numero = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Informe o nome do banco: ");
            nome = Console.ReadLine();
            Banco banco = new Banco(numero, nome);
            bancos.Add(banco);
        }

        public  void CriarAgencia()
        {
            try
            {
                int numero;
                string cep, telefone;
                Console.WriteLine("Informe o Banco da agência: ");
                Banco banco = ObterBanco();
                if (banco != null)
                {
                    Console.WriteLine("Informe o número da agencia: ");
                    numero = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe o CEP da agência: ");
                    cep = Console.ReadLine();
                    Console.WriteLine("Informe o Telefone da agência: ");
                    telefone = Console.ReadLine();
                    Agencia agencia = new Agencia(numero, banco);
                    agencia.Telefone = telefone;
                    agencia.Cep = cep;
                    agencias.Add(agencia);
                }
                else
                    Console.WriteLine("Não é possível criar contas sem que um cliente seja informado.");

            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void CriarCliente()
        {
            try
            {
                String nome, cpf;
                int ano;
                Console.WriteLine("Informe o nome do cliente: ");
                nome = Console.ReadLine();
                Console.WriteLine("Informe o CPF do cliente: ");
                cpf = Console.ReadLine();
                Console.WriteLine("Informe o ano de nascimento do cliente: ");
                ano = Int32.Parse(Console.ReadLine());
                Cliente cliente = new Cliente();
                cliente.Nome = nome;
                cliente.Cpf = cpf;
                cliente.AnoNascimento = ano;
                clientes.Add(cliente);
            }
            catch (InvalidCpfException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CriarConta()
        {
            try
            {
                int numero;
                decimal saldo;
                Console.WriteLine("Informe a agencia da conta: ");
                Agencia agencia = ObterAgencia();
                if (agencia != null)
                {
                    Console.WriteLine("Informe o cliente da conta: ");
                    Cliente cliente = ObterCliente();
                    if (cliente != null)
                    {
                        Console.WriteLine("Informe o número da conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Informe o saldo da conta: ");
                        saldo = Decimal.Parse(Console.ReadLine());
                        Conta conta = new Conta(numero, saldo, cliente, agencia);
                        contas.Add(conta);
                    }
                    else
                        Console.WriteLine("Não é possível criar contas sem que um cliente seja informado.");

                }
                else
                    Console.WriteLine("Não é possível criar contas sem que uma agencia seja informada.");

            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ListarBancos()
        {
            Relatorio<Banco>.Listar(bancos);
            
        }

        public void ListarAgencias()
        {
            Relatorio<Agencia>.Listar(agencias);
        }

        public void ListarContas()
        {
            Relatorio<Conta>.Listar(contas);
        }

        public void ListarClientes()
        {
            Relatorio<Cliente>.Listar(clientes);
        }

        public Banco ObterBanco()
        {
            
            if (bancos.Count > 0)
            {
                ListarBancos();
                Banco banco = null;
                int numero = Int32.Parse(Console.ReadLine());

                foreach (Banco bank in bancos)
                {
                    if (bank.Numero == numero)
                    {
                        banco = bank;
                    }
                }
                if (banco != null)
                {
                    Console.WriteLine($"{banco.Numero} identificado");
                    return banco;
                }
                else
                {
                    Console.WriteLine($"Não há banco cadastrado com o número {numero}");
                    return null;
                }

            }
            else
            {
                Console.WriteLine("Não existem bancos cadastrados.");
                return null;
            }

        }

        public Agencia ObterAgencia()
        {
            if (agencias.Count > 0)
            {
                ListarAgencias();
                Agencia agencia = null;
                int numero = Int32.Parse(Console.ReadLine());
                foreach (Agencia agen in agencias)
                {
                    if (agen.Numero == numero)
                    {
                        agencia = agen;
                    }
                }
                if (agencia != null)
                {
                    Console.WriteLine($"{agencia.Numero} identificada");
                    return agencia;
                }
                else
                {
                    Console.WriteLine($"Não há agencia cadastrada com o número {numero}");
                    return null;
                }

            }
            else
            {
                Console.WriteLine("Não existem agencias cadastradas.");
                return null;
            }

        }

        public Conta ObterConta()
        {
            if (contas.Count > 0)
            {
                ListarContas();
                Conta contaDeposito = null;
                int numero = Int32.Parse(Console.ReadLine());
                foreach (Conta conta in contas)
                {
                    if (conta.Numero == numero)
                    {
                        contaDeposito = conta;
                    }
                }
                if (contaDeposito != null)
                {
                    Console.WriteLine($"{contaDeposito.Numero} identificada");
                    return contaDeposito;
                }
                else
                {
                    Console.WriteLine($"Não há conta cadastrada com o número {numero}");
                    return null;
                }

            }
            else
            {
                Console.WriteLine("Não existem contas cadastradas.");
                return null;
            }

        }

        public Cliente ObterCliente()
        {
            if (clientes.Count > 0)
            {
                ListarClientes();
                Console.WriteLine("Informe o CPF do cliente desejado: ");
                String cpf = Console.ReadLine();
                Cliente cliente = null;
                foreach (Cliente cli in clientes)
                {
                    if (cli.Cpf.Equals(cpf))
                    {
                        cliente = cli;
                    }
                }
                if (cliente != null)
                {
                    Console.WriteLine($"{cliente.Cpf} identificado");
                    return cliente;
                }
                else
                {
                    Console.WriteLine($"Não há cliente cadastrado com o CPF {cpf}");
                    return null;
                }

            }
            else
            {
                Console.WriteLine("Não existem clientes cadastrados.");
                return null;
            }

        }

        public void Depositar()
        {
            Console.WriteLine("Informe o número da conta a depositar: ");
            Conta conta = ObterConta();
            if (conta != null)
            {
                Console.WriteLine("Informe o valor a ser depositado: ");
                decimal valor = Decimal.Parse(Console.ReadLine());
                conta.Deposito(valor);
            }
            else
            {
                Console.WriteLine("Depósito não realizado.");
            }

        }

        public void Sacar()
        {
            Console.WriteLine("Informe o número da conta na qual deseja realizar o saque: ");
            Conta conta = ObterConta();
            if (conta != null)
            {
                Console.WriteLine("Informe o valor a ser retirado: ");
                decimal valor = Decimal.Parse(Console.ReadLine());
                conta.Saque(valor);
                Console.WriteLine($"O saldo da conta após o saque é R${conta.Saldo}");
            }
            else
            {
                Console.WriteLine("Saque não realizado.");
            }
        }

        public void Transferir()
        {
            Console.WriteLine("Informe a conta de origem da transferencia:");
            Conta origem = ObterConta();
            Console.WriteLine("Informe a conta de destino da transferência: ");
            Conta destino = ObterConta();
            if ((origem != null) && (destino != null))
            {
                if (origem != destino)
                {
                    Console.WriteLine("Informe o valor a ser transferido: ");
                    decimal valor = Decimal.Parse(Console.ReadLine());
                    origem.Transfere(destino, valor);
                }
                else
                {
                    Console.WriteLine("As conta de destino e origem devem ser diferentes");
                }
            }
            else
            {
                Console.WriteLine("As contas de origem e destino devem ser informadas");
            }
        }
        public void SaldoGeral()
        {
            Console.WriteLine("Informe o número da conta a qual deseja saber o saldo ");
            Conta conta = ObterConta();

            Console.WriteLine($"O saldo da conta após o saque é R${conta.Saldo}");

        }
            

            public void Listar()
        {
            throw new NotImplementedException();
        }
    }
}
