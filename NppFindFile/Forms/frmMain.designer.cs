using System.Windows.Forms;

namespace Kbg.NppPluginNET
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.lsViewFiles = new System.Windows.Forms.ListView();
            this.clName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.chkRegular = new System.Windows.Forms.CheckBox();
            this.chkExtension = new System.Windows.Forms.CheckBox();
            this.txtExtension = new System.Windows.Forms.TextBox();
            this.chkContain = new System.Windows.Forms.CheckBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnGetCurPath = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(10, 10);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(570, 20);
            this.txtPath.TabIndex = 2;
            this.txtPath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(10, 36);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(215, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(516, 83);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(64, 20);
            this.btnFind.TabIndex = 1;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // lsViewFiles
            // 
            this.lsViewFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsViewFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clName,
            this.clPath});
            this.lsViewFiles.ContextMenuStrip = this.contextMenuStrip1;
            this.lsViewFiles.FullRowSelect = true;
            this.lsViewFiles.GridLines = true;
            this.lsViewFiles.HideSelection = false;
            this.lsViewFiles.Location = new System.Drawing.Point(0, 121);
            this.lsViewFiles.Name = "lsViewFiles";
            this.lsViewFiles.Size = new System.Drawing.Size(673, 286);
            this.lsViewFiles.TabIndex = 3;
            this.lsViewFiles.UseCompatibleStateImageBehavior = false;
            this.lsViewFiles.View = System.Windows.Forms.View.Details;
            this.lsViewFiles.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.lsViewFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
            // 
            // clName
            // 
            this.clName.Text = "File Name";
            this.clName.Width = 220;
            // 
            // clPath
            // 
            this.clPath.Text = "Path";
            this.clPath.Width = 450;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuCopy});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(103, 26);
            // 
            // toolStripMenuCopy
            // 
            this.toolStripMenuCopy.Name = "toolStripMenuCopy";
            this.toolStripMenuCopy.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuCopy.Text = "Copy";
            this.toolStripMenuCopy.Click += new System.EventHandler(this.toolStripMenuCopy_Click);
            // 
            // chkRegular
            // 
            this.chkRegular.AutoSize = true;
            this.chkRegular.Location = new System.Drawing.Point(502, 39);
            this.chkRegular.Name = "chkRegular";
            this.chkRegular.Size = new System.Drawing.Size(63, 17);
            this.chkRegular.TabIndex = 4;
            this.chkRegular.Text = "Regular";
            this.chkRegular.UseVisualStyleBackColor = true;
            this.chkRegular.Visible = false;
            // 
            // chkExtension
            // 
            this.chkExtension.AutoSize = true;
            this.chkExtension.Location = new System.Drawing.Point(10, 86);
            this.chkExtension.Name = "chkExtension";
            this.chkExtension.Size = new System.Drawing.Size(94, 17);
            this.chkExtension.TabIndex = 4;
            this.chkExtension.Text = "Search Parten";
            this.chkExtension.UseVisualStyleBackColor = true;
            this.chkExtension.CheckedChanged += new System.EventHandler(this.chkExtension_CheckedChanged);
            // 
            // txtExtension
            // 
            this.txtExtension.Enabled = false;
            this.txtExtension.Location = new System.Drawing.Point(106, 83);
            this.txtExtension.Name = "txtExtension";
            this.txtExtension.Size = new System.Drawing.Size(119, 20);
            this.txtExtension.TabIndex = 1;
            this.txtExtension.Text = "*.*";
            // 
            // chkContain
            // 
            this.chkContain.AutoSize = true;
            this.chkContain.Checked = true;
            this.chkContain.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkContain.Location = new System.Drawing.Point(373, 39);
            this.chkContain.Name = "chkContain";
            this.chkContain.Size = new System.Drawing.Size(62, 17);
            this.chkContain.TabIndex = 4;
            this.chkContain.Text = "Contain";
            this.chkContain.UseVisualStyleBackColor = true;
            this.chkContain.Visible = false;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(231, 86);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(36, 13);
            this.lblTime.TabIndex = 5;
            this.lblTime.Text = "Time: ";
            // 
            // btnGetCurPath
            // 
            this.btnGetCurPath.Image = global::NppFindFile.Properties.Resources.reload;
            this.btnGetCurPath.Location = new System.Drawing.Point(586, 8);
            this.btnGetCurPath.Name = "btnGetCurPath";
            this.btnGetCurPath.Size = new System.Drawing.Size(39, 23);
            this.btnGetCurPath.TabIndex = 6;
            this.btnGetCurPath.UseVisualStyleBackColor = true;
            this.btnGetCurPath.Click += new System.EventHandler(this.btnGetCurPath_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 407);
            this.Controls.Add(this.btnGetCurPath);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.chkExtension);
            this.Controls.Add(this.chkContain);
            this.Controls.Add(this.chkRegular);
            this.Controls.Add(this.lsViewFiles);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.txtExtension);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.txtPath);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Finder";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtPath;
        private TextBox txtSearch;
        private Button btnFind;
        private ListView lsViewFiles;
        private ColumnHeader clName;
        private ColumnHeader clPath;
        private CheckBox chkRegular;
        private CheckBox chkExtension;
        private TextBox txtExtension;
        private CheckBox chkContain;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuCopy;
        private Label lblTime;
        private Button btnGetCurPath;
    }
}