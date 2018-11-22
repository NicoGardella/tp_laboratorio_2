using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class GuardaString
    {
        public static bool Guardar(this string texto, string archivo)
        {
            bool retorno = false;
            StreamWriter escribir = null;
            try
            {
                escribir = File.AppendText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + archivo);
                escribir.WriteLine(texto);
                retorno = true;
            }
            catch (FileNotFoundException)
            {
                string error = "El archivo no existe";
                throw new FileNotFoundException(error);
            }
            finally
            {
                escribir.Close();
            }
            return retorno;
        }
    }
}
