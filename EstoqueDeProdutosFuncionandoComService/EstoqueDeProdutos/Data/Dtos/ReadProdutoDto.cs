using System.ComponentModel.DataAnnotations;

namespace EstoqueDeProdutos.Data.Dtos;

public class ReadProdutoDto
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public double Valor { get; set; }

    public int TotalEstoque { get; set; }

    public bool Status { get; set; }

    public DateTime DataCriacao { get; set; } = DateTime.Now;

    public DateTime DataModificacao { get; set; } = DateTime.Now;
}

