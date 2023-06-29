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

        public FornecedoresController(IFornecedorRepository fornecedorRepository, 
                                      IFornecedorService fornecedorService, 
                                      IMapper mapper) {

            this._fornecedorRepository = fornecedorRepository;
            this._fornecedorService = fornecedorService;
            this._mapper = mapper;
        }
        #endregion

        #region Metodos

        [Route(template:"lista-de-fornecedores")]
        public async Task<ActionResult> Index() {

            return View(this._mapper.Map<IEnumerable<FornecedorViewModel>>(await this._fornecedorRepository.ObterTodos()));

        }

        private async Task<FornecedorViewModel> ObterFornecedorEndereco(Guid id) {

            return this._mapper.Map<FornecedorViewModel>(await this._fornecedorRepository.ObterFornecedorEndereco(id)); 
        
        }

        //07:25
        private async Task<FornecedorViewModel> ObterFornecedorProdutosEndereco(Guid id) {

            return this._mapper.Map<FornecedorViewModel>(await this._fornecedorRepository.ObterFornecedorProdutosEndereco(id));
        }

        #endregion

    }
}