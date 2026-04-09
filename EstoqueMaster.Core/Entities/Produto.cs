namespace EstoqueMaster.Core.Entities;

public class Produto
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string? Descricao { get; set; }

    public string Categoria { get; set; } = string.Empty;

    public string Codigo { get; set; } = string.Empty;

    public bool Ativo { get; private set; } = true;

    public ICollection<ProdutoVariacao> Variacoes { get; set; } = new List<ProdutoVariacao>();

    public void Desativar()
    {
        Ativo = false;
    }
}