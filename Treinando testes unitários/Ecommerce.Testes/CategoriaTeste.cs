using Ecommerce;

namespace Ecommerce.Testes
{
    public class CategoriaTeste
    {
        [Fact]
        public void TestarCadastroCategoria()
        {
            var menu = new Menu();
            menu.Cadastrar("Aline", "Ativo");
            Assert.NotNull(menu);
        }
        [Fact]
        public void TestarValidaNomeParaCadastroDeCategorias()
        {
            var menu = new Menu();
            menu.ValidaNome(nome: "Aline");
            Assert.NotNull(menu);
        }
        [Fact]
        public void TestarEditarCategorias()
        {
            var menu = new Menu();
            menu.Editar("Aline","Ativo");
            Assert.NotNull(menu);
        }
        [Fact]
        public void TestarAlterarStatusCategorias()
        {
            var menu = new Menu();
            menu.AlterarStatus();
            Assert.NotNull(menu);
        }
        [Fact]
        public void TestarListarCategorias()
        {
            var menu = new Menu();
            menu.Listar();
            Assert.NotNull(menu);
        }
    }
}