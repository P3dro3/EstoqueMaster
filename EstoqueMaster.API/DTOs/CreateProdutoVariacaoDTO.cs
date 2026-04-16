namespace EstoqueMaster.API.DTOs
{
    public class CreateProdutoVariacaoDTO
    {
        public string Tamanho { get; set; } = string.Empty;
        public string? Cor { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoVenda { get; set; }
        public int EstoqueMinimo { get; set; }
    }
}