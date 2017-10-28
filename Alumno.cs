using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;


namespace Clases_Instanciables
{
    [Serializable]
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            Deudor,
            Becado,
            AlDia,
        }

        private Clases_Instanciables.Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        /// <summary>
        /// 
        /// </summary>
        public Alumno()
        {
            this.DNI = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Clases_Instanciables.Universidad.EClases claseQueToma) : base(id,nombre,apellido,dni,nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Clases_Instanciables.Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("CLASE QUE TOMA: " + this._claseQueToma);
            sb.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta);

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator == (Alumno a, Clases_Instanciables.Universidad.EClases clase)
        {
            bool value = false;
            EEstadoCuenta e1 = EEstadoCuenta.Deudor;
            
            if(a._claseQueToma == clase && e1 != EEstadoCuenta.Deudor)
            {
                value = true;
            }

            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator != (Alumno a, Clases_Instanciables.Universidad.EClases clase)
        {
            bool value = false;

            if (a._claseQueToma != clase)
            {
                value = true;
            }

            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("TOMA CLASE DE: " + this._claseQueToma);

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            return this.MostrarDatos();
        }

    }
}
