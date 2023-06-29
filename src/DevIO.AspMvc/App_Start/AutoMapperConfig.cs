using AutoMapper;
using DevIO.AspMvc.ViewModels;
using DevIO.Business.Models.Fornecedores;
using DevIO.Business.Models.Produtos;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace DevIO.AspMvc.App_Start {
    public class AutoMapperConfig {

        public static MapperConfiguration GetMapperConfiguration() {


            var profiles = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => typeof(Profile).IsAssignableFrom(x)); //procura as classes que herdam de Profile.

            return new MapperConfiguration(cfg => {
                foreach (var profile in profiles) {
                    cfg.AddProfile(Activator.CreateInstance(profile) as Profile);
                }
            });

        }

    }

    public class AutoMapperProfile : Profile {

        #region Construtor
        public AutoMapperProfile() {

            this.CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap(); //ReverseMap -> mapeia nas duas direçoes
            this.CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            this.CreateMap<Produto, ProdutoViewModel>().ReverseMap();
        }
        #endregion

    }

}