using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastosApp.Core.Entities
{
    public class Gasto
    {
        public int Id { get; set; }

        public string Descripcion { get; set; } = null!;
        public decimal Monto { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; } = null!;
    }
}
