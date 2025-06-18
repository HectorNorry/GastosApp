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
    public partial class FormGastos : Form
    {
        private readonly Usuario _usuario;
        private readonly ApiService _api;
        private List<Gasto> _gastos = new();

        public FormGastos(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;
            _api = new ApiService();
        }

        private async void FormGastos_Load(object sender, EventArgs e)
        {
            await CargarGastosAsync();
        }

        private async Task CargarGastosAsync()
        {
            dgvGastos.DataSource = null;
            _gastos = await _api.ObtenerGastosPorUsuarioAsync(_usuario.Id);
            dgvGastos.DataSource = _gastos;

            CalcularTotal();
        }

        private void CalcularTotal()
        {
            decimal total = _gastos.Sum(g => g.Monto);
            labeltot.Text = $"Total gastado: ${total}";
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            var nuevo = new Gasto
            {
                Descripcion = txtDescripcion.Text.Trim(),
                Monto = nudMonto.Value,
                Fecha = dtpFecha.Value,
                UsuarioId = _usuario.Id
            };

            await _api.CrearGastoAsync(nuevo);
            await CargarGastosAsync();
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtDescripcion.Text = "";
            nudMonto.Value = 0;
            dtpFecha.Value = DateTime.Now;
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvGastos.CurrentRow?.DataBoundItem is Gasto seleccionado)
            {
                await _api.EliminarGastoAsync(seleccionado.Id);
                await CargarGastosAsync();
            }
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvGastos.CurrentRow?.DataBoundItem is Gasto seleccionado)
            {
                seleccionado.Descripcion = txtDescripcion.Text.Trim();
                seleccionado.Monto = nudMonto.Value;
                seleccionado.Fecha = dtpFecha.Value;

                await _api.ModificarGastoAsync(seleccionado.Id, seleccionado);
                await CargarGastosAsync();
                LimpiarCampos();
            }
        }

        private void dgvGastos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGastos.CurrentRow?.DataBoundItem is Gasto seleccionado)
            {
                txtDescripcion.Text = seleccionado.Descripcion;
                nudMonto.Value = seleccionado.Monto;
                dtpFecha.Value = seleccionado.Fecha;
            }
        }
    }
}