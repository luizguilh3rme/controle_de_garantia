using ControleEstoque.Filters;
using ControleEstoque.Models;
using ControleEstoque.Repositorio;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace ControleEstoque.Controllers
{
    //Função para ativar o filtro e diferenciar se é um usuario padrão ou admin e colocar suas restrições
    [PaginaParaUsuarioLogado]
    public class OnuIntelbrasController : Controller
    {
        private readonly IOnuIntelbrasRepositorio _onuintelbrasRepositorio;
        public OnuIntelbrasController(IOnuIntelbrasRepositorio onuintelbrasRepositorio)
        {
            _onuintelbrasRepositorio = onuintelbrasRepositorio;
        }
        public IActionResult Index()
        {
            List<OnuIntelbrasModel> OnuIntelbrass = _onuintelbrasRepositorio.Buscartodos();
            return View(OnuIntelbrass);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            OnuIntelbrasModel onuintelbras= _onuintelbrasRepositorio.ListarPorId(id);
            return View(onuintelbras);
        }

        public IActionResult detalhes(int id)
        {
            OnuIntelbrasModel onuIntelbras= _onuintelbrasRepositorio.ListarPorId(id);
            return View(onuIntelbras);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            OnuIntelbrasModel onuIntelbras= _onuintelbrasRepositorio.ListarPorId(id);
            return View(onuIntelbras);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                //Chamando o método Apagar da OntRepositorio
                bool apagado = _onuintelbrasRepositorio.Apagar(id);

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
        public IActionResult Criar(OnuIntelbrasModel onuIntelbras)
        {
            //Chamando o método Adicionar da OnuIntelbrasRepositorio

            try
            {
                if (ModelState.IsValid)
                {
                    _onuintelbrasRepositorio.Adicionar(onuIntelbras);
                    TempData["MensagemSucesso"] = "Produto cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(onuIntelbras);
            }
            catch (Exception erro) 
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu produto, tente novamente, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
         
        }

        [HttpPost]
        public IActionResult Alterar(OnuIntelbrasModel onuintelbras)
        {

            try
            {
                //Chamando o método Atualizar da OntRepositorio
                if (ModelState.IsValid)
                {
                    _onuintelbrasRepositorio.Atualizar(onuintelbras);
                    TempData["MensagemSucesso"] = "Produto alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                //Comando para forçar o return view cair na view de editar, porque não existe uma view com o nome Alterar, existe com o nome Editar
                return View("Editar", onuintelbras);
            }
            catch (Exception erro) 
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos editar seu produto, tente novamente, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
}
}
