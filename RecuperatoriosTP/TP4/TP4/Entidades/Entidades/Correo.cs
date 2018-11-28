using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }

        public Correo()
        {
            paquetes = new List<Paquete>();
            mockPaquetes = new List<Thread>();
        }
        public void FinEntregas()
        {
            foreach (Thread hilo in mockPaquetes)
            {
                if (hilo.IsAlive)
                {
                    hilo.Abort();
                }
            }
        }
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            List<Paquete> lstPaquetes = (List<Paquete>)((Correo)elementos).Paquetes;
            StringBuilder datos = new StringBuilder();
            foreach (Paquete p in lstPaquetes)
            {
                datos.AppendLine(string.Format("{0} para {1} ({2})", p.TrackingID, p.DireccionEntrega, p.Estado.ToString()));
            }
            return datos.ToString();
        }
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete aux in c.paquetes)
            {
                if (p == aux)
                {
                    throw new TrackingIdRepetidoException("Id repetido");
                }
            }
            c.paquetes.Add(p);
            Thread hilo = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(hilo);
            hilo.Start();

            return c;
        }
    }
}
