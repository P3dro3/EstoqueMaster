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
        // TESTE 1
        [Fact]
        public async Task GetProdutos_DeveRetornarListaDeProdutos()
        {
            var produtos = new List<Produto>
            {
                new Produto("Produto A", "Desc", "Cat", 10, 20, 1, 10),
                new Produto("Produto B", "Desc", "Cat", 15, 30, 1, 10),
            };

            var mockRepo = new Mock<IProdutoRepository>();
            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(produtos);

            var controller = new ProdutosController(mockRepo.Object);

            var result = await controller.GetProdutos();
            var okResult = result.Result as OkObjectResult;

            Assert.NotNull(okResult);

            var produtosRetornados = Assert.IsType<List<Produto>>(okResult.Value);
            Assert.Equal(2, produtosRetornados.Count);
        }

        // TESTE 2
        [Fact]
        public async Task GetProduto_DeveRetornarNotFound_QuandoProdutoNaoExiste()
        {
            var mockRepo = new Mock<IProdutoRepository>();
            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                    .ReturnsAsync((Produto?)null);

            var controller = new ProdutosController(mockRepo.Object);

            var result = await controller.GetProduto(999);
            var notFoundResult = result.Result as NotFoundResult;

            Assert.NotNull(notFoundResult);
            Assert.IsType<NotFoundResult>(notFoundResult);
        }
    }
}
