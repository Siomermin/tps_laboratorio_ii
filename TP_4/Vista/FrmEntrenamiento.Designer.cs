
namespace Vista
{
    partial class FrmEntrenamiento
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
            this.components = new System.ComponentModel.Container();
            this.lblTiempoArranqueEntrenamiento = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnDetener = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblHorario = new System.Windows.Forms.Label();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.lblApellidoCliente = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblEstadoCliente = new System.Windows.Forms.Label();
            this.lblCronometroStopWatch = new System.Windows.Forms.Label();
            this.TimerEntrenamiento = new System.Windows.Forms.Timer(this.components);
            this.lblCronometro = new System.Windows.Forms.Label();
            this.btnReiniciarCronometro = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTiempoArranqueEntrenamiento
            // 
            this.lblTiempoArranqueEntrenamiento.AutoSize = true;
            this.lblTiempoArranqueEntrenamiento.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTiempoArranqueEntrenamiento.Location = new System.Drawing.Point(112, 104);
            this.lblTiempoArranqueEntrenamiento.Name = "lblTiempoArranqueEntrenamiento";
            this.lblTiempoArranqueEntrenamiento.Size = new System.Drawing.Size(102, 32);
            this.lblTiempoArranqueEntrenamiento.TabIndex = 0;
            this.lblTiempoArranqueEntrenamiento.Text = "00:00:00";
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(128, 217);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(149, 49);
            this.btnIniciar.TabIndex = 3;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnDetener
            // 
            this.btnDetener.Location = new System.Drawing.Point(438, 217);
            this.btnDetener.Name = "btnDetener";
            this.btnDetener.Size = new System.Drawing.Size(149, 49);
            this.btnDetener.TabIndex = 4;
            this.btnDetener.Text = "Detener";
            this.btnDetener.UseVisualStyleBackColor = true;
            this.btnDetener.Click += new System.EventHandler(this.btnDetener_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNombre.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblNombre.Location = new System.Drawing.Point(5, 9);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(107, 32);
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblApellido.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblApellido.Location = new System.Drawing.Point(5, 56);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(107, 32);
            this.lblApellido.TabIndex = 6;
            this.lblApellido.Text = "Apellido:";
            // 
            // lblHorario
            // 
            this.lblHorario.AutoSize = true;
            this.lblHorario.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHorario.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblHorario.Location = new System.Drawing.Point(5, 104);
            this.lblHorario.Name = "lblHorario";
            this.lblHorario.Size = new System.Drawing.Size(98, 32);
            this.lblHorario.TabIndex = 7;
            this.lblHorario.Text = "Horario:";
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNombreCliente.Location = new System.Drawing.Point(121, 9);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(0, 32);
            this.lblNombreCliente.TabIndex = 8;
            // 
            // lblApellidoCliente
            // 
            this.lblApellidoCliente.AutoSize = true;
            this.lblApellidoCliente.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblApellidoCliente.Location = new System.Drawing.Point(121, 56);
            this.lblApellidoCliente.Name = "lblApellidoCliente";
            this.lblApellidoCliente.Size = new System.Drawing.Size(0, 32);
            this.lblApellidoCliente.TabIndex = 9;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEstado.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblEstado.Location = new System.Drawing.Point(5, 156);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(89, 32);
            this.lblEstado.TabIndex = 10;
            this.lblEstado.Text = "Estado:";
            // 
            // lblEstadoCliente
            // 
            this.lblEstadoCliente.AutoSize = true;
            this.lblEstadoCliente.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEstadoCliente.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEstadoCliente.Location = new System.Drawing.Point(112, 156);
            this.lblEstadoCliente.Name = "lblEstadoCliente";
            this.lblEstadoCliente.Size = new System.Drawing.Size(0, 32);
            this.lblEstadoCliente.TabIndex = 11;
            // 
            // lblCronometroStopWatch
            // 
            this.lblCronometroStopWatch.AutoSize = true;
            this.lblCronometroStopWatch.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCronometroStopWatch.ForeColor = System.Drawing.Color.Indigo;
            this.lblCronometroStopWatch.Location = new System.Drawing.Point(422, 56);
            this.lblCronometroStopWatch.Name = "lblCronometroStopWatch";
            this.lblCronometroStopWatch.Size = new System.Drawing.Size(102, 32);
            this.lblCronometroStopWatch.TabIndex = 12;
            this.lblCronometroStopWatch.Text = "00:00:00";
            // 
            // TimerEntrenamiento
            // 
            this.TimerEntrenamiento.Enabled = true;
            this.TimerEntrenamiento.Tick += new System.EventHandler(this.TimerEntrenamiento_Tick);
            // 
            // lblCronometro
            // 
            this.lblCronometro.AutoSize = true;
            this.lblCronometro.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCronometro.ForeColor = System.Drawing.Color.SlateBlue;
            this.lblCronometro.Location = new System.Drawing.Point(422, 24);
            this.lblCronometro.Name = "lblCronometro";
            this.lblCronometro.Size = new System.Drawing.Size(143, 32);
            this.lblCronometro.TabIndex = 13;
            this.lblCronometro.Text = "Cronometro";
            // 
            // btnReiniciarCronometro
            // 
            this.btnReiniciarCronometro.Location = new System.Drawing.Point(283, 217);
            this.btnReiniciarCronometro.Name = "btnReiniciarCronometro";
            this.btnReiniciarCronometro.Size = new System.Drawing.Size(149, 49);
            this.btnReiniciarCronometro.TabIndex = 14;
            this.btnReiniciarCronometro.Text = "Reiniciar Cronometro";
            this.btnReiniciarCronometro.UseVisualStyleBackColor = true;
            this.btnReiniciarCronometro.Click += new System.EventHandler(this.btnReiniciarCronometro_Click);
            // 
            // FrmEntrenamiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 278);
            this.Controls.Add(this.btnReiniciarCronometro);
            this.Controls.Add(this.lblCronometro);
            this.Controls.Add(this.lblCronometroStopWatch);
            this.Controls.Add(this.lblEstadoCliente);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblApellidoCliente);
            this.Controls.Add(this.lblNombreCliente);
            this.Controls.Add(this.lblHorario);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnDetener);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.lblTiempoArranqueEntrenamiento);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEntrenamiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entrenamiento";
            this.Load += new System.EventHandler(this.FrmEntrenamiento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTiempoArranqueEntrenamiento;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnDetener;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblHorario;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.Label lblApellidoCliente;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblEstadoCliente;
        private System.Windows.Forms.Label lblCronometroStopWatch;
        private System.Windows.Forms.Timer TimerEntrenamiento;
        private System.Windows.Forms.Label lblCronometro;
        private System.Windows.Forms.Button btnReiniciarCronometro;
    }
}