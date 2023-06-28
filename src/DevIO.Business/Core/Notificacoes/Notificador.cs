using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Core.Notificacoes {
    public class Notificador : INotificador {

        #region Atributos
        private List<Notificacao> _notificacoes;
        #endregion

        #region Construtor
        public Notificador() {
            this._notificacoes = new List<Notificacao>();
        }
        #endregion

        #region Metodos de Contrato
        public void Handle(Notificacao notificacao) {
            this._notificacoes.Add(notificacao);
        }

        public List<Notificacao> ObterNotificacoes() {
            return this._notificacoes;
        }

        public bool TemNotificacao() {
            return !this._notificacoes.Any();
        }
        #endregion

    }
}
