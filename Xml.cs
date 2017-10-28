using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Excepciones;


namespace Archivos
{
    public class Xml <T> : IArchivo<T>
    {
        public bool guardar(string archivo, T datos)
        {
            FileStream fs;        //Objeto que escribirá en binario.
            BinaryFormatter ser;  //Objeto que serializará.
            Exception e = new Exception();

            fs = new FileStream(archivo, FileMode.Create);
            //Se indica ubicación del archivo binario y el modo.

            if(fs != null)
            {
                ser = new BinaryFormatter();
                //Se crea el objeto serializador.
                ser.Serialize(fs, datos);
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

        public bool leer(string archivo, out T datos)
        {
            FileStream fs;        //Objeto que escribirá en binario.
            BinaryFormatter ser;  //Objeto que serializará.
            Exception e = new Exception();

            fs = new FileStream(archivo, FileMode.Create);
            //Se indica ubicación del archivo binario y el modo.

            if (fs != null)
            {
                ser = new BinaryFormatter();
                //Se crea el objeto serializador.
                datos = (T)ser.Deserialize(fs);
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
    }
}
