namespace WinFormActivosFijos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cbxTipo = new System.Windows.Forms.ComboBox();
            this.grdActivosFijos = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.checkSerial = new System.Windows.Forms.CheckBox();
            this.checkIdActivo = new System.Windows.Forms.CheckBox();
            this.checTipo = new System.Windows.Forms.CheckBox();
            this.checkFechaCompra = new System.Windows.Forms.CheckBox();
            this.numId = new System.Windows.Forms.NumericUpDown();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.dtFechaCompra = new System.Windows.Forms.DateTimePicker();
            this.grbBusqueda = new System.Windows.Forms.GroupBox();
            this.grbActualizar = new System.Windows.Forms.GroupBox();
            this.dtFechaBaja = new System.Windows.Forms.DateTimePicker();
            this.checkFechaBaja = new System.Windows.Forms.CheckBox();
            this.txtActSerial = new System.Windows.Forms.TextBox();
            this.checActSerial = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdActivosFijos)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numId)).BeginInit();
            this.grbBusqueda.SuspendLayout();
            this.grbActualizar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(15, 71);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(79, 62);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cbxTipo
            // 
            this.cbxTipo.Enabled = false;
            this.cbxTipo.FormattingEnabled = true;
            this.cbxTipo.Location = new System.Drawing.Point(139, 38);
            this.cbxTipo.Name = "cbxTipo";
            this.cbxTipo.Size = new System.Drawing.Size(192, 21);
            this.cbxTipo.TabIndex = 3;
            // 
            // grdActivosFijos
            // 
            this.grdActivosFijos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdActivosFijos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdActivosFijos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdActivosFijos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdActivosFijos.Location = new System.Drawing.Point(0, 0);
            this.grdActivosFijos.MultiSelect = false;
            this.grdActivosFijos.Name = "grdActivosFijos";
            this.grdActivosFijos.ReadOnly = true;
            this.grdActivosFijos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdActivosFijos.Size = new System.Drawing.Size(800, 298);
            this.grdActivosFijos.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grdActivosFijos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 298);
            this.panel1.TabIndex = 7;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grbActualizar);
            this.splitContainer1.Panel1.Controls.Add(this.grbBusqueda);
            this.splitContainer1.Panel1.Controls.Add(this.btnGuardar);
            this.splitContainer1.Panel1.Controls.Add(this.btnEditar);
            this.splitContainer1.Panel1.Controls.Add(this.btnBuscar);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 148;
            this.splitContainer1.TabIndex = 8;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Enabled = false;
            this.btnGuardar.Location = new System.Drawing.Point(181, 71);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 62);
            this.btnGuardar.TabIndex = 20;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(100, 71);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 62);
            this.btnEditar.TabIndex = 19;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkSerial
            // 
            this.checkSerial.AutoSize = true;
            this.checkSerial.Location = new System.Drawing.Point(357, 19);
            this.checkSerial.Name = "checkSerial";
            this.checkSerial.Size = new System.Drawing.Size(52, 17);
            this.checkSerial.TabIndex = 18;
            this.checkSerial.Text = "Serial";
            this.checkSerial.UseVisualStyleBackColor = true;
            this.checkSerial.CheckedChanged += new System.EventHandler(this.checkSerial_CheckedChanged);
            // 
            // checkIdActivo
            // 
            this.checkIdActivo.AutoSize = true;
            this.checkIdActivo.Location = new System.Drawing.Point(477, 19);
            this.checkIdActivo.Name = "checkIdActivo";
            this.checkIdActivo.Size = new System.Drawing.Size(88, 17);
            this.checkIdActivo.TabIndex = 17;
            this.checkIdActivo.Text = "Id ACtivo Fijo";
            this.checkIdActivo.UseVisualStyleBackColor = true;
            this.checkIdActivo.CheckedChanged += new System.EventHandler(this.checkIdActivo_CheckedChanged);
            // 
            // checTipo
            // 
            this.checTipo.AutoSize = true;
            this.checTipo.Location = new System.Drawing.Point(139, 19);
            this.checTipo.Name = "checTipo";
            this.checTipo.Size = new System.Drawing.Size(47, 17);
            this.checTipo.TabIndex = 16;
            this.checTipo.Text = "Tipo";
            this.checTipo.UseVisualStyleBackColor = true;
            this.checTipo.CheckedChanged += new System.EventHandler(this.checTipo_CheckedChanged);
            // 
            // checkFechaCompra
            // 
            this.checkFechaCompra.AutoSize = true;
            this.checkFechaCompra.Location = new System.Drawing.Point(15, 19);
            this.checkFechaCompra.Name = "checkFechaCompra";
            this.checkFechaCompra.Size = new System.Drawing.Size(110, 17);
            this.checkFechaCompra.TabIndex = 15;
            this.checkFechaCompra.Text = "Fecha de Compra";
            this.checkFechaCompra.UseVisualStyleBackColor = true;
            this.checkFechaCompra.CheckedChanged += new System.EventHandler(this.checkFechaCompra_CheckedChanged);
            // 
            // numId
            // 
            this.numId.Enabled = false;
            this.numId.Location = new System.Drawing.Point(477, 40);
            this.numId.Name = "numId";
            this.numId.Size = new System.Drawing.Size(120, 20);
            this.numId.TabIndex = 14;
            // 
            // txtSerial
            // 
            this.txtSerial.Enabled = false;
            this.txtSerial.Location = new System.Drawing.Point(357, 39);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(100, 20);
            this.txtSerial.TabIndex = 10;
            // 
            // dtFechaCompra
            // 
            this.dtFechaCompra.CustomFormat = "yyyy-MM-dd";
            this.dtFechaCompra.Enabled = false;
            this.dtFechaCompra.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaCompra.Location = new System.Drawing.Point(15, 39);
            this.dtFechaCompra.MaxDate = new System.DateTime(2023, 2, 15, 0, 0, 0, 0);
            this.dtFechaCompra.Name = "dtFechaCompra";
            this.dtFechaCompra.Size = new System.Drawing.Size(96, 20);
            this.dtFechaCompra.TabIndex = 9;
            this.dtFechaCompra.Value = new System.DateTime(2023, 2, 15, 0, 0, 0, 0);
            // 
            // grbBusqueda
            // 
            this.grbBusqueda.Controls.Add(this.checkFechaCompra);
            this.grbBusqueda.Controls.Add(this.cbxTipo);
            this.grbBusqueda.Controls.Add(this.dtFechaCompra);
            this.grbBusqueda.Controls.Add(this.checkSerial);
            this.grbBusqueda.Controls.Add(this.txtSerial);
            this.grbBusqueda.Controls.Add(this.checkIdActivo);
            this.grbBusqueda.Controls.Add(this.numId);
            this.grbBusqueda.Controls.Add(this.checTipo);
            this.grbBusqueda.Location = new System.Drawing.Point(3, 3);
            this.grbBusqueda.Name = "grbBusqueda";
            this.grbBusqueda.Size = new System.Drawing.Size(731, 62);
            this.grbBusqueda.TabIndex = 21;
            this.grbBusqueda.TabStop = false;
            this.grbBusqueda.Text = "Parametros de Busqueda";
            // 
            // grbActualizar
            // 
            this.grbActualizar.Controls.Add(this.checActSerial);
            this.grbActualizar.Controls.Add(this.txtActSerial);
            this.grbActualizar.Controls.Add(this.checkFechaBaja);
            this.grbActualizar.Controls.Add(this.dtFechaBaja);
            this.grbActualizar.Location = new System.Drawing.Point(274, 71);
            this.grbActualizar.Name = "grbActualizar";
            this.grbActualizar.Size = new System.Drawing.Size(308, 74);
            this.grbActualizar.TabIndex = 22;
            this.grbActualizar.TabStop = false;
            this.grbActualizar.Text = "Datos Actualizar";
            this.grbActualizar.Visible = false;
            // 
            // dtFechaBaja
            // 
            this.dtFechaBaja.CustomFormat = "yyyy-MM-dd";
            this.dtFechaBaja.Enabled = false;
            this.dtFechaBaja.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaBaja.Location = new System.Drawing.Point(6, 42);
            this.dtFechaBaja.MaxDate = new System.DateTime(2023, 2, 15, 0, 0, 0, 0);
            this.dtFechaBaja.Name = "dtFechaBaja";
            this.dtFechaBaja.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtFechaBaja.Size = new System.Drawing.Size(95, 20);
            this.dtFechaBaja.TabIndex = 19;
            this.dtFechaBaja.Value = new System.DateTime(2023, 2, 15, 0, 0, 0, 0);
            // 
            // checkFechaBaja
            // 
            this.checkFechaBaja.AutoSize = true;
            this.checkFechaBaja.Location = new System.Drawing.Point(6, 19);
            this.checkFechaBaja.Name = "checkFechaBaja";
            this.checkFechaBaja.Size = new System.Drawing.Size(95, 17);
            this.checkFechaBaja.TabIndex = 19;
            this.checkFechaBaja.Text = "Fecha de Baja";
            this.checkFechaBaja.UseVisualStyleBackColor = true;
            this.checkFechaBaja.CheckedChanged += new System.EventHandler(this.checkFechaBaja_CheckedChanged);
            // 
            // txtActSerial
            // 
            this.txtActSerial.Enabled = false;
            this.txtActSerial.Location = new System.Drawing.Point(152, 42);
            this.txtActSerial.Name = "txtActSerial";
            this.txtActSerial.Size = new System.Drawing.Size(137, 20);
            this.txtActSerial.TabIndex = 20;
            // 
            // checActSerial
            // 
            this.checActSerial.AutoSize = true;
            this.checActSerial.Location = new System.Drawing.Point(152, 19);
            this.checActSerial.Name = "checActSerial";
            this.checActSerial.Size = new System.Drawing.Size(52, 17);
            this.checActSerial.TabIndex = 21;
            this.checActSerial.Text = "Serial";
            this.checActSerial.UseVisualStyleBackColor = true;
            this.checActSerial.CheckedChanged += new System.EventHandler(this.checActSerial_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion deActios Fijos";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdActivosFijos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numId)).EndInit();
            this.grbBusqueda.ResumeLayout(false);
            this.grbBusqueda.PerformLayout();
            this.grbActualizar.ResumeLayout(false);
            this.grbActualizar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cbxTipo;
        private System.Windows.Forms.DataGridView grdActivosFijos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DateTimePicker dtFechaCompra;
        private System.Windows.Forms.TextBox txtSerial;
        private System.Windows.Forms.NumericUpDown numId;
        private System.Windows.Forms.CheckBox checkSerial;
        private System.Windows.Forms.CheckBox checkIdActivo;
        private System.Windows.Forms.CheckBox checTipo;
        private System.Windows.Forms.CheckBox checkFechaCompra;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox grbActualizar;
        private System.Windows.Forms.CheckBox checkFechaBaja;
        private System.Windows.Forms.DateTimePicker dtFechaBaja;
        private System.Windows.Forms.GroupBox grbBusqueda;
        private System.Windows.Forms.CheckBox checActSerial;
        private System.Windows.Forms.TextBox txtActSerial;
    }
}

