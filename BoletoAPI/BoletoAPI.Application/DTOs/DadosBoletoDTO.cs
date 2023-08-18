using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoletoAPI.Application.DTOs
{
    public class DadosBoletoDTO
    {
        #region Propriedades

        [Key]
        [DisplayName("Id")]
        public int BoletoId { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [DisplayName("Nosso Número")]
        public string NossoNumero { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [DisplayName("Data de vencimento")]
        public DateTime Vencimento { get; private set; } = DateTime.MinValue;

        [DisplayName("Campo Livre")]
        public string? CampoLivre { get; private set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Valor")]
        public decimal Valor { get; private set; } = decimal.Zero;

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [DisplayName("Data Emissão")]
        public DateTime DataEmissao { get; private set; } = DateTime.MinValue;

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [DisplayName("Data Processamento")]
        public DateTime DataProcessamento { get; private set; } = DateTime.MinValue;

        #endregion Propriedades

        #region Propriedades de navegação

        public SacadoDTO SacadoDTO { get; set; } = new SacadoDTO();
        public BeneficiarioDTO BeneficiarioDTO { get; set; } = new BeneficiarioDTO();

        #endregion Propriedades de navegação
    }
}