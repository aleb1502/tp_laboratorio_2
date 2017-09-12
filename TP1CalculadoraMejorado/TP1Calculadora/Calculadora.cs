using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1Calculadora
{
    public class Calculadora
    {   /// <summary>
    /// 
    /// </summary> Boton que sirve para operar la calculadora
    /// <param name="numero1"></param>
    /// <param name="numero2"></param>
    /// <param name="operador"></param>
    /// <returns></returns>
        public static double operar(Numero numero1, Numero numero2, string operador)
        {
            double number1 = numero1.getNumero();
            double number2 = numero2.getNumero();
            double result = 0;

            //Buscar como castear el operador directamente.
            switch (operador)
            {
                case "*":
                    result = number1 * number2;
                    break;

                case "-":
                    result = number1 - number2;
                    break;

                case "+":
                    result = number1 + number2;
                    break;

                case "/":
                    if (number2 == 0)
                        result = 0;
                    else
                        result = number1 / number2;
                    break;
            }

            return result;

        }
        /// <summary> Valida la funcion que sea una de las cuatro operaciones
        /// 
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static string validarOperador(string operador)
        {
            string operatorC = "+";

            if (operador == "-" || operador == "*" || operador == "/")
            {
                operatorC = operador;
            }

            return operatorC;
        }
    }
}
