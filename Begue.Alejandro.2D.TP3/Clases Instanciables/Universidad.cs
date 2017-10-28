using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Legislacion,
            Laboratorio,
            Programacion,
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

        /*public Jornada this[int i] {

            get
            {
                //return this.jornada;
            }

            set
            {
                //this.jornada = value;
            }
        }*/

        /*public bool Guardar(Universidad gim)
        {

        }*/

        private string MostrarDatos(Universidad gim)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Alumno item in alumnos)
            {
                sb.AppendLine("Alumno: " + item.ToString());
            }

            foreach (Jornada item in jornada)
            {
                sb.AppendLine("Jornada: " + item.ToString());
            }

            foreach (Profesor item in profesores)
            {
                sb.AppendLine("Profesores: " + item.ToString());
            }

            return sb.ToString();
        }

        public static bool operator == (Universidad g, Alumno a)
        {
            bool value = false;

            foreach(Alumno item in g.alumnos)
            {
                if(item is Alumno)
                {
                    value = true;
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
            foreach (Alumno item in g.alumnos)
            {
                if (!(item is Alumno))
                {
                    g.alumnos.Add(item);
                }
            }

            return g;
        }

        public static bool operator == (Universidad g, Profesor i)
        {
            bool value = false;

            foreach (Profesor item in g.profesores)
            {
                if (item is Profesor)
                {
                    value = true;
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
            foreach (Profesor item in g.profesores)
            {
                if (!(item is Profesor))
                {
                    g.profesores.Add(item);
                }
            }

            return g;
        }

        /*public static Profesor operator == (Universidad g, EClases clase)
        {
            foreach(Profesor item in g.profesores)
            {
                if(item is Profesor)
                {
                    g.profesores.Add(item);
                }
            }

            //return g.profesores.Add(item);
        }*/

        /*public static Profesor operator != (Universidad g, EClases clase)
        {
            return !(g == clase);
        }*/

        public string ToString()
        {
            Universidad u1 = new Universidad();

            return this.MostrarDatos(u1);
        }

        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
    }
}
