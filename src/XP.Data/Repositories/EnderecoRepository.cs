using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XP.Business.Interfaces;
using XP.Business.Models;
using XP.Data.Context;

namespace XP.Data.Ropositories
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(MeuDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Endereco>> ObterEnderecosPorUsuario(Guid usuarioId)
        {
            return await Db.Enderecos.AsNoTracking().Include(f => f.UsuarioId == usuarioId)
                .OrderBy(e => e.Complemento).ToListAsync();
        }

        public Task<Endereco> ObterEnderecoPrincipal(Guid usuarioId)
        {
            throw new NotImplementedException();
        }
    }
}
