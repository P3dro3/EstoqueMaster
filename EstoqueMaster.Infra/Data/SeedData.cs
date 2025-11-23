using EstoqueMaster.Core.Entities;

namespace EstoqueMaster.Infra.Data
{
    public static class SeedData
    {
        public static async Task Initialize(AppDbContext context)
        {
            if (context.Produtos.Any())
            {
                return;
            }

            var produtos = new[]
            {
                new Produto("Notebook Dell Inspiron", "Notebook i5 8GB RAM 256GB SSD", "Eletrônicos", 2500.00m, 3200.00m, 2, 10),
                new Produto("Mouse Logitech MX", "Mouse sem fio ergonômico", "Periféricos", 150.00m, 299.00m, 5, 30),
                new Produto("Teclado Mecânico Redragon", "Teclado mecânico RGB switches blue", "Periféricos", 200.00m, 450.00m, 3, 15),
                new Produto("Monitor Samsung 24\"", "Monitor LED 24 polegadas Full HD", "Monitores", 600.00m, 899.00m, 1, 8),
                new Produto("Cadeira Gamer", "Cadeira gamer ergonômica preta e vermelha", "Móveis", 800.00m, 1200.00m, 1, 5)
            };

            // APENAS adiciona estoque - NÃO redefina EstoqueMinimo/EstoqueMaximo
            produtos[0].AdicionarEstoque(5);
            produtos[1].AdicionarEstoque(20);
            produtos[2].AdicionarEstoque(2);
            produtos[3].AdicionarEstoque(8);
            produtos[4].AdicionarEstoque(6);

            await context.Produtos.AddRangeAsync(produtos);
            await context.SaveChangesAsync();
        }
    }
}