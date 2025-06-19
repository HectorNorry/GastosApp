namespace GastosApp.API.Models
{
    public class LoginRequestDto
    {
        public string email { get; set; } = null!;
        public string contraseña { get; set; } = null!;
    }
}
