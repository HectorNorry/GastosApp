using System;
using System.Windows.Forms;
using GastosApp.Desktop.Services;
using GastosApp.Desktop.Models;
using GastosApp.API.Models;
using System.Threading.Tasks; // Necesario para async/await

// No necesitamos System.Threading aquí si no usamos SynchronizationContext.Current explícitamente en Post.
// using System.Threading;

namespace GastosApp.Desktop.Forms // <<-- ¡Solo un namespace aquí!
{
    public partial class FormLogin : Form
    {
        private readonly ApiService _apiService;

        public FormLogin()
        {
            InitializeComponent();
            _apiService = new ApiService();
        }

        private async void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("Por favor, ingresa tu email y contraseña.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var loginRequest = new LoginRequestDto
            {
                email = txtEmail.Text.Trim(),
                contraseña = txtContraseña.Text.Trim()
            };

            try
            {
                // <<<< PON UN BREAKPOINT AQUÍ (Línea A)
                var usuarioLogueado = await _apiService.LoginAsync(loginRequest);

                // <<<< PON OTRO BREAKPOINT AQUÍ (Línea B)
                if (usuarioLogueado != null)
                {
                    MessageBox.Show($"Bienvenido, {usuarioLogueado.nombre}!", "Inicio de Sesión Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();

                    FormGastos formGastos = new FormGastos(usuarioLogueado);
                    formGastos.Show();
                    formGastos.FormClosed += (s, args) => this.Show();
                }
                else
                {
                    // Si usuarioLogueado es null, significa que ApiService.LoginAsync devolvió null
                    // (ya sea por credenciales incorrectas o por un error HTTP/general capturado allí).
                    MessageBox.Show("Credenciales incorrectas o error al conectar con el servidor.", "Error de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (HttpRequestException ex)
            {
                // Este catch capturará si ApiService.LoginAsync lanzó una HttpRequestException
                // y no fue capturada internamente, o si el StatusCode fue 401 y no fue manejado.
                MessageBox.Show($"Error de conexión o en el servidor: {ex.StatusCode} - {ex.Message}", "Error de Comunicación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error HTTP en LoginAsync (FormLogin): {ex.StatusCode} - {ex.Message}");
            }
            catch (Exception ex)
            {
                // Este catch es para cualquier otra excepción inesperada.
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error general en LoginAsync (FormLogin): {ex.Message}");
            }
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            FormRegistro formRegistro = new FormRegistro(_apiService);
            formRegistro.ShowDialog();
        }
    }
}