
namespace Dorisoy.EmailAuto
{
    partial class FrmEmailBook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmailBook));
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuISelectNone = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripImport = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.toolStripMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToResizeRows = false;
            this.dgvList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(0, 36);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersWidth = 62;
            this.dgvList.RowTemplate.Height = 33;
            this.dgvList.Size = new System.Drawing.Size(1769, 579);
            this.dgvList.TabIndex = 3;
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.toolStripButtonDelete,
            this.toolStripImport});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(1769, 33);
            this.toolStripMenu.TabIndex = 5;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuSelectAll,
            this.toolStripMenuISelectNone});
            this.toolStripSplitButton1.Image = global::Dorisoy.EmailAuto.Properties.Resources.checkbox_unchecked;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(45, 28);
            this.toolStripSplitButton1.Text = "Select Options";
            // 
            // toolStripMenuSelectAll
            // 
            this.toolStripMenuSelectAll.Name = "toolStripMenuSelectAll";
            this.toolStripMenuSelectAll.Size = new System.Drawing.Size(270, 34);
            this.toolStripMenuSelectAll.Text = "全选";
            // 
            // toolStripMenuISelectNone
            // 
            this.toolStripMenuISelectNone.Name = "toolStripMenuISelectNone";
            this.toolStripMenuISelectNone.Size = new System.Drawing.Size(270, 34);
            this.toolStripMenuISelectNone.Text = "反选";
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.toolStripButtonDelete.Image = global::Dorisoy.EmailAuto.Properties.Resources.delete;
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(74, 28);
            this.toolStripButtonDelete.Text = "删除";
            // 
            // toolStripImport
            // 
            this.toolStripImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripImport.Image = ((System.Drawing.Image)(resources.GetObject("toolStripImport.Image")));
            this.toolStripImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripImport.Name = "toolStripImport";
            this.toolStripImport.Size = new System.Drawing.Size(50, 28);
            this.toolStripImport.Text = "导入";
            // 
            // FrmEmailBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1769, 614);
            this.Controls.Add(this.toolStripMenu);
            this.Controls.Add(this.dgvList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "FrmEmailBook";
            this.Text = "邮件簿";
            this.Load += new System.EventHandler(this.FrmEmailBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton toolStripImport;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuSelectAll;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuISelectNone;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
    }
}