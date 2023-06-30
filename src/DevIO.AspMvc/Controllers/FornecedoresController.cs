using AutoMapper;
using DevIO.AspMvc.ViewModels;
using DevIO.Business.Models.Fornecedores;
using DevIO.Business.Models.Fornecedores.Services;
using DevIO.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DevIO.AspMvc.Controllers {

    public class FornecedoresController : BaseController {

        #region Atributos
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IFornecedorService _fornecedorService;
        private readonly IMapper _mapper;
        #endregion

        #region Construtor
        public FornecedoresController(IFornecedorRepository fornecedorRepository,
                                      IFornecedorService fornecedorService,
                                      IMapper mapper) {

            this._fornecedorRepository = fornecedorRepository;
            this._fornecedorService = fornecedorService;
            this._mapper = mapper;
        }
        #endregion

        #region Metodos

        [Route(template: "lista-de-fornecedores")]
        public async Task<ActionResult> Index() {

            return View(this._mapper.Map<IEnumerable<FornecedorViewModel>>(await this._fornecedorRepository.ObterTodos()));

        }

        [Route(template: "editar-fornecedor/{id:guid}")]
        public async Task<ActionResult> Edit(Guid id) {

            var fornecedorViewModel = await ObterFornecedorProdutosEndereco(id);

            if (fornecedorViewModel == null) return HttpNotFound();

            return View(model: fornecedorViewModel);

        }

        [Route(template:"dados-do-fornecedor/{id:guid}")]
        public async Task<ActionResult> Details(Guid id) {

            var fornecedorViewModel = await ObterFornecedorEndereco(id);

            if (fornecedorViewModel == null) return HttpNotFound();

            return View(model: fornecedorViewModel);

        }

        [Route(template: "novo-fornecedor")]
        public ActionResult Create() {
            return View();
        }

        [Route(template:"novo-fornecedor")]
        [HttpPost]
        public async Task<ActionResult> Create(FornecedorViewModel fornecedorViewModel) {

            if (!this.ModelState.IsValid) return View(model: fornecedorViewModel);

            var fornecedor = this._mapper.Map<Fornecedor>(fornecedorViewModel);

            await this._fornecedorService.Adicionar(fornecedor);


            //TODO: posteriormente fazer tratamento para notificar o usuário quando a inclusão não for bem sucedida.
            return RedirectToAction("Index");   

        }

        [Route(template: "editar-fornecedor/{id:guid}")]
        [HttpPost]
        public async Task<ActionResult> Edit(Guid id,
                                             FornecedorViewModel fornecedorViewModel) {

            if (id != fornecedorViewModel.Id) return HttpNotFound();

            if (!this.ModelState.IsValid) return View(model: fornecedorViewModel);

            var fornecedor = this._mapper.Map<Fornecedor>(fornecedorViewModel);

            await this._fornecedorService.Atualizar(fornecedor);

            //TODO: posteriormente fazer tratamento para notificar o usuário quando a alteração não for bem sucedida.
            return RedirectToAction(actionName: "Index");   
        }

        [Route(template: "excluir-fornecedor/id{id:guid}")]
        public async Task<ActionResult> Delete(Guid id) {

            var fornecedorViewModel = await ObterFornecedorEndereco(id);

            if(fornecedorViewModel == null) return HttpNotFound();

            //TODO: posteriormente fazer tratamento para notificar o usuário quando a exclusão não for bem sucedida.
            return View(fornecedorViewModel);
        }

        [Route(template: "excluir-fornecedor/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(Guid id) {

            var fornecedor = await ObterFornecedorEndereco(id);

            if(fornecedor == null) return HttpNotFound();

            await this._fornecedorService.Remover(id);

            return RedirectToAction(actionName: "Index");
        }

        private async Task<FornecedorViewModel> ObterFornecedorEndereco(Guid id) {

            return this._mapper.Map<FornecedorViewModel>(await this._fornecedorRepository.ObterFornecedorEndereco(id));

        }

        private async Task<FornecedorViewModel> ObterFornecedorProdutosEndereco(Guid id) {

            return this._mapper.Map<FornecedorViewModel>(await this._fornecedorRepository.ObterFornecedorProdutosEndereco(id));
        }

        #endregion

    }
}