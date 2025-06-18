namespace GastosApp.Desktop.Forms
{
    partial class formRegistro
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
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtEmail = new TextBox();
            txtContraseña = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(222, 128);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(257, 23);
            txtNombre.TabIndex = 0;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(222, 196);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(257, 23);
            txtApellido.TabIndex = 1;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(222, 259);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(257, 23);
            txtEmail.TabIndex = 2;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(222, 318);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(257, 23);
            txtContraseña.TabIndex = 3;
            txtContraseña.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("OCR A Extended", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(169, 38);
            label1.Name = "label1";
            label1.Size = new Size(387, 29);
            label1.TabIndex = 4;
            label1.Text = "Formulario de Registro";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(222, 100);
            label2.Name = "label2";
            label2.Size = new Size(90, 25);
            label2.TabIndex = 5;
            label2.Text = "Nombre :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(222, 168);
            label3.Name = "label3";
            label3.Size = new Size(91, 25);
            label3.TabIndex = 6;
            label3.Text = "Apellido :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(222, 231);
            label4.Name = "label4";
            label4.Size = new Size(67, 25);
            label4.TabIndex = 7;
            label4.Text = "Email :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(222, 290);
            label5.Name = "label5";
            label5.Size = new Size(122, 25);
            label5.TabIndex = 8;
            label5.Text = "Contraseña : ";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(222, 388);
            button1.Name = "button1";
            button1.Size = new Size(257, 35);
            button1.TabIndex = 9;
            button1.Text = "Registrate!";
            button1.UseVisualStyleBackColor = true;
            // 
            // formRegistro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(725, 450);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtContraseña);
            Controls.Add(txtEmail);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Name = "formRegistro";
            Text = "Registrarse";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtEmail;
        private TextBox txtContraseña;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button1;
    }
}