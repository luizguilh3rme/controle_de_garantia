using ControleEstoque.Data;
using ControleEstoque.Models;
using static System.Net.Mime.MediaTypeNames;

namespace ControleEstoque.Repositorio
{
    public class OnuIntelbrasRepositorio : IOnuIntelbrasRepositorio
    {
        private readonly BancoContext _context;
        public OnuIntelbrasRepositorio(BancoContext bancoContext) 
        {
            this._context = bancoContext;
        }

        //Listar ID para editação de produtos
        public OnuIntelbrasModel ListarPorId(int id)
        {
            return _context.OnuIntelbras.FirstOrDefault( x => x.Id == id);
        }

        // Chama tudo que esta no banco de dados na tabela ONTs
        public List<OnuIntelbrasModel> Buscartodos()
        {
            return _context.OnuIntelbras.ToList();
        }

        //Método para adicionar no banco de dados
        public OnuIntelbrasModel Adicionar(OnuIntelbrasModel onuintelbras)
        {
            onuintelbras.DataCadastro = DateTime.Now;
            // Gravar no banco de dados
            _context.OnuIntelbras.Add(onuintelbras);
            _context.SaveChanges();

            return onuintelbras;
        }

        //Método para editar no banco de dados
        public OnuIntelbrasModel Atualizar(OnuIntelbrasModel onuintelbras)
        {
            //Captura o ID ao editar o item selecionado
            OnuIntelbrasModel onuintelbrasDB = ListarPorId(onuintelbras.Id);

            //Se o ID do produto for inexistente dará esse erro
            if (onuintelbrasDB == null) throw new Exception("Houve um erro na atualização do produto");

            //Chamado os dados a serem editados
            onuintelbrasDB.Nome = onuintelbras.Nome;
            onuintelbrasDB.Mac = onuintelbras.Mac;
            onuintelbrasDB.NumeroSerie = onuintelbras.NumeroSerie;

            //Atualizar e salva os dados no banco de dados
            _context.OnuIntelbras.Update(onuintelbrasDB);
            _context.SaveChanges();

            return onuintelbrasDB;
        }

        public bool Apagar(int id)
        {
            //Captura o ID ao apagar o item selecionado
            OnuIntelbrasModel onuintelbrasDB = ListarPorId(id);

            //Se o ID do produto for inexistente dará esse erro
            if (onuintelbrasDB == null) throw new Exception("Houve um erro na deleção do produto");

            //Remove e salva os dados no banco de dados
            _context.OnuIntelbras.Remove(onuintelbrasDB);
            _context.SaveChanges();

            return true;
        }

        
    }
}
