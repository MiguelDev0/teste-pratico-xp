using Microsoft.EntityFrameworkCore;
using XP.Business.Interfaces;
using XP.Business.Models;
using XP.Data.Context;

namespace XP.Data.Ropositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(MeuDbContext context) : base(context) { }

        public async Task<Usuario> ObterDetalhesDoCliente(Guid Id)
        {
            return await Db.Usuarios.AsNoTracking().Include(c => c.Emails.Where(x => x.EmailPrincipal == 1)).Include(c => c.Enderecos.Where(x => x.EnderecoPrincipal == true)).FirstOrDefaultAsync(c => c.Id == Id);             
        }
    }
}
