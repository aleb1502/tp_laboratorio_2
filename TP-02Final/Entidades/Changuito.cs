using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public class Changuito
    {
        private List<Producto> _productos;
        private int _espacioDisponible;
        public enum ETipo
        {
            Dulce, Leche, Snacks, Todos
        }

        #region "Constructores"

        /// <summary>
        /// Es un constructor privado que inicia la lista
        /// </summary>
        private Changuito()
        {
            this._productos = new List<Producto>();
        }

        /// <summary>
        /// Es un constructor publico que llama a this, y devuelve el espacio disponible
        /// </summary>
        /// <param name="espacioDisponible"></param>
        public Changuito(int espacioDisponible) : this()
        {
            this._espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro la concecionaria y TODOS los Productos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Changuito.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="concesionaria">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Mostrar(Changuito concesionaria, ETipo tipoDeChanguito) //quitar static
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", concesionaria._productos.Count, concesionaria._espacioDisponible);
            sb.AppendLine("");
            foreach (Producto v in concesionaria._productos)
            {
                switch (tipoDeChanguito)
                {
                    case ETipo.Snacks:
                        if (v is Snacks)//pregunto si v es de la clase que necesito.
                        {
                            sb.AppendLine(v.Mostrar());//de serlo, claramente se sabe que es un objeto de la clase Snacks
                        }                               //y por lo tanto el Mostrar() será el de Snacks
                        break;
                    case ETipo.Dulce:
                        if(v is Dulce)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Leche:
                        if(v is Leche)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="changuito">Objeto donde se agregará el elemento</param>
        /// <param name="producto">Objeto a agregar</param>
        /// <returns></returns>
        public static Changuito operator +(Changuito changuito, Producto producto)
        {
            foreach (Producto item in changuito._productos)
            {
                if (item.Equals(producto))  //Comparo la igualdad con el metodo virtual Equals sobreescrito
                {
                    return changuito;       //en mi clase Producto
                }
            }

            if(changuito._productos.Count < changuito._espacioDisponible)
            {
                changuito._productos.Add(producto);
            }

            return changuito;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="changuito">Objeto donde se quitará el elemento</param>
        /// <param name="producto">Objeto a quitar</param>
        /// <returns></returns>
        public static Changuito operator -(Changuito changuito, Producto producto)
        {
            foreach (Producto item in changuito._productos)
            {
                if (item == producto)
                {
                    changuito._productos.Remove(producto);
                    break;
                }
            }

            return changuito;
        }
        #endregion
    }
}
