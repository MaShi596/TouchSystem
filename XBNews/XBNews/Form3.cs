using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XBNews
{
    public partial class Form3 : Form
    {
        FileUpDown fileop;
        public Form3()
        {
            InitializeComponent();
            fileop = new FileUpDown("115.24.170.44","FtpUser","xiaoban");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;

            OpenFileDialog opdialog = new OpenFileDialog();
            opdialog.InitialDirectory = @"C:\";
            opdialog.FilterIndex = 1;
            opdialog.Filter = "Image   Files(*.jpg)|*.jpg";
            if (opdialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Image a  = Image.FromFile(opdialog.FileName);
                if (a.Width == 1000 && a.Height == 500)
                {
                    p.BackgroundImage = a;// Image.FromFile(opdialog.FileName);
                    fileop.DeleteFileName("scenery_" + p.Tag.ToString() + ".jpg", "");
                    fileop.Upload(opdialog.FileName, "");
                    fileop.Rename(opdialog.FileName, "scenery_" + p.Tag.ToString() + ".jpg", "");
                    MessageBox.Show("上传成功！");
                }
                else
                {
                    MessageBox.Show("您选择的图片格式有问题");
                
                }
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //fileop.Download(
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.button1.Cursor = Cursors.WaitCursor;
            for(int i = 0; i<11;i++)
            {
                if (File.Exists(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp" + "\\scenery_" + (i + 1).ToString() + ".jpg"))
                {
                    File.Delete(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp" + "\\scenery_" + (i + 1).ToString() + ".jpg");
                }
                fileop.Download(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp", "scenery_" + (i + 1).ToString() + ".jpg", "");
            }
            pictureBox1.BackgroundImage = Image.FromFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp" + "\\scenery_1.jpg");
            pictureBox2.BackgroundImage = Image.FromFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp" + "\\scenery_2.jpg");
            pictureBox3.BackgroundImage = Image.FromFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp" + "\\scenery_3.jpg");
            pictureBox10.BackgroundImage = Image.FromFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp" + "\\scenery_4.jpg");
            pictureBox4.BackgroundImage = Image.FromFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp" + "\\scenery_5.jpg");
            pictureBox5.BackgroundImage = Image.FromFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp" + "\\scenery_6.jpg");
            pictureBox6.BackgroundImage = Image.FromFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp" + "\\scenery_7.jpg");
            pictureBox11.BackgroundImage = Image.FromFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp" + "\\scenery_8.jpg");
            pictureBox7.BackgroundImage = Image.FromFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp" + "\\scenery_9.jpg");
            pictureBox8.BackgroundImage = Image.FromFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp" + "\\scenery_10.jpg");
            pictureBox9.BackgroundImage = Image.FromFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp" + "\\scenery_11.jpg");

            this.button1.Cursor = Cursors.Hand;
            this.button1.Enabled = false;

        }
    }
}
