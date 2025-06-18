using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastosApp.Desktop.Models
{
    public class Gasto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }
    }
}
