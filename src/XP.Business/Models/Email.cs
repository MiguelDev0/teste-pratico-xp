using System;

namespace XP.Business.Models
{
    public class Email : Entity
    {
        public Guid UsuarioId { get; set; }
        public string? EmailCadastro { get; set; }
        public int? EmailPrincipal{ get; set; }
        public bool IsEmailPrincipal {
            get
            {
                return (EmailPrincipal == 1) ? true : false;
            }
        }
        public Usuario Usuario { get; set; }
    }
}
