using DevIO.Business.Models.Fornecedores;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DevIO.Infra.Data.Repository {

    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository {

        #region Metodos de Contrato
        public async Task<Fornecedor> ObterFornecedorEndereco(Guid Id) {
            return await this.Db.Fornecedores
                .AsNoTracking()
                .Include(f => f.Endereco)
                .FirstOrDefaultAsync(f => f.Id == Id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid Id) {
            return await this.Db.Fornecedores
               .AsNoTracking()
               .Include(f => f.Endereco)
               .Include(f => f.Produtos)
               .FirstOrDefaultAsync(f => f.Id == Id);
        }
        #endregion

    }
}
