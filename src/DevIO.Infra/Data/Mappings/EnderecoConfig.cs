using DevIO.Business.Models.Fornecedores;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Infra.Data.Mappings {
    public class EnderecoConfig : EntityTypeConfiguration<Endereco> {

        #region Construtor
        public EnderecoConfig() {

            this.HasKey(e => e.Id);

            this.Property(e => e.Logradouro)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(e => e.Cep)
                .IsRequired()
                .HasMaxLength(8)
                .IsFixedLength(); //tamanho fixo.

            this.Property(e => e.Complemento)
                .HasMaxLength(250);

            this.Property(e => e.Bairro)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(e => e.Cidade)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(e => e.Estado)
                .IsRequired()
                .HasMaxLength(100);

            this.ToTable(tableName:"Enderecos");

        }
        #endregion

    }
}
