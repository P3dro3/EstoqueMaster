using Xunit;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EstoqueMaster.Core.Entities;
using EstoqueMaster.Core.Interfaces;
using EstoqueMaster.API.Controllers;

namespace EstoqueMaster.Test
{
    public class ProdutoControllerTests
    {
        [Fact]
        public async Task GetProdutos_DeveRetornarListaDeProdutos()
        {
            // Arrange
            var produtos = new List<Produto>
            {
                new Produto("Produto A", "Desc", "Cat", 10, 20, 1, 10),
                new Produto("Produto B", "Desc", "Cat", 15, 30, 1, 10),
            };

            var mockRepo = new Mock<IProdutoRepository>();
            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(produtos);

            var controller = new ProdutosController(mockRepo.Object);

            // Act
            var result = await controller.GetProdutos();
            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            // Assert
            var lista = Assert.IsType<List<Produto>>(okResult.Value);
            Assert.Equal(2, lista.Count);
        }

        [Fact]
        public async Task GetProduto_DeveRetornarNotFound_QuandoProdutoNaoExiste()
        {
            // Arrange
            var mockRepo = new Mock<IProdutoRepository>();
            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                    .ReturnsAsync((Produto?)null);

            var controller = new ProdutosController(mockRepo.Object);

            // Act
            var result = await controller.GetProduto(999);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task CreateProduto_DeveRetornarCreated()
        {
            // Arrange
            var produto = new Produto("Novo Produto", "Desc", "Cat", 10, 20, 1, 10);
            var mockRepo = new Mock<IProdutoRepository>();
            mockRepo.Setup(r => r.AddAsync(It.IsAny<Produto>())).ReturnsAsync(produto);

            var controller = new ProdutosController(mockRepo.Object);

            // Act
            var result = await controller.CreateProduto(produto);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal("GetProduto", createdResult.ActionName);
        }
    }
}