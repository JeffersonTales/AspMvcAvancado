using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevIO.AspMvc.ViewModels {
    public class EnderecoViewModel {

        #region Propriedades
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(maximumLength: 200, ErrorMessage ="O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength =2)]
        public string Logradouro { get;set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [StringLength(maximumLength: 50,ErrorMessage ="O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength =1)]
        public string Numero { get; set; }
        
        public string Complemento { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [StringLength(maximumLength:100, ErrorMessage ="O campo {0} precisa ter {2} e {1} caracteres", MinimumLength =2)]
        public string Bairro { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [StringLength(maximumLength:8, ErrorMessage ="O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength =2)]
        public string Cep { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [StringLength(maximumLength: 100, ErrorMessage ="O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Cidade { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [StringLength(maximumLength:50, ErrorMessage ="O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength =2)]
        public string Estado { get; set; }

        [HiddenInput] //--> o campo FornecedorId sempre será tratado com hidden, não aparecerá em um campo.
        public Guid FornecedorId { get; set; }  
        #endregion

        #region Construtor
        public EnderecoViewModel() {
            this.Id = Guid.NewGuid();
        }
        #endregion

    }
}