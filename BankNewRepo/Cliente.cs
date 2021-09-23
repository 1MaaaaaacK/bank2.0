using System;
namespace controleContas
{
    public class Cliente
    {
        private String nome;
        private String cpf;
        private int anoNascimento;
        public int AnoNascimento
        {
            get
            {
                return anoNascimento;
            }
            set
            {
                if (DateTime.Today.Year - value >= 18)
                {
                    this.anoNascimento = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("O cliente deve ser maior de idade1");
                }
            }
        }
        public String Nome {
            get
            {
                return this.nome;
            }
            set
            {
                this.nome = value;
            }
        }
        public String Cpf
        {
            get
            {
                return this.cpf;
            }
            set
            {
                if (value.Length != 11)
                {
                    throw new InvalidCpfException();
                }
                else
                {
                    this.cpf = value;
                }
            }
        }

        public Cliente()
        {
        }

        public override string ToString()
        {
            return "Nome: " + this.nome + " / CPF: " + this.cpf + " / Ano de Nascimento: " + this.anoNascimento;
        }

        
    }
}
