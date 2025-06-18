namespace GastosApp.Desktop.Forms
{
    partial class FormLogin
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
            txtEmail = new TextBox();
            txtContraseña = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            btnRegistrarse = new Button();
            label4 = new Label();
            SuspendLayout();
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(292, 158);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(173, 23);
            txtEmail.TabIndex = 0;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(292, 226);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(173, 23);
            txtContraseña.TabIndex = 1;
            txtContraseña.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Lucida Sans", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(255, 46);
            label1.Name = "label1";
            label1.Size = new Size(254, 42);
            label1.TabIndex = 2;
            label1.Text = "Inicie Sesión";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(292, 130);
            label2.Name = "label2";
            label2.Size = new Size(74, 25);
            label2.TabIndex = 3;
            label2.Text = "Email : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(292, 198);
            label3.Name = "label3";
            label3.Size = new Size(123, 25);
            label3.TabIndex = 4;
            label3.Text = "Contraseña :";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(292, 286);
            button1.Name = "button1";
            button1.Size = new Size(173, 35);
            button1.TabIndex = 5;
            button1.Text = "Iniciar Sesión";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnRegistrarse
            // 
            btnRegistrarse.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnRegistrarse.Location = new Point(664, 396);
            btnRegistrarse.Name = "btnRegistrarse";
            btnRegistrarse.Size = new Size(102, 30);
            btnRegistrarse.TabIndex = 6;
            btnRegistrarse.Text = "Registrarse";
            btnRegistrarse.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(649, 363);
            label4.Name = "label4";
            label4.Size = new Size(139, 20);
            label4.TabIndex = 7;
            label4.Text = "No está registrado?";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(btnRegistrarse);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtContraseña);
            Controls.Add(txtEmail);
            Name = "FormLogin";
            Text = "Inicio de Sesión";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEmail;
        private TextBox txtContraseña;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button btnRegistrarse;
        private Label label4;
    }
}