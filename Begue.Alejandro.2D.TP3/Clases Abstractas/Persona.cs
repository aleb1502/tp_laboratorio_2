using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
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
                this._apellido = value;
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
                if (this._dni >= 1 && this._dni <= 89999999)
                {
                    this._dni = value;
                }
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
                if (this._dni >= 1 && this._dni <= 89999999 && this._nacionalidad == ENacionalidad.Argentino)
                {
                    this._nacionalidad = value;
                }
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
            }

        }

        public string StringToDNI
        {

            set
            {
                //this._dni = value;
            }

        }

        public Persona()
        {
            this._dni = 0;
        }
        
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre,apellido,nacionalidad)
        {
            this._dni = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        public string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Apellido: " + this._apellido);
            sb.AppendLine("Nombre: " + this._nombre);
            sb.AppendLine("DNI: " + this._dni);
            sb.AppendLine("Nacionalidad: " + this._nacionalidad);

            return sb.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if(nacionalidad == ENacionalidad.Argentino)
            {
                this.DNI = dato;
            }

            return dato;
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int value = 0;

            if (nacionalidad == ENacionalidad.Argentino)
            {
                this.StringToDNI = dato;
                value = 1;
            }

            return value;
        }

        private string ValidarNombreApellido(string dato)
        {
            if(String.Compare(this._nombre,"A") >= 0 && String.Compare(this._nombre,"Z") <= 0)
            {
                if (String.Compare(this._apellido, "A") >= 0 && String.Compare(this._apellido, "Z") <= 0)
                {
                    dato = this._nombre + this._apellido;
                }
            }

            return dato;
        }
    }
}
