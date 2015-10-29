using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Diagnostics;
using Microsoft.Win32;

namespace TouchSystem
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.SetVisibleCore(false);
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.SetVisibleCore(true);

            this.pictureBox8.Size = new Size(300,300);
          
        }

        #region menu

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //学校简介
            SchoolProfile h = new SchoolProfile();
            h.ShowDialog();
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.BackgroundImage = TouchSystem.Properties.Resources.学校概况_副本;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = TouchSystem.Properties.Resources.学校概况;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            TeachersTtroop h=new TeachersTtroop();
            h.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ZZJG h = new ZZJG();
            h.ShowDialog();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DepartSet h = new DepartSet();
            h.ShowDialog();
        }




        /// <summary>
        /// 楼层分布
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            LCFB h = new LCFB();
            h.ShowDialog();
        }



        /// <summary>
        /// 校园风光
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            XYFG h = new XYFG();
            h.ShowDialog();
        }

        /// <summary>
        /// 校友之家
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            XYZJ h = new XYZJ();
            h.ShowDialog();
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox4.BackgroundImage = TouchSystem.Properties.Resources.师资队伍_副本;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackgroundImage = TouchSystem.Properties.Resources.师资队伍;
        }

        private void pictureBox6_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox6.BackgroundImage = TouchSystem.Properties.Resources.组织机构_副本;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackgroundImage = TouchSystem.Properties.Resources.组织机构;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox1.BackgroundImage = TouchSystem.Properties.Resources.院系设置_副本;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = TouchSystem.Properties.Resources.院系设置;
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox3.BackgroundImage = TouchSystem.Properties.Resources.校友之家_副本;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackgroundImage = TouchSystem.Properties.Resources.校友之家;
        }

        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox5.BackgroundImage = TouchSystem.Properties.Resources.校园风光_副本;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.BackgroundImage = TouchSystem.Properties.Resources.校园风光;
        }

        private void pictureBox7_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox7.BackgroundImage = TouchSystem.Properties.Resources.楼层分布_副本;
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.BackgroundImage = TouchSystem.Properties.Resources.楼层分布;
        }
        #endregion


        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }     

    }
}
