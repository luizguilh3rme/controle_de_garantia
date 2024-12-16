using ControleEstoque.Models;
using ControleEstoque.Repositorio;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace ControleEstoque.Controllers
{
    public class W5Controller : Controller
    {
        private readonly IW5Repositorio _w5Repositorio;
        public W5Controller(IW5Repositorio w5Repositorio)
        {
            _w5Repositorio = w5Repositorio;
        }
        public IActionResult Index()
        {
            List<W5Model> W5s = _w5Repositorio.Buscartodos();
            return View(W5s);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            W5Model w5= _w5Repositorio.ListarPorId(id);
            return View(w5);
        }

        public IActionResult detalhes(int id)
        {
            W5Model w5= _w5Repositorio.ListarPorId(id);
            return View(w5);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            W5Model w5= _w5Repositorio.ListarPorId(id);
            return View(w5);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                //Chamando o método Apagar da OntRepositorio
                bool apagado = _w5Repositorio.Apagar(id);

                if(apagado)
                {
                    TempData["MensagemSucesso"] = "Produto apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar seu produto!";
                }

                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu produto, mais detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(W5Model w5)
        {
            //Chamando o método Adicionar da OntRepositorio

            try
            {
                if (ModelState.IsValid)
                {
                    _w5Repositorio.Adicionar(w5);
                    TempData["MensagemSucesso"] = "Produto cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(w5);
            }
            catch (Exception erro) 
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu produto, tente novamente, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
         
        }

        [HttpPost]
        public IActionResult Alterar(W5Model w5)
        {

            try
            {
                //Chamando o método Atualizar da OntRepositorio
                if (ModelState.IsValid)
                {
                    _w5Repositorio.Atualizar(w5);
                    TempData["MensagemSucesso"] = "Produto alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                //Comando para forçar o return view cair na view de editar, porque não existe uma view com o nome Alterar, existe com o nome Editar
                return View("Editar", w5);
            }
            catch (Exception erro) 
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos editar seu produto, tente novamente, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
}
}
