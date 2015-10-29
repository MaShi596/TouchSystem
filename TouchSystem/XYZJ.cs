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
    public partial class XYZJ : Form
    {
        public XYZJ()
        {
            InitializeComponent();
        }

        private void XYZJ_Load(object sender, EventArgs e)
        {
            this.SetVisibleCore(false);
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.SetVisibleCore(true);


        }


        #region 校友捐赠
        private void label2_Click(object sender, EventArgs e)
        {
            XYJZ h = new XYJZ();
            h.ShowDialog();
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            this.label2.Font = new Font("华文楷体", 27);
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            this.label2.Font = new Font("华文楷体", 37);
        }

        #endregion



        #region 返回
        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            this.label3.Font = new Font("华文楷体", 27);
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            this.label3.Font = new Font("华文楷体", 37);
        }
        #endregion



        #region 知名校友
        
        private void label1_MouseHover(object sender, EventArgs e)
        {
            this.label1.Font = new Font("华文楷体", 37);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            this.label1.Font = new Font("华文楷体", 27);
        }



        /// <summary>
        /// 知名校友
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_Click(object sender, EventArgs e)
        {
            ZMXY h = new ZMXY();
            h.ShowDialog();
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            this.label1.Font = new Font("华文楷体", 37);
        }
        #endregion

      



    }
}
