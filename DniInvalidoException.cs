﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private static string mensajeBase = "El DNI ingresado no es un número válido.";

        public DniInvalidoException() 
            : base(mensajeBase)
        {

        }

        public DniInvalidoException(string message) : this(message,null)
        {
            
        }

        public DniInvalidoException(Exception e) : base(mensajeBase,e)
        {

        }

        public DniInvalidoException(string message, Exception e)
            : base(mensajeBase + message, e)
        {
           
        }
    }
}
