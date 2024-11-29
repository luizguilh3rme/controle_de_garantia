using ControleEstoque.Data;
using ControleEstoque.Models;
using static System.Net.Mime.MediaTypeNames;

namespace ControleEstoque.Repositorio
{
    public class OntRepositorio : IOntRepositorio
    {
        private readonly BancoContext _context;
        public OntRepositorio(BancoContext bancoContext) 
        {
            this._context = bancoContext;
        }

        //Listar ID para editação de produtos
        public OntModel ListarPorId(int id)
        {
            return _context.Onts.FirstOrDefault( x => x.Id == id);
        }

        // Chama tudo que esta no banco de dados na tabela ONTs
        public List<OntModel> Buscartodos()
        {
            return _context.Onts.ToList();
        }

        //Método para adicionar no banco de dados
        public OntModel Adicionar(OntModel ont)
        {
            // Gravar no banco de dados
            _context.Onts.Add(ont);
            _context.SaveChanges();

            return ont;
        }

        //Método para editar no banco de dados
        public OntModel Atualizar(OntModel ont)
        {
            //Captura o ID ao editar o item selecionado
            OntModel ontDB = ListarPorId(ont.Id);

            //Se o ID do produto for inexistente dará esse erro
            if (ontDB == null) throw new Exception("Houve um erro na atualização do produto");

            //Chamado os dados a serem editados
            ontDB.Nome = ont.Nome;
            ontDB.Mac = ont.Mac;
            ontDB.NumeroSerie = ont.NumeroSerie;

            //Atualizar e salva os dados no banco de dados
            _context.Onts.Update(ontDB);
            _context.SaveChanges();

            return ontDB;
        }

        public bool Apagar(int id)
        {
            //Captura o ID ao apagar o item selecionado
            OntModel ontDB = ListarPorId(id);

            //Se o ID do produto for inexistente dará esse erro
            if (ontDB == null) throw new Exception("Houve um erro na deleção do produto");

            //Remove e salva os dados no banco de dados
            _context.Onts.Remove(ontDB);
            _context.SaveChanges();

            return true;
        }
    }
}
