using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    /// <summary>
    /// La clase Producto será abstracta, evitando que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }
        EMarca _marca;
        private string _codigoDeBarras;
        private ConsoleColor _colorPrimarioEmpaque;


        /// <summary>
        /// ReadOnly: Retornará la cantidad de ruedas del vehículo
        /// </summary>
        public abstract short CantidadCalorias {
            get;
        }

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        public abstract string Mostrar();

        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CODIGO DE BARRAS: {0}\r\n" + p._codigoDeBarras);
            sb.AppendLine("MARCA          : {0}\r\n" +  p._marca.ToString());
            sb.AppendLine("COLOR EMPAQUE  : {0}\r\n" +  p._colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            bool value = false;

            if(!object.ReferenceEquals(v1,null) && !object.ReferenceEquals(v2,null))
            {
                if (v1._codigoDeBarras == v2._codigoDeBarras)
                {
                    value = true;
                }
                else
                {
                    value = false;
                }
            }

            return value;
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return !(v1 == v2);
        }

        public override bool Equals(object objeto)//sobreescribo el metodo virtual de object llamado Equals para comparar 
        {                                      //2 objetos y saber si son iguales. Esto ademas usa el == sobrecargado de
            return (this == (Producto)objeto);    //arriba, dentro de este método.
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoDeBarras"></param>
        /// <param name="marca"></param>
        /// <param name="color"></param>
        public Producto(string codigoDeBarras, EMarca marca ,ConsoleColor color)
        {
            this._codigoDeBarras = codigoDeBarras;
            this._marca = marca;
            this._colorPrimarioEmpaque = color;
        }
    }
}
