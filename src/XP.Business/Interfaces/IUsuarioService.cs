using XP.Business.Models;

namespace XP.Business.Interfaces
{
    public interface IUsuarioService : IDisposable
    {
        Task<bool> Adicionar(Usuario usuario);
        Task<bool> Atualizar(Usuario usuario);
        Task<bool> Remover(Guid id);

        Task AtualizarEndereco(Endereco endereco);
        Task AtualizarEmail(Email email);
    }
}
