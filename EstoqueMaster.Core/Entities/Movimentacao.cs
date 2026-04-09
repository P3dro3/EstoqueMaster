namespace EstoqueMaster.Core.Entities;
public class Movimentacao
{
    public int Id { get; set; }

    public int ProdutoVariacaoId { get; set; }

    public string Tipo { get; set; } = string.Empty;

    public int Quantidade { get; set; }

    public DateTime Data { get; set; } = DateTime.Now;

    public string? Motivo { get; set; }

    public ProdutoVariacao ProdutoVariacao { get; set; } = null!;
}
