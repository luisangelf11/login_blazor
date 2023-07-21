using Login.Data.Request;
using Login.Data.Response;
using System.ComponentModel.DataAnnotations;

namespace Login.Data.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Rol { get; set; }

        public static Usuario Crear(UsuarioRequest usuario) =>
            new Usuario
            {
                Id = usuario.Id,
                Email = usuario.Email,
                Password = usuario.Password,
                Rol = usuario.Rol
            };

        public bool Modificar(UsuarioRequest usuario)
        {
            var cambio = false;
            if(Email != usuario.Email)
            {
                Email = usuario.Email;
                cambio = true;
            }
            if(Password != usuario.Password)
            {
                Password = usuario.Password;
                cambio = true;
            }
            if (Rol != usuario.Rol)
            {
                Rol = usuario.Rol;
                cambio = true;
            }
            return cambio;
        }
        public UsuarioResponse ToResponse() =>
            new()
            {
                Id = Id,
                Email = Email,
                Password = Password,
                Rol = Rol
            };
    }
}
