using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Pruebas
{
    [TestClass]
    public class ClienteTest
    {
        [TestMethod]
        public void ValidarDatosCliente_RetornaNull_CuandoUnoDeSusParametrosNoCumplenConLasValidaciones()
        {
            //Arrange
            Cliente clienteAux = new Cliente("pepe", "pep3ardo", 250, 1, ETipoPlanGimnasio.Premium);

            //Act
            clienteAux = Cliente.ValidarDatosCliente(clienteAux.Nombre, clienteAux.Apellido, clienteAux.Edad, clienteAux.Dni.ToString(), (int)clienteAux.PlanGimnasio);

            // Assert
            Assert.IsNull(clienteAux);
        }

        [TestMethod]
        public void ValidarDatosCliente_RetornaUnClienteInstanciado_CuandoSusParametrosCumplenConLasValidaciones()
        {
            //Arrange
            Cliente cliente1 = new Cliente("pepe", "pepardo", 40, 12345678, ETipoPlanGimnasio.Premium);

            Cliente cliente2;

            //Act
            cliente2 = Cliente.ValidarDatosCliente(cliente1.Nombre, cliente1.Apellido, cliente1.Edad, cliente1.Dni.ToString(), (int)cliente1.PlanGimnasio);

            // Assert
            Assert.AreEqual(cliente1, cliente2);
        }
    }
}
