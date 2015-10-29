using ClassLibrary;
using NHibernateService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace XBNews
{
    public partial class Form2 : Form
    {
        BaseService baseservice = new BaseService();
        News thenews;
        public Form2(News n)
        {
            
            InitializeComponent();
            this.Width = Screen.PrimaryScreen.Bounds.Width; ;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            if (n != null)
            {
                thenews = n;
                htmlEditor1.BodyInnerHTML = n.NewsContent;
                this.textBox1.Text = n.Subject;
            }
        }
        /// <summary>
        /// 提交按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" )
            {
                if(this.htmlEditor1.BodyInnerHTML != "")
                {

                    if (MessageBox.Show("确定要提交吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        #region 上传图片并生成新html
                        Regex r = new Regex("<IMG[\\s\\S]*?>");
                        MatchCollection mc = r.Matches(htmlEditor1.BodyInnerHTML);

                        String html = htmlEditor1.BodyInnerHTML;
                        Uri endpoint = new Uri(IniReadAndWrite.IniReadValue("fileManage", "filePath"));
                        for (int i = 0; i < mc.Count; i++)
                        {
                            if (mc[i].Value.Contains("src=\"http://"))
                            {
                                continue;
                            }
                            using (WebClient myWebClient = new WebClient())
                            {
                                myWebClient.UploadFileCompleted += new UploadFileCompletedEventHandler(uploadCompleted);
                                String imgHtml = mc[i].Value;

                                string inPath = HtmlUtility.GetTitleContent(imgHtml, "img", "src");  //imgHtml.Substring(startIndex, imgHtml.LastIndexOf("\"") - startIndex);

                                try
                                {
                                    String newName = "xiaoban_"+DateTime.Now.Ticks + inPath.Substring(inPath.LastIndexOf("."));
                                    String tempPath = Application.StartupPath.ToString() + "\\temp\\" + newName;
                                    File.Copy(inPath, tempPath, true);

                                    myWebClient.UploadFileAsync(endpoint, tempPath);

                                    String newString2 = imgHtml.Remove(imgHtml.IndexOf("src"), inPath.Length + 6);//.Remove(imgHtml.LastIndexOf('>'))+" src=\"" + Securit.DeDES(IniReadAndWrite.IniReadValue("fileManage", "savePath")) + newName + "\">";
                                    string newString1 = newString2.Remove(newString2.LastIndexOf('>'));
                                    string newString = newString1 + " src=\"" + IniReadAndWrite.IniReadValue("fileManage", "savePath") + @"xiaobanpic/" + newName + "\">";
                                  

                                    html = html.Replace(mc[i].Value, newString);

                                }
                                catch (Exception exp)
                                {
                                    MessageBox.Show(exp.ToString());
                                    return;
                                }
                            }
                        }
                        #endregion


                        try
                        {
                            if (thenews == null)
                            {
                                thenews = new News();
                            
                            }
                            thenews.Subject = this.textBox1.Text;
                            thenews.NewsContent = html;
                            thenews.Time = DateTime.Now.Ticks;
                            thenews.State = 0;
                            baseservice.SaveOrUpdateEntity(thenews);
                            this.DialogResult = DialogResult.OK;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                    }
                }
                else
                {
                    MessageBox.Show("当前内容为空");
                }
            
            }
            else
            {
                MessageBox.Show("当前标题为空");
            }
           
        }

        /// <summary>
        /// 上传完毕后删除生成的临时文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uploadCompleted(object sender, UploadFileCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                String fileName = Encoding.Default.GetString(e.Result);
                String tempFilePath = Application.StartupPath.ToString() + "\\temp\\" + fileName;
                if (File.Exists(tempFilePath))
                {
                    File.Delete(tempFilePath);
                }
            }
            else
            {
                MessageBox.Show(e.Error.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                thenews.State = 1;
                baseservice.SaveOrUpdateEntity(thenews);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
