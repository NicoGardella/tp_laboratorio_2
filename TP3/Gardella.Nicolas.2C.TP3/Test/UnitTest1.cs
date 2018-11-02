using System;
using System.IO;
using Archivos;
using ClasesInstanciables;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
       
        [TestMethod]
        public void ComprobarAtributosDeUniversidad()
        {
            Universidad universidad = new Universidad();

            Assert.IsNotNull(universidad.Instructores);
            Assert.IsNotNull(universidad.Jornadas);
            Assert.IsNotNull(universidad.Alumnos);
        }


        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void TestFileNotFoundException()
        {
            Texto texto = new Texto();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\fileNotFound.txt";
            string res;
            try
            {
                texto.Leer(path, out res);
            }
            catch (ArchivosException a)
            {

                throw new FileNotFoundException();
            }
        }


        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestDniInvalidoException()
        {
            Alumno alumno = null;

            try
            {
                 alumno = new Alumno(1, "Juan Carlos", "Cárdenas",
                    "122a4458", EntidadesAbstractas.Persona.ENacionalidad.Argentino,
                    Universidad.EClases.SPD);
            }
            catch (DniInvalidoException)
            {
                throw new DniInvalidoException("dni con caracteres no numericos");
            }            
        }

        [TestMethod]
        public void TestDni()
        {
            string dni = "12234458";
           Alumno alumno = new Alumno(1, "Humberto Dionisio", "Maschio",
                dni, EntidadesAbstractas.Persona.ENacionalidad.Argentino,
                Universidad.EClases.Programacion);

            Assert.AreEqual(int.Parse(dni), alumno.DNI);
        }

    }
}
