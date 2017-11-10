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
    public class Texto : IArchivo<string>
    {
        public bool guardar(string archivo, string datos)
        {
            StreamWriter sw;        //Objeto que escribirá en binario.
            bool value = false;

            try
            {
                using (sw = new StreamWriter(archivo,true))
                {
                    sw.WriteLine(datos);
                    sw.Close();
                }
                value = true;
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }

            return value;
        }

        public bool leer(string archivo, out string datos)
        {
            StreamReader sr;
            bool value = false;

            try
            {
                using (sr = new StreamReader(archivo))
                {
                    datos = sr.ReadToEnd();
                    sr.Close();
                }
                value = true;

            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }

            return value;
        }
    }
}
