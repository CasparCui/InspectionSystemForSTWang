using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace InspectionSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            try
            {
                FileInfo file = new FileInfo(@"c:\1.txt");
                if (!file.Exists)
                {
                    using (File.Create(@"c:\1.txt"))
                    {
                    }
                }
            }
            catch
            {
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Edit.Enabled = false;
            Dropt.Enabled = false;
            Create.Enabled = false;
            Refrash.Enabled = false;
            ReAlert.Enabled = false;
            另存为ToolStripMenuItem.Enabled = false;
        }

        private void Create_Click(object sender, EventArgs e)
        {
            CreateNewItem newItem = new CreateNewItem(打开ToolStripMenuItem.Tag as String);
            newItem.Show();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                EditItem editItem = new EditItem(listView1.SelectedItems[0], 打开ToolStripMenuItem.Tag as String);
                editItem.Show();
            }
        }

        private void Refrash_Click(object sender, EventArgs e)
        {
            Edit.Enabled = false;
            Dropt.Enabled = false;
            listView1.Clear();
            new Function().refreshFile(打开ToolStripMenuItem.Tag as String, listView1);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                Edit.Enabled = false;
                Dropt.Enabled = false;
            }
            else
            {
                Edit.Enabled = true;
                Dropt.Enabled = true;
            }
        }

        private void Dropt_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                Drop drop = new Drop(listView1.SelectedItems[0], 打开ToolStripMenuItem.Tag as String);
                drop.Show();
            }
        }

        private void ReAlert_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            Form1_Load(sender, e);
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                Setting setting = new Setting(item, 打开ToolStripMenuItem.Tag as String);
                setting.Show();
            }
        }

        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "数据文档|*.isdat";
            openFile.ShowDialog();
            String filePath = openFile.FileName;
            new Function().openFile(filePath, listView1);
            打开ToolStripMenuItem.Tag = filePath;
            Create.Enabled = true;
            Refrash.Enabled = true;
            ReAlert.Enabled = true;
            另存为ToolStripMenuItem.Enabled = true;
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

        }

        private void 另存为ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            if (打开ToolStripMenuItem.Tag != null && 打开ToolStripMenuItem.Tag as String != "")
            {
               String  openedFilePath  = 打开ToolStripMenuItem.Tag as String;
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "数据文档|*.isdat";
                saveFile.ShowDialog();
                String filePath = saveFile.FileName;
                new Function().saveFile(openedFilePath, filePath);
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}