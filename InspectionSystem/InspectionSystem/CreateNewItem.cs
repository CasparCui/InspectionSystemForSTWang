using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace InspectionSystem
{
    public partial class CreateNewItem : Form
    {
        private Object lockObject = new Object();
        public CreateNewItem(String filePath)
        {
            InitializeComponent();
            NameText.Tag = filePath;
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            try
            {
                String name = NameText.Text;
                String projectId = ProjectIdText.Text;
                String date = DateData.Value.ToString("yyyy-MM-dd");
                String dictionary = DictionaryText.Text;
                if (name != String.Empty && projectId != String.Empty && date != String.Empty && dictionary != String.Empty)
                {
                    String line = String.Format("{0},{1},{2},{3}", projectId, name, date, dictionary);
                    using (StreamWriter writer = new StreamWriter(NameText.Tag as String, true, Encoding.Unicode))
                    {
                        lock (lockObject)
                        {

                            writer.WriteLine(line);
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

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}