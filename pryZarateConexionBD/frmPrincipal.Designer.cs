namespace pryZarateConexionBD
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.ConexionDB = new System.Windows.Forms.StatusStrip();
            this.lblEstadoConexión = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvConexion = new System.Windows.Forms.DataGridView();
            this.ConexionDB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConexion)).BeginInit();
            this.SuspendLayout();
            // 
            // ConexionDB
            // 
            this.ConexionDB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblEstadoConexión});
            this.ConexionDB.Location = new System.Drawing.Point(0, 330);
            this.ConexionDB.Name = "ConexionDB";
            this.ConexionDB.Size = new System.Drawing.Size(719, 22);
            this.ConexionDB.TabIndex = 0;
            this.ConexionDB.Text = "statusStrip1";
            // 
            // lblEstadoConexión
            // 
            this.lblEstadoConexión.Name = "lblEstadoConexión";
            this.lblEstadoConexión.Size = new System.Drawing.Size(57, 17);
            this.lblEstadoConexión.Text = "Conexion";
            // 
            // dgvConexion
            // 
            this.dgvConexion.BackgroundColor = System.Drawing.Color.DarkKhaki;
            this.dgvConexion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConexion.Location = new System.Drawing.Point(41, 21);
            this.dgvConexion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvConexion.Name = "dgvConexion";
            this.dgvConexion.Size = new System.Drawing.Size(638, 291);
            this.dgvConexion.TabIndex = 1;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(719, 352);
            this.Controls.Add(this.dgvConexion);
            this.Controls.Add(this.ConexionDB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conexión Base de Datos en Access";
            this.Load += new System.EventHandler(this.frmPrincipal_Load_1);
            this.ConexionDB.ResumeLayout(false);
            this.ConexionDB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConexion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip ConexionDB;
        private System.Windows.Forms.ToolStripStatusLabel lblEstadoConexión;
        private System.Windows.Forms.DataGridView dgvConexion;
    }
}

