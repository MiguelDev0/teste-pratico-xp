using Microsoft.EntityFrameworkCore;
using XP.Business.Interfaces;
using XP.Business.Models;
using XP.Data.Context;

namespace XP.Data.Ropositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(MeuDbContext context) : base(context) { }

        public Task<Usuario> ListarDetalhesDoCliente(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> ListarTodosOsClientes(Guid Id)
        {
            return await Db.Usuarios.AsNoTracking().Include(c => c.Emails).Include(c => c.Enderecos).FirstOrDefaultAsync(c => c.Id == Id);
        }
    }
}
