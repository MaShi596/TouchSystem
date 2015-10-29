using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace TouchSystem
{
    public partial class DepartSet : Form
    {


        private const int GWL_WNDPROC = -4;
        public delegate IntPtr FlaWndProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        private IntPtr OldWndProc = IntPtr.Zero;
        private FlaWndProc Wpr = null;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowLong(IntPtr hWnd, int nIndex, FlaWndProc wndProc);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr CallWindowProc(IntPtr wndProc, IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        //给此控件一个特定消息值
        private IntPtr FlashWndProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam)
        {
            if (msg == 516)
                return (IntPtr)0;
            return CallWindowProc(OldWndProc, hWnd, msg, wParam, lParam);
        }

        public DepartSet()
        {
            InitializeComponent();
        }

        private void DepartSet_Load(object sender, EventArgs e)
        {

            this.Wpr = new FlaWndProc(this.FlashWndProc);
            this.OldWndProc = SetWindowLong(axShockwaveFlash1.Handle, GWL_WNDPROC, Wpr);

            this.SetVisibleCore(false);
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.SetVisibleCore(true);

            string str = System.Windows.Forms.Application.StartupPath;//获取当前程序的相对路径；

            axShockwaveFlash1.Movie = str + "\\Newflash2804.swf";

            axShockwaveFlash1.Play();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            this.label1.Font = new System.Drawing.Font("微软雅黑", 26, FontStyle.Regular); 
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            this.label1.Font = new System.Drawing.Font("微软雅黑", 36, FontStyle.Regular); 
        }



    }
}
