using System.ComponentModel.DataAnnotations;

namespace EstoqueDeProdutos.Data.Dtos
{
    public class CreateControleEstoqueDto
    {
        [Required(ErrorMessage = "O campo Id do produto é obrigatório.")]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "O campo quantidade de entrada é obrigatório.")]
        public int QtdEntrada { get; set; }

        [Required(ErrorMessage = "O campo quantidade de saída é obrigatório.")]
        public int QtdSaida { get; set; }

        [Required(ErrorMessage = "O campo observação é obrigatório.")]
        public string Observacao { get; set; }

    }
}
