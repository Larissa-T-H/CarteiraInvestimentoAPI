using System.ComponentModel.DataAnnotations;

namespace CarteiraInvestimentosApi.Models
{
    public class Autenticacao
    {
        public int AutenticacaoId { get; set; }

        [Required]
        [StringLength(50)]
        public string AutenticacaoNome { get; set; } = string.Empty;

        [Required]
        [StringLength(15)]
        public string AutenticacaoCpf { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        [DataType(DataType.EmailAddress)]
        public string AutenticacaoEmail { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string AutenticacaoSenha { get; set; } = string.Empty;

    }
}
