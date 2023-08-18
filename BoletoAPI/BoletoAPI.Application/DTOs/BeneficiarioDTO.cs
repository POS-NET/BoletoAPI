using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BoletoAPI.Application.DTOs
{
    public class BeneficiarioDTO
    {
        #region Propriedades

        [DisplayName("Beneficiario Id")]
        public int BeneficiarioId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Código")]
        public string Codigo { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Código DV")]
        public string CodigoDV { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Código Formatado")]
        public string CodigoFormatado { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Código Transmissão")]
        public string CodigoTransmissao { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(11, 14, ErrorMessage = "O campo {0} é inválido. Utilize 11 dígitos para CPF ou 14 para CNPJ.")]
        [DisplayName("CPF/CNPJ")]
        public string CPFCNPJ { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(10, 100, ErrorMessage = "O campo {0} é inválido. precisa ser pelo menos de 10 a 100 caracteres.")]
        [DisplayName("Nome")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Observações")]
        public string Observacoes { get; set; } = string.Empty;

        #endregion

        #region Propriedades de navegação

        public ContaBancariaDTO ContaBancariaDTO { get; set; } = new ContaBancariaDTO();

        #endregion
    }
}