using System;
namespace controleContas
{
    public class Conta
    {
        private int numero;
        private decimal saldo;
        public Cliente Cliente { get; private set; }
        public Agencia Agencia { get; private set; }
        public static decimal SaldoTotal;
        public static decimal MaiorSaldo = decimal.MinValue;
        public static int ContaMaiorSaldo;
        public Conta(int numero, decimal saldo, Cliente cliente, Agencia agencia)
        {
            this.Numero = numero;
            this.Cliente = cliente;
            this.Agencia = agencia;
            if (saldo >= 10m)
                this.Saldo = saldo;
            else
                throw new ArgumentOutOfRangeException("O saldo inicial da conta deve ser maior que 10");
        }
        public int Numero {
            get
            {
                return numero;
            }
            set
            {
                this.numero = value;
            }
        }
        public decimal Saldo {
            get
            {
                return this.saldo;
            }
            set
            {
                if (value >= 0.0m)
                {
                    this.saldo = value;
                    SaldoTotal += value; //que problema existe com essa implementação? como resolver?
                    //O saldo total deverá ser alterado de quado houver redução do saldo de uma conta
                    VerificaMaiorSaldo();
                }
                else
                    throw new ArgumentOutOfRangeException("O saldo não pode ser definido como negativo");
            }
        }
    
        public void Deposito(decimal valor)
        {
            if(saldo > 0)
            {
                this.saldo += valor;
            }
        }

        private void VerificaMaiorSaldo()
        {
            if(this.saldo > MaiorSaldo)
            {
                MaiorSaldo = this.saldo;
                ContaMaiorSaldo = this.numero;
            }
        }

        public void Saque(decimal valor)
        {
            if((this.saldo - valor - 0.1m) >= 0)
            {
                this.saldo -= (valor + 0.1m);
            }
            else
            {
                throw new  ArgumentOutOfRangeException("O valor do saque é maior que o saldo disponível");
            }
        }

        public void Transfere(Conta destino, Decimal valor)
        {
            this.Saque(valor);
            destino.Deposito(valor);
        }

        public override string ToString()
        {
            return "Número: " + this.Numero + " / Saldo: " + this.saldo + " / Cliente: " + this.Cliente.Cpf;
        }
    }
}
