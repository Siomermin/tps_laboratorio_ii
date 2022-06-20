using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO;

namespace Pruebas
{
    [TestClass]
    public class PuntoTxtTest
    {
        [TestMethod]
        public void ValidarExtension_RetornaTrue_CuandoLaExtensionEsTxt()
        {
            // Arrange
            PuntoTxt puntoTxt = new PuntoTxt();
            bool retorno;

            // Act
            retorno = puntoTxt.ValidarExtension("archivo.txt");

            // Assert
            Assert.IsTrue(retorno);
        }


        [TestMethod]
        [ExpectedException(typeof(ArchivoIncorrectoException))]
        public void ValidarExtension_LanzaArchivoInvalidoException_CuandoLaExtensionNoEsTxt()
        {
            // Arrange
            PuntoTxt puntoTxt = new PuntoTxt();

            // Act
            bool retorno = puntoTxt.ValidarExtension("archivo.pedorro");
        }
    }
}

