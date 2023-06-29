using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DevIO.AspMvc.Models;
using DevIO.AspMvc.ViewModels;
using DevIO.Business.Models.Produtos;
using DevIO.Business.Models.Produtos.Services;
using DevIO.Infra.Data.Repository;
using DevIO.Business.Core.Notificacoes;
using AutoMapper;

namespace DevIO.AspMvc.Controllers {
    public class ProdutosController : Controller {

        #region Propriedades
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoRepository produtoRepository, 
                                  IProdutoService produtoService, 
                                  IMapper mapper) {

            this._produtoRepository = produtoRepository;
            this._produtoService = produtoService;
            this._mapper = mapper;
        }
        #endregion

        #region Construtor

        #endregion

        #region Metodos

        [Route(template:"lista-de-produtos")]
        [HttpGet]
        public async Task<ActionResult> Index() {

            return View(model: this._mapper.Map<IEnumerable<ProdutoViewModel>>(await this._produtoRepository.ObterTodos()));

        }

        [Route(template:"dados-do-produto/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Details(Guid id) {

            var produtoViewModel = await this.ObterProduto(id);

            if (produtoViewModel == null) {
                return HttpNotFound();
            }

            return View(produtoViewModel);

        }

        [Route(template:"novo-produto")]
        [HttpGet]
        public ActionResult Create() {
            return View();
        }

        [Route(template:"novo-produto")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FornecedorId,Nome,Descricao,Imagem,Valor,DataCadastro,Ativo")] ProdutoViewModel produtoViewModel) {

            if (ModelState.IsValid) {

                await this._produtoService.Adicionar(produto: this._mapper.Map<Produto>(produtoViewModel));

                return RedirectToAction("Index");
            }

            return View(produtoViewModel);
        }

        [Route(template: "editar-produto/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Edit(Guid id) {

            var produtoViewModel = await this.ObterProduto(id: id);
            if (produtoViewModel == null) {
                return HttpNotFound();
            }
            return View(produtoViewModel);
        }

        [Route(template: "editar-produto/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProdutoViewModel produtoViewModel) {

            if (ModelState.IsValid) {

                await this._produtoService.Atualizar(produto: this._mapper.Map<Produto>(produtoViewModel));

                return RedirectToAction("Index");
            }

            return View(produtoViewModel);

        }

        [Route(template:"excluir-produto/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Delete(Guid id) {

            var produtoViewModel = await this.ObterProduto(id: id);
            if (produtoViewModel == null) {
                return HttpNotFound();
            }
            return View(produtoViewModel);
        }

        [Route(template: "excluir-produto/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id) {

            var produtoViewModel = await this.ObterProduto(id: id);

            if (produtoViewModel == null) {
                return HttpNotFound();
            }

            await this._produtoService.Remover(id: id);
            return RedirectToAction("Index");

        }

        private async Task<ProdutoViewModel> ObterProduto(Guid id) {

            var produto = this._mapper.Map<ProdutoViewModel>(await this._produtoRepository.ObterProdutosPorFornecedor(id));
            return produto;
        }

        protected override void Dispose(bool disposing) {

            if (disposing) {
                this._produtoRepository.Dispose();
                this._produtoService.Dispose();
            }

            base.Dispose(disposing);
        }
        #endregion

    }
}
