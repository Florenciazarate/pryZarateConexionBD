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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ConexionDB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ConexionDB
            // 
            this.ConexionDB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblEstadoConexión});
            this.ConexionDB.Location = new System.Drawing.Point(0, 428);
            this.ConexionDB.Name = "ConexionDB";
            this.ConexionDB.Size = new System.Drawing.Size(800, 22);
            this.ConexionDB.TabIndex = 0;
            this.ConexionDB.Text = "statusStrip1";
            // 
            // lblEstadoConexión
            // 
            this.lblEstadoConexión.Name = "lblEstadoConexión";
            this.lblEstadoConexión.Size = new System.Drawing.Size(57, 17);
            this.lblEstadoConexión.Text = "Conexion";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(86, 63);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(638, 291);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ConexionDB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPrincipal";
            this.Text = "Conexión Base de Datos en Access";
            this.Load += new System.EventHandler(this.frmPrincipal_Load_1);
            this.ConexionDB.ResumeLayout(false);
            this.ConexionDB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip ConexionDB;
        private System.Windows.Forms.ToolStripStatusLabel lblEstadoConexión;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

