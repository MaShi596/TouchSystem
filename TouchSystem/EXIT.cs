using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text;


namespace TouchSystem
{
    public partial class EXIT : Form
    {
        public EXIT()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string strLine;
            FileStream aFile = new FileStream("code.txt",FileMode.Open);
            StreamReader sr = new StreamReader(aFile);
            strLine = sr.ReadLine();

            if (textBox1.Text.Equals(strLine))
            {
                MessageBox.Show("密码正确，程序即将退出。");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("密码错误！");
                this.DialogResult = DialogResult.Cancel;
            }
            sr.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                button1_Click(sender, e);
        }
    }
}
