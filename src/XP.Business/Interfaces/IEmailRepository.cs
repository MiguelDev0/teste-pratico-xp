using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XP.Business.Models;

namespace XP.Business.Interfaces
{
    public interface IEmailRepository  : IRepository<Email>
    {
        Task<IEnumerable<Email>> ObterEmailsPorUsuario();
        Task<Email> ObterEmailPrincipal(Guid usuarioId);
    }
}
