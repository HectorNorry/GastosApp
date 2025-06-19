namespace GastosApp.Desktop.Forms
{
    partial class FormGastos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvGastos = new DataGridView();
            txtDescripcion = new TextBox();
            nudMonto = new NumericUpDown();
            dtpFecha = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnAgregar = new Button();
            btnEliminar = new Button();
            btnModificar = new Button();
            labeltot = new Label();
            lblTotal = new Label();
            btnCerrarSesion = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvGastos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMonto).BeginInit();
            SuspendLayout();
            // 
            // dgvGastos
            // 
            dgvGastos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGastos.Location = new Point(12, 261);
            dgvGastos.Name = "dgvGastos";
            dgvGastos.Size = new Size(1172, 321);
            dgvGastos.TabIndex = 0;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(254, 90);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(327, 23);
            txtDescripcion.TabIndex = 1;
            // 
            // nudMonto
            // 
            nudMonto.Location = new Point(273, 138);
            nudMonto.Name = "nudMonto";
            nudMonto.Size = new Size(200, 23);
            nudMonto.TabIndex = 2;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(254, 178);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(230, 23);
            dtpFecha.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label1.Location = new Point(128, 88);
            label1.Name = "label1";
            label1.Size = new Size(126, 25);
            label1.TabIndex = 4;
            label1.Text = "Descripcion :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label2.Location = new Point(108, 132);
            label2.Name = "label2";
            label2.Size = new Size(159, 25);
            label2.TabIndex = 5;
            label2.Text = "Monto gastado :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label3.Location = new Point(178, 176);
            label3.Name = "label3";
            label3.Size = new Size(72, 25);
            label3.TabIndex = 6;
            label3.Text = "Fecha :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft JhengHei UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(128, 24);
            label4.Name = "label4";
            label4.Size = new Size(243, 35);
            label4.TabIndex = 7;
            label4.Text = "Cargá tus gastos!";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(646, 70);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(114, 23);
            btnAgregar.TabIndex = 8;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(646, 109);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(114, 23);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(646, 151);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(114, 23);
            btnModificar.TabIndex = 10;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            // 
            // labeltot
            // 
            labeltot.AutoSize = true;
            labeltot.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labeltot.Location = new Point(760, 609);
            labeltot.Name = "labeltot";
            labeltot.Size = new Size(155, 30);
            labeltot.TabIndex = 11;
            labeltot.Text = "Total gastado :";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(921, 621);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(38, 15);
            lblTotal.TabIndex = 12;
            lblTotal.Text = "label5";
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(1031, 24);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(124, 23);
            btnCerrarSesion.TabIndex = 13;
            btnCerrarSesion.Text = "Cerrar Sesion";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // FormGastos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(1196, 648);
            Controls.Add(btnCerrarSesion);
            Controls.Add(lblTotal);
            Controls.Add(labeltot);
            Controls.Add(btnModificar);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpFecha);
            Controls.Add(nudMonto);
            Controls.Add(txtDescripcion);
            Controls.Add(dgvGastos);
            Name = "FormGastos";
            Text = "Inicio";
            ((System.ComponentModel.ISupportInitialize)dgvGastos).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMonto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvGastos;
        private TextBox txtDescripcion;
        private NumericUpDown nudMonto;
        private DateTimePicker dtpFecha;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnAgregar;
        private Button btnEliminar;
        private Button btnModificar;
        private Label labeltot;
        private Label lblTotal;
        private Button btnCerrarSesion;
    }
}