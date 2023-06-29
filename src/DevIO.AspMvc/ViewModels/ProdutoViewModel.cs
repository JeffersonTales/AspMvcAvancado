using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevIO.AspMvc.ViewModels {
    public class ProdutoViewModel {

        #region Propriedades
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Fornecedor")]
        public Guid FornecedorId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(maximumLength: 200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(maximumLength: 1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

        [DisplayName("Imagem do Produto")]
        public HttpPostedFileBase ImagemUpload { get; set; }

        public string Imagem { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }

        [ScaffoldColumn(scaffold: false)] //não irá criar na view, -será criado na regra de negocios.
        public DateTime DataCadastro { get; set; }

        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }


        public FornecedorViewModel Fornecedor { get; set; } //será o fornecedor que representa o produto.

        public IEnumerable<FornecedorViewModel> Fornecedores { get; set; }

        #endregion

        #region Construtor
        public ProdutoViewModel() {
            this.Id = Guid.NewGuid();   
        }
        #endregion


    }
}