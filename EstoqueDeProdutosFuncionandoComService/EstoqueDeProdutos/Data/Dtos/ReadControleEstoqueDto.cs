namespace EstoqueDeProdutos.Data.Dtos
{
    public class ReadControleEstoqueDto
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int QtdEntrada { get; set; }
        public int QtdSaida { get; set; }
        public int TotalEstoque { get; set; }
        public string Observacao { get; set; }
        public DateTime DataMovimentacao { get; set; } = DateTime.Now;
    }
}
