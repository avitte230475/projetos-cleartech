using System.ComponentModel.DataAnnotations;

namespace EstoqueDeProdutos.Models;

public class ControleEstoque
{
    [Key]
    [Required]
    public int Id { get; set; }
    public int ProdutoId { get;set; }
    public int QtdEntrada { get; set; }
    public int QtdSaida { get; set; }
    public string Observacao { get; set; }
    public DateTime DataMovimentacao { get; set; } = DateTime.Now;

    public Produto Produto { get; set; }
}
