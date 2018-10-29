using System.Collections.Generic;
using System.Text;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private EClases clase;
        private Profesor instructor;

        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        public EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }
        public Jornada(EClases clase, Profesor instructor) : this()
        {
            this.Instructor = instructor;
            this.Clase = clase;
        }
        public static bool Guardar(Jornada jornada)
        {
            return true;
            //TODO
        }
        public string Leer()
        {
            StringBuilder sb = new StringBuilder();
            //TODO
            return sb.ToString();
        }
        public static bool operator ==(Jornada j, Alumno a)
        {
            return j.Alumnos.Contains(a);
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.Alumnos.Add(a);
            }
            return j;
        }
        /// <summary>
        /// muestra datos de jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            
            sb.Append("CLASE DE " + this.Clase);
            sb.AppendLine(" POR " + this.Instructor.ToString());
            sb.AppendLine("ALUMNOS: ");

            foreach (Alumno a in this.Alumnos)
            {
                sb.AppendLine(a.ToString());
            }

            return sb.ToString();
        }
    }

}
