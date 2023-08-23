using XP.Business.Models;

namespace XP.Business.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<IEnumerable<Endereco>> ObterEnderecosPorUsuario(Guid usuarioId);
        Task<Endereco> ObterEnderecoPrincipal(Guid usuarioId);
    }
}
