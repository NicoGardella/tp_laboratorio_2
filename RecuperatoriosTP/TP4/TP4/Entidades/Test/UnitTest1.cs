using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void claseInstanciada()
        {
            Correo c = new Correo();
            Assert.IsNotNull(c.Paquetes);
        }

        [TestMethod]
        public void ingresarPaquete()
        {
            Correo c = new Correo();
            Paquete p1 = new Paquete("Avellaneda", "123456");
            Paquete p2 = new Paquete("Wildel", "123456");
            try
            {
                c += p1;
                c += p2;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(TrackingIdRepetidoException));
            }
        }

    }


}
