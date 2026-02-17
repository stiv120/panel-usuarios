using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Entidades;
using Negocio;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly PruebaSDContext _context;

        public UsuarioRepository(PruebaSDContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<User>> ObtenerTodosAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Usuario
                .AsNoTracking()
                .OrderBy(u => u.Id)
                .ToListAsync(cancellationToken);
        }
    }
}
