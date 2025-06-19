using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GastosApp.Desktop.Models;
using GastosApp.Desktop.Services;

namespace GastosApp.Desktop.Forms
{
    public partial class FormRegistro : Form
    {
        private readonly ApiService _api;

        public FormRegistro(ApiService api)
        {
            InitializeComponent();
            _api = api;
        }

        private async void btnRegistrarse_Click(object sender, EventArgs e)
        {
            var nuevo = new Usuario
            {
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Contraseña = txtContraseña.Text.Trim()
            };

            try
            {
                var creado = await _api.RegistrarAsync(nuevo);
                if (creado != null)
                {
                    MessageBox.Show("Usuario registrado con éxito");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error desconocido al registrar usuario");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Registro fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }


}

