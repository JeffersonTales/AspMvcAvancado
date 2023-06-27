using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Core.Models {
    public abstract class Entity {

        #region Propriedades
        public Guid Id { get; set; }
        #endregion

        #region Construtor
        protected Entity() {
            this.Id = Guid.NewGuid();
        }
        #endregion

    }
}
