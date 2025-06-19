namespace GastosApp.API.Models
{
    public class LoginRequestDto
    {
        public string Email { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
    }
}
