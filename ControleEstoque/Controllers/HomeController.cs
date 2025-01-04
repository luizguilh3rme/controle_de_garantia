using System.Diagnostics;
using ControleEstoque.Filters;
using ControleEstoque.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Controllers
{
    //Função para ativar o filtro e diferenciar se é um usuario padrão ou admin e colocar suas restrições
    [PaginaParaUsuarioLogado]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            HomeModel home = new HomeModel();

            //home.Nome = "Guilherme";
            //home.Email = "guilherme@gmail.com";

            return View(home);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
