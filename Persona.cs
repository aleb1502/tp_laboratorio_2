using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    [Serializable]
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero,
        };

        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

        public string Apellido
        {

            get
            {
                return this._apellido;
            }

            set
            {
                if (String.Compare(this._apellido, "A") >= 0 && String.Compare(this._apellido, "Z") <= 0)
                {
                    this._apellido = value;
                }
                else
                {
                    Console.Write("No se puede cargar el apellido");
                }
            }

        }

        public int DNI
        {

            get
            {
                return this._dni;
            }

            set
            {
                this.ValidarDni(this._nacionalidad,this._dni);
            }

        }

        public ENacionalidad Nacionalidad
        {

            get
            {
                return this._nacionalidad;
            }

            set
            {
                this._nacionalidad = value;
            }

        }

        public string Nombre
        {

            get
            {
                return this._nombre;
            }

            set
            {
                if (String.Compare(this._nombre, "A") >= 0 && String.Compare(this._nombre, "Z") <= 0)
                {
                    this._nombre = value;
                }
                else
                {
                    Console.Write("No se puede cargar el nombre");
                }
            }

        }

        public string StringToDNI
        {
            set
            {
                this._dni = ValidarDni(this._nacionalidad, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Persona()
        {
            this._dni = 0;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre,apellido,nacionalidad)
        {
            this._dni = dni;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Apellido: " + this._apellido);
            sb.AppendLine("Nombre: " + this._nombre);
            sb.AppendLine("DNI: " + this._dni);
            sb.AppendLine("Nacionalidad: " + this._nacionalidad);

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            // Es válido SI, y sólo SI:
            // dato - 1 a 89999999 y nacionalidad es Argentino
            // dato - 90000000 a 99999999 y nacionalidad es Extranjero
            // Si es inválido lanza NacionalidadInvalidaException

            int value = 0;

            if (dato >= 1 && dato <= 89999999 && this._nacionalidad == ENacionalidad.Argentino)
            {
                value = dato;
            }
            else if (dato >= 90000000 && dato <= 99999999 && this._nacionalidad == ENacionalidad.Extranjero)
            {
                value = dato;
            }
            else 
            {
                throw new NacionalidadInvalidaException();
            }
             
            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            // Validar que dato sea NUMERICO
            // Reutilizar ValidarDni (ENacionalidad nacionalidad, int dato);
            // Si el DNI NO es numérico, lanza DniInvalidoException
            int value;

            if (int.TryParse(dato, out value))
            {
                this.ValidarDni(nacionalidad, value);
            }
            else
            {
                throw new DniInvalidoException();
            }

            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            if(this.Nombre + this.Apellido == dato)
            {
                dato = this._nombre + this._apellido;
            }
                
            return dato;
        }
    }
}
