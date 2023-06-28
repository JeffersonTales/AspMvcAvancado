using DevIO.Business.Core.Models;
using DevIO.Business.Core.Notificacoes;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Core.Services {

    public abstract class BaseService {


        #region Atributos
        private readonly INotificador _notificador;
        #endregion

        #region Construtor
        public BaseService(INotificador notificador) {
            this._notificador = notificador;
        }
        #endregion


        #region Metodos
        protected void Notificar(ValidationResult validationResult) {
            foreach (var error in validationResult.Errors) {
                this.Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem) {
            this._notificador.Handle(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao,
                                                 TE entidade) where TV : AbstractValidator<TE> where TE : Entity {

            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true; //se for válido retorna true

            //se tiver erros irá chamar o método Notificar
            this.Notificar(validationResult: validator);

            return false;

        }
        #endregion

    }
}
