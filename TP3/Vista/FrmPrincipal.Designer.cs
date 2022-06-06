
namespace Vista
{
    partial class FrmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnCargarClientes = new System.Windows.Forms.Button();
            this.btnGuardarClientes = new System.Windows.Forms.Button();
            this.lblGestionarClientes = new System.Windows.Forms.Label();
            this.lblCargarClientes = new System.Windows.Forms.Label();
            this.lblGuardarClientes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(12, 46);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(179, 62);
            this.btnClientes.TabIndex = 0;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnCargarClientes
            // 
            this.btnCargarClientes.Location = new System.Drawing.Point(260, 46);
            this.btnCargarClientes.Name = "btnCargarClientes";
            this.btnCargarClientes.Size = new System.Drawing.Size(179, 62);
            this.btnCargarClientes.TabIndex = 1;
            this.btnCargarClientes.Text = "Cargar Clientes";
            this.btnCargarClientes.UseVisualStyleBackColor = true;
            this.btnCargarClientes.Click += new System.EventHandler(this.btnCargarClientes_Click);
            // 
            // btnGuardarClientes
            // 
            this.btnGuardarClientes.Location = new System.Drawing.Point(507, 46);
            this.btnGuardarClientes.Name = "btnGuardarClientes";
            this.btnGuardarClientes.Size = new System.Drawing.Size(179, 62);
            this.btnGuardarClientes.TabIndex = 2;
            this.btnGuardarClientes.Text = "Guardar Clientes";
            this.btnGuardarClientes.UseVisualStyleBackColor = true;
            this.btnGuardarClientes.Click += new System.EventHandler(this.btnGuardarClientes_Click);
            // 
            // lblGestionarClientes
            // 
            this.lblGestionarClientes.AutoSize = true;
            this.lblGestionarClientes.Location = new System.Drawing.Point(24, 9);
            this.lblGestionarClientes.Name = "lblGestionarClientes";
            this.lblGestionarClientes.Size = new System.Drawing.Size(152, 30);
            this.lblGestionarClientes.TabIndex = 3;
            this.lblGestionarClientes.Text = "Gestion de clientes\r\n(ABM y Guardar credencial)";
            // 
            // lblCargarClientes
            // 
            this.lblCargarClientes.AutoSize = true;
            this.lblCargarClientes.Location = new System.Drawing.Point(282, 9);
            this.lblCargarClientes.Name = "lblCargarClientes";
            this.lblCargarClientes.Size = new System.Drawing.Size(127, 30);
            this.lblCargarClientes.TabIndex = 4;
            this.lblCargarClientes.Text = "Cargar archivo clientes\r\n         (JSON o XML)";
            // 
            // lblGuardarClientes
            // 
            this.lblGuardarClientes.AutoSize = true;
            this.lblGuardarClientes.Location = new System.Drawing.Point(528, 9);
            this.lblGuardarClientes.Name = "lblGuardarClientes";
            this.lblGuardarClientes.Size = new System.Drawing.Size(134, 30);
            this.lblGuardarClientes.TabIndex = 5;
            this.lblGuardarClientes.Text = "Guardar archivo clientes\r\n         (JSON o XML)";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(698, 143);
            this.Controls.Add(this.lblGuardarClientes);
            this.Controls.Add(this.lblCargarClientes);
            this.Controls.Add(this.lblGestionarClientes);
            this.Controls.Add(this.btnGuardarClientes);
            this.Controls.Add(this.btnCargarClientes);
            this.Controls.Add(this.btnClientes);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gimnasio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnCargarClientes;
        private System.Windows.Forms.Button btnGuardarClientes;
        private System.Windows.Forms.Label lblGestionarClientes;
        private System.Windows.Forms.Label lblCargarClientes;
        private System.Windows.Forms.Label lblGuardarClientes;
    }
}

