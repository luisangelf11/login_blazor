namespace Login.Data.Request
{
    public class UsuarioRequest
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Rol { get; set; }
    }
}
