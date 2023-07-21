using AgendaElectronica.Data.Services;
using Login.Data.Models;
using Login.Data.Request;
using Login.Data.Response;

namespace Login.Data.Services
{
    public interface IUsuarioServices
    {
        Task<Usuario> Autenticar(string username, string password);
        Task<Result<List<UsuarioResponse>>> Consultar(string filtro);
        Task<Result> Crear(UsuarioRequest request);
        Task<Result> Eliminar(UsuarioRequest request);
        Task<Result> Modificar(UsuarioRequest request);
    }
}