using XP.Business.Models;

namespace XP.Business.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorUsuario(Guid usuarioId);
        Task<Endereco> ObterEnderecoPrincipal(Guid usuarioId);
    }
}
