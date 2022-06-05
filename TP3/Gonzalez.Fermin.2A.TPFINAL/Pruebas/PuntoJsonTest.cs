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
    public class PuntoJsonTest
    {
        [TestMethod]
        public void ValidarExtension_RetornaTrue_CuandoLaExtensionEsJson()
        {
            // Arrange
            PuntoJson<string> puntoJson = new PuntoJson<string>();
            bool retorno;

            // Act
            retorno = puntoJson.ValidarExtension("clientes.json");

            // Assert
            Assert.IsTrue(retorno);
        }

        [TestMethod]
        [ExpectedException(typeof(ArchivoIncorrectoException))]
        public void ValidarExtension_LanzaArchivoInvalidoException_CuandoLaExtensionNoEsJson()
        {
            // Arrange
            PuntoJson<string> puntoJson = new PuntoJson<string>();

            // Act
            bool retorno = puntoJson.ValidarExtension("archivo.xd");
        }
    }
}
