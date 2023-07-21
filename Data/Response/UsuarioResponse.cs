using Login.Data.Request;

namespace Login.Data.Response
{
    public class UsuarioResponse
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Rol { get; set; }

        public UsuarioRequest ToRequest()
        {
            return new UsuarioRequest
            {
                Id = Id,
                Email = Email,
                Password = Password,
                Rol = Rol
            };
        }
    }
}
