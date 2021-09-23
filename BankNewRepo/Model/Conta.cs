using System;
namespace controleContas.Model
{
    public abstract class Conta
    {
        public Conta()
        {
        }
        public abstract void Sacar(double valor);
    }
}
