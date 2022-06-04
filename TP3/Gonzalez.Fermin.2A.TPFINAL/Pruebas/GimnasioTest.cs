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
            Gimnasio.AgregarCliente(clienteAux);
            bool retorno;

            //Act
            retorno = Gimnasio.ValidarClienteExistente(clienteAux);

            //Assert
            Assert.IsTrue(retorno);
        }



    }
}
