using XP.Business.Interfaces;
using XP.Business.Models;
using XP.Data.Context;

namespace XP.Data.Ropositories
{
    public class EmailRepository : Repository<Email>, IEmailRepository
    {
        public EmailRepository(MeuDbContext context) : base(context) { }

        public Task<Email> ObterEmailPrincipal(Guid usuarioId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Email>> ObterEmailsPorUsuario()
        {
            throw new NotImplementedException();
        }
    }
}
