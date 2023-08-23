using XP.Business.Models;

namespace XP.Business.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> ObterUsuarioEmail(Guid Id);
        Task<Usuario> ObterDetalhesDoCliente(Guid Id);
    }
}
