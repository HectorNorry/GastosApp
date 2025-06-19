namespace GastosApp.API.Models
{
    public class UsuarioLoginResponseDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        
    }

    
}
