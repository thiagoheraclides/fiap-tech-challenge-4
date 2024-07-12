using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Br.Com.Fiap.Api.DTO
{
    public partial class UsuarioDTO
    {

        [Required(ErrorMessage = "Campo CPF é obrigatório", AllowEmptyStrings = false)]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Preenchimento obrigatório de 11 caracteres")]
        public string CPF { get; set; } = null!;

        [Required(ErrorMessage = "Campo nome é obrigatório", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Preenchimento obrigatório mínimo de 2 e máximo de 100 caracteres")]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "Campo email é obrigatório", AllowEmptyStrings = false)]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Preencher um email válido")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Preenchimento obrigatório mínimo de 10 e máximo de 100 caracteres")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Campo login é obrigatório", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Preenchimento obrigatório mínimo de 2 e máximo de 50 caracteres")]
        public string Login { get; set; } = null!;

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Campo senha é obrigatório", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Preenchimento obrigatório mínimo de 5 e máximo de 50 caracteres")]
        public string Senha { get; set; } = null!;

        [Required(ErrorMessage = "Campo tipo usuário id é obrigatório")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Por favor, entre com um valor válido")]
        [Range(1, uint.MaxValue, ErrorMessage = "Por favor, entre com um valor válido")]
        public uint TipoUsuarioCodigo { get; set; }
        
        [RegularExpression("([0-9]+)", ErrorMessage = "Por favor, entre com um valor válido")]
        [Range(1, uint.MaxValue, ErrorMessage = "Por favor, entre com um valor válido")]
        public uint? PerfilCodigo { get; set; }

        public required EnderecoDTO Endereco { get; set; }

    }
}
