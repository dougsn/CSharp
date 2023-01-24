using Microsoft.AspNetCore.Mvc;
using DevIO.App.ViewModels;
using DevIO.Business.Inferfaces;
using AutoMapper;
using AppMvcBasica.Models;
using Microsoft.AspNetCore.Authorization;
using static DevIO.App.Extensions.CustomAuthorize;

namespace DevIO.App.Controllers
{
    [Authorize]
    public class ProdutosController : BaseController
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoRepository produtoRepository, IMapper mapper, IFornecedorRepository fornecedorRepository, IProdutoService produtoService, INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
            _fornecedorRepository = fornecedorRepository;
            _produtoService = produtoService;
        }
        // GET: Produtos
        [Route("lista-de-produtos")]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            // Retornando uma lista de produto, com seu devido fornecedor (possivel por conta do mapeamento)
            return View(_mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterProdutosFornecedores()));
        }

        // GET: Produtos/Details/5
        [Route("dados-do-produto/{id:guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid id)
        {

            var produtoViewModel = await ObterProduto(id);

            if (produtoViewModel == null)
            {
                return NotFound();
            }

            return View(produtoViewModel);
        }

        // GET: Produtos/Create
        [Route("novo-produto")]
        [ClaimsAuthorize("Produto","Adicionar")]
        public async Task<IActionResult> Create()
        {            
            var produtoViewModel = await PopularFornecedores(new ProdutoViewModel());
            
            return View(produtoViewModel);
        }

        // POST: Produtos/Create
        [ClaimsAuthorize("Produto", "Adicionar")]
        [Route("novo-produto")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel produtoViewModel)
        {
            // Populando os Fornecedores com o que veio do objeto da VIEW
            produtoViewModel = await PopularFornecedores(produtoViewModel);
            
            // Verificando se o Objeto é nulo
            if (!ModelState.IsValid) return View(produtoViewModel);


            // Realizando o Upload da Imagem
            var imgPrefixo = Guid.NewGuid() + "_";
            if (!await UploadArquivo(produtoViewModel.ImagemUpload, imgPrefixo))
            {
                return View(produtoViewModel); 
            }

            // Populando a propriedade Imagem (que é populado no banco) com os dados do ImagemUpload tratado.
            produtoViewModel.Imagem = imgPrefixo + produtoViewModel.ImagemUpload.FileName;

            // Mapeando o Produto com o Modelo e persistindo na base de dados.
            await _produtoService.Adicionar(_mapper.Map<Produto>(produtoViewModel));

            if (!OperacaoValida()) return View(produtoViewModel);

            return RedirectToAction("Index");
        }

        // GET: Produtos/Edit/5
        [ClaimsAuthorize("Produto", "Editar")]
        [Route("editar-produto/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {

            // Pegando o Objeto pelo ID e verificando se é nulo, se não for, entregue uma VIEW com os dados do Objeto
            var produtoViewModel = await ObterProduto(id);
            if (produtoViewModel == null)
            {
                return NotFound();
            }
            

            return View(produtoViewModel);
        }

        // POST: Produtos/Edit/5
        [ClaimsAuthorize("Produto", "Editar")]
        [Route("editar-produto/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProdutoViewModel produtoViewModel)
        {
            // Verificando se o ID do objeto é igual ao que foi passado por parâmetro
            if (id != produtoViewModel.Id) return NotFound();


            // Indo no Banco para poder pegar o Produto com as informações completas e populando o objeto do formulario e vice e versa
            var produtoAtualizacao = await ObterProduto(id);
            produtoViewModel.Fornecedor = produtoAtualizacao.Fornecedor;
            produtoViewModel.Imagem = produtoAtualizacao.Imagem;

             // Verificando se o objeto é valido ou não
            if (!ModelState.IsValid) return View(produtoViewModel);

            // Atualizando a imagem
            if (produtoViewModel.ImagemUpload != null)
            {
                var imgPrefixo = Guid.NewGuid() + "_";
                if (!await UploadArquivo(produtoViewModel.ImagemUpload, imgPrefixo))
                {
                    return View(produtoViewModel);
                }
                produtoAtualizacao.Imagem = imgPrefixo + produtoViewModel.ImagemUpload.FileName;
            }

            // Realizando a Edição de Forma segura
            produtoAtualizacao.Nome = produtoViewModel.Nome;
            produtoAtualizacao.Descricao = produtoViewModel.Descricao;
            produtoAtualizacao.Valor = produtoViewModel.Valor;
            produtoAtualizacao.Ativo = produtoViewModel.Ativo;


            // Mapeando a model, para persistir na base de dados o objeto pego na VIEW / Atualizado
            await _produtoService.Atualizar(_mapper.Map<Produto>(produtoAtualizacao));

            if (!OperacaoValida()) return View(produtoViewModel);

            return RedirectToAction("Index");
        }

        // GET: Produtos/Delete/5
        [ClaimsAuthorize("Produto", "Excluir")]
        [Route("excluir-produto/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            // Buscando o produto Pelo ID e redirecionando para a página de exclusão
            var produto = await ObterProduto(id);
            if (produto == null)
            {
                return NotFound();
            }


            return View(produto);
        }

        // POST: Produtos/Delete/5
        [ClaimsAuthorize("Produto", "Excluir")]
        [Route("excluir-produto/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            // Obtendo o produto pelo ID, para verificar se é nulo
            var produto = await ObterProduto(id);
            if (produto == null)
            {
                return NotFound();
            }
            // Se não for nulo, remova da base de dados.
            await _produtoService.Remover(id);

            if (!OperacaoValida()) return View(produto);

            TempData["Sucesso"] = "Produto excluido com sucesso!";

            return RedirectToAction("Index");
        }

        private async Task<ProdutoViewModel> ObterProduto(Guid id)
        {
            // Mapeando um Produtoviewmodel, atraves do produtoFornecedor
            var produto = _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterProdutoFornecedor(id));

            // Mapeando uma lista de Fornecedores, busccando essas lista no repositório do Fornecedor.
            produto.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
            return produto;
        }

        private async Task<ProdutoViewModel> PopularFornecedores(ProdutoViewModel produto)
        {           

            // A partir de qualquer view model que seja passada, é populado os fornecedores naquela viewmodel
            produto.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
            return produto;
        }

        // Metodo responsavel por realizar as verificações do upload da imagem.
        private async Task<bool> UploadArquivo(IFormFile arquivo, string imgPrefixo)
        {
            if (arquivo.Length <= 0) return false;

            // Criando o path para o upload da imagem
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", imgPrefixo + arquivo.FileName);

            // Verificando se o nome da existe
            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Já existe um arquivo com este nome!");
                return false;
            }

            // Efetivando o Upload da imagem com o FileStream
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            return true;

        }
    }
}
