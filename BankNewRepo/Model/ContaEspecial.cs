using System;
namespace controleContas.Model
{
    public abstract class ContaEspecial : Conta
    {
        public ContaEspecial()
        {
        }

        public override void Sacar(double valor) { }

        public abstract void Depositar();
    }
}
