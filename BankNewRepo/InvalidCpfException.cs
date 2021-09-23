using System;
using System.Runtime.Serialization;

namespace controleContas
{
    [Serializable]
    internal class InvalidCpfException : Exception
    {
        public InvalidCpfException()
        { 
        }

        public InvalidCpfException(string message) : base(message)
        {
        }

        public InvalidCpfException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidCpfException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string Message => "O CPF deve possuir exatamente 11 dígitos";
    }
}