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
    public partial class Form5 : Form
    {
        FileUpDown fileop;
        public Form5()
        {
            InitializeComponent();
            fileop = new FileUpDown("115.24.170.44", "FtpUser", "xiaoban");
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
                Image a = Image.FromFile(opdialog.FileName);
                
                    p.BackgroundImage = a;// Image.FromFile(opdialog.FileName);
                    fileop.DeleteFileName(p.Tag.ToString() + ".jpg", "");
                    fileop.Upload(opdialog.FileName, "");
                    fileop.Rename(opdialog.FileName, p.Tag.ToString() + ".jpg", "");
                    MessageBox.Show("上传成功！");
               
                
            }
            else
            {
                MessageBox.Show("您选择的图片格式有问题");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Cursor = Cursors.WaitCursor;
            for (int i = 0; i < 19; i++)
            {
                if (File.Exists(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp" + "\\" + (i + 1).ToString() + ".jpg"))
                {
                    File.Delete(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp" + "\\" + (i + 1).ToString() + ".jpg");
                }
                fileop.Download(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp",  (i + 1).ToString() + ".jpg", "");
            }
            pictureBox1.BackgroundImage = Image.FromFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp" + "\\1.jpg");
            pictureBox2.BackgroundImage = Image.FromFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp" + "\\2.jpg");
            pictureBox3.BackgroundImage = Image.FromFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp" + "\\3.jpg");
            pictureBox13.BackgroundImage = Image.FromFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp" + "\\4.jpg");
            pictureBox17.BackgroundImage = Image.FromFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp" + "\\5.jpg");
            pictureBox4.BackgroundImage = Image.FromFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp" + "\\6.jpg");
            pictureBox5.BackgroundImage = Image.FromFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp" + "\\7.jpg");
            pictureBox6.BackgroundImage = Image.FromFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp" + "\\8.jpg");
            pictureBox14.BackgroundImage = Image.FromFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp" + "\\9.jpg");
            pictureBox18.BackgroundImage = Image.FromFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp" + "\\10.jpg");
            pictureBox7.BackgroundImage = Image.FromFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp" + "\\11.jpg");
            pictureBox8.BackgroundImage = Image.FromFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp" + "\\12.jpg");
            pictureBox9.BackgroundImage = Image.FromFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp" + "\\13.jpg");
            pictureBox15.BackgroundImage = Image.FromFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp" + "\\14.jpg");
            pictureBox19.BackgroundImage = Image.FromFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp" + "\\15.jpg");
            pictureBox10.BackgroundImage = Image.FromFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp" + "\\16.jpg");
            pictureBox11.BackgroundImage = Image.FromFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp" + "\\17.jpg");
            pictureBox12.BackgroundImage = Image.FromFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp" + "\\18.jpg");
            pictureBox16.BackgroundImage = Image.FromFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"temp" + "\\19.jpg");


            this.button1.Cursor = Cursors.Hand;
            this.button1.Enabled = false;
        }
    }
}
