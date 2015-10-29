using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XBNews;
using ClassLibrary;
using System.Collections;
using NHibernateService;
namespace TouchSystem
{
    public partial class News : Form
    {
        List<ClassLibrary.News> news = new List<ClassLibrary.News>();
        BaseService baseservice = new BaseService();
        public News()
        {
            InitializeComponent();
        }

        private void News_Load(object sender, EventArgs e)
        {
            this.SetVisibleCore(false);
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.SetVisibleCore(true);
            this.MinimizeBox = false;
            this.backgroundWorker1.RunWorkerAsync();
        }

        private void webBrowser1_NewWindow(object sender, CancelEventArgs e)
        {
            News2 newForm = new News2();
            string url = ((WebBrowser)sender).StatusText;
            //string url = ((WebBrowser)sender).Document.ActiveElement.GetAttribute("href");//第二种方式
            newForm.webBrowser1.Navigate(url);
            newForm.Show();
            e.Cancel = true;
        }




        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string sql = "select * from News where News.State = 0 order by News.Time desc";
            
            IList i = baseservice.ExecuteSQL(sql);
            if (i != null && i.Count > 0)
            {
                foreach (object[] o in i)
                {
                    ClassLibrary.News n1 = new ClassLibrary.News();
                    n1.Id = (int)o[0] ;
                    n1.Subject = o[1].ToString();
                    n1.NewsContent = o[2].ToString();
                    n1.Time = long.Parse(o[3].ToString());
                    this.news.Add(n1);
                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (ClassLibrary.News o in news)
            {
                NewsPanel np1 = new NewsPanel();
                np1.NewsSubject = o.Subject;
                np1.NewsTimeTicks = o.Time;
                np1.Tag = o;
                np1.ContentClicked += np1_ContentClicked;
                np1.Parent = this.flowLayoutPanel1;

            }

        }

        void np1_ContentClicked(object sender, EventArgs e)
        {
            NewsPanel l = (NewsPanel)((Label)sender).Parent;
            ClassLibrary.News n = l.Tag as ClassLibrary.News;
            htmlEditor1.ShowToolBar = false;
            htmlEditor1.ReadOnly = true;
            htmlEditor1.BodyInnerHTML = n.NewsContent;
            this.label2.Text = n.Subject;
        }
    }
}
