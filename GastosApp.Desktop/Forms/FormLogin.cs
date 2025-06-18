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
    public partial class FormLogin : Form
    {
        private readonly ApiService _api;

        public FormLogin()
        {
            InitializeComponent();
            _api = new ApiService();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();

            var usuario = await _api.LoginAsync(email, contraseña);
            if (usuario != null)
            {
                MessageBox.Show("Inicio de sesión exitoso");
                // Abrir el formulario de gastos pasando el usuario logueado
                var formGastos = new FormGastos(usuario); // lo hacemos luego
                formGastos.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas");
            }
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            var formRegistro = new FormRegistro();
            formRegistro.ShowDialog();
        }
    }
}
