namespace DiscoTest
{
    partial class VentanaAgregar
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblTracks = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtTracks = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtPortada = new System.Windows.Forms.TextBox();
            this.lblPortada = new System.Windows.Forms.Label();
            this.cboGenero = new System.Windows.Forms.ComboBox();
            this.lblGenero = new System.Windows.Forms.Label();
            this.cboFormato = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.dtpFechaLanzamiento = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.pBoxAgregar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxAgregar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(36, 39);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblTracks
            // 
            this.lblTracks.AutoSize = true;
            this.lblTracks.Location = new System.Drawing.Point(38, 79);
            this.lblTracks.Name = "lblTracks";
            this.lblTracks.Size = new System.Drawing.Size(43, 13);
            this.lblTracks.TabIndex = 1;
            this.lblTracks.Text = "Tracks:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(84, 36);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(121, 20);
            this.txtNombre.TabIndex = 0;
            // 
            // txtTracks
            // 
            this.txtTracks.Location = new System.Drawing.Point(84, 72);
            this.txtTracks.Name = "txtTracks";
            this.txtTracks.Size = new System.Drawing.Size(121, 20);
            this.txtTracks.TabIndex = 1;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(34, 278);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(169, 278);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtPortada
            // 
            this.txtPortada.Location = new System.Drawing.Point(84, 109);
            this.txtPortada.Name = "txtPortada";
            this.txtPortada.Size = new System.Drawing.Size(121, 20);
            this.txtPortada.TabIndex = 2;
            this.txtPortada.Leave += new System.EventHandler(this.txtPortada_Leave);
            // 
            // lblPortada
            // 
            this.lblPortada.AutoSize = true;
            this.lblPortada.Location = new System.Drawing.Point(31, 112);
            this.lblPortada.Name = "lblPortada";
            this.lblPortada.Size = new System.Drawing.Size(47, 13);
            this.lblPortada.TabIndex = 8;
            this.lblPortada.Text = "Portada:";
            // 
            // cboGenero
            // 
            this.cboGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGenero.FormattingEnabled = true;
            this.cboGenero.Location = new System.Drawing.Point(84, 146);
            this.cboGenero.Name = "cboGenero";
            this.cboGenero.Size = new System.Drawing.Size(121, 21);
            this.cboGenero.TabIndex = 3;
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Location = new System.Drawing.Point(35, 149);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(45, 13);
            this.lblGenero.TabIndex = 10;
            this.lblGenero.Text = "Género:";
            // 
            // cboFormato
            // 
            this.cboFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormato.FormattingEnabled = true;
            this.cboFormato.Location = new System.Drawing.Point(84, 185);
            this.cboFormato.Name = "cboFormato";
            this.cboFormato.Size = new System.Drawing.Size(121, 21);
            this.cboFormato.TabIndex = 4;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(35, 188);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(48, 13);
            this.lblTipo.TabIndex = 12;
            this.lblTipo.Text = "Formato:";
            // 
            // dtpFechaLanzamiento
            // 
            this.dtpFechaLanzamiento.Location = new System.Drawing.Point(102, 225);
            this.dtpFechaLanzamiento.Name = "dtpFechaLanzamiento";
            this.dtpFechaLanzamiento.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaLanzamiento.TabIndex = 5;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(11, 231);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(85, 13);
            this.lblFecha.TabIndex = 14;
            this.lblFecha.Text = "Fecha de salida:";
            // 
            // pBoxAgregar
            // 
            this.pBoxAgregar.Location = new System.Drawing.Point(305, 39);
            this.pBoxAgregar.Name = "pBoxAgregar";
            this.pBoxAgregar.Size = new System.Drawing.Size(183, 167);
            this.pBoxAgregar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxAgregar.TabIndex = 15;
            this.pBoxAgregar.TabStop = false;
            // 
            // VentanaAgregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 313);
            this.Controls.Add(this.pBoxAgregar);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.dtpFechaLanzamiento);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.cboFormato);
            this.Controls.Add(this.lblGenero);
            this.Controls.Add(this.cboGenero);
            this.Controls.Add(this.lblPortada);
            this.Controls.Add(this.txtPortada);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtTracks);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblTracks);
            this.Controls.Add(this.lblNombre);
            this.Name = "VentanaAgregar";
            this.Text = "Agregar disco nuevo";
            this.Load += new System.EventHandler(this.VentanaAgregar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxAgregar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblTracks;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtTracks;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtPortada;
        private System.Windows.Forms.Label lblPortada;
        private System.Windows.Forms.ComboBox cboGenero;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.ComboBox cboFormato;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.DateTimePicker dtpFechaLanzamiento;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.PictureBox pBoxAgregar;
    }
}