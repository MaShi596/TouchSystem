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
    public partial class SP_JCRC : Form
    {
        public SP_JCRC()
        {
            InitializeComponent();
        }

        private void SP_JCRC_Load(object sender, EventArgs e)
        {

            this.SetVisibleCore(false);
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.SetVisibleCore(true);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox1.BackgroundImage = TouchSystem.Properties.Resources.师资概况_返回副本;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = TouchSystem.Properties.Resources.师资概况_返回;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.BackgroundImage = TouchSystem.Properties.Resources.专家_副本;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = TouchSystem.Properties.Resources.专家;
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox3.BackgroundImage = TouchSystem.Properties.Resources.学者_副本;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackgroundImage = TouchSystem.Properties.Resources.学者;
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox4.BackgroundImage = TouchSystem.Properties.Resources.名师_副本;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackgroundImage = TouchSystem.Properties.Resources.名师;
        }

        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox5.BackgroundImage = TouchSystem.Properties.Resources.人才_副本;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.BackgroundImage = TouchSystem.Properties.Resources.人才;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.pictureBox6.Image = TouchSystem.Properties.Resources.专家1;
            this.label1.Text = "专   家";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.pictureBox6.Image = TouchSystem.Properties.Resources.学者1;
            this.label1.Text = "学   者";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.pictureBox6.Image = TouchSystem.Properties.Resources.名师1;
            this.label1.Text = "名   师";
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.pictureBox6.Image = TouchSystem.Properties.Resources.人才1;
            this.label1.Text = "人   才 ";
        }

       
    }
}
