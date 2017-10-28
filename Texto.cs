using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool guardar(string archivo, string datos)
        {
            FileStream fs;        //Objeto que escribirá en binario.
            BinaryFormatter ser;  //Objeto que serializará.

            fs = new FileStream(archivo, FileMode.Create);
            //Se indica ubicación del archivo binario y el modo.
            ser = new BinaryFormatter();
            //Se crea el objeto serializador.
            ser.Serialize(fs, datos);
            //Serializa el objeto p en el archivo contenido en fs.
            fs.Close();
            //Se cierra el objeto fs.
            return true;
        }

        public bool leer(string archivo, out string datos)
        {
            FileStream fs;        //Objeto que escribirá en binario.
            BinaryFormatter ser;  //Objeto que serializará.

            fs = new FileStream(archivo, FileMode.Create);
            //Se indica ubicación del archivo binario y el modo.
            ser = new BinaryFormatter();
            //Se crea el objeto serializador.
            datos = (string)ser.Deserialize(fs);
            //Serializa el objeto p en el archivo contenido en fs.
            fs.Close();
            //Se cierra el objeto fs.
            return true;
        }
    }
}
