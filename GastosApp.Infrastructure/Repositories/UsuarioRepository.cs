using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GastosApp.Core.Entities;
using GastosApp.Infrastructure.Data;
using GastosApp.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GastosApp.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _context.Usuarios
                .Include(u => u.Gastos)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Usuario> AddAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
    }
}
