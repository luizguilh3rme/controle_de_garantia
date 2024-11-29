using ControleEstoque.Models;
using ControleEstoque.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Controllers
{
    public class OntController : Controller
    {
        private readonly IOntRepositorio _ontRepositorio;
        public OntController(IOntRepositorio ontRepositorio)
        {
            _ontRepositorio = ontRepositorio;
        }
        public IActionResult Index()
        {
            List<OntModel> onts = _ontRepositorio.Buscartodos();
            return View(onts);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            OntModel ont = _ontRepositorio.ListarPorId(id);
            return View(ont);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            OntModel ont = _ontRepositorio.ListarPorId(id);
            return View(ont);
        }

        public IActionResult Apagar(int id)
        {
            //Chamando o método Apagar da OntRepositorio
            _ontRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(OntModel ont)
        {
            //Chamando o método Adicionar da OntRepositorio
            _ontRepositorio.Adicionar(ont);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(OntModel ont)
        {
            //Chamando o método Atualizar da OntRepositorio
            _ontRepositorio.Atualizar(ont);
            return RedirectToAction("Index");
        }
    }
}
