using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace TouchSystem
{
    public partial class FlashPlay : Form
    {


        //private const int GWL_WNDPROC = -4;
        //public delegate IntPtr FlaWndProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        //private IntPtr OldWndProc = IntPtr.Zero;
        //private FlaWndProc Wpr = null;

        //[DllImport("user32.dll", CharSet = CharSet.Auto)]
        //public static extern IntPtr SetWindowLong(IntPtr hWnd, int nIndex, FlaWndProc wndProc);
        //[DllImport("user32.dll", CharSet = CharSet.Auto)]
        //public static extern IntPtr CallWindowProc(IntPtr wndProc, IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        ////给此控件一个特定消息值
        //private IntPtr FlashWndProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam)
        //{
        //    if (msg == 516)
        //        return (IntPtr)0;
        //    return CallWindowProc(OldWndProc, hWnd, msg, wParam, lParam);
        //}





        public FlashPlay()
        {
            InitializeComponent();
        }

        private void FlashPlay_Load(object sender, EventArgs e)
        {

            this.SetVisibleCore(false);
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.SetVisibleCore(true);
            panel2.Enabled = false; 
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.stretchToFit = true;
            string Path = System.Windows.Forms.Application.StartupPath + "\\Show3DPic\\data\\images1\\video";
            string[] files = Directory.GetFiles(Path);
            

            
            foreach (string s in files)
            {
                NewsPanel np1 = new NewsPanel();
                np1.NewsSubject = s.Substring(s.LastIndexOf('\\') + 1);
                np1.Tag = s;
                np1.ContentClicked += np1_ContentClicked;
                np1.Parent = this.flowLayoutPanel1;
                axWindowsMediaPlayer1.currentPlaylist.appendItem(axWindowsMediaPlayer1.newMedia(s));
            
            }
            axWindowsMediaPlayer1.Ctlcontrols.play();

        }

        void np1_ContentClicked(object sender, EventArgs e)
        {
            NewsPanel l = (NewsPanel)((Label)sender).Parent;
            string n = l.Tag as string;
            axWindowsMediaPlayer1.URL = n;
        }



        private void label1_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.Width == 1920)
            {
                axWindowsMediaPlayer1.Width = 1500;
                this.label1.Text = "全屏显示";
                this.panel3.Visible = true;
            }
            else if (axWindowsMediaPlayer1.Width == 1500)
            {
                axWindowsMediaPlayer1.Width = 1920;
                this.label1.Text = "退出全屏";
                this.panel3.Visible = false;

            }
          
        }

        private void label3_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            this.Close();
        }
    }
}
