using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using GastosApp.Desktop.Models;      
using GastosApp.API.Models;            

namespace GastosApp.Desktop.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://localhost:5003"; 

        public ApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BaseUrl); // Configura la URL base aquí para no repetirla en cada llamada
        }

        // Método de Login: Utiliza LoginRequestDto y devuelve UsuarioLoginResponseDto
        public async Task<UsuarioLoginResponseDto?> LoginAsync(LoginRequestDto loginRequest)
        {
            try
            {
                // La llamada a PostAsJsonAsync ahora incluirá la ruta completa y explícita.
                // Esto es para depurar el 404 y asegurar que la URL sea la que la API espera.
                var response = await _httpClient.PostAsJsonAsync("api/Usuario/login", loginRequest).ConfigureAwait(false);

                // Esta línea lanzará una HttpRequestException si el StatusCode no es de éxito (ej. 404, 500, 401).
                response.EnsureSuccessStatusCode();

                // Si llega aquí, la respuesta fue 2xx (ej. 200 OK), intenta deserializar.
                return await response.Content.ReadFromJsonAsync<UsuarioLoginResponseDto>().ConfigureAwait(false);
            }
            catch (HttpRequestException ex)
            {
                // Este catch capturará errores HTTP como 404, 500, 401, y errores de conexión.
                Console.WriteLine($"Error HTTP en LoginAsync (ApiService): StatusCode: {ex.StatusCode}. Message: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                // Este catch es para cualquier otro tipo de error no relacionado con HTTP directamente.
                Console.WriteLine($"Error general en LoginAsync (ApiService): {ex.Message}");
                return null;
            }
        }

        // Método de Registro: Para consistencia, deberías usar un DTO de registro aquí también,
        // pero por ahora mantengo la firma que pasaste, asumiendo que tu API acepta el modelo Usuario completo para registro.
        // Lo ideal sería un 'RegistroRequestDto' y que devuelva 'UsuarioLoginResponseDto'
        public async Task<UsuarioLoginResponseDto?> RegistrarAsync(Usuario usuario) // Considera cambiar 'Usuario' por un DTO de registro
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Usuario/registro", usuario);

                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<UsuarioLoginResponseDto>(); // Devuelve el DTO de respuesta
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error HTTP en RegistrarAsync: {ex.StatusCode} - {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general en RegistrarAsync: {ex.Message}");
                return null;
            }
        }

        // Obtener gastos de un usuario por su ID
        public async Task<List<Gasto>?> GetGastosByUsuarioIdAsync(int usuarioId) // Renombrado para consistencia
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Gasto/usuario/{usuarioId}");
                response.EnsureSuccessStatusCode(); // Lanza excepción si el código de estado no es 2xx
                return await response.Content.ReadFromJsonAsync<List<Gasto>>();
            }
            catch (HttpRequestException ex)
            {
                if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // Si el servidor devuelve 404 (Not Found) porque no hay gastos, devolver una lista vacía
                    return new List<Gasto>();
                }
                Console.WriteLine($"Error HTTP en GetGastosByUsuarioIdAsync: {ex.StatusCode} - {ex.Message}");
                throw; // Relanzar otras excepciones HTTP
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general en GetGastosByUsuarioIdAsync: {ex.Message}");
                throw; // Relanzar otras excepciones generales
            }
        }

        // Agregar un nuevo gasto
        public async Task<Gasto?> AddGastoAsync(Gasto nuevoGasto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Gasto", nuevoGasto);
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Respuesta no exitosa: {response.StatusCode} - {errorContent}");
                    return null;
                }

                return await response.Content.ReadFromJsonAsync<Gasto>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error HTTP en AddGastoAsync: {ex.StatusCode} - {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general en AddGastoAsync: {ex.Message}");
                return null;
            }
        }

        // Modificar un gasto existente: Toma un objeto Gasto completo, asumiendo que contiene el Id
        public async Task<Gasto?> UpdateGastoAsync(Gasto gastoModificado) // Renombrado y firma ajustada (Opción B)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/Gasto/{gastoModificado.Id}", gastoModificado);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Gasto>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error HTTP en UpdateGastoAsync: {ex.StatusCode} - {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general en UpdateGastoAsync: {ex.Message}");
                return null;
            }
        }

        // Eliminar un gasto por su ID
        public async Task<bool> DeleteGastoAsync(int id) // Renombrado y retorno Task<bool>
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/Gasto/{id}");
                response.EnsureSuccessStatusCode();
                return true; // Éxito
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error HTTP en DeleteGastoAsync: {ex.StatusCode} - {ex.Message}");
                return false; // Error HTTP
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general en DeleteGastoAsync: {ex.Message}");
                return false; // Otro tipo de error
            }
        }
    }
}