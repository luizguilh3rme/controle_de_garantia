using ControleEstoque.Data;
using ControleEstoque.Models;
using static System.Net.Mime.MediaTypeNames;

namespace ControleEstoque.Repositorio
{
    public class W5Repositorio : IW5Repositorio
    {
        private readonly BancoContext _context;
        public W5Repositorio(BancoContext bancoContext) 
        {
            this._context = bancoContext;
        }

        //Listar ID para editação de produtos
        public W5Model ListarPorId(int id)
        {
            return _context.W5.FirstOrDefault( x => x.Id == id);
        }

        // Chama tudo que esta no banco de dados na tabela ONTs
        public List<W5Model> Buscartodos()
        {
            return _context.W5.ToList();
        }

        //Método para adicionar no banco de dados
        public W5Model Adicionar(W5Model w5)
        {
            w5.DataCadastro = DateTime.Now;
            // Gravar no banco de dados
            _context.W5.Add(w5);
            _context.SaveChanges();

            return w5;
        }

        //Método para editar no banco de dados
        public W5Model Atualizar(W5Model w5)
        {
            //Captura o ID ao editar o item selecionado
            W5Model w5DB = ListarPorId(w5.Id);

            //Se o ID do produto for inexistente dará esse erro
            if (w5DB == null) throw new Exception("Houve um erro na atualização do produto");

            //Chamado os dados a serem editados
            w5DB.Nome = w5.Nome;
            w5DB.Mac = w5.Mac;
            w5DB.NumeroSerie = w5.NumeroSerie;

            //Atualizar e salva os dados no banco de dados
            _context.W5.Update(w5DB);
            _context.SaveChanges();

            return w5DB;
        }

        public bool Apagar(int id)
        {
            //Captura o ID ao apagar o item selecionado
            W5Model w5DB = ListarPorId(id);

            //Se o ID do produto for inexistente dará esse erro
            if (w5DB == null) throw new Exception("Houve um erro na deleção do produto");

            //Remove e salva os dados no banco de dados
            _context.W5.Remove(w5DB);
            _context.SaveChanges();

            return true;
        }

        
    }
}
