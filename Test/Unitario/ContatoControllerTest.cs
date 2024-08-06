using Core.Entity;
using Core.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TechChallangeCadastroContatosAPI.Controllers;

namespace Test.Unitario
{
    public class ContatoControllerTest
    {
        [Fact]
        public void Get_DeveReotrnar200ComUmaListaVazia_QuandoRepositoryDevolverVazio()
        {
            var mockContatoRepository = new Mock<IContatoRepository>();
            mockContatoRepository.Setup(repository => repository.ObterTodos()).Returns(new List<Contato>());

            var contatoController = new ContatoController(mockContatoRepository.Object);

            var resultado = Assert.IsType<OkObjectResult>(contatoController.Get());
            Assert.NotNull(resultado);
            Assert.Equal(StatusCodes.Status200OK, resultado.StatusCode);
            var valor = Assert.IsType<List<Contato>>(resultado.Value);
            Assert.Empty(valor);
        }
    }
}
