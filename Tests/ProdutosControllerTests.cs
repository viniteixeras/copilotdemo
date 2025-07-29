using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using copilotdemo.Controllers;
using copilotdemo.Models;
using copilotdemo.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace copilotdemo.Tests
{
    public class ProdutosControllerTests
    {
        private readonly Mock<IProdutoRepository> _mockRepository;
        private readonly ProdutosController _controller;

        public ProdutosControllerTests()
        {
            _mockRepository = new Mock<IProdutoRepository>();
            _controller = new ProdutosController(_mockRepository.Object);
        }

        [Fact]
        public void GetProdutos_QuandoExistemProdutos_RetornaOkComListaDeProdutos()
        {
            // Arrange
            var produtosMock = new List<Produto>
            {
                new Produto { Id = 1, Nome = "Produto 1", Preco = 10.0m },
                new Produto { Id = 2, Nome = "Produto 2", Preco = 20.0m }
            };

            _mockRepository.Setup(repo => repo.GetAll())
                         .Returns(produtosMock);

            // Act
            var resultado = _controller.GetProdutos();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(resultado.Result);
            var produtos = Assert.IsAssignableFrom<IEnumerable<Produto>>(okResult.Value);
            Assert.Equal(2, produtos.Count());
        }

        [Fact]
        public void GetProdutos_QuandoNaoExistemProdutos_RetornaNotFound()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetAll())
                         .Returns(new List<Produto>());

            // Act
            var resultado = _controller.GetProdutos();

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(resultado.Result);
            Assert.Equal("Nenhum produto encontrado.", notFoundResult.Value);
        }

        [Fact]
        public void GetProdutos_QuandoOcorreErro_RetornaStatusCode500()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetAll())
                         .Throws(new System.Exception("Erro ao acessar o banco de dados"));

            // Act
            var resultado = _controller.GetProdutos();

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(resultado.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            Assert.Equal("Erro interno: Erro ao acessar o banco de dados", statusCodeResult.Value);
        }
    }
}
