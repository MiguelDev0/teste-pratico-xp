using XP.Business.Interfaces;
using XP.Business.Models;
using XP.Data.Context;

namespace XP.Data.Ropositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(MeuDbContext context) : base(context) { }

        public Task<Usuario> ListarDetalhesDoCliente(Guid clientId)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> ListarTodosOsClientes()
        {
            throw new NotImplementedException();
        }
    }
}
