using DevIO.Business.Models.Produtos;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Infra.Data.Mappings {
    public class ProdutoConfig : EntityTypeConfiguration<Produto> {

        #region Construtor
        public ProdutoConfig() {
            
            this.HasKey(p =>  p.Id);

            this.Property(p => p.Nome);

            this.Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(1000);

            this.Property(p => p.Imagem)
                .IsRequired()
                .HasMaxLength(100);


            this.HasRequired(p => p.Fornecedor)
                .WithMany(f => f.Produtos)// withMany (relação de um para muitos) -> um fornecedor pode ter vários produtos.
                .HasForeignKey(p => p.FornecedorId); //chave extrangeira FornecedorId

            this.ToTable(tableName:"Produtos");

        }

        #endregion

    }
}
