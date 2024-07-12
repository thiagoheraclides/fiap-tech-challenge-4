using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Br.Com.Fiap.Api.DTO
{
    public partial class TipoUsuarioDTO
    {        
        public uint? Codigo { get; set; } = default;

        [Required(ErrorMessage = "Campo nome é obrigatório", AllowEmptyStrings = false)]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Preenchimento obrigatório mínimo de 2 e máximo de 20 caracteres")]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "Campo descrição é obrigatório", AllowEmptyStrings = false)]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Preenchimento obrigatório mínimo de 2 e máximo de 200 caracteres")]
        public string Descricao { get; set; } = null!;

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataRegistro { get; set; }

        [DefaultValue(true)]
        [Required, Range(typeof(bool), "true", "true", ErrorMessage = "Por favor, entre com um valor válido")]
        public bool Ativo { get; set; }

    }
}
