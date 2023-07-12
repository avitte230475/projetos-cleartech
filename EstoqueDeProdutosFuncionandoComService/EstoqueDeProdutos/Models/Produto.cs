using System.ComponentModel.DataAnnotations;

namespace EstoqueDeProdutos.Models;

public class Produto
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo nome é obrigatório.")]
    [MaxLength(50, ErrorMessage = "O tamanho do nome não deve exceder 50 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo valor é obrigatório.")]
    public double Valor { get; set; }

    [Required(ErrorMessage = "O campo estoque é obrigatório.")]
    public int TotalEstoque { get; set; } = 0;

    [Required(ErrorMessage = "O campo status é obrigatório.")]
    public bool Status { get; set; }
    
    public virtual ICollection<ControleEstoque> ControleEstoques { get; set; }

    
}
