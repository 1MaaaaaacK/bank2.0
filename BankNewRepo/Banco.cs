using System;
namespace controleContas
{
    public class Banco
    {
        public int Numero { get; private set; }
        public String Nome { get; set; }
        public Banco(int numero, String nome)
        {
            if(numero > 0)
            {
                this.Numero = numero;
                this.Nome = nome;
            }
            else
            {
                throw new ArgumentOutOfRangeException("O número do banco deve ser maior que zero");
            }
        }

        public override string ToString()
        {
            return "Número: " + this.Numero + " / Nome: " + this.Nome;
        }
    }
}
