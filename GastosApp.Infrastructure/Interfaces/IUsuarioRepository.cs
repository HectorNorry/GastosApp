using GastosApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastosApp.Infrastructure.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> GetByEmailAsync(string email);
        Task<Usuario> AddAsync(Usuario usuario);
    }
}
