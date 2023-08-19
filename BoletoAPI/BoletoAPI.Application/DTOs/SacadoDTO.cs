using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BoletoAPI.Application.DTOs
{
    public class SacadoDTO
    {
        #region Propriedades

        [DisplayName("Sacado Ids")]
        public int SacadoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Nome")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("CPF")]
        public string CPF { get; set; } = string.Empty;

        #endregion Propriedades

        #region Propriedades de navegação

        public EnderecoDTO EnderecoDTO { get; set; } = new EnderecoDTO();

        #endregion Propriedades de navegação
    }
}