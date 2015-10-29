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
    public partial class SP_SZGK : Form
    {
        public SP_SZGK()
        {
            InitializeComponent();
        }

        private void SP_SZGK_Load(object sender, EventArgs e)
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
    }
}
