using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Text.RegularExpressions;

namespace EntidadesAbstractas
{
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
                this._apellido = this.ValidarNombreApellido(value);
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
                this._dni = this.ValidarDni(this._nacionalidad,value);
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
                this._nombre = this.ValidarNombreApellido(value);
            }

        }

        public string StringToDNI
        {
            set
            {
                this.DNI = ValidarDni(this._nacionalidad, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Persona()
        {
            //this._dni = this.DNI;
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
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.Apellido, this.Nombre);
            sb.AppendFormat("NACIONALIDAD: {0}", this.Nacionalidad);
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

            if (dato < 1 || dato > 99999999)
                throw new DniInvalidoException();
            else if (!(nacionalidad == ENacionalidad.Argentino && dato < 90000000 || nacionalidad == ENacionalidad.Extranjero && dato > 89999999))
                throw new NacionalidadInvalidaException();
            return dato;
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
            int aux;
            if (!int.TryParse(dato, out aux))
                throw new DniInvalidoException();

            return this.ValidarDni(nacionalidad, aux);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            Regex r = new Regex("^[áéíóúa-zA-Z ]+$");
            if (!r.IsMatch(dato))
                return "";
            return dato;
        }
    }
}
