using EstoqueMaster.Core.Entities;
using EstoqueMaster.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EstoqueMaster.Infra.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Produto?> GetByIdAsync(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<IEnumerable<Produto>> GetAllAsync()
        {
            return await _context.Produtos
                .Where(p => p.Ativo)
                .ToListAsync();
        }

        public async Task<Produto> AddAsync(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task UpdateAsync(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var produto = await GetByIdAsync(id);
            if (produto != null)
            {
                produto.Desativar();
                await UpdateAsync(produto);
            }
        }

        public async Task<Produto?> GetByCodigoAsync(string codigo)
        {
            return await _context.Produtos
                .FirstOrDefaultAsync(p => p.Codigo == codigo && p.Ativo);
        }

        public async Task<IEnumerable<Produto>> GetProdutosComEstoqueBaixoAsync()
        {
            return await _context.Produtos
                .Where(p => p.EstoqueAtual <= p.EstoqueMinimo && p.Ativo)
                .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> GetByCategoriaAsync(string categoria)
        {
            return await _context.Produtos
                .Where(p => p.Categoria == categoria && p.Ativo)
                .ToListAsync();
        }
    }
}