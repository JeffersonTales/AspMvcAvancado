﻿using DevIO.Business.Models.Fornecedores;
using DevIO.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Infra.Data.Repository {
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository {

        #region Construtor
        public EnderecoRepository(MeuDbContext context) : base(db: context) {}
        #endregion

        #region Metodos de Contrato
        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId) {
            return await this.ObterPorId(fornecedorId);
        }
        #endregion
    }
}
