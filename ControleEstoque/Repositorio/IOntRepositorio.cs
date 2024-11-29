using ControleEstoque.Models;

namespace ControleEstoque.Repositorio
{
    public interface IOntRepositorio
    {
        OntModel ListarPorId(int id);
        List<OntModel> Buscartodos();
        OntModel Adicionar(OntModel ont);
        OntModel Atualizar(OntModel ont);
        bool Apagar(int id);
    }
}
