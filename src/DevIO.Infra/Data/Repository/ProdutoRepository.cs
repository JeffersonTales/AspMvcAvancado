using DevIO.Business.Models.Produtos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Infra.Data.Repository {
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository {

        #region Metodos de Contrato
        public async Task<Produto> ObterProdutoFornecedor(Guid id) {
            return await this.Db.Produtos
                .AsNoTracking()
                .Include(p=>p.Fornecedor)
                .FirstOrDefaultAsync(p=>p.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores() {
            return await this.Db.Produtos
                .AsNoTracking()
                .Include(p=>p.Fornecedor)
                .OrderBy(p=>p.Nome)
                .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId) {
            return await this.Buscar(p=>p.FornecedorId == fornecedorId);
        }
        #endregion

    }
}
