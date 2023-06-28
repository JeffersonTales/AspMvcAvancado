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
    public class FornecedoresController : Controller {

        //#region Atributos
        //private readonly IFornecedorService _fornecedorService;
        //#endregion


        //#region Construtor
        //public FornecedoresController() {
        //    this._fornecedorService = new FornecedorService(fornecedorRepository: new FornecedorRepository(), 
        //                                                    enderecoRepository: new EnderecoRepository());
        //}
        //#endregion

        //// GET: Fornecedores
        //public async Task<ActionResult> Index() {

        //    var fornecedor = new Fornecedor() {
        //        Nome = "",
        //        Documento = "11111",
        //        Endereco = new Endereco(),
        //        TipoFornecedor = TipoFornecedor.PessoaFisica,
        //        Ativo = true
        //    };

        //    await this._fornecedorService.Adicionar(fornecedor);

        //    return new EmptyResult();
        //}
    }
}