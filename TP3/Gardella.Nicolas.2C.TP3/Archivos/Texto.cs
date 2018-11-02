using Excepciones;
using System;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(archivo, true);
                sw.WriteLine(datos);
            }
            catch (Exception e)
            {
                throw new ArchivosException();
            }
            finally
            {
                sw.Close();
            }
            return true;
        }
        public bool Leer(string archivo, out string datos)
        {
            StreamReader sw = null;
            try
            {
                sw = new StreamReader(archivo);
                datos = sw.ReadToEnd();
            }
            catch (Exception e)
            {
                throw new ArchivosException();
            }
            finally
            {
                try
                {
                    sw.Close();
                }
                catch (Exception)
                {

                    
                }
            }
            return true;
        }
    }
}
