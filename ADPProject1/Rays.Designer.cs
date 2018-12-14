namespace ADPProject1
{
    partial class Rays
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnHome = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chestPanel = new System.Windows.Forms.Panel();
            this.txtChest = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelChest = new System.Windows.Forms.Button();
            this.btnSaveChesst = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtAbdominal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSaveAbd = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMct = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancelMsct = new System.Windows.Forms.Button();
            this.btnsaveMSCt = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.chestPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnHome,
            this.toolStripSeparator4,
            this.btnSave,
            this.toolStripSeparator2,
            this.btnSearch,
            this.txtSearch,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.MinimumSize = new System.Drawing.Size(0, 40);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(739, 40);
            this.toolStrip1.TabIndex = 101;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnHome
            // 
            this.btnHome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHome.Image = global::ADPProject1.Properties.Resources.home__2_1;
            this.btnHome.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnHome.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(38, 37);
            this.btnHome.Text = "toolStripButton2";
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 40);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::ADPProject1.Properties.Resources.save1___Copy;
            this.btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(44, 37);
            this.btnSave.Text = "toolStripButton1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // btnSearch
            // 
            this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSearch.Image = global::ADPProject1.Properties.Resources.search1;
            this.btnSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(23, 37);
            this.btnSearch.Text = "toolStripButton1";
            // 
            // txtSearch
            // 
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 40);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 40);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 34);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(236, 503);
            this.dataGridView1.TabIndex = 148;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // chestPanel
            // 
            this.chestPanel.Controls.Add(this.txtChest);
            this.chestPanel.Controls.Add(this.label1);
            this.chestPanel.Controls.Add(this.btnCancelChest);
            this.chestPanel.Controls.Add(this.btnSaveChesst);
            this.chestPanel.Location = new System.Drawing.Point(243, 44);
            this.chestPanel.Name = "chestPanel";
            this.chestPanel.Size = new System.Drawing.Size(484, 537);
            this.chestPanel.TabIndex = 149;
            // 
            // txtChest
            // 
            this.txtChest.Location = new System.Drawing.Point(125, 133);
            this.txtChest.Multiline = true;
            this.txtChest.Name = "txtChest";
            this.txtChest.Size = new System.Drawing.Size(263, 104);
            this.txtChest.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chest X Ray";
            // 
            // btnCancelChest
            // 
            this.btnCancelChest.Location = new System.Drawing.Point(277, 337);
            this.btnCancelChest.Name = "btnCancelChest";
            this.btnCancelChest.Size = new System.Drawing.Size(67, 32);
            this.btnCancelChest.TabIndex = 1;
            this.btnCancelChest.Text = "Cancel";
            this.btnCancelChest.UseVisualStyleBackColor = true;
            this.btnCancelChest.Click += new System.EventHandler(this.btnCancelChest_Click);
            // 
            // btnSaveChesst
            // 
            this.btnSaveChesst.Location = new System.Drawing.Point(170, 337);
            this.btnSaveChesst.Name = "btnSaveChesst";
            this.btnSaveChesst.Size = new System.Drawing.Size(67, 32);
            this.btnSaveChesst.TabIndex = 0;
            this.btnSaveChesst.Text = "OK";
            this.btnSaveChesst.UseVisualStyleBackColor = true;
            this.btnSaveChesst.Click += new System.EventHandler(this.btnSaveChesst_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtAbdominal);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtSaveAbd);
            this.panel1.Location = new System.Drawing.Point(243, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 537);
            this.panel1.TabIndex = 150;
            // 
            // txtAbdominal
            // 
            this.txtAbdominal.Location = new System.Drawing.Point(125, 133);
            this.txtAbdominal.Multiline = true;
            this.txtAbdominal.Name = "txtAbdominal";
            this.txtAbdominal.Size = new System.Drawing.Size(263, 104);
            this.txtAbdominal.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Abdominal U/S";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(277, 337);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSaveAbd
            // 
            this.txtSaveAbd.Location = new System.Drawing.Point(170, 337);
            this.txtSaveAbd.Name = "txtSaveAbd";
            this.txtSaveAbd.Size = new System.Drawing.Size(67, 32);
            this.txtSaveAbd.TabIndex = 0;
            this.txtSaveAbd.Text = "OK";
            this.txtSaveAbd.UseVisualStyleBackColor = true;
            this.txtSaveAbd.Click += new System.EventHandler(this.txtSaveAbd_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtMct);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btnCancelMsct);
            this.panel2.Controls.Add(this.btnsaveMSCt);
            this.panel2.Location = new System.Drawing.Point(240, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(484, 537);
            this.panel2.TabIndex = 152;
            // 
            // txtMct
            // 
            this.txtMct.Location = new System.Drawing.Point(125, 133);
            this.txtMct.Multiline = true;
            this.txtMct.Name = "txtMct";
            this.txtMct.Size = new System.Drawing.Size(263, 104);
            this.txtMct.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "MSCT";
            // 
            // btnCancelMsct
            // 
            this.btnCancelMsct.Location = new System.Drawing.Point(277, 337);
            this.btnCancelMsct.Name = "btnCancelMsct";
            this.btnCancelMsct.Size = new System.Drawing.Size(67, 32);
            this.btnCancelMsct.TabIndex = 1;
            this.btnCancelMsct.Text = "Cancel";
            this.btnCancelMsct.UseVisualStyleBackColor = true;
            this.btnCancelMsct.Click += new System.EventHandler(this.btnCancelMsct_Click_1);
            // 
            // btnsaveMSCt
            // 
            this.btnsaveMSCt.Location = new System.Drawing.Point(170, 337);
            this.btnsaveMSCt.Name = "btnsaveMSCt";
            this.btnsaveMSCt.Size = new System.Drawing.Size(67, 32);
            this.btnsaveMSCt.TabIndex = 0;
            this.btnsaveMSCt.Text = "OK";
            this.btnsaveMSCt.UseVisualStyleBackColor = true;
            this.btnsaveMSCt.Click += new System.EventHandler(this.btnsaveMSCt_Click_1);
            // 
            // Rays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 593);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chestPanel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Rays";
            this.Text = "Rays";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Rays_FormClosed);
            this.Load += new System.EventHandler(this.Rays_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.chestPanel.ResumeLayout(false);
            this.chestPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnHome;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel chestPanel;
        private System.Windows.Forms.TextBox txtChest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelChest;
        private System.Windows.Forms.Button btnSaveChesst;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtAbdominal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button txtSaveAbd;
        private System.Windows.Forms.Button btnsaveMSCt;
        private System.Windows.Forms.Button btnCancelMsct;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMct;
        private System.Windows.Forms.Panel panel2;
    }
}