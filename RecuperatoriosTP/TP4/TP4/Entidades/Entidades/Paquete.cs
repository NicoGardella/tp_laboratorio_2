using System;
using System.Text;

namespace Entidades
{
    public delegate void DelegadoEstado(Object sender, EventArgs e);
    public delegate void DelegadoConexion(object sender, Exception inner);
    public class Paquete : IMostrar<Paquete>
    {
        public event DelegadoEstado InformaEstado;
        public event DelegadoConexion InformarConexion;

        public enum EEstado
        {
            Ingresado, EnViaje, Entregado
        }

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }

        }
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }

        }
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }

        }
        public Paquete(string direccionEntrega, string trackingId)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingId;
            this.Estado = EEstado.Ingresado;
        }

        public void MockCicloDeVida()
        {
            do
            {
                System.Threading.Thread.Sleep(1000);
                this.Estado++;                
                InformaEstado(this.Estado, null);
            } while (this.Estado != EEstado.Entregado);
            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception e)
            {
                InformarConexion(this, null);
            }
        }
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine(string.Format("{0} para {1}", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega));
            return datos.ToString();
        }
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            if (p1.trackingID == p2.trackingID)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

    }

}
