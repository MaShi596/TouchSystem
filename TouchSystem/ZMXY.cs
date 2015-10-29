using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TouchSystem
{
    public partial class ZMXY : Form
    {
        public ZMXY()
        {
            InitializeComponent();
        }
        int page;
        Image[] pages;
        private void ZMXY_Load(object sender, EventArgs e)
        {
            this.SetVisibleCore(false);
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.SetVisibleCore(true);
            this.pictureBox1.Image = TouchSystem.Properties.Resources.ZhiMingPage1;
            page = 1;
            pages = new Image[2];
            pages[0] = TouchSystem.Properties.Resources.ZhiMingPage1;
            pages[1] = TouchSystem.Properties.Resources.ZhiMingPage2;
        }


        private void label1_MouseLeave(object sender, EventArgs e)
        {
            Label la = (Label)sender;
            la.Font = new Font("微软雅黑",20);
        }



        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            Label la = (Label)sender;
            la.Font = new Font("微软雅黑", 25);
        }


        /// <summary>
        /// 第一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = TouchSystem.Properties.Resources.ZhiMingPage1;
            
        }


        /// <summary>
        /// 返回按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = TouchSystem.Properties.Resources.ZhiMingPage2;
        }
    }
}
