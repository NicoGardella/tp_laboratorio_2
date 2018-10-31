using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
    public sealed class Alumno:Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }
        private EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        public Alumno()
        {

        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma):base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma,EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        public static bool operator ==(Alumno a, EClases clase)
        {
            return (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor);
        }
        public static bool operator !=(Alumno a, EClases clase)
        {
            return a.claseQueToma != clase;
        }
        /// <summary>
        /// muestra clase en la que participa el alumno
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this.claseQueToma.ToString();
        }
        /// <summary>
        /// muestra datos de Alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine(base.MostrarDatos());
            retorno.AppendLine("ESTADO DE CUENTA: " + (this.estadoCuenta==EEstadoCuenta.AlDia?"Cuota al día":this.estadoCuenta.ToString()));
            retorno.AppendLine(this.ParticiparEnClase());

            return retorno.ToString();
        }
        /// <summary>
        /// llama a MostrarDatos()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
