using ControleEstoque.Data;
using ControleEstoque.Models;
using static System.Net.Mime.MediaTypeNames;

namespace ControleEstoque.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _context;
        public UsuarioRepositorio(BancoContext bancoContext) 
        {
            this._context = bancoContext;
        }

        // Verifica se o login digitado pelo usuario é IGUAL ao do banco de dados
        public UsuarioModel BuscarPorLogin(string login)
        {
            //ToUpper  vai transformar o Login em letra maiuscula ao digita-lo
            return _context.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public UsuarioModel BuscarPorEmailELogin(string email, string login)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());
        }

        //Listar ID para editação de produtos
        public UsuarioModel ListarPorId(int id)
        {
            return _context.Usuarios.FirstOrDefault( x => x.Id == id);
        }

        // Chama tudo que esta no banco de dados na tabela ONTs
        public List<UsuarioModel> Buscartodos()
        {
            return _context.Usuarios.ToList();
        }

        //Método para adicionar no banco de dados
        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            usuario.SetSenhaHash();
            // Gravar no banco de dados
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return usuario;
        }

        //Método para editar no banco de dados
        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            //Captura o ID ao editar o item selecionado
            UsuarioModel usuarioDB = ListarPorId(usuario.Id);

            //Se o ID do produto for inexistente dará esse erro
            if (usuarioDB == null) throw new Exception("Houve um erro na atualização do usuario");

            //Chamado os dados a serem editados
            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataAtualizacao = DateTime.Now;

            //Atualizar e salva os dados no banco de dados
            _context.Usuarios.Update(usuarioDB);
            _context.SaveChanges();

            return usuarioDB;
        }

        public UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel)
        {
            UsuarioModel usuarioDB = ListarPorId(alterarSenhaModel.Id);

            if (usuarioDB == null) throw new Exception("Houve um erro na atualização da senha, usuário não encontrado!");

            if (!usuarioDB.SenhaValida(alterarSenhaModel.SenhaAtual)) throw new Exception("Senha atual não confere!");

            if (usuarioDB.SenhaValida(alterarSenhaModel.NovaSenha)) throw new Exception("Nova senha deve ser diferente da senha atual!");

            usuarioDB.SetNovaSenha(alterarSenhaModel.NovaSenha);
            usuarioDB.DataAtualizacao = DateTime.Now;

            _context.Usuarios.Update(usuarioDB);
            _context.SaveChanges();

            return usuarioDB;
        }

        public bool Apagar(int id)
        {
            //Captura o ID ao apagar o item selecionado
            UsuarioModel usuarioDB = ListarPorId(id);

            //Se o ID do produto for inexistente dará esse erro
            if (usuarioDB == null) throw new Exception("Houve um erro na deleção do usuario");

            //Remove e salva os dados no banco de dados
            _context.Usuarios.Remove(usuarioDB);
            _context.SaveChanges();

            return true;
        }

       
    }
}
