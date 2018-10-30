using Excepciones;
using System;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            XmlTextWriter writer = null;  //Objeto que escribirá en XML.
            XmlSerializer s;     //Objeto que serializará.
            try
            {
                writer = new XmlTextWriter(archivo, Encoding.UTF8);
                s = new XmlSerializer(typeof(T));
                s.Serialize(writer, datos);                              
            }
            catch (Exception e)
            {
                throw new ArchivosException();
            }
            finally
            {
                writer.Close();
            }
            return true;
        }
        public bool Leer(string archivo, out T datos)
        {
            XmlTextReader reader = null;
            XmlSerializer ser;
            try
            {

                reader = new XmlTextReader(archivo);
                ser = new XmlSerializer(typeof(T));
                datos = (T)ser.Deserialize(reader);

            }
            catch (Exception e)
            {
                throw new ArchivosException();
            }
            finally
            {
                reader.Close();
            }
            return true;

        }
    }
}
