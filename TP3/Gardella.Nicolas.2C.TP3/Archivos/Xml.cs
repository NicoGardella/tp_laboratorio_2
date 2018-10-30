using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            XmlTextWriter writer;  //Objeto que escribirá en XML.
            XmlSerializer ser;     //Objeto que serializará.

            //Se indica ubicación del archivo XML y su codificación.
            writer = new XmlTextWriter(archivo, Encoding.UTF8);
            //Se indica el tipo de objeto ha serializar.
            ser = new XmlSerializer(typeof(T));
            //Serializa el objeto p en el archivo contenido en writer.
            ser.Serialize(writer, datos);
            //Se cierra la conexión al archivo
            writer.Close();

            return true;
        }
        public bool Leer(string archivo, out T datos)
        {
            XmlTextReader reader;
            XmlSerializer ser;
            try
            {

                reader = new XmlTextReader(archivo);
                ser = new XmlSerializer(typeof(T));
                datos = (T)ser.Deserialize(reader);
                reader.Close();
            }
            catch (ArchivosException e)
            {
                throw e;
            }

            return true;
        }
    }
}
