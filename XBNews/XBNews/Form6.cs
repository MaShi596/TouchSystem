using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XBNews
{
    public partial class Form6 : Form
    {
        FileUpDown fileop;
        public Form6()
        {
            InitializeComponent();
            fileop = new FileUpDown("115.24.170.44", "FtpUser", "xiaoban");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Cursor = Cursors.WaitCursor;
            OpenFileDialog opdialog = new OpenFileDialog();
            opdialog.InitialDirectory = @"C:\";
            opdialog.FilterIndex = 1;
            opdialog.Filter = "Image   Files(*.mp4)|*.mp4";
            if (opdialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.button1.Text = "正在上传…请等待…";

                    fileop.Upload(opdialog.FileName, "video");

                    FileInfo fi = new FileInfo (opdialog.FileName);
                    if (fi.Name.IndexOf(' ') > 0)
                        fileop.Rename(fi.Name, fi.Name.Replace(' ', '_'), "video");
                    RefreshDataView();
                    MessageBox.Show("上传成功！");
            }
            this.button1.Cursor = Cursors.Hand;
             this.button1.Text = "上传视频（请选择Mp4格式）";
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            RefreshDataView();
        }
        void RefreshDataView()
        {
            string[] names = fileop.GetFilesDetailList("video");
            this.dataGridView1.Rows.Clear();
            foreach (string o in names)
            {
                string thename = o.Substring(o.LastIndexOf(' ')+1).Trim();
                this.dataGridView1.Rows.Add(thename, "删除");
                this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Tag = thename;

            }

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "删除")
            {
                if (MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    fileop.DeleteFileName(this.dataGridView1.Rows[e.RowIndex].Tag.ToString(), "video");
                    RefreshDataView();
                }
            }
        }
    }
}
