using System;
namespace controleContas.Model.Dao
{
    public interface IManipulaBanco<T>
    {
        public void Criar(T obj);
        public Banco Obter(int numero);
        public void Alterar(T obj);
    }
}
