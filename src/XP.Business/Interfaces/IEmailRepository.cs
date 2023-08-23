using XP.Business.Models;

namespace XP.Business.Interfaces
{
    public interface IEmailRepository  : IRepository<Email>
    {
        Task<IEnumerable<Email>> ObterEmailsPorUsuario(Guid usuarioId);
        Task<Email> ObterEmailPrincipal(Guid usuarioId);
    }
}
