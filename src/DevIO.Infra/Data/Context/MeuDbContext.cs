using DevIO.Business.Models.Fornecedores;
using DevIO.Business.Models.Produtos;
using DevIO.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Infra.Data.Context {
    public class MeuDbContext : DbContext {

        #region Construtor
        public MeuDbContext() : base(nameOrConnectionString: "DefaultConnection") {
            //desabilitados para melhorar a perfomance
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }
        #endregion

        #region Mapeamentos

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {

            #region Convencoes
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//no plural o ef não entende nomes em portugues, por isso removi essa convenção.
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); //removido, pois se deletar o fornecedor vai apagar tudo relacionado ao fornecedor.
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            #endregion

            #region Configuracoes Propriedades
            //Toda propriedade que for string será criada no banco como varchar e terá o valor máximo de 100.
            //(Por padrão o EF cria o script com nvarchar ao invés do varchar).
            modelBuilder.Properties<string>().Configure(p => p
                                                             .HasColumnType(columnType: "varchar")
                                                             .HasMaxLength(100));
            #endregion

            #region Configuracoes
            modelBuilder.Configurations.Add(new FornecedorConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());
            modelBuilder.Configurations.Add(new ProdutoConfig());
            #endregion

            base.OnModelCreating(modelBuilder);

        }

    }
}
