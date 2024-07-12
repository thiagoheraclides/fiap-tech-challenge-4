using System.ComponentModel.DataAnnotations;

namespace Br.Com.Fiap.Api.DTO
{
    public class LoginDTO
    {

        [Required(ErrorMessage = "Campo login é obrigatório", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Preenchimento obrigatório mínimo de 2 e máximo de 50 caracteres")]
        public string Login { get; set; } = null!;

        [Required(ErrorMessage = "Campo senha é obrigatório", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Preenchimento obrigatório mínimo de 5 e máximo de 50 caracteres")]
        public string Senha { get; set; } = null!;
    }
}
