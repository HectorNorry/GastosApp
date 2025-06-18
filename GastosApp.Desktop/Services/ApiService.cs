using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GastosApp.Desktop.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace GastosApp.Desktop.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://localhost:5003/api";

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Usuario?> LoginAsync(string email, string contraseña)
        {
            var usuario = new Usuario { Email = email, Contraseña = contraseña };

            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/Usuario/login", usuario);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Usuario>();
            }

            return null;
        }

        public async Task<Usuario?> RegistrarAsync(Usuario usuario)
        {
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/Usuario/registro", usuario);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Usuario>();
            }

            return null;
        }

        public async Task<List<Gasto>> ObtenerGastosPorUsuarioAsync(int usuarioId)
        {
            return await _httpClient.GetFromJsonAsync<List<Gasto>>($"{BaseUrl}/Gasto/usuario/{usuarioId}") ?? new();
        }

        public async Task<Gasto?> CrearGastoAsync(Gasto gasto)
        {
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/Gasto", gasto);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<Gasto>()
                : null;
        }

        public async Task EliminarGastoAsync(int id)
        {
            await _httpClient.DeleteAsync($"{BaseUrl}/Gasto/{id}");
        }

        public async Task ModificarGastoAsync(int id, Gasto gasto)
        {
            await _httpClient.PutAsJsonAsync($"{BaseUrl}/Gasto/{id}", gasto);
        }
    }
}
