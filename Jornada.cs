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
            Texto t1;
            FileStream fs;        //Objeto que escribirá en binario.
            BinaryFormatter ser;  //Objeto que serializará.
            Exception e = new Exception();
            string dato = " ";

            t1 = new Texto();

            fs = new FileStream("Jornada.txt", FileMode.Create);

            if(fs != null)
            {
                t1.guardar("Jornada.txt", dato);
                //Se indica ubicación del archivo binario y el modo.
                ser = new BinaryFormatter();
                //Se crea el objeto serializador.
                ser.Serialize(fs, jornada);
                //Serializa el objeto p en el archivo contenido en fs.
            }
            else
            {
                throw new ArchivosException(e);
            }

            fs.Close();
            //Se cierra el objeto fs.
            return true;
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
            Texto t1;
            FileStream fs;        //Objeto que escribirá en binario.
            BinaryFormatter ser;  //Objeto que serializará.
            Exception e = new Exception();
            string datos = " ";

            t1 = new Texto();

            fs = new FileStream("Jornada.txt", FileMode.Create);

            if (fs != null)
            {
                t1.leer("Jornada.txt", out datos);
                //Se indica ubicación del archivo binario y el modo.
                ser = new BinaryFormatter();
                //Se crea el objeto serializador.
                datos = (string)ser.Deserialize(fs);
                //Serializa el objeto p en el archivo contenido en fs.
            }
            else
            {
                throw new ArchivosException(e);
            }
            fs.Close();
            //Se cierra el objeto fs.
            return datos;
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

            foreach(Alumno item in j._alumnos)
            {
                if(item is Alumno)
                {
                    value = true;
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
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
