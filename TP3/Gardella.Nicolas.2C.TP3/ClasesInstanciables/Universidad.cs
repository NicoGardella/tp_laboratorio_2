using Excepciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClasesInstanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
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
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }
        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }
        }
        public static bool Guardar(Universidad uni)
        {
            return true;
            //TODO
        }
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA: ");

            foreach (Jornada j in uni.jornada)
            {
                sb.AppendLine(j.ToString());
                sb.AppendLine("<------------------------------------------------------->");
            }

            return sb.ToString();
        }
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>();
        }
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Jornada j in u.Jornadas)
            {
                if (j.Clase != clase)
                {
                    return j.Instructor;
                }
            }
            throw new SinProfesorException();
        }

        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
            {
                g.Instructores.Add(i);
            }
            return g;
        }
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return u;
        }
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor p;
            try
            {
                p = (g == clase);
            }
            catch (Exception e)
            {

                throw e;
            }
            Jornada j = new Jornada(clase, p);
            foreach (Alumno aux in g.alumnos)
            {
                if (aux == clase)
                {
                    j += aux;
                }
            }
            g.Jornadas.Add(j);
            return g;
        }

        public static bool operator ==(Universidad g, Alumno a)
        {
            return (g.Alumnos.Contains(a));
        }
        public static bool operator ==(Universidad g, Profesor i)
        {
            return (g.Instructores.Contains(i));
        }
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor i in u.Instructores)
            {
                if (i == clase)
                {
                    return i;
                }
            }
            throw new SinProfesorException();
        }

    }
}
