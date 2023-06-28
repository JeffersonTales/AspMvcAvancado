using DevIO.Business.Models.Fornecedores.Validations.Documentos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Models.Fornecedores.Validations {
    public class FornecedorValidation : AbstractValidator<Fornecedor> {

        #region Construtor
        public FornecedorValidation() {

            this.RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(min: 2, max: 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");


            this.When(predicate: f => f.TipoFornecedor == TipoFornecedor.PessoaFisica,
                      action: () => {

                          RuleFor(f => f.Documento.Length).Equal(CpfValidacao.TamanhoCpf)
                          .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");

                          RuleFor(f => CpfValidacao.Validar(f.Documento)).Equal(true)
                          .WithMessage("O documento fornecido é inválido.");
                      }
                      );


            this.When(predicate: f => f.TipoFornecedor == TipoFornecedor.PessoaJuridica,
                      action: () => {

                          RuleFor(f => f.Documento.Length).Equal(CnpjValidacao.TamanhoCnpj)
                         .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");

                          RuleFor(f => CnpjValidacao.Validar(f.Documento)).Equal(true)
                          .WithMessage("O documento fornecido é inválido.");
                      }
                      );

        }
        #endregion

    }
}
