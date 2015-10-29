using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace TouchSystem
{
    public partial class TeachersTtroop : Form
    {
        public TeachersTtroop()
        {
            InitializeComponent();
        }

        private void TeachersTtroop_Load(object sender, EventArgs e)
        {
            this.SetVisibleCore(false);
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.SetVisibleCore(true);
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
           
            label1.Font = new System.Drawing.Font("黑体",48,FontStyle.Regular);
            label1.ForeColor = Color.DeepSkyBlue;
            
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.Font = new System.Drawing.Font("黑体", 36, FontStyle.Regular);
            label1.ForeColor = Color.White;
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            label2.Font = new System.Drawing.Font("黑体", 36, FontStyle.Regular);
            label2.ForeColor = Color.DeepSkyBlue;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.Font = new System.Drawing.Font("黑体", 28, FontStyle.Regular);
            label2.ForeColor = Color.White;
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            label3.Font = new System.Drawing.Font("黑体", 36, FontStyle.Regular);
            label3.ForeColor = Color.DeepSkyBlue;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.Font = new System.Drawing.Font("黑体", 28, FontStyle.Regular);
            label3.ForeColor = Color.White;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            SP_SZGK szgk = new SP_SZGK();
            szgk.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            SP_CXTD cxtd = new SP_CXTD();
            cxtd.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            SP_JCRC jcrc = new SP_JCRC();
            jcrc.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.Font = new System.Drawing.Font("黑体", 28, FontStyle.Regular);
            label5.ForeColor = Color.White;
        }

        private void label5_MouseMove(object sender, MouseEventArgs e)
        {
            label5.Font = new System.Drawing.Font("黑体", 36, FontStyle.Regular);
            label5.ForeColor = Color.DeepSkyBlue;
        }
    }
}
