using ControleEstoque.Models;
using ControleEstoque.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.Buscartodos();
            return View(usuarios);
           
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult detalhes(int id)
        {
            UsuarioModel ont = _usuarioRepositorio.ListarPorId(id);
            return View(ont);
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            //Chamando o método Adicionar da OntRepositorio

            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu usuario, tente novamente, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}
