using Core.Entity;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using TechChallangeCadastroCotatosAPI.Controllers;
using Microsoft.AspNetCore.Http;

namespace UnitTest
{
    public class ContatoControllerTest
    {
        [Fact]
        public void Get_DeveReotrnar200ComUmaListaVazia_QuandoRepositoryDevolverVazio()
        {
            var mockContatoRepository = new Mock<IContatoRepository>();
            mockContatoRepository.Setup(repository => repository.ObterTodos()).Returns(new List<Contato>());

            var contatoController = new ContatoController(mockContatoRepository.Object);

            var resultado = Assert.IsType<OkObjectResult>( contatoController.Get());
            Assert.NotNull(resultado);
            Assert.Equal(StatusCodes.Status200OK, resultado.StatusCode);
            var valor = Assert.IsType<List<Contato>>(resultado.Value);
            Assert.Empty(valor);
        }
        [Fact]
        public void Get_DeveReotrnarBadRequest_QuandoDerUmaExeção()
        {
            var mockContatoRepository = new Mock<IContatoRepository>();
            mockContatoRepository.Setup(repository => repository.ObterTodos()).Throws<System.IO.IOException>();
                

            var contatoController = new ContatoController(mockContatoRepository.Object);

            var resultado = Assert.IsType<OkObjectResult>(contatoController.Get());
            Assert.Equal(StatusCodes.Status500InternalServerError, resultado.StatusCode);
        }
    }
}