using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Models.Fornecedores.Validations {
    public class EnderecoValidation : AbstractValidator<Endereco> {

        #region Construtor
        public EnderecoValidation() {

            RuleFor(e => e.Logradouro)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(min: 2, max: 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(e => e.Bairro)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(min: 2, max: 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(e => e.Cep)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(exactLength: 8).WithMessage("O campo {PropertyName} precisa ter {MaxLength} caracteres.");

            RuleFor(e => e.Cidade)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(min: 2, max: 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(e => e.Estado)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(min: 2, max: 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(e => e.Numero)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(min: 1, max: 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

        }
        #endregion

    }
}
