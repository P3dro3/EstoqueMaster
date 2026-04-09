namespace EstoqueMaster.Core.Entities;
public class ProdutoVariacao
{
    public int Id { get; set; }

    public int ProdutoId { get; set; }

    public string Tamanho { get; set; } = string.Empty;

    public string? Cor { get; set; }

    public int Quantidade { get; set; }

    public decimal PrecoVenda { get; set; }

    public int EstoqueMinimo { get; set; }

    public Produto Produto { get; set; } = null!;

    public ICollection<Movimentacao> Movimentacoes { get; set; } = new List<Movimentacao>();
}
