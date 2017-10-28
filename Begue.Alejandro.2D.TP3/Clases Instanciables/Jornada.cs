using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private EClases _clases;
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

        public EClases Clases {

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

        /*public bool Guardar(Jornada jornada)
        {

        }*/

        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(EClases clase, Profesor instructor)
        {
            this._clases = clase;
            this._instructor = instructor;
        }

        /*public string Leer()
        {

        }*/

        public static bool operator == (Jornada j, Alumno a)
        {
            bool value = false;

            foreach(Alumno item in j._alumnos)
            {
                if(a is Alumno)
                {
                    value = true;
                }
            }

            return value;
        }

        public static bool operator != (Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator + (Jornada j, Alumno a)
        {
            foreach (Alumno item in j._alumnos)
            {
                if (!(a is Alumno))
                {
                    j._alumnos.Add(a);
                }
            }

            return j;
        }

        public string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach(Alumno item in this._alumnos)
            {
                sb.AppendLine("Alumno: " + this._alumnos);
                sb.AppendLine("Clase: " + this._clases);
                sb.AppendLine("Profesor: " + this._instructor);
            }

            return sb.ToString();
        }
    }
}
