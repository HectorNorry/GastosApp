namespace GastosApp.API.Models
{
    public class UsuarioLoginResponseDto
    {
        public int id { get; set; }
        public string nombre { get; set; } = null!;
        public string apellido { get; set; } = null!;
        public string email { get; set; } = null!;
        
    }

    
}
