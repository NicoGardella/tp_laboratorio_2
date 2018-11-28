using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlConnection conexion;
        private static SqlCommand comando;

        public static bool Insertar(Paquete p)
        {
            bool retorno = false;
            try
            {
                string query = string.Format("INSERT INTO Paquetes (direccionEntrega,trackingID,alumno) VALUES ('{0}','{1}','{2}')", p.DireccionEntrega, p.TrackingID, "Nicolas Gardella");
                comando = new SqlCommand(query, conexion);
                conexion.Open();
                comando.ExecuteNonQuery();
                retorno = true;
            }
            catch (Exception e)
            {
                throw new Exception("Error al insertar en la base de datos", e);
            }
            finally
            {
                conexion.Close();
            }
            return retorno;
        }
        static PaqueteDAO()
        {
            try
            {
                string conectionStr = "Data Source=.\\SQLEXPRESS;Initial Catalog=correo-sp-2017;Integrated Security=True";
                conexion = new SqlConnection(conectionStr);
            }
            catch (Exception e)
            {
                throw new Exception("Error en la coneccion con la base de datos", e);
            }
        }
    }
}
