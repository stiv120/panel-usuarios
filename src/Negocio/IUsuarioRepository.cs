using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Entidades;

namespace Negocio
{
    public interface IUsuarioRepository
    {
        Task<IReadOnlyList<User>> ObtenerTodosAsync(CancellationToken cancellationToken = default);
    }
}
