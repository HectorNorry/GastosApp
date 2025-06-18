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
    public class GastoRepository : IGastoRepository
    {
        private readonly AppDbContext _context;

        public GastoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Gasto>> GetByUsuarioAsync(int usuarioId)
        {
            return await _context.Gastos
                .Where(g => g.UsuarioId == usuarioId)
                .ToListAsync();
        }

        public async Task<Gasto> AddAsync(Gasto gasto)
        {
            _context.Gastos.Add(gasto);
            await _context.SaveChangesAsync();
            return gasto;
        }

        public async Task DeleteAsync(int id)
        {
            var gasto = await _context.Gastos.FindAsync(id);
            if (gasto != null)
            {
                _context.Gastos.Remove(gasto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Gasto>> ObtenerPorUsuarioIdAsync(int usuarioId)
        {
            return await _context.Gastos
                .Where(g => g.UsuarioId == usuarioId)
                .ToListAsync();
        }

        public async Task ActualizarAsync(Gasto gasto)
        {
            _context.Gastos.Update(gasto);
            await _context.SaveChangesAsync();
        }

        public async Task<Gasto> ObtenerPorIdAsync(int id)
        {
            return await _context.Gastos.FindAsync(id);
        }

        public async Task EliminarAsync(Gasto gasto)
        {
            _context.Gastos.Remove(gasto);
            await _context.SaveChangesAsync();
        }

    }
}
