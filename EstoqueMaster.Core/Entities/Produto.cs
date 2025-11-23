namespace EstoqueMaster.Core.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public decimal Custo { get; set; }
        public decimal PrecoVenda { get; set; }
        public int EstoqueAtual { get; set; }
        public int EstoqueMinimo { get; set; }
        public int EstoqueMaximo { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool Ativo { get; set; } = true;

        // Construtor vazio para EF
        public Produto() { }

        // Construtor principal
        public Produto(string nome, string descricao, string categoria, decimal custo, decimal precoVenda, int estoqueMinimo, int estoqueMaximo)
        {
            Nome = nome;
            Descricao = descricao;
            Categoria = categoria;
            Custo = custo;
            PrecoVenda = precoVenda;
            EstoqueAtual = 0;
            EstoqueMinimo = estoqueMinimo;
            EstoqueMaximo = estoqueMaximo;
            Codigo = GerarCodigoUnico();
            DataCriacao = DateTime.Now;
            Ativo = true;
        }

        private string GerarCodigoUnico()
        {
            return $"PROD-{DateTime.Now:yyyyMMddHHmmss}";
        }

        public void AdicionarEstoque(int quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("Quantidade deve ser maior que zero");
                
            EstoqueAtual += quantidade;
            DataAtualizacao = DateTime.Now;
        }

        public void RemoverEstoque(int quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("Quantidade deve ser maior que zero");
                
            if (quantidade > EstoqueAtual)
                throw new InvalidOperationException($"Estoque insuficiente. Disponível: {EstoqueAtual}, Solicitado: {quantidade}");
                
            EstoqueAtual -= quantidade;
            DataAtualizacao = DateTime.Now;
        }

        public bool EstaComEstoqueBaixo()
        {
            return EstoqueAtual <= EstoqueMinimo;
        }

        public bool EstaComEstoqueExcessivo()
        {
            return EstoqueAtual > EstoqueMaximo;
        }

        public void AtualizarInformacoes(string nome, string descricao, string categoria, decimal custo, decimal precoVenda, int estoqueMinimo, int estoqueMaximo)
        {
            Nome = nome;
            Descricao = descricao;
            Categoria = categoria;
            Custo = custo;
            PrecoVenda = precoVenda;
            EstoqueMinimo = estoqueMinimo;
            EstoqueMaximo = estoqueMaximo;
            DataAtualizacao = DateTime.Now;
        }

        public void Desativar()
        {
            Ativo = false;
            DataAtualizacao = DateTime.Now;
        }
    }
}