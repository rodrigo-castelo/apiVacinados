using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiVacinados.Exceptions
{
    public class VacinadoJaCadastradoException : Exception
    {
        public VacinadoJaCadastradoException() : base("Esse cadastro já foi realizado") { }
    }
}
