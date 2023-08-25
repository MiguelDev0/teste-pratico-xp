using XP.Business.Models;

namespace XP.Business.Interfaces
{
    public interface IUsuarioService : IDisposable
    {
        Task<bool> Adicionar(Usuario usuario);
        Task<bool> Atualizar(Usuario usuario);
        Task<bool> Remover(Guid id);
        Task<Usuario> BuscaDetalhada(Guid id);
        Task<List<Usuario>> BuscarTodos();
    }
}
