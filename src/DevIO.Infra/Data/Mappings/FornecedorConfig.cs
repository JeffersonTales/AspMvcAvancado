using DevIO.Business.Models.Fornecedores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Infra.Data.Mappings {
    public class FornecedorConfig : EntityTypeConfiguration<Fornecedor> {

        //Utilização do FluentAPI para mapear a classe de acesso à dados do Fornecedor.

        #region Construtor
        public FornecedorConfig() {

            this.HasKey(f => f.Id);

            this.Property(f => f.Nome)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(f => f.Documento)
                .IsRequired()
                .HasMaxLength(14)
                .HasColumnAnnotation(name: "IX_Documento", //indexa a coluna documento, mais otimizado para realizar consultas.
                                     value: new IndexAnnotation(new IndexAttribute { IsUnique = true })); //index é único.

            /*relacionamento entre Fornecedor e Endereco*/
            this.HasRequired(f => f.Endereco) //é exigido -requerido um endereço para cadastrar o fornecedor. (fornecedor tem um endereço requerido).
                .WithRequiredPrincipal(e => e.Fornecedor); //o principal na relação é o fornecedor.


            this.ToTable(tableName: "Fornecedores"); //define o nome da tabela.

        }
        #endregion

    }
}
