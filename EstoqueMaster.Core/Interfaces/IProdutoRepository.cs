using EstoqueMaster.Core.Entities;

namespace EstoqueMaster.Core.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto?> GetByIdAsync(int id);
        Task<IEnumerable<Produto>> GetAllAsync();
        Task<Produto> AddAsync(Produto produto);
        Task UpdateAsync(Produto produto);
        Task DeleteAsync(int id);
        Task<Produto?> GetByCodigoAsync(string codigo);
        Task<IEnumerable<Produto>> GetProdutosComEstoqueBaixoAsync();
        Task<IEnumerable<Produto>> GetByCategoriaAsync(string categoria);
    }
}