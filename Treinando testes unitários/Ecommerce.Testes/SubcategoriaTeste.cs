using Ecommerce;

namespace Ecommerce.Testes
{
    public class SubcategoriaTeste
    {
        [Fact]
        public void TestarCadastroSubcategoria()
        {
            var menu = new Menu();
            menu.CadastrarSubcategoria("Gisele", "Ativo");
            Assert.NotNull(menu);
        }
        [Fact]
        public void TestarValidaNomeParaCadastroDeSubcategorias()
        {
            var menu = new Menu();
            menu.ValidaNome(nome: "Gisele");
            Assert.NotNull(menu);
        }
        [Fact]
        public void TestarEditarSubcategorias()
        {
            var menu = new Menu();
            menu.EditarSubcategoria("Gisele", "Ativo");
            Assert.NotNull(menu);
        }
        [Fact]
        public void TestarAlterarStatusSubcategorias()
        {
            var menu = new Menu();
            menu.AlterarStatusSubcategoria();
            Assert.NotNull(menu);
        }
        [Fact]
        public void TestarListarSubcategorias()
        {
            var menu = new Menu();
            menu.ListarSubcategorias();
            Assert.NotNull(menu);
        }
    }
}
