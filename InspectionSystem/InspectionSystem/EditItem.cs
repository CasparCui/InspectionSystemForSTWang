using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace InspectionSystem
{
    public partial class EditItem : Form
    {
        private Object lockObject = new Object();
        public EditItem(ListViewItem item,String filePath)
        {
            InitializeComponent();
            ProjectIdText.Text = item.SubItems[0].Text;
            NameText.Text = item.SubItems[1].Text;
            DateData.Value = DateTime.Parse(item.SubItems[2].Text);
            DictionaryText.Text = item.SubItems[3].Text;
            String name = item.SubItems[1].Text;
            String projectId = item.SubItems[0].Text;
            String date = item.SubItems[2].Text;
            String dictionary = item.SubItems[3].Text;
            String line = String.Format("{0},{1},{2},{3}", projectId, name, date, dictionary);
            this.Tag = line;
            NameText.Tag = filePath;
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<String> tempList = new List<string>();
                String name = NameText.Text;
                String projectId = ProjectIdText.Text;
                String date = DateData.Value.ToString("yyyy-MM-dd");
                String dictionary = DictionaryText.Text;
                if (name != String.Empty && projectId != String.Empty && date != String.Empty && dictionary != String.Empty)
                {
                    String line = String.Format("{0},{1},{2},{3}", projectId, name, date, dictionary);
                    using (StreamReader reader = new StreamReader(NameText.Tag as String, Encoding.Unicode))
                    {
                        lock (lockObject)
                        {

                            while (true)
                            {
                                String readLine = reader.ReadLine();
                                if (readLine == null)
                                    break;
                                if (readLine != Tag as String)
                                    tempList.Add(readLine);
                                else
                                    tempList.Add(line);
                            }
                        }
                    }
                    using (StreamWriter writer = new StreamWriter(NameText.Tag as String, false, Encoding.Unicode))
                    {
                        lock (lockObject)
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
                else
                {
                    throw new FormatException("输入不能为空值！");
                }
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