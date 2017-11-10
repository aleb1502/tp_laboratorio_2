using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;


namespace Clases_Instanciables
{
    [Serializable]
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Clases_Instanciables.Universidad.EClases _clases;
        private Profesor _instructor;

        public List<Alumno> Alumnos {

            get
            {
                return this._alumnos;
            }

            set
            {
                this._alumnos = value;
            }

        }

        public Clases_Instanciables.Universidad.EClases Clases {

            get
            {
                return this._clases;
            }

            set
            {
                this._clases = value;
            }

        }

        public Profesor Instructor {

            get
            {
                return this._instructor;
            }

            set
            {
                this._instructor = value;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            return new Texto().guardar("Jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Clases_Instanciables.Universidad.EClases clase, Profesor instructor) : this()
        {
            this._clases = clase;
            this._instructor = instructor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Leer()
        {
            string retorno = "\nEl archivo no pudo ser leido!\n";
            new Texto().leer("Jornada.txt", out retorno);
            return retorno;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator == (Jornada j, Alumno a)
        {
            bool value = false;

            if (!object.ReferenceEquals(j, null) && !object.ReferenceEquals(a, null))
            {
                foreach (Alumno item in j._alumnos)
                {
                    if (!object.ReferenceEquals(item,null) && a == item)
                    {
                        value = true;
                    }
                }
            }

            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator != (Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool value = false;

            if(obj is Jornada && this == (Jornada)obj)
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
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator + (Jornada j, Alumno a)
        {
            if (j == a)
            {
                throw new AlumnoRepetidoException();
            }
            else if (!object.ReferenceEquals(j, null) && !object.ReferenceEquals(a, null)) // necesito repetir esta evaluacion porque que j y a sean no iguales(==) no me indica que no lo sean por objetos nulos
            {
                j.Alumnos.Add(a);
            }
                
            return j;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CLASE DE {0} POR {1}", this.Clases, this.Instructor.ToString());
            sb.AppendLine("\nALUMNOS:");
            foreach (Alumno alumno in this.Alumnos)
            {
                if (!object.ReferenceEquals(alumno, null))
                    sb.AppendLine(alumno.ToString());
            }
            return sb.ToString();
        }
    }
}
