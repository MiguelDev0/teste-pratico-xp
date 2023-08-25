using XP.Business.Models;

namespace XP.Business.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPrincipal(Guid usuarioId);
    }
}
