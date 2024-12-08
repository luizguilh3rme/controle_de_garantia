using ControleEstoque.Models;
using ControleEstoque.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IOntRepositorio _ontRepositorio;
        public UsuarioController(IOntRepositorio ontRepositorio)
        {
            _ontRepositorio = ontRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult detalhes(int id)
        {
            OntModel ont = _ontRepositorio.ListarPorId(id);
            return View(ont);
        }
    }
}
