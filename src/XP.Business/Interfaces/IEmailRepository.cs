using XP.Business.Models;

namespace XP.Business.Interfaces
{
    public interface IEmailRepository  : IRepository<Email>
    {
        Task<Email> ObterEmailPrincipal(Guid usuarioId);
    }
}
