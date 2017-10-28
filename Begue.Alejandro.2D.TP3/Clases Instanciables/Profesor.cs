using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<EClases> _clasesDelDia;
        private Random _random;

        private void _randomClases()
        {

        }

        protected override string MostrarDatos()
        {
            EClases miClase = EClases.Legislacion;
            EEstadoCuenta miEstadoCuenta = EEstadoCuenta.Deudor;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("CLASE QUE TOMA: " + miClase.ToString());
            sb.AppendLine("ESTADO DE CUENTA: " + miEstadoCuenta.ToString());

            return sb.ToString();
        }

        public static bool operator == (Profesor i, EClases clase)
        {
            bool value = false;

            foreach(EClases item in i._clasesDelDia)
            {
                if (item is EClases)
                {
                    value = true;
                }
            }

            return value;
        }

        public static bool operator != (Profesor i, EClases clase)
        {
            return !(i == clase); 
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            foreach(EClases item in this._clasesDelDia)
            {
                sb.AppendLine("CLASES DEL DIA: " + this._clasesDelDia);
            }

            return sb.ToString();
        }

        public Profesor()
        {
            this._random = new Random();
            this._clasesDelDia = new Queue<EClases>();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id,nombre,apellido,dni,nacionalidad)
        {

        }

        public string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
