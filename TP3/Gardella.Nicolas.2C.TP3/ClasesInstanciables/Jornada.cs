using Archivos;
using System;
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

        /// <summary>
        /// Guarda los datos de jordana previamente formateados en un archivo txt
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            string path = AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt";
            string txtDato = jornada.ToString();
            return texto.Guardar(path, txtDato);
        }
        /// <summary>
        /// lee el archivo txt y retorna en un string 
        /// </summary>
        /// <returns></returns>
        public string Leer()
        {
            string retorno;
            Texto texto = new Texto();
            string path = AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt";
            texto.Leer(path, out retorno);
            return retorno;
        }
        /// <summary>
        /// Devuelve true cuando la jornada j contiene al alumno a en su lista de alumnos
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return j.Alumnos.Contains(a);
        }
        /// <summary>
        /// niega el metodo anteriorE
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// en caso de que la jornada no contenga al alumno, lo agrega a la lista
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
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
            sb.AppendLine("<------------------------------------------------------->");
            return sb.ToString();
        }
    }

}
