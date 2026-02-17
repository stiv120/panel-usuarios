using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Entidades;

namespace Negocio
{
    public class ObtenerUsuariosCasoUso : IObtenerUsuariosCasoUso
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public ObtenerUsuariosCasoUso(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Task<IReadOnlyList<User>> EjecutarAsync(CancellationToken cancellationToken = default)
        {
            return _usuarioRepository.ObtenerTodosAsync(cancellationToken);
        }
    }
}
