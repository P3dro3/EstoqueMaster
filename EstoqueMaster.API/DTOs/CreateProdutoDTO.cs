namespace EstoqueMaster.API.DTOs
{
    public class CreateProdutoDTO
    {
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        
        public string Categoria { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;

        public List<CreateProdutoVariacaoDTO> Variacoes { get; set; } = new();
    }
}