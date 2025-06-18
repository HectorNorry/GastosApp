using GastosApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastosApp.Infrastructure.Interfaces
{
    public interface IGastoRepository
    {
        Task<List<Gasto>> GetByUsuarioAsync(int usuarioId);
        Task<Gasto> AddAsync(Gasto gasto);
        Task DeleteAsync(int id);
        Task<IEnumerable<Gasto>> ObtenerPorUsuarioIdAsync(int usuarioId);
        Task<Gasto> ObtenerPorIdAsync(int id);
        Task EliminarAsync(Gasto gasto);
        Task ActualizarAsync(Gasto gasto);



    }
}
