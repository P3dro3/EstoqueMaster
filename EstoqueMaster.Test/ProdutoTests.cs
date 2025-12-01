using Xunit;
using EstoqueMaster.Core.Entities; 

namespace EstoqueMaster.Test
{
    public class ProdutoTests
    {
        [Fact]
        public void CriarProduto_DeveInicializarCorretamente()
        {
            var produto = new Produto(
                "Mouse",
                "Mouse óptico",
                "Periféricos",
                20m,
                50m,
                5,
                100
            );

            Assert.Equal("Mouse", produto.Nome);
            Assert.Equal("Mouse óptico", produto.Descricao);
            Assert.Equal("Periféricos", produto.Categoria);
            Assert.Equal(20m, produto.Custo);
            Assert.Equal(50m, produto.PrecoVenda);
            Assert.Equal(5, produto.EstoqueMinimo);
            Assert.Equal(100, produto.EstoqueMaximo);
            Assert.True(produto.Ativo);
            Assert.NotNull(produto.Codigo);
        }

        [Fact]
        public void AdicionarEstoque_DeveSomarQuantidade()
        {
            var produto = new Produto("Mouse", "Desc", "Cat", 10m, 20m, 2, 100);

            produto.AdicionarEstoque(10);

            Assert.Equal(10, produto.EstoqueAtual);
            Assert.NotNull(produto.DataAtualizacao);
        }

        [Fact]
        public void AdicionarEstoque_QuantidadeInvalida_DeveGerarErro()
        {
            var produto = new Produto("Mouse", "Desc", "Cat", 10m, 20m, 2, 100);

            Assert.Throws<ArgumentException>(() =>
                produto.AdicionarEstoque(0)
            );
        }

        [Fact]
        public void RemoverEstoque_ComEstoqueSuficiente_DeveDiminuir()
        {
            var produto = new Produto("Mouse", "Desc", "Cat", 10m, 20m, 2, 100);

            produto.AdicionarEstoque(20);
            produto.RemoverEstoque(5);

            Assert.Equal(15, produto.EstoqueAtual);
        }

        [Fact]
        public void RemoverEstoque_ComEstoqueInsuficiente_DeveGerarErro()
        {
            var produto = new Produto("Mouse", "Desc", "Cat", 10m, 20m, 2, 100);

            produto.AdicionarEstoque(5);

            Assert.Throws<InvalidOperationException>(() =>
                produto.RemoverEstoque(10)
            );
        }
    }
}
