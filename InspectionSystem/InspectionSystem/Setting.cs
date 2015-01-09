using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace InspectionSystem
{
    public partial class Setting : Form
    {
        private Object lockObject = new Object();
        public Setting(ListViewItem item,String filePath)
        {
            InitializeComponent();
            ProjectIdText.Text = item.SubItems[0].Text;
            NameText.Text = item.SubItems[1].Text;
            dateTimePicker1.Value = DateTime.Parse(item.SubItems[2].Text);
            DictionaryText.Text = item.SubItems[3].Text;
            comboBox1.SelectedItem = comboBox1.Items[0];
            dateTimePicker1.Enabled = false;
            String name = item.SubItems[1].Text;
            String projectId = item.SubItems[0].Text;
            String date = item.SubItems[2].Text;
            String dictionary = item.SubItems[3].Text;
            String line = String.Format("{0},{1},{2},{3}", projectId, name, date, dictionary);
            this.Tag = line;
            NameText.Tag = filePath;
        }

        private void Setting_Load(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "自定义")
                dateTimePicker1.Enabled = true;
            else
                dateTimePicker1.Enabled = false;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<String> tempList = new List<string>();
                String name = NameText.Text;
                String projectId = ProjectIdText.Text;
                String date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                String dictionary = DictionaryText.Text;
                if (comboBox1.SelectedItem.ToString() == "一天后")
                {
                    date = dateTimePicker1.Value.AddDays(1).ToString("yyyy-MM-dd");
                }
                else if (comboBox1.SelectedItem.ToString() == "一周后")
                {
                    date = dateTimePicker1.Value.AddDays(7).ToString("yyyy-MM-dd");
                }
                else if (comboBox1.SelectedItem.ToString() == "一月后")
                {
                    date = dateTimePicker1.Value.AddMonths(1).ToString("yyyy-MM-dd");
                }
                else
                {
                    date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                }

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
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancleButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}