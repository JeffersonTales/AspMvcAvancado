using Microsoft.Ajax.Utilities;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleInjector.Integration.Web.Mvc;
using DevIO.Business.Models.Produtos;
using DevIO.Infra.Data.Repository;
using DevIO.Business.Models.Produtos.Services;
using DevIO.Business.Models.Fornecedores;
using DevIO.Business.Models.Fornecedores.Services;
using DevIO.Business.Core.Notificacoes;
using DevIO.Infra.Data.Context;

namespace DevIO.AspMvc.App_Start {
    public class DependencyInjectionConfig {

        public static void RegisterDIContainer() {

            var container = new Container();

            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(resolver: new SimpleInjectorDependencyResolver(container:container));

        }

        private static void InitializeContainer(Container container) {

            //Ciclo de vida do Objeto: Lifestyle
            //
            //Lifestyle.Singleton: Uma única instância por aplicação.
            //
            //Lifestyle.Transient: Cria uma nova instância para cada injeção.
            //
            //Lifestyle.Scoped: Uma única instância por request.


            //Quando tiver a injeção da interface no construtor, automaticamente irá instanciar a classe associada.
            container.Register<IProdutoRepository, ProdutoRepository>(lifestyle: Lifestyle.Scoped);
            container.Register<IProdutoService, ProdutoService>(lifestyle: Lifestyle.Scoped);
            container.Register<IFornecedorRepository, FornecedorRepository>(lifestyle: Lifestyle.Scoped);
            container.Register<IEnderecoRepository, EnderecoRepository>(lifestyle: Lifestyle.Scoped);
            container.Register<IFornecedorService, FornecedorService>(lifestyle: Lifestyle.Scoped);
            container.Register<INotificador, Notificador>(lifestyle: Lifestyle.Scoped);
            container.Register<MeuDbContext>(Lifestyle.Scoped);

            container.RegisterSingleton(instanceCreator: ()=> AutoMapperConfig.GetMapperConfiguration().CreateMapper(container.GetInstance)); 

        }

    }
}