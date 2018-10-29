using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        /// <summary>
        /// son iguales si son del mismo tipo y tienen el mismo dni o legajo
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if ((this.GetType() == obj.GetType()) && ((this.DNI == ((Universitario)(obj)).DNI) || (this.legajo == ((Universitario)(obj)).legajo)))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// muestra datos de universitario
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("LEGAJO NÚMERO: " + this.legajo);
            return sb.ToString();
        }
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2);
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        protected abstract string ParticiparEnClase();
        public Universitario()
        {

        }
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad): base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
    }
}
