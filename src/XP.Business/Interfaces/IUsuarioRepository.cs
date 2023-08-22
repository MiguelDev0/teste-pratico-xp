using XP.Business.Models;

namespace XP.Business.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> ListarTodosOsClientes(Guid Id);
        Task<Usuario> ListarDetalhesDoCliente(Guid Id);
    }
}
