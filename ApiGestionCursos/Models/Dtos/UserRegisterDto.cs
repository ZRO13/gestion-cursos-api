namespace ApiGestionCursos.Models.Dtos
{
    public class UserRegisterDto
    {
        public string? Id { get; set; }
        public required string Username { get; set; } = string.Empty;
        public required string Password { get; set; }
        public string? Name { get; set; }
        public string? Role { get; set; }
    }
}
