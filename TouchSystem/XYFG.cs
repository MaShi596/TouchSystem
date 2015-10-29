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
    public partial class XYFG : Form
    {
        public XYFG()
        {
            InitializeComponent();
        }

        private void XYFG_Load(object sender, EventArgs e)
        {
            this.SetVisibleCore(false);
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.SetVisibleCore(true);

            this.webBrowser1.Url = new Uri(Application.StartupPath + "\\Show3DPic\\data\\index.html");
            //this.webBrowser1.Url = new Uri(Application.StartupPath + "\\3D\\index.html");


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
