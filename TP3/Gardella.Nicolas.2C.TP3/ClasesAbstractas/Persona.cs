using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }
        #region atributos
        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;
        #endregion
        #region propiedades
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                try
                {
                    string nombreV = ValidarNombreApellido(value);
                    if (nombreV != null)
                    {
                        this.nombre = nombreV;
                    }
                }
                catch (Exception)
                {

                    // throw;
                }
            }
        }
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                string apellidoV = ValidarNombreApellido(value);
                if (apellidoV != null)
                {
                    this.apellido = apellidoV;
                }
            }
        }
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                try
                {
                    this.dni = ValidarDni(this.nacionalidad, value);
                }
                catch (Exception)
                {

                    // throw;
                }
            }
        }
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;

            }
        }
        public string StringToDNI
        {
            set
            {
                try
                {
                    this.dni = ValidarDni(this.nacionalidad, value);
                }
                catch (Exception e)
                {

                     throw e;
                }
            }
        }
        #endregion
        #region metodos
        public Persona()
        {
        }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        /// <summary>
        /// Muestra datos de Persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre);
            sb.AppendLine("NACIONALIDAD: " + this.Nacionalidad.ToString());

            return sb.ToString();
        }
        /// <summary>
        /// valida que el dni sea valido teniendo en cuenta su nacionalidad
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>retorna el dni en caso de ser correcto</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (dato > 99999999)
            {
                throw new DniInvalidoException();
            }
            else if (nacionalidad == ENacionalidad.Argentino)
            {
                if (dato < 1 || dato > 89999999)
                {
                    throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                }
            }
            else if ((nacionalidad == ENacionalidad.Extranjero))
            {
                if (dato < 90000000)
                {
                    throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                }
            }
            return dato;
        }
        /// <summary>
        /// Trata de convertir el dni a Int y en caso de ser correcto llama a ValidarDni(ENacionalidad nacionalidad, int dato) 
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int intDni;
            if (int.TryParse(dato, out intDni))
            {
                return ValidarDni(nacionalidad, intDni);
            }
            else
            {
                throw new DniInvalidoException();
            }
        }
        /// <summary>
        /// valida que el string recibido sea valido como nombre o apellido
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            if (!Regex.IsMatch(dato, @"^[a-zA-Z]+$"))
            {
                return null;
            }
            return dato;
        }
        #endregion
    }
}
