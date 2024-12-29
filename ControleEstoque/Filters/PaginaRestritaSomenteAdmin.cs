using ControleEstoque.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace ControleEstoque.Filters
{
    public class PaginaRestritaSomenteAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string sessaoUsuario = context.HttpContext.Session.GetString("sessaoUsuarioLogado");

            //Se o objeto for nulo ou vazio ele vai para a controller Login e o campo Index
            if(string.IsNullOrEmpty(sessaoUsuario) )
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { {"controller", "Login" }, {"action", "Index" } });
            }

            // se o objeto não for nulo, mas mesmo assim ele não conseguiu serializar o objeto usuario, ele volta para a controller Login e campo Index
            else
            {
                UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);

                if(usuario == null )
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                }

                // Função que faz que faz o admin visualizar os usuários
                if(usuario.Perfil != Enums.PerfilEnum.Admin)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Restrito" }, { "action", "Index" } });
                }
            }

            base.OnActionExecuted(context);
        }
    }
}
