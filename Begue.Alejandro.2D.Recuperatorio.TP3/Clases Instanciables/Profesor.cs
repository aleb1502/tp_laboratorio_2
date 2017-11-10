using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Clases_Instanciables;
namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;

        /// <summary>
        /// 
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
                this._clasesDelDia.Enqueue((Universidad.EClases)Profesor._random.Next(0, 3));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
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
            if (!object.ReferenceEquals(i, null))
            {
                foreach (Universidad.EClases c in i._clasesDelDia)
                {
                    if (!object.ReferenceEquals(c, null) && c == clase)
                        return true;
                }
            }
            return false;
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
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool value = false;

            if (obj is Profesor && this == (Profesor)obj)
            {
                value = true;
            }

            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder("CLASES DEL DÍA:\n");
            if (!object.ReferenceEquals(this._clasesDelDia, null))
            {
                foreach (Universidad.EClases c in this._clasesDelDia)
                    sb.AppendFormat("{0}\n", c);
            }
            return sb.ToString();
        }

        static Profesor()
        {
            Profesor._random = new Random();
        }

        public Profesor() : base()
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
