using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Net.Mime;

namespace AppModelo.Extensions
{
    // Foi chamado no Layout a tag <email></email>, ele já é reconhecida automaticamente, por conta da convensão dessa classe, Email (tag).
    public class EmailTagHelper : TagHelper
    {
        public string EmailDomain { get; set; } = "desenvolvedor.io"; // Esse atributo foi passado como email-domain = "", para se passado como parametro.
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a"; // Especificando a saída HTML , <a></a>
            var content = await output.GetChildContentAsync(); // Pegando o conteudo do taghelper
            var target = content.GetContent() + "@" + EmailDomain; // acrescentado o dominio
            output.Attributes.SetAttribute("href", "mailto:" + target); // Colocando os atributos
            output.Content.SetContent(target); // Colocando na página
        }
    }
}
