using System;
namespace controleContas
{
    public class Agencia
    {
        public int Numero { get; private set; }
        public String Cep { get; set; }
        public String Telefone { get; set; }
        public Banco Banco { get; private set; }
        public Agencia(int numero, Banco banco)
        {
            if(numero > 0 && banco != null)
            {
                this.Numero = numero;
                this.Banco = banco;
            }
            else
            {
                if (numero <= 0) throw new ArgumentOutOfRangeException("O número deve ser maior que zero"); 
                throw new ArgumentNullException("O banco deve ser informado!");
            }
            
        }

        public override string ToString()
        {
            return "Numero: " + this.Numero + " / Banco: " + this.Banco.Numero;
        }
    }
}
