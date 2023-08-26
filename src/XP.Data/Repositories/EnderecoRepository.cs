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

        public Task<Endereco> ObterEnderecoPrincipal(Guid usuarioId)
        {
            throw new NotImplementedException();
        }
    }
}
