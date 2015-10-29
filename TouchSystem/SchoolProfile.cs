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
    public partial class SchoolProfile : Form
    {
   
        public SchoolProfile()
        {
            InitializeComponent();
        }

        private void SchoolProfile_Load(object sender, EventArgs e)
        {
            this.SetVisibleCore(false);
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.SetVisibleCore(true);
           // SetLineSpace(richTextBox1,  300 );

            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox1.BackgroundImage = TouchSystem.Properties.Resources.学校简介_副本;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = TouchSystem.Properties.Resources.学校简介;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.BackgroundImage = TouchSystem.Properties.Resources.学校领导_副本;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = TouchSystem.Properties.Resources.学校领导;
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox3.BackgroundImage = TouchSystem.Properties.Resources.历史沿革_副本;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackgroundImage = TouchSystem.Properties.Resources.历史沿革;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;

        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            panel4.Visible = false;

        }


        private void pictureBox7_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;
        }



        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            //label2.Font = new System.Drawing.Font("黑体",40,FontStyle.Regular);
             
            //label2.Size = new Size(177, 35);
               
        }
        #region
        //历史沿革字体效果设置
        private void label2_MouseLeave(object sender, EventArgs e)
        {
            //label2.Font = new System.Drawing.Font("黑体", 18, FontStyle.Regular);
        }
        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            //label3.Font = new System.Drawing.Font("黑体", 40, FontStyle.Regular);
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
           // label3.Font = new System.Drawing.Font("黑体", 24, FontStyle.Regular);
        }

        private void label4_MouseMove(object sender, MouseEventArgs e)
        {
            //label4.Font = new System.Drawing.Font("黑体", 40, FontStyle.Regular);
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
           // label4.Font = new System.Drawing.Font("黑体", 18, FontStyle.Regular);
        }

        private void label5_MouseMove(object sender, MouseEventArgs e)
        {
            //label5.Font = new System.Drawing.Font("黑体", 40, FontStyle.Regular);
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            //label5.Font = new System.Drawing.Font("黑体", 18, FontStyle.Regular);
        }

        private void label6_MouseMove(object sender, MouseEventArgs e)
        {
            //label6.Font = new System.Drawing.Font("黑体", 40, FontStyle.Regular);
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
           // label6.Font = new System.Drawing.Font("黑体", 24, FontStyle.Regular);
        }
        private void label7_MouseMove(object sender, MouseEventArgs e)
        {
           // label7.Font = new System.Drawing.Font("黑体", 40, FontStyle.Regular);
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            //label7.Font = new System.Drawing.Font("黑体", 18, FontStyle.Regular);
        }
      
        #endregion

        private void label2_Click(object sender, EventArgs e)
        {
            panel3.BackgroundImage = TouchSystem.Properties.Resources.历史沿革11;
            //1902-1006按钮
            //label2.Visible = false;
            //label3.Visible = false;
            //label4.Visible = false;
            //label5.Visible = false;
            //label6.Visible = false;
            //label7.Visible = false;

            pictureBox4.Visible = true;

        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox4.BackgroundImage = TouchSystem.Properties.Resources.返回_副本;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackgroundImage = TouchSystem.Properties.Resources.返回;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //返回原来的主界面历史沿革显示，同事将各个年份的可见性设置为true;
            panel3.BackgroundImage = TouchSystem.Properties.Resources.历史沿革1;
            
            //label2.Visible = true;
            //label3.Visible = true;
            //label4.Visible = true;
            //label5.Visible = true;
            //label6.Visible = true;
            //label7.Visible = true;

            pictureBox4.Visible = false;

        }

        private void label3_Click(object sender, EventArgs e)
        {
            //1907-1911
            panel3.BackgroundImage = TouchSystem.Properties.Resources.历史沿革2;
            
            //label2.Visible = false;
            //label3.Visible = false;
            //label4.Visible = false;
            //label5.Visible = false;
            //label6.Visible = false;
            //label7.Visible = false;

            pictureBox4.Visible = true;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            panel3.BackgroundImage = TouchSystem.Properties.Resources.历史沿革3;

            //label2.Visible = false;
            //label3.Visible = false;
            //label4.Visible = false;
            //label5.Visible = false;
            //label6.Visible = false;
            //label7.Visible = false;

            pictureBox4.Visible = true;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            panel3.BackgroundImage = TouchSystem.Properties.Resources.历史沿革4;

            //label2.Visible = false;
            //label3.Visible = false;
            //label4.Visible = false;
            //label5.Visible = false;
            //label6.Visible = false;
            //label7.Visible = false;

            pictureBox4.Visible = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            panel3.BackgroundImage = TouchSystem.Properties.Resources.历史沿革5;

            //label2.Visible = false;
            //label3.Visible = false;
            //label4.Visible = false;
            //label5.Visible = false;
            //label6.Visible = false;
            //label7.Visible = false;

            pictureBox4.Visible = true;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            panel3.BackgroundImage = TouchSystem.Properties.Resources.历史沿革6;

            //label2.Visible = false;
            //label3.Visible = false;
            //label4.Visible = false;
            //label5.Visible = false;
            //label6.Visible = false;
            //label7.Visible = false;

            pictureBox4.Visible = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox5.BackgroundImage = TouchSystem.Properties.Resources.返回_副本;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.BackgroundImage = TouchSystem.Properties.Resources.返回;
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.BackgroundImage = TouchSystem.Properties.Resources.校园规划_;
        }

        private void pictureBox7_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox7.BackgroundImage = TouchSystem.Properties.Resources.校园规划;
        }




        private void label2_Click_1(object sender, EventArgs e)
        {
            this.pictureBox8.Image = TouchSystem.Properties.Resources._1;
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            this.pictureBox8.Image = TouchSystem.Properties.Resources._2;
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            this.pictureBox8.Image = TouchSystem.Properties.Resources._3;
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            this.pictureBox8.Image = TouchSystem.Properties.Resources._4;
        }




       

       
        
    }
}
