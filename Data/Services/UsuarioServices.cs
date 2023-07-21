using AgendaElectronica.Data.Services;
using Login.Data.Context;
using Login.Data.Models;
using Login.Data.Request;
using Login.Data.Response;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace Login.Data.Services
{
   
    public class UsuarioServices : IUsuarioServices
    {
        private readonly LoginDBContext dBContext;

        public UsuarioServices(LoginDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<Result> Crear(UsuarioRequest request)
        {
            try
            {
                var usuario = Usuario.Crear(request);
                dBContext.Usuarios.Add(usuario);
                await dBContext.SaveChangesAsync();
                return new Result { Success = true, Message = "OK" };
            }
            catch (Exception E)
            {
                return new Result { Success = false, Message = E.Message };
            }
        }

        public async Task<Result> Modificar(UsuarioRequest request)
        {
            try
            {
                var usuario = await dBContext.Usuarios
                    .FirstOrDefaultAsync(u => u.Id == request.Id);
                if (usuario == null)
                    return new Result { Success = false, Message = "No se encuentra el usuario" };
                if (usuario.Modificar(request))
                    await dBContext.SaveChangesAsync();
                return new Result { Success = true, Message = "OK" };
            }
            catch (Exception E)
            {
                return new Result { Success = false, Message = E.Message };
            }
        }

        public async Task<Result> Eliminar(UsuarioRequest request)
        {
            try
            {
                var usuario = await dBContext.Usuarios
                    .FirstOrDefaultAsync(u => u.Id == request.Id);
                if (usuario == null)
                    return new Result { Success = false, Message = "No se encuentra el usuario" };
                dBContext.Usuarios.Remove(usuario);
                await dBContext.SaveChangesAsync();
                return new Result { Success = true, Message = "OK" };
            }
            catch (Exception E)
            {
                return new Result { Success = false, Message = E.Message };
            }
        }

        public async Task<Result<List<UsuarioResponse>>> Consultar(string filtro)
        {
            try
            {
                var contactos = await dBContext.Usuarios
                    .Where(u => (u.Email + " " + u.Password + " " + u.Rol)
                    .ToLower()
                    .Contains(filtro.ToLower()))
                    .Select(u => u.ToResponse())
                    .ToListAsync();
                return new Result<List<UsuarioResponse>>
                { Message = "OK", Success = true, Data = contactos };
            }
            catch (Exception E)
            {
                return new Result<List<UsuarioResponse>>
                { Message = E.Message, Success = true };
            }
        }
        public async Task<Usuario> Autenticar(string username, string password)
        {
            var usuario = await dBContext.Usuarios.FirstOrDefaultAsync(u => u.Email == username && u.Password == password);
            return usuario!;
        }
    }
}
