using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private static string mensajeBase = "El DNI ingresado no es un número válido.";

        public DniInvalidoException() : base(mensajeBase)
        {

        }

        public DniInvalidoException(Exception e) : base(mensajeBase, e)
        {

        }

        public DniInvalidoException(string message, Exception e) : base(message, e)
        {

        }

        public DniInvalidoException(string message) : base(message)
        {

        }
    }
}
