using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GastosApp.Desktop.Models;
using GastosApp.Desktop.Services;
using GastosApp.API.Models;

namespace GastosApp.Desktop.Forms
{
    public partial class FormGastos : Form
    {
        private readonly ApiService _apiService;
        private readonly UsuarioLoginResponseDto _usuarioActual;

        public FormGastos(UsuarioLoginResponseDto usuario)
        {
            InitializeComponent();
            _apiService = new ApiService();
            _usuarioActual = usuario;

            nudMonto.Minimum = 0.01M;
            nudMonto.Maximum = 9999999999.99M;
            nudMonto.DecimalPlaces = 2;

            

            ConfigurarDataGridView();
            this.Load += async (s, e) => await CargarGastosUsuario();
            dgvGastos.CellClick += dgvGastos_CellClick;
            btnAgregar.Click += btnAgregar_Click;
            btnModificar.Click += btnModificar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            dgvGastos.ReadOnly = true;
            this.Tag = null;
        }

        private void ConfigurarDataGridView()
        {
            dgvGastos.AutoGenerateColumns = false;
            dgvGastos.Columns.Clear();

            dgvGastos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", DataPropertyName = "Id", Visible = false });
            dgvGastos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Descripcion", HeaderText = "Descripción", DataPropertyName = "Descripcion", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvGastos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Monto", HeaderText = "Monto", DataPropertyName = "Monto", DefaultCellStyle = { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }, Width = 120 });
            dgvGastos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Fecha", HeaderText = "Fecha", DataPropertyName = "Fecha", DefaultCellStyle = { Format = "dd/MM/yyyy", Alignment = DataGridViewContentAlignment.MiddleCenter }, Width = 120 });

            foreach (DataGridViewColumn column in dgvGastos.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }

            dgvGastos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGastos.MultiSelect = false;
        }

        private async Task CargarGastosUsuario()
        {
            if (_usuarioActual == null)
            {
                MessageBox.Show("No se pudo cargar el usuario actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var gastos = await _apiService.GetGastosByUsuarioIdAsync(_usuarioActual.id);
                dgvGastos.DataSource = gastos;
                CalcularYMostrarTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los gastos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvGastos.DataSource = new List<Gasto>();
                CalcularYMostrarTotal();
            }
        }

        private void CalcularYMostrarTotal()
        {
            decimal total = 0;
            if (dgvGastos.DataSource is List<Gasto> gastos)
            {
                total = gastos.Sum(g => g.Monto);
            }
            lblTotal.Text = $"Total gastado: {total:C2}";
        }

        private void dgvGastos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvGastos.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvGastos.Rows[e.RowIndex];

                int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                string descripcion = selectedRow.Cells["Descripcion"].Value?.ToString() ?? string.Empty;
                decimal monto = Convert.ToDecimal(selectedRow.Cells["Monto"].Value);
                DateTime fecha = Convert.ToDateTime(selectedRow.Cells["Fecha"].Value);

                txtDescripcion.Text = descripcion;
                nudMonto.Value = monto;
                dtpFecha.Value = fecha.Date;

                this.Tag = id;
            }
            else
            {
                LimpiarCampos();
            }
        }

        private bool ValidarEntradas()
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("La descripción del gasto no puede estar vacía.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false;
            }

            if (nudMonto.Value <= 0)
            {
                MessageBox.Show("El monto del gasto debe ser un valor positivo.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudMonto.Focus();
                return false;
            }

            if (dtpFecha.Value.Date > DateTime.Today.Date)
            {
                MessageBox.Show("La fecha del gasto no puede ser en el futuro.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpFecha.Focus();
                return false;
            }
            return true;
        }

        private void LimpiarCampos()
        {
            txtDescripcion.Clear();
            nudMonto.Value = nudMonto.Minimum;
            dtpFecha.Value = DateTime.Today;
            this.Tag = null;
            dgvGastos.ClearSelection();
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarEntradas()) return;

            var nuevoGasto = new Gasto
            {
                Descripcion = txtDescripcion.Text.Trim(),
                Monto = nudMonto.Value,
                Fecha = dtpFecha.Value.Date,
                UsuarioId = _usuarioActual.id
            };

            try
            {
                Console.WriteLine($"Intentando crear gasto: {nuevoGasto.Descripcion} - {nuevoGasto.Monto} - {nuevoGasto.Fecha} - {nuevoGasto.UsuarioId}");
                var creado = await _apiService.AddGastoAsync(nuevoGasto);
                if (creado != null)
                {
                    MessageBox.Show("Gasto agregado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    await CargarGastosUsuario();
                }
                else
                {
                    MessageBox.Show("Error al agregar el gasto. Verifique la conexión o los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al agregar el gasto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                MessageBox.Show("Seleccione un gasto de la tabla para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidarEntradas()) return;

            int gastoId = (int)this.Tag;
            var gastoModificado = new Gasto
            {
                Id = gastoId,
                Descripcion = txtDescripcion.Text.Trim(),
                Monto = nudMonto.Value,
                Fecha = dtpFecha.Value.Date,
                UsuarioId = _usuarioActual.id
            };

            try
            {
                var actualizado = await _apiService.UpdateGastoAsync(gastoModificado);
                if (actualizado != null)
                {
                    MessageBox.Show("Gasto modificado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    await CargarGastosUsuario();
                }
                else
                {
                    MessageBox.Show("Error al modificar el gasto. Verifique la conexión o los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al modificar el gasto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                MessageBox.Show("Seleccione un gasto de la tabla para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro de que desea eliminar este gasto?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int gastoId = (int)this.Tag;
                try
                {
                    bool eliminado = await _apiService.DeleteGastoAsync(gastoId);
                    if (eliminado)
                    {
                        MessageBox.Show("Gasto eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos();
                        await CargarGastosUsuario();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el gasto. Verifique la conexión o los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al eliminar el gasto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }
    }
}
