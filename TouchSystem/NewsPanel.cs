using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TouchSystem
{
    public partial class NewsPanel : UserControl
    {
        public NewsPanel()
        {
            InitializeComponent();
        }


        //定义委托
        public delegate void ContentClickHandle(object sender, EventArgs e);
        //定义事件
        public event ContentClickHandle ContentClicked;

      
        private void label1_Click(object sender, EventArgs e)
        {
            if (ContentClicked != null)
                ContentClicked(sender, new EventArgs());//把按钮自身作为参数传递
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.DeepSkyBlue;
        }

         public string NewsSubject
        {
            set
            {
                if (value.Length < 20)
                    this.label1.Text = value;
                else
                    this.label1.Text = value.Substring(0, 19)+"…";
            }
        }

         public long NewsTimeTicks
         {
             set
             {
                 this.label2.Text = new DateTime(value).ToString("yyyy年MM月dd日");
             }
         }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White; ;
        }
    }
}
