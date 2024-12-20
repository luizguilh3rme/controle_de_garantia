using ControleEstoque.Models;

namespace ControleEstoque.Repositorio
{
    public interface IOnuIntelbrasRepositorio
    {
        OnuIntelbrasModel ListarPorId(int id);
        List<OnuIntelbrasModel> Buscartodos();
        OnuIntelbrasModel Adicionar(OnuIntelbrasModel onuintelbras);
        OnuIntelbrasModel Atualizar(OnuIntelbrasModel onuintelbras);
        bool Apagar(int id);
    }
}
