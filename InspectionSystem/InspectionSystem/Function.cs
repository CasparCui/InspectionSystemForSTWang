using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace InspectionSystem
{
    public enum color
    {
        red = 0,
        yellow = 1,
        blue = 2
    }

    public class Function
    {
        public color showLineColor(DateTime date)
        {
            DateTime dataNow = DateTime.Now;
            TimeSpan days = date - dataNow;
            int Day = days.Days;
            if (Day >= 30)
            {
                return color.blue;
            }
            else if (Day > 0)
            {
                return color.yellow;
            }
            else
            {
                return color.red;
            }
        }

        public int GetSurplusDays(DateTime date)
        {
            DateTime dataNow = DateTime.Now;
            TimeSpan days = date - dataNow;
            int Day = days.Days;
            return Day;
        }
        public void openFile(String filePath, ListView listView1)
        {
            try
            {

                listView1.Clear();
                List<ListViewItem> listRed = new List<ListViewItem>();
                List<ListViewItem> listYellow = new List<ListViewItem>();
                List<ListViewItem> listBlue = new List<ListViewItem>();
                listView1.GridLines = true;//表格是否显示网格线
                listView1.FullRowSelect = true;//是否选中整行


                listView1.View = View.Details;//设置显示方式
                listView1.Scrollable = true;//是否自动显示滚动条
                listView1.MultiSelect = false;//是否可以选择多行

                //添加表头（列）
                listView1.Columns.Add("ProductId", "编号");
                listView1.Columns.Add("Name", "名称");
                listView1.Columns.Add("Date", "送检日期");
                listView1.Columns.Add("Dictionary", "备注");

                //添加表格内容

                using (StreamReader reader = new StreamReader(filePath, Encoding.Unicode))
                {
                    while (true)
                    {
                        String line = reader.ReadLine();
                        if (line == null)
                            break;
                        ListViewItem item = new ListViewItem();
                        String[] subItemTest = line.Split(',');
                        int times = subItemTest.Length;
                        item.SubItems[0].Text = subItemTest[0];
                        for (int i = 1; i < times; i++)
                        {
                            item.SubItems.Add(subItemTest[i]);
                            if (i == 2)
                            {
                                DateTime timeLoad = DateTime.Parse(subItemTest[i]);
                                color color = showLineColor(timeLoad);
                                switch (color)
                                {
                                    case color.red:
                                        item.ForeColor = Color.Red;
                                        //MessageBox.Show(String.Format("工件{0}应于{1}检修！", subItemTest[0], subItemTest[2]));
                                        break;

                                    case color.yellow:
                                        item.ForeColor = Color.Gold;
                                        //MessageBox.Show(String.Format("距离工件{0}的检修时间{1}还有{2}天！", subItemTest[0], subItemTest[2],new Function().GetSurplusDays(timeLoad)));
                                        break;

                                    case color.blue:
                                        item.ForeColor = Color.Blue;
                                        break;

                                    default:
                                        break;
                                }
                            }
                        }
                        if (item.ForeColor == Color.Red)
                        {
                            listRed.Add(item);
                            Thread show = new Thread(() =>
                            {
                                MessageBox.Show(String.Format("工件{0}应于{1}检修！", item.SubItems[0].Text, item.SubItems[2].Text), "检修提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            });
                            show.Start();
                        }
                        else if (item.ForeColor == Color.Gold)
                        {
                            listYellow.Add(item);
                            Thread show = new Thread(() =>
                            {
                                MessageBox.Show(String.Format("距离工件{0}的检修时间{1}还有{2}天！", item.SubItems[0].Text, item.SubItems[2].Text, GetSurplusDays(DateTime.Parse(item.SubItems[2].Text))), "检修提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            });
                            show.Start();
                        }
                        else if (item.ForeColor == Color.Blue)
                        {
                            listBlue.Add(item);
                        }
                    }
                }
                foreach (ListViewItem item in listRed)
                {
                    listView1.Items.Add(item);
                }
                foreach (ListViewItem item in listYellow)
                {
                    listView1.Items.Add(item);
                }
                foreach (ListViewItem item in listBlue)
                {
                    listView1.Items.Add(item);
                }
                for (int i = 0; i < listView1.Columns.Count; i++)//自适应显示。
                {
                    listView1.Columns[i].Width = -1;
                }
                for (int i = 0; i < listView1.Columns.Count; i++)//自适应显示。
                {
                    listView1.Columns[i].Width = -1;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void saveFile(String filePathBefore, String filePathAfter)
        {
            try
            {
                File.Copy(filePathBefore, filePathAfter);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void refreshFile(String filePath, ListView listView1)
        {
            try
            {
                List<ListViewItem> listRed = new List<ListViewItem>();
                List<ListViewItem> listYellow = new List<ListViewItem>();
                List<ListViewItem> listBlue = new List<ListViewItem>();
                listView1.GridLines = true;//表格是否显示网格线
                listView1.FullRowSelect = true;//是否选中整行


                listView1.View = View.Details;//设置显示方式
                listView1.Scrollable = true;//是否自动显示滚动条
                listView1.MultiSelect = false;//是否可以选择多行

                //添加表头（列）
                listView1.Columns.Add("ProductId", "编号");
                listView1.Columns.Add("Name", "名称");
                listView1.Columns.Add("Date", "送检日期");
                listView1.Columns.Add("Dictionary", "备注");

                //添加表格内容

                using (StreamReader reader = new StreamReader(filePath, Encoding.Unicode))
                {
                    while (true)
                    {
                        String line = reader.ReadLine();
                        if (line == null)
                            break;
                        ListViewItem item = new ListViewItem();
                        String[] subItemTest = line.Split(',');
                        int times = subItemTest.Length;
                        item.SubItems[0].Text = subItemTest[0];
                        for (int i = 1; i < times; i++)
                        {
                            item.SubItems.Add(subItemTest[i]);
                            if (i == 2)
                            {
                                DateTime timeLoad = DateTime.Parse(subItemTest[i]);
                                color color = showLineColor(timeLoad);
                                switch (color)
                                {
                                    case color.red:
                                        item.ForeColor = Color.Red;
                                        //MessageBox.Show(String.Format("工件{0}应于{1}检修！", subItemTest[0], subItemTest[2]));
                                        break;

                                    case color.yellow:
                                        item.ForeColor = Color.Gold;
                                        //MessageBox.Show(String.Format("距离工件{0}的检修时间{1}还有{2}天！", subItemTest[0], subItemTest[2],new Function().GetSurplusDays(timeLoad)));
                                        break;

                                    case color.blue:
                                        item.ForeColor = Color.Blue;
                                        break;

                                    default:
                                        break;
                                }
                            }
                        }
                        if (item.ForeColor == Color.Red)
                        {
                            listRed.Add(item);
                        }
                        else if (item.ForeColor == Color.Gold)
                        {
                            listYellow.Add(item);
                        }
                        else if (item.ForeColor == Color.Blue)
                        {
                            listBlue.Add(item);
                        }
                    }
                }
                foreach (ListViewItem item in listRed)
                {
                    listView1.Items.Add(item);
                }
                foreach (ListViewItem item in listYellow)
                {
                    listView1.Items.Add(item);
                }
                foreach (ListViewItem item in listBlue)
                {
                    listView1.Items.Add(item);
                }
                for (int i = 0; i < listView1.Columns.Count; i++)//自适应显示。
                {
                    listView1.Columns[i].Width = -1;
                }
                for (int i = 0; i < listView1.Columns.Count; i++)//自适应显示。
                {
                    listView1.Columns[i].Width = -1;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}