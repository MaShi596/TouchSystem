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
    public partial class XYJZ : Form
    {


        Image New1 = Image.FromFile(Application.StartupPath + "//New//New1.png");
        Image New2 = Image.FromFile(Application.StartupPath + "//New//New2.png");
        Image New3 = Image.FromFile(Application.StartupPath + "//New//New3.png");
        Image New4 = Image.FromFile(Application.StartupPath + "//New//New4.png");
        Image New5 = Image.FromFile(Application.StartupPath + "//New//New5.png");
        Image[] News;
        
        int count;

        public XYJZ()
        {
            InitializeComponent();
        }

        private void XYJZ_Load(object sender, EventArgs e)
        {
            this.SetVisibleCore(false);
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.SetVisibleCore(true);
            
            count = 0;
            
            News = new Image[5];
            News[0] = New1;
            News[1] = New2;
            News[2] = New3;
            News[3] = New4;
            News[4] = New5;

            //this.pictureBox1.Image = News[0];
        }

        #region 返回按钮
        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            this.label1.Font = new Font("微软雅黑", 20);
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            this.label1.Font = new Font("微软雅黑", 25);
        }

        #endregion

        private void webBrowser1_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }


        //#region 下一页
        //private void label2_MouseLeave(object sender, EventArgs e)
        //{
        //    this.label2.Font = new Font("微软雅黑", 20);
        //}

        //private void label2_MouseMove(object sender, MouseEventArgs e)
        //{
        //    this.label2.Font = new Font("微软雅黑", 25);
        //}

        //private void label2_Click(object sender, EventArgs e)
        //{
        //  //  this.pictureBox1.Image = News[count % 5];
        //    count++;
        //}

        //#endregion
    }
}
