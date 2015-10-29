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
    public partial class LCFB : Form
    {
        public LCFB()
        {
            InitializeComponent();
        }

        private void LCFB_Load(object sender, EventArgs e)
        {
            this.SetVisibleCore(false);
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.SetVisibleCore(true);
        }


        #region
        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            this.label1.Font = new Font ("微软雅黑",20);
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            this.label1.Font = new Font("微软雅黑",25);
        }

        #endregion

        private void A1_Click(object sender, EventArgs e)
        {
            this.pictureBox11.Image = TouchSystem.Properties.Resources.A区1楼;
        }

        private void A2_Click(object sender, EventArgs e)
        {
            this.pictureBox11.Image = TouchSystem.Properties.Resources.A区2楼;
        }

        private void A3_Click(object sender, EventArgs e)
        {
            this.pictureBox11.Image = TouchSystem.Properties.Resources.A区3楼;
        }

        private void A4_Click(object sender, EventArgs e)
        {
            this.pictureBox11.Image = TouchSystem.Properties.Resources.A区4楼;
        }

        private void A5_Click(object sender, EventArgs e)
        {
            this.pictureBox11.Image = TouchSystem.Properties.Resources.A区5楼;
        }

        private void B1_Click(object sender, EventArgs e)
        {
            this.pictureBox11.Image = TouchSystem.Properties.Resources.B区1楼;
        }

        private void B2_Click(object sender, EventArgs e)
        {
            this.pictureBox11.Image = TouchSystem.Properties.Resources.B区2楼;
        }

        private void B3_Click(object sender, EventArgs e)
        {
            this.pictureBox11.Image = TouchSystem.Properties.Resources.B区3楼;
        }

        private void B4_Click(object sender, EventArgs e)
        {
            this.pictureBox11.Image = TouchSystem.Properties.Resources.B区4楼;

        }

        private void B5_Click(object sender, EventArgs e)
        {
            this.pictureBox11.Image = TouchSystem.Properties.Resources.B区5楼;

        }

        private void A1_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pic.BackgroundImage = TouchSystem.Properties.Resources.Bg;
        }

        private void A1_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pic.BackgroundImage = TouchSystem.Properties.Resources.BgFocus;
        }

        private void A1_MouseDown(object sender, MouseEventArgs e)
        {
            this.A1.BackgroundImage = TouchSystem.Properties.Resources.Bg;
            this.A2.BackgroundImage = TouchSystem.Properties.Resources.Bg;
            this.A3.BackgroundImage = TouchSystem.Properties.Resources.Bg;
            this.A4.BackgroundImage = TouchSystem.Properties.Resources.Bg;
            this.A5.BackgroundImage = TouchSystem.Properties.Resources.Bg;

            this.B1.BackgroundImage = TouchSystem.Properties.Resources.Bg;
            this.B2.BackgroundImage = TouchSystem.Properties.Resources.Bg;
            this.B3.BackgroundImage = TouchSystem.Properties.Resources.Bg;
            this.B4.BackgroundImage = TouchSystem.Properties.Resources.Bg;
            this.B5.BackgroundImage = TouchSystem.Properties.Resources.Bg;


            PictureBox pic = (PictureBox)sender;
            pic.BackgroundImage = TouchSystem.Properties.Resources.BgFocus;

        }

        


    }
}
