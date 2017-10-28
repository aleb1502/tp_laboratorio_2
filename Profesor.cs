using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Clases_Instanciables;
namespace Clases_Instanciables
{
    [Serializable]
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;

        /// <summary>
        /// 
        /// </summary>
        private void _randomClases()
        {
            Universidad.EClases c1 = (Universidad.EClases)_random.Next(0,3); //Agrego el primer random Next para elegir la primer clase al azar
            Universidad.EClases c2 = (Universidad.EClases)_random.Next(0,3); //Agrego el segundo random Next para elegir la segunda clase al azar
            this._clasesDelDia.Enqueue(c1); //Agrego la primer clase del dia con Enqueue
            this._clasesDelDia.Enqueue(c2); //Agrego la segunda clase del dia con Enqueue 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            Clases_Instanciables.Universidad.EClases miClase = Clases_Instanciables.Universidad.EClases.Legislacion;
            Clases_Instanciables.Alumno.EEstadoCuenta miEstadoCuenta = Clases_Instanciables.Alumno.EEstadoCuenta.Deudor;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("CLASE QUE TOMA: " + miClase.ToString());
            sb.AppendLine("ESTADO DE CUENTA: " + miEstadoCuenta.ToString());

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator == (Profesor i, Clases_Instanciables.Universidad.EClases clase)
        {
            bool value = false;

            foreach(Clases_Instanciables.Universidad.EClases item in i._clasesDelDia)
            {
                if (item is Clases_Instanciables.Universidad.EClases)
                {
                    value = true;
                }
            }

            return value;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator != (Profesor i, Clases_Instanciables.Universidad.EClases clase)
        {
            return !(i == clase); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            foreach(Clases_Instanciables.Universidad.EClases item in this._clasesDelDia)
            {
                sb.AppendLine("CLASES DEL DIA: " + this._clasesDelDia);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        public Profesor()
        {
            this._clasesDelDia = new Queue<Clases_Instanciables.Universidad.EClases>();
            this._randomClases(); //Llamo al metodo randomClases()
        }

        /// <summary>
        /// 
        /// </summary>
        static Profesor()
        {
            _random = new Random();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id,nombre,apellido,dni,nacionalidad)
        {

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
