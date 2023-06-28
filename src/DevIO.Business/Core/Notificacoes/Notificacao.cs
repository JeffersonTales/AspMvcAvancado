using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Core.Notificacoes {
    public class Notificacao {

        #region Propriedades
        public string Mensagem { get; }
        #endregion

        #region Construtor
        public Notificacao(string mensagem) {
            this.Mensagem = mensagem;
        }
        #endregion

    }
}
