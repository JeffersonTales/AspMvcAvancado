using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Models.Produtos.Validations {

    public class ProdutoValidation : AbstractValidator<Produto> {

        #region Construtor
        public ProdutoValidation() {

            RuleFor(p => p.Nome)
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
              .Length(min: 2, max: 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(p => p.Descricao)
             .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
             .Length(min: 2, max: 1000).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(p => p.Valor)
             .GreaterThan(valueToCompare: 0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

        }
        #endregion

    }
}
