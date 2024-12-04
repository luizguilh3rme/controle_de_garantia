using ControleEstoque.Models;
using ControleEstoque.Repositorio;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

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

        public IActionResult detalhes(int id)
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
            try
            {
                //Chamando o método Apagar da OntRepositorio
                bool apagado = _ontRepositorio.Apagar(id);

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
        public IActionResult Criar(OntModel ont)
        {
            //Chamando o método Adicionar da OntRepositorio

            try
            {
                if (ModelState.IsValid)
                {
                    _ontRepositorio.Adicionar(ont);
                    TempData["MensagemSucesso"] = "Produto cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(ont);
            }
            catch (Exception erro) 
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu produto, tente novamente, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
         
        }

        [HttpPost]
        public IActionResult Alterar(OntModel ont)
        {

            try
            {
                //Chamando o método Atualizar da OntRepositorio
                if (ModelState.IsValid)
                {
                    _ontRepositorio.Atualizar(ont);
                    TempData["MensagemSucesso"] = "Produto alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                //Comando para forçar o return view cair na view de editar, porque não existe uma view com o nome Alterar, existe com o nome Editar
                return View("Editar", ont);
            }
            catch (Exception erro) 
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos editar seu produto, tente novamente, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
}
}
