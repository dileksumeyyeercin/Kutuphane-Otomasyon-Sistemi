
namespace Kutuphane_Otomasyon_Sistemi
{
    partial class EmanetKitaplar_Form
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblFiltrele = new System.Windows.Forms.Label();
            this.lblEmanetKitaplar = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnAra = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(33, 128);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(579, 277);
            this.dataGridView1.TabIndex = 0;
            // 
            // lblFiltrele
            // 
            this.lblFiltrele.AutoSize = true;
            this.lblFiltrele.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblFiltrele.Location = new System.Drawing.Point(325, 35);
            this.lblFiltrele.Name = "lblFiltrele";
            this.lblFiltrele.Size = new System.Drawing.Size(67, 20);
            this.lblFiltrele.TabIndex = 1;
            this.lblFiltrele.Text = "Filtrele :";
            this.lblFiltrele.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblEmanetKitaplar
            // 
            this.lblEmanetKitaplar.AutoSize = true;
            this.lblEmanetKitaplar.Font = new System.Drawing.Font("Bookman Old Style", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblEmanetKitaplar.Location = new System.Drawing.Point(29, 37);
            this.lblEmanetKitaplar.Name = "lblEmanetKitaplar";
            this.lblEmanetKitaplar.Size = new System.Drawing.Size(161, 21);
            this.lblEmanetKitaplar.TabIndex = 2;
            this.lblEmanetKitaplar.Text = "Emanet Kitaplar";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Tüm Kitaplar",
            "Geciken Kitaplar",
            "Gecikmeyen Kitaplar"});
            this.comboBox1.Location = new System.Drawing.Point(412, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 24);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnAra
            // 
            this.btnAra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(155)))), ((int)(((byte)(241)))));
            this.btnAra.Location = new System.Drawing.Point(476, 77);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(136, 34);
            this.btnAra.TabIndex = 4;
            this.btnAra.Text = "Arama Yap";
            this.btnAra.UseVisualStyleBackColor = false;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // EmanetKitaplar_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(786, 486);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblEmanetKitaplar);
            this.Controls.Add(this.lblFiltrele);
            this.Controls.Add(this.dataGridView1);
            this.Name = "EmanetKitaplar_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmanetKitaplar_Form";
            this.Load += new System.EventHandler(this.EmanetKitaplar_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblFiltrele;
        private System.Windows.Forms.Label lblEmanetKitaplar;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnAra;
    }
}