using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace Pruebas
{
    [TestClass]
    public class GimnasioTest
    {
        [TestMethod]
        public void ValidarClienteExistente_DevuelveTrue_CuandoElClienteEstaEnElGimnasio()
        {
            //Arrange
            Cliente clienteAux = new Cliente("pepe", "pepardo", 20, 42312456, ETipoPlanGimnasio.Premium);
            Gimnasio.ListaClientes.Add(clienteAux);
            bool retorno;

            //Act
            retorno = Gimnasio.ValidarClienteExistente(clienteAux);

            //Assert
            Assert.IsTrue(retorno);
        }

        [TestMethod]
        public void ValidarClienteExistente_DevuelveFalse_CuandoElClienteNoEstaEnElGimnasio()
        {
            //Arrange
            Cliente clienteAux = new Cliente("pepe", "pepardo", 20, 42312456, ETipoPlanGimnasio.Premium);
            bool retorno;

            //Act
            retorno = Gimnasio.ValidarClienteExistente(clienteAux);

            //Assert
            Assert.IsFalse(retorno);
        }

        [TestMethod]
        public void AgregarCliente_DevuelveTrue_CuandoElClienteSeAgregoAlGimnasio()
        {
            //Arrange
            Cliente clienteAux = new Cliente("pepe", "pepardo", 20, 42312456, ETipoPlanGimnasio.Premium);
            bool retorno;

            //Act
            retorno = Gimnasio.AgregarCliente(clienteAux);

            //Assert
            Assert.IsTrue(retorno);
        }


        [TestMethod]
        public void EliminarCliente_DevuelveTrue_CuandoElClienteSeEliminoDelGimnasio()
        {
            //Arrange
            Cliente clienteAux = new Cliente("pepe", "pepardo", 20, 42312456, ETipoPlanGimnasio.Premium);
            Gimnasio.AgregarCliente(clienteAux);
            bool retorno;

            //Act
            retorno = Gimnasio.EliminarCliente(clienteAux);

            //Assert
            Assert.IsTrue(retorno);
        }
    }
}
