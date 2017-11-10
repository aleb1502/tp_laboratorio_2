using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Excepciones;
using Archivos;
using System.Xml.Serialization;


namespace Clases_Instanciables
{
    [Serializable]
    public class Universidad
    {
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD,
        }

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        public List<Alumno> Alumno {

            get
            {
                return this.alumnos;
            }
            
            set
            {
                this.alumnos = value;
            }

        }

        public List<Profesor> Instructores {

            get
            {
                return this.profesores;
            }

            set
            {
                this.profesores = value;
            }

        }

        public List<Jornada> Jornadas {

            get
            {
                return this.jornada;
            }

            set
            {
                this.jornada = value;
            }

        }

        public Jornada this[int i] {

            get
            {
                if (i >= 0 && i < this.Jornadas.Count)
                    return this.Jornadas[i];
                throw new IndiceInvalidoException();
            }

            set
            {
                if (i >= 0 && i < this.Jornadas.Count)
                    this.Jornadas[i] = value;
                else if (i == this.Jornadas.Count)
                    this.Jornadas.Add(value);
                else
                    throw new IndiceInvalidoException();
            }
        }

        public static bool Guardar(Universidad gim)
        {
            return new Xml<Universidad>().guardar("Universitad.xml", gim);
        }

        public Universidad Leer(Universidad gim)
        {
            new Xml<Universidad>().leer("Universitad.xml", out gim);
            return gim;
        }

        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Jornada jornada in gim.Jornadas)
            {
                if (!object.ReferenceEquals(jornada, null))
                {
                    sb.AppendLine("JORNADA:");
                    sb.AppendLine(jornada.ToString());
                    sb.AppendLine("< ---------------------------------------------------------------->");
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool value = false;

            if (obj is Universidad && this == (Universidad)obj)
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

        public static bool operator == (Universidad g, Alumno a)
        {
            bool value = false;

            if (!object.ReferenceEquals(g, null) && !object.ReferenceEquals(a, null))
            {
                foreach (Alumno item in g.alumnos)
                {
                    if (!object.ReferenceEquals(item,null) && a == item)
                    {
                        value = true;
                    }
                }
            }

            return value;
        }

        public static bool operator != (Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static Universidad operator + (Universidad g, Alumno a)
        {
            if (g == a)
            {
                throw new AlumnoRepetidoException();
            }
            else if (!object.ReferenceEquals(g, null) && !object.ReferenceEquals(a, null)) // necesito repetir esta evaluacion porque que g y a sean no iguales(==) no me indica que no lo sean por objetos nulos
            {
                g.alumnos.Add(a);
            }
                
            return g;
        }

        public static bool operator == (Universidad g, Profesor i)
        {
            bool value = false;

            if (!object.ReferenceEquals(g, null) && !object.ReferenceEquals(i, null))
            {
                foreach (Profesor item in g.profesores)
                {
                    if (!object.ReferenceEquals(item,null) && i == item)
                    {
                        value = true;
                    }
                }
            }

            return value;
        }

        public static bool operator != (Universidad g, Profesor i)
        {
            return !(g == i);
        }

        public static Universidad operator + (Universidad g, Profesor i)
        {
            if (g == i)
            {
                throw new ProfesorRepetidoException();
            }
            else if (!object.ReferenceEquals(g, null) && !object.ReferenceEquals(i, null)) // necesito repetir esta evaluacion porque que g e i sean no iguales(==) no me indica que no lo sean por objetos nulos
            {
                g.profesores.Add(i);
            }
               
            return g;
        }

        public static Profesor operator == (Universidad g, EClases clase)
        {
            if (!object.ReferenceEquals(g, null))
            {
                foreach (Profesor p in g.profesores)
                {
                    if (!object.ReferenceEquals(p, null) && p == clase)
                        return p; // Si p == clase (el profesor da esa clase) lo retorna (primero que encuentra)
                }
            }

            throw new SinProfesorException();
        }

        public static Profesor operator != (Universidad g, EClases clase)
        {
            if (!object.ReferenceEquals(g, null))
            {
                foreach (Profesor p in g.profesores)
                {
                    if (!object.ReferenceEquals(p, null) && p != clase)
                        return p; // Si p != clase (el profesor NO da esa clase) lo retorna (primero que encuentra)
                }
            }

            throw new SinProfesorException();
        }

        public static Universidad operator + (Universidad g, EClases clase)
        {
            if (!object.ReferenceEquals(g, null))
            {
                Jornada j = new Jornada(clase, g == clase);

                foreach (Alumno alumno in g.alumnos)
                {
                    if (!object.ReferenceEquals(alumno, null) && alumno == clase) // acá evaluo los alumnos que toman esa clase para agregarlos (en caso afirmativo) a la jornada
                        j += alumno;
                }

                g.Jornadas.Add(j);
            }
            return g;
        }

        public override string ToString()
        {
            return MostrarDatos(this);
        }

        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
    }
}
