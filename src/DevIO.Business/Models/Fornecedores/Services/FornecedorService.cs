using DevIO.Business.Core.Notificacoes;
using DevIO.Business.Core.Services;
using DevIO.Business.Models.Fornecedores.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Models.Fornecedores.Services {

    public class FornecedorService : BaseService, IFornecedorService {

        #region Atributos
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        #endregion

        #region Construtor
        public FornecedorService(IFornecedorRepository fornecedorRepository, 
                                 IEnderecoRepository enderecoRepository, 
                                 INotificador notificador) : base(notificador: notificador) {

            this._fornecedorRepository = fornecedorRepository;
            this._enderecoRepository = enderecoRepository;
        }
        #endregion

        #region Metodos de Contrato
        public async Task Adicionar(Fornecedor fornecedor) {

            if (!this.ExecutarValidacao(validacao: new FornecedorValidation(), entidade: fornecedor) ||
                !this.ExecutarValidacao(validacao: new EnderecoValidation(), entidade: fornecedor.Endereco)) {
                return;
            }

            if (await this.FornecedorExistente(fornecedor)) return;

            await this._fornecedorRepository.Adicionar(fornecedor);

        }

        public async Task Atualizar(Fornecedor fornecedor) {

            if (!this.ExecutarValidacao(validacao: new FornecedorValidation(), entidade: fornecedor)) return;

            if (await this.FornecedorExistente(fornecedor)) return;

            await this._fornecedorRepository.Atualizar(fornecedor);
        }

        public async Task Remover(Guid id) {

            var fornecedor = await this._fornecedorRepository.ObterFornecedorProdutosEndereco(id);

            if (fornecedor.Produtos.Any()) {
                this.Notificar(mensagem:"O fornecedor possui produtos cadastrados!");
                return; //se o fornecedor tiver produtos (retorna) -não pode remover.
            }

            if (fornecedor.Endereco != null) {
                await this._enderecoRepository.Remover(id: fornecedor.Endereco.Id);
            }

            await this._fornecedorRepository.Remover(id: id);   

        }

        public async Task AtualizarEndereco(Endereco endereco) {

            if (!this.ExecutarValidacao(validacao: new EnderecoValidation(), entidade: endereco)) return;

            await this._enderecoRepository.Atualizar(endereco);

        }

        public void Dispose() {
            this._fornecedorRepository?.Dispose();
            this._enderecoRepository?.Dispose();    
        }
        #endregion

        #region Metodos Auxiliares
        private async Task<bool> FornecedorExistente(Fornecedor fornecedor) {

            var fornecedorAtual = await this._fornecedorRepository.Buscar(predicate: f => f.Documento == fornecedor.Documento &&
                                                                                          f.Id != fornecedor.Id);

            if (!fornecedorAtual.Any()) return false;

            this.Notificar(mensagem: "Já existe um fornecedor com este documento informado.");

            return true;

        }
        #endregion

    }

}
