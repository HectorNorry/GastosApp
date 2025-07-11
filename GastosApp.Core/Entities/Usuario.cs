﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastosApp.Core.Entities
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Contraseña { get; set; } = null!;

        public ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();
    }
}
