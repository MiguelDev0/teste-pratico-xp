using System.ComponentModel.DataAnnotations;

namespace XP.API.DTO
{
    public class EmailDTO
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string EmailCadastro { get; set; }
        public bool? EmailPrincipal { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
