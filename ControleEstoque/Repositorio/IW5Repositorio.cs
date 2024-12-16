using ControleEstoque.Models;

namespace ControleEstoque.Repositorio
{
    public interface IW5Repositorio
    {
        W5Model ListarPorId(int id);
        List<W5Model> Buscartodos();
        W5Model Adicionar(W5Model w5);
        W5Model Atualizar(W5Model w5);
        bool Apagar(int id);
    }
}
