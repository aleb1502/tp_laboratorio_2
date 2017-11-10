using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Xml.Serialization;
using EntidadesAbstractas;
using System.Xml;

namespace Archivos
{
    public class Xml <T> : IArchivo<T>
    {
        public bool guardar(string archivo, T datos)
        {
            try
            {
                using (XmlTextWriter file = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(file, datos);
                    file.Close();
                }
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        public bool leer(string archivo, out T datos)
        {
            try
            {
                using (XmlTextReader file = new XmlTextReader(archivo))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    datos = (T)serializer.Deserialize(file);
                    file.Close();
                }
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
    }
}
