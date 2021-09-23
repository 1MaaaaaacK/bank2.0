using System;
using System.Collections.Generic;

namespace controleContas
{
    public class Relatorio<T>
    {
        

        public static void Listar(List<T> list)
        {
            if (list.Count > 0)
                list.ForEach(obj => { Console.WriteLine(obj.ToString()); });
            else
            {
                Console.WriteLine("Não há nenhum item cadastrado!");
            }
        }


    }
}
