using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace InspectionSystem
{
    public partial class Drop : Form
    {
        private Object lockObjeck = new Object();
        public Drop(ListViewItem item,String filePath)
        {
            InitializeComponent();
            String name = item.SubItems[1].Text;
            String projectId = item.SubItems[0].Text;
            String date = item.SubItems[2].Text;
            String dictionary = item.SubItems[3].Text;
            String line = String.Format("{0},{1},{2},{3}", projectId, name, date, dictionary);
            this.Tag = line;
            CancelButton.Tag = filePath;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<String> tempList = new List<string>();
                DirectoryInfo dir = new DirectoryInfo(@"c:\backup_Format");
                dir.Create();
                String backupFileName = String.Format(@"c:\backup_Format\{0}", DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss"));
                using (StreamWriter writer = new StreamWriter(backupFileName + ".isdat", false, Encoding.Unicode))
                using (StreamReader reader = new StreamReader(CancelButton.Tag as String, Encoding.Unicode))
                {
                    lock (lockObjeck)
                    {
                        while (true)
                        {


                            String readLine = reader.ReadLine();
                            if (readLine == null)
                                break;
                            writer.WriteLine(readLine);
                            if (readLine != Tag as String)
                                tempList.Add(readLine);
                        }
                    }
                }
                using (StreamWriter writer = new StreamWriter(CancelButton.Tag as String, false, Encoding.Unicode))
                {
                    lock (lockObjeck)
                    {

                        while (tempList.Count != 0)
                        {
                            writer.WriteLine(tempList[0]);
                            tempList.RemoveAt(0);
                        }
                    }
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}