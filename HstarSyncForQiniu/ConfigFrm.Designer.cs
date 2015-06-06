namespace HstarSyncForQiniu
{
    partial class ConfigFrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TbSecretKey = new System.Windows.Forms.TextBox();
            this.TbAccessKey = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DgvSpaceConfig = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSpaceConfig)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ACCESS_KEY：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "SECRET_KEY：";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(455, 311);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.TbSecretKey);
            this.tabPage1.Controls.Add(this.TbAccessKey);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(447, 285);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "访问KEY配置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // TbSecretKey
            // 
            this.TbSecretKey.Location = new System.Drawing.Point(109, 64);
            this.TbSecretKey.Name = "TbSecretKey";
            this.TbSecretKey.Size = new System.Drawing.Size(307, 20);
            this.TbSecretKey.TabIndex = 2;
            // 
            // TbAccessKey
            // 
            this.TbAccessKey.Location = new System.Drawing.Point(109, 26);
            this.TbAccessKey.Name = "TbAccessKey";
            this.TbAccessKey.Size = new System.Drawing.Size(307, 20);
            this.TbAccessKey.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DgvSpaceConfig);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(447, 285);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "空间配置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DgvSpaceConfig
            // 
            this.DgvSpaceConfig.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvSpaceConfig.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DgvSpaceConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvSpaceConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.DgvSpaceConfig.GridColor = System.Drawing.SystemColors.Control;
            this.DgvSpaceConfig.Location = new System.Drawing.Point(3, 3);
            this.DgvSpaceConfig.Name = "DgvSpaceConfig";
            this.DgvSpaceConfig.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvSpaceConfig.ShowEditingIcon = false;
            this.DgvSpaceConfig.Size = new System.Drawing.Size(441, 247);
            this.DgvSpaceConfig.TabIndex = 0;
            // 
            // ConfigFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 311);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "配置";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvSpaceConfig)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox TbSecretKey;
        private System.Windows.Forms.TextBox TbAccessKey;
        private System.Windows.Forms.DataGridView DgvSpaceConfig;
    }
}