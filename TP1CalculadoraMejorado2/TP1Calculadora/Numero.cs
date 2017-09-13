using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TP1Calculadora
{
    public class Numero
    {
        private double numero;
        /// <summary> Obtiene el numero
        /// 
        /// </summary>
        /// <returns></returns> Retorna el this
        public double getNumero()
        {
            return this.numero;
        }
        /// <summary> Valida y crea el numero
        /// 
        /// </summary>
        /// <param name="numero"></param>
        private void setNumero(string numero)
        {
            this.numero = Numero.validarNumero(numero);

        }
        /// <summary> Sirve para validar el numero
        /// 
        /// </summary>
        /// <param name="numeroString"></param>
        /// <returns></returns> auxNumero si cumple con las condiciones de string, caso contrario un 0
        private static double validarNumero(string numeroString)
        {
            double auxNumero;

            if (double.TryParse(numeroString, out auxNumero))
                return auxNumero;
            else
                return 0;
        }


        //public void setNumero()
        /// <summary> Constructor por defecto
        /// 
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary> Otro constructor que recibe un string como parametro
        /// 
        /// </summary>
        /// <param name="numero"></param>
        public Numero(string numero)
        {
            this.setNumero(numero);
        }
        /// <summary> Otro constructor que recibe un double como parametro
        /// 
        /// </summary>
        /// <param name="numero1"></param>
        public Numero(double numero1)
        {
            this.numero = numero1;
        }
    }
}
