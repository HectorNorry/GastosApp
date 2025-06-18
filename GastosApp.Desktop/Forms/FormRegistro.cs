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
    public partial class formRegistro : Form
    {
        private readonly ApiService _api;

        public formRegistro()
        {
            InitializeComponent();
            _api = new ApiService();
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

            var creado = await _api.RegistrarAsync(nuevo);
            if (creado != null)
            {
                MessageBox.Show("Usuario registrado con éxito");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al registrar usuario");
            }
        }
    }
}
