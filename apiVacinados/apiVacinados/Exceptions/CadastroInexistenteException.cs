using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiVacinados.Exceptions
{
    public class CadastroInexistenteException : Exception
    {
        public CadastroInexistenteException() : base("Id não cadastrado")
        {
        }
    }
}
