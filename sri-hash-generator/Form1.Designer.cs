namespace sri_hash_generator
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.script = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selecionarArquivo = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(51, 104);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(489, 210);
            this.dataGridView1.TabIndex = 0;
            // 
            // script
            // 
            this.script.HeaderText = "script";
            this.script.MinimumWidth = 8;
            this.script.Name = "script";
            this.script.Width = 150;
            // 
            // selecionarArquivo
            // 
            this.selecionarArquivo.Location = new System.Drawing.Point(51, 26);
            this.selecionarArquivo.Name = "selecionarArquivo";
            this.selecionarArquivo.Size = new System.Drawing.Size(188, 34);
            this.selecionarArquivo.TabIndex = 1;
            this.selecionarArquivo.Text = "Selecionar Arquivo";
            this.selecionarArquivo.UseVisualStyleBackColor = true;
            this.selecionarArquivo.Click += new System.EventHandler(this.selecionarArquivo_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(615, 104);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(112, 34);
            this.btnExportar.TabIndex = 2;
            this.btnExportar.Text = "Exportar >>";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(51, 353);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(361, 34);
            this.progressBar1.TabIndex = 3;
            this.progressBar1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.selecionarArquivo);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "sri-hash-generator";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn script;
        private System.Windows.Forms.Button selecionarArquivo;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
