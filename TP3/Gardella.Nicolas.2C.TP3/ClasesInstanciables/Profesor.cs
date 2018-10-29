using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
    public sealed class Profesor:Universitario
    {
        private Queue<EClases> clasesDelDia;
        private static Random random;

        /// <summary>
        /// muestra datos de profesor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            sb.Append(this.ParticiparEnClase());

            return sb.ToString();
        }
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA: ");
            foreach (EClases clase in this.clasesDelDia)
            {
                sb.AppendLine(clase.ToString());
            }
            return sb.ToString();
        }
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        static Profesor()
        {
            random = new Random();
        }
        private Profesor()
        {
            random = new Random();
        }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad): base(id, nombre, apellido, dni, nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }
        /// <summary>
        /// asigna dos clases aleatorias
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
            }
        }
        public static bool operator ==(Profesor i, EClases clase)
        {
            return i.clasesDelDia.Contains(clase);
        }
        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }

    }
}
