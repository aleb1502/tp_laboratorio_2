using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            Deudor,
            Becado,
            AlDia,
        }

        /*public enum EClases
        {
            Legislacion,
            Laboratorio,
            Programacion,
        }*/

        private EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        public Alumno()
        {
            this.DNI = 0;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma) : base(id,nombre,apellido,dni,nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("CLASE QUE TOMA: " + this._claseQueToma);
            sb.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta);

            return sb.ToString();
        }

        public static bool operator == (Alumno a, EClases clase)
        {
            bool value = false;

            if(a._claseQueToma == clase)
            {
                value = true;
            }

            return value;
        }

        public static bool operator != (Alumno a, EClases clase)
        {
            return !(a == clase);
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("TOMA CLASE DE: " + this._claseQueToma);

            return sb.ToString();
        }

        public string ToString()
        {
            return this.MostrarDatos();
        }

    }
}
