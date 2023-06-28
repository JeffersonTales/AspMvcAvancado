using DevIO.Business.Core.Notificacoes;
using DevIO.Business.Core.Services;
using DevIO.Business.Models.Produtos.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Models.Produtos.Services {

    public class ProdutoService : BaseService, IProdutoService {

        #region Atributos
        private readonly IProdutoRepository _produtoRepository;
        #endregion

        #region Construtor
        public ProdutoService(IProdutoRepository produtoRepository, 
                              INotificador notificador) : base(notificador: notificador) {
            this._produtoRepository = produtoRepository;
        }
        #endregion

        #region Metodos de Contrato
        public async Task Adicionar(Produto produto) {
            
            if (!this.ExecutarValidacao(validacao: new ProdutoValidation(), entidade: produto)) return;

            await this._produtoRepository.Adicionar(produto);
        }
        
        public async Task Atualizar(Produto produto) {
            if (!this.ExecutarValidacao(validacao: new ProdutoValidation(), entidade: produto)) return;

            await this._produtoRepository.Atualizar(produto);
        }

        public async Task Remover(Guid id) {

            await this._produtoRepository.Remover(id);
        }

        public void Dispose() {
            this._produtoRepository?.Dispose();
        }
        #endregion

    }
}
