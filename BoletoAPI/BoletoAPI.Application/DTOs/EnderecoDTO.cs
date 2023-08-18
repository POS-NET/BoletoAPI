using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BoletoAPI.Application.DTOs
{
    public class EnderecoDTO
    {
        #region Propriedades

        [DisplayName("Endereço Id")]
        public int EnderecoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(9,9,ErrorMessage = "O campo {0} não pode ser diferente de 9 digitos.")]
        [DisplayName("CEP")]
        public string CEP { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(10, 100, ErrorMessage = "O campo {0} teve ter no mínimo 10 e no máximo 100 caracteres.")]
        public string Logradouro { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(1 , 5, ErrorMessage = "O campo {0} deve conter até 5 digitos.")]
        public string Numero { get; set;} = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(1, 50, ErrorMessage = "O campo {0} deve ser até 50 caracteres.")]
        public string Bairro { get; set; } = string.Empty;


        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(1, 50, ErrorMessage = "O campo {0} deve ser até 50 caracteres.")]
        public string Cidade { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(2, 2, ErrorMessage = "O campo {0} deve conter 2 digitos.")]
        public string Estado { get; set; } = string.Empty;
        #endregion
    }
}