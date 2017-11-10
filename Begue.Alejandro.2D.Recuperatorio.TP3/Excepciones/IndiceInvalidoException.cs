using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class IndiceInvalidoException : Exception
    {
        public IndiceInvalidoException() : base("El índice indicado está fuera del rango válido")
        {

        }
    }
}
