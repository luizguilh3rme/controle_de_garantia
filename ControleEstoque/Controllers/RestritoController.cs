using ControleEstoque.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Controllers
{
    [PaginaParaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
