using Kbg.NppPluginNET.PluginInfrastructure;
using NppFindFile;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kbg.NppPluginNET
{
    public partial class frmMain : Form
    {

        private readonly IScintillaGateway editor;
        private readonly INotepadPPGateway notepad;
        public frmMain(IScintillaGateway editor, INotepadPPGateway notepad)
        {
            this.editor = editor;
            this.notepad = notepad;
            InitializeComponent();

            this.Icon = NppFindFile.Properties.Resources.ninja;
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            txtPath.Text = System.IO.Path.GetDirectoryName(notepad.GetCurrentFilePath());
        }

        List<SimpleFileInfo> fileInfos = new List<SimpleFileInfo>();

        void getFiles(string path, List<SimpleFileInfo> fileInfos)
        {
            var lsfiles = Directory.GetFiles(path);
            var lsdirectories = Directory.GetDirectories(path);

            foreach (var lsfile in lsfiles)
            {
                fileInfos.Add(
                    new SimpleFileInfo()
                    {
                        Name = Path.GetFileName(lsfile),
                        FullName = lsfile,
                        Extension = "*" + Path.GetExtension(lsfile),
                        NameWithoutExtension = Path.GetFileNameWithoutExtension(lsfile)
                    });
            }

            foreach (string lsdirectory in lsdirectories)
            {
                getFiles(lsdirectory, fileInfos);
            }

        }

        void SearchParten()
        {
            lblTime.Text = "Searching...";

            if (!Directory.Exists(txtPath.Text))
            {
                MessageBox.Show($"Path: {txtPath.Text} not found!");
                lblTime.Text = $"Time: ";
                return;
            }

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();


            Task.Factory.StartNew(() =>
            {
                fileInfos = new List<SimpleFileInfo>();
                SearchInCurrentDirectory(txtPath.Text, txtSearch.Text, txtExtension.Text);

                //fileInfos
                lsViewFiles.Items.Clear();
                foreach (var item in fileInfos)
                {
                    lsViewFiles.Items.Add(new ListViewItem(new string[] { item.Name, item.FullName }));
                }

                sw.Stop();
                lblTime.Text = $"Found: {lsViewFiles.Items.Count} items. Time: {sw.Elapsed.Minutes.ToString("D2")}:{sw.Elapsed.Seconds.ToString("D2")}:{sw.Elapsed.Milliseconds.ToString("D3")}";
            });

            pathIsChanged = false;
        }

        void SearchInCurrentDirectory(string folder, string searchString, string searchPattern)
        {
            if (!String.IsNullOrWhiteSpace(folder))
            {
                string currentFilePath = folder;

                foreach (var filePath in Directory.GetFiles(currentFilePath, searchPattern, SearchOption.AllDirectories)
                             .AsParallel().Where(e =>
                                 e.IndexOf(searchString, StringComparison.CurrentCultureIgnoreCase) >= 0 ||
                                 e.Contains(searchString))
                             .ToList())
                {
                    fileInfos.Add(new SimpleFileInfo()
                    {
                        Name = Path.GetFileName(filePath),
                        FullName = filePath,
                        Extension = Path.GetExtension(filePath),
                        NameWithoutExtension = Path.GetFileNameWithoutExtension(filePath)
                    });
                }
            }
        }

        private void Search()
        {
            lblTime.Text = "Searching...";

            if (!Directory.Exists(txtPath.Text))
            {
                MessageBox.Show($"Path: {txtPath.Text} not found!");
                lblTime.Text = $"Time: ";
                return;
            }

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            lsViewFiles.Items.Clear();

            //Task.Factory.StartNew(() =>
            //{
            //    Timer timer = new Timer();
            //    timer.Interval = 1000;
            //    timer.Tick += (s,e) => { 

            //    };
            //});

            Task.Factory.StartNew(() =>
            {
                if (pathIsChanged || fileInfos.Count == 0)
                {
                    fileInfos.Clear();
                    getFiles(txtPath.Text, fileInfos);
                }

                IEnumerable<SimpleFileInfo> files = fileInfos.ToList();// .OrderBy(i => i.FullName);

                if (chkExtension.Checked)
                {
                    files = files.Where(i => i.Extension.Equals(txtExtension.Text));
                }

                if (chkContain.Checked)
                {
                    files = files.Where(i => i.NameWithoutExtension.ToLower().Contains(txtSearch.Text.ToLower()));
                }
                else if (chkRegular.Checked)
                {
                    files = files.Where(i =>
                        Regex.Match(i.NameWithoutExtension, txtSearch.Text).Success);
                }
                else
                {
                    files = files.Where(i => i.NameWithoutExtension.ToLower().Equals(txtSearch.Text.ToLower()));
                }

                foreach (var item in files)
                {
                    lsViewFiles.Items.Add(new ListViewItem(new string[] { item.Name, item.FullName }));
                }

                sw.Stop();
                lblTime.Text = $"Found: {lsViewFiles.Items.Count} items. Time: {sw.Elapsed.Minutes.ToString("D2")}:{sw.Elapsed.Seconds.ToString("D2")}:{sw.Elapsed.Milliseconds.ToString("D3")}";

            });
            pathIsChanged = false;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            SearchParten();
        }

        private void chkExtension_CheckedChanged(object sender, EventArgs e)
        {
            txtExtension.Enabled = chkExtension.Checked;
            txtExtension.SelectAll();
        }

        private void toolStripMenuCopy_Click(object sender, EventArgs e)
        {
            if (lsViewFiles.SelectedItems.Count > 0)
            {
                try
                {
                    Clipboard.SetText(lsViewFiles.SelectedItems[0].SubItems[1].Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void openFile()
        {

            if (lsViewFiles.SelectedItems.Count > 0)
            {
                Process.Start("notepad++.exe", lsViewFiles.SelectedItems[0].SubItems[1].Text);
                txtSearch.SelectAll();
                txtSearch.Focus();
                this.Hide();
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            openFile();
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                openFile();
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.Back)
                {
                    e.SuppressKeyPress = true;
                    try
                    {
                        txtPath.Text = Directory.GetParent(txtPath.Text).FullName;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    e.SuppressKeyPress = true;
                    txtSearch.Text = "";
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                SearchParten();
            }
            else if (e.KeyCode == Keys.Down)
            {
                lsViewFiles.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
            }
        }


        bool pathIsChanged = false;
        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            pathIsChanged = true;
        }

        private void btnGetCurPath_Click(object sender, EventArgs e)
        {
            txtPath.Text = System.IO.Path.GetDirectoryName(notepad.GetCurrentFilePath());
        }
    }
}