using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Entidades;

namespace Negocio
{
    public interface IObtenerUsuariosCasoUso
    {
        Task<IReadOnlyList<User>> EjecutarAsync(CancellationToken cancellationToken = default);
    }
}
