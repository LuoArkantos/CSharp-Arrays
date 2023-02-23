using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bytebank_ATENDIMENTO.bytebank.Exception
{
    public class ByteBankException
    {

        [Serializable]
        public class BytebankException : System.Exception
        {
            public BytebankException() { }
            public BytebankException(string message) : base("Seu programa encontrou um erro - "+message) { }
            public BytebankException(string message, System.Exception inner) : base(message, inner) { }
            protected BytebankException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
    }
}
