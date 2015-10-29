using ClassLibrary;
using NHibernateService;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XBNews
{
    public partial class Form1 : Form
    {
        BaseService baseservice = new BaseService();
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 newnews = new Form2(null);
            newnews.ShowDialog();
        }

        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.button2.Cursor = Cursors.WaitCursor;

            select();

            this.button2.Cursor = Cursors.Hand;
        }


        void select()
        {
            this.dataGridView1.Rows.Clear();
            string sql = "select u from News u where u.Subject like '%" + this.textBox1.Text.Trim() + "%'" + " and u.Time >" + this.dateTimePicker1.Value.Date.Ticks.ToString() + " and u.Time < " + this.dateTimePicker2.Value.Date.AddDays(1).Ticks + " and u.State = 0";

            IList i = baseservice.loadEntityList(sql);

            if (i != null && i.Count > 0)
            {

                int num = 1;
                foreach (News n in i)
                {
                    this.dataGridView1.Rows.Add(num, n.Subject, new DateTime(n.Time).ToString("yyyy-MM-dd HH:mm"), "修改", "删除");
                    this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Tag = n;
                    num++;
                }

            }
        
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 3 && this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "修改")
            {
                News nn = this.dataGridView1.Rows[e.RowIndex].Tag as News;
                Form2 f2 = new Form2(nn);
                f2.ShowDialog();
                if (f2.DialogResult == DialogResult.OK)
                {

                    select();
                }
            }
            else if (e.ColumnIndex == 4 && this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "删除")
            {
                if (MessageBox.Show("确定要删除这条记录吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    News nn = this.dataGridView1.Rows[e.RowIndex].Tag as News;
                    nn.State = 1;
                    baseservice.SaveOrUpdateEntity(nn);
                    MessageBox.Show("删除成功！");
                    this.dataGridView1.Rows.RemoveAt(e.RowIndex);
                }
            
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }
    }
}
