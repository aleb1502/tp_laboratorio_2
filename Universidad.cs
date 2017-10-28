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
                return this.jornada[i];
            }

            set
            {
                this.jornada[i] = value;
            }
        }

        public static bool Guardar(Universidad gim)
        {
            Xml<string> xml;
            FileStream fs;        //Objeto que escribirá en binario.
            BinaryFormatter ser;  //Objeto que serializará.
            Exception e = new Exception();
            string datos = " ";

            xml = new Xml<string>();

            fs = new FileStream("Universidad.xml", FileMode.Create); //Se indica ubicación del archivo binario y el modo.

            if (fs != null)
            {
                xml.guardar("Universidad.xml", datos);
                ser = new BinaryFormatter();
                //Se crea el objeto serializador.
                ser.Serialize(fs, gim);
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

        public Universidad Leer(Universidad gim)
        {
            Xml<string> xml;
            FileStream fs;        //Objeto que escribirá en binario.
            BinaryFormatter ser;  //Objeto que serializará.
            Exception e = new Exception();
            string datos = " ";

            xml = new Xml<string>();

            fs = new FileStream("Universidad.xml", FileMode.Create);

            if (fs != null)
            {
                xml.leer("Universidad.xml", out datos);
                //Se indica ubicación del archivo binario y el modo.
                ser = new BinaryFormatter();
                //Se crea el objeto serializador.
                gim = (Universidad)ser.Deserialize(fs);
                //Serializa el objeto p en el archivo contenido en fs.
            }
            else
            {
                throw new ArchivosException(e);
            }
            fs.Close();
            //Se cierra el objeto fs.
            return gim;
        }

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
                if(g == item)
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
                if (!(g == a))
                {
                    g.alumnos.Add(a);
                }
            }

            return g;
        }

        public static bool operator == (Universidad g, Profesor i)
        {
            bool value = false;

            foreach (Profesor item in g.profesores)
            {
                if (g == i)
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
                if (!(g == i))
                {
                    g.profesores.Add(i);
                }
            }

            return g;
        }

        public static Profesor operator == (Universidad g, EClases clase)
        {
            foreach(Profesor item in g.profesores)
            {
                if (item == clase)
                {
                    return item;
                }
            }

            throw new SinProfesorException();
        }

        public static Profesor operator != (Universidad g, EClases clase)
        {
            foreach (Profesor item in g.profesores)
            {
                if (item != clase)
                {
                    return item;
                }
            }

            throw new SinProfesorException();
        }

        public static Universidad operator + (Universidad g, EClases clase)
        {
            Profesor p1 = null;

            foreach(Profesor item in g.profesores)
            {
                    if(item == clase)
                    {
                       p1 = item;
                    }
            }
            
            Jornada j1 = new Jornada(clase,p1);

            foreach (Alumno item in g.alumnos)
            {
                if (item == clase)
                {
                    j1.Alumnos.Add(item);
                }
            }

            g.jornada.Add(j1);

            return g;
        }

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
