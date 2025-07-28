using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;

namespace WebApplicationST.Extensions
{
    //Quais elementos HTML o TagHelper pode ser aplicado | parametros de eentrada
    [HtmlTargetElement("*", Attributes = "ctype-button, croute-id")]
    public class ButtonTagHelper : TagHelper
    {
        //inserindo correção de geração de links
        private readonly LinkGenerator _linkGenerator;

        //injetar o contexto para controller na rota
        private readonly IHttpContextAccessor _accessor;

        //Injetando o contexto para controller na rota
        //Será colocado na injessão da program.cs
        //builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        public ButtonTagHelper(IHttpContextAccessor accessor, LinkGenerator linkGenerator)
        {
            _accessor = accessor;
            _linkGenerator = linkGenerator;
        }

        //Nome do tipo do botão pelo enum
        [HtmlAttributeName("ctype-button")]
        public ButtonType TypeButtonSelect { get; set; }

        //Nome da rota
        [HtmlAttributeName("croute-id")]
        public string RouteId { get; set; }

        private string nomeAction;
        private string nomeClasse;
        private string spamIcone;
        private string titleIcon;

        //Definir como o output irá funcionar
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //Definir o nome da ação, a classe e o icone do botão
            switch (TypeButtonSelect)
            {
                case ButtonType.Detalhes:
                    nomeAction = "Details";
                    nomeClasse = "btn btn-info";
                    spamIcone = "fa fa-search";
                    titleIcon = "Detalhes do registro";
                    break;
                case ButtonType.Editar:
                    nomeAction = "Edit";
                    nomeClasse = "btn btn-warning";
                    spamIcone = "fa fa-pencil-alt";
                    titleIcon = "Atualizar registro";
                    break;
                case ButtonType.Remover:
                    nomeAction = "Delete";
                    nomeClasse = "btn btn-danger";
                    spamIcone = "fa fa-trash";
                    titleIcon = "Remover registro";
                    break;
                case ButtonType.Novo:
                    nomeAction = "Create";
                    nomeClasse = "btn btn-dark";
                    spamIcone = "fa fa-plus";
                    titleIcon = "Novo registro";
                    break;
            }

            //injetar controller - Pega dados da rota de acordo com a controller
            var controller = _accessor.HttpContext?.GetRouteData().Values["controller"]?.ToString();

            //Variavel para gerar link para correção da criação manual
            var indexPath = _linkGenerator.GetPathByAction(
                _accessor.HttpContext, 
                nomeAction, 
                controller, 
                values: new { id = RouteId }!);

            var host = $"{_accessor.HttpContext.Request.Scheme}://{_accessor.HttpContext.Request.Host.Value}";

            //Criação de um botão
            output.TagName = "a";
            output.Attributes.SetAttribute("href", $"{host}{indexPath}");
            output.Attributes.SetAttribute("class", nomeClasse);
            output.Attributes.SetAttribute("title", titleIcon);

            //Criação de um spam com a imagem do fontawesome
            var iconSpam = new TagBuilder("spam");
            iconSpam.AddCssClass(spamIcone);

            //inserir o spam no botão no html
            output.Content.AppendHtml(iconSpam);
        }

    }

    //Para encontar o tipo da tag por uma sequencia de ids
    public enum ButtonType
    {
        Detalhes,
        Editar,
        Remover,
        Novo
    }
}
