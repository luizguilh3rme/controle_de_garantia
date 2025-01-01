using ControleEstoque.Models;

namespace ControleEstoque.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel BuscarPorLogin(string login);
        UsuarioModel BuscarPorEmailELogin(string email, string login);
        UsuarioModel ListarPorId(int id);
        List<UsuarioModel> Buscartodos();
        UsuarioModel Adicionar(UsuarioModel ont);
        UsuarioModel Atualizar(UsuarioModel ont);
        bool Apagar(int id);
    }
}
