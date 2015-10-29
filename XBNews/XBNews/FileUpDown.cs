using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace XBNews
{
    public class FileUpDown
    {
        string ftpServerIP;

        public string FtpServerIP
        {
            get { return ftpServerIP; }
            set { ftpServerIP = value; }
        }
        string ftpUserID;

        public string FtpUserID
        {
            get { return ftpUserID; }
            set { ftpUserID = value; }
        }
        string ftpPassword;

        public string FtpPassword
        {
            get { return ftpPassword; }
            set { ftpPassword = value; }
        }
        FtpWebRequest reqFTP;

        private void Connect(String path)//连接ftp  
        {
            // 根据uri创建FtpWebRequest对象  
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(path));
           
            // ftp用户名和密码  
            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
            // 指定数据传输类型  
            reqFTP.UseBinary = true;
            reqFTP.UsePassive = false;
        }
        public FileUpDown(string ftpServerIP, string ftpUserID, string ftpPassword)
        {
            this.ftpServerIP = ftpServerIP;
            this.ftpUserID = ftpUserID;
            this.ftpPassword = ftpPassword;
        }
        //都调用这个  
        private string[] GetFileList(string path, string WRMethods)//上面的代码示例了如何从ftp服务器上获得文件列表  
        {
            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            try
            {
                Connect(path);
                reqFTP.Method = WRMethods;
                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);//中文文件名  
                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                // to remove the trailing '/n'  
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                reader.Close();
                response.Close();
                return result.ToString().Split('\n');
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                downloadFiles = null;
                return downloadFiles;
            }
        }
        public string[] GetFileList(string path)//上面的代码示例了如何从ftp服务器上获得文件列表  
        {
            return GetFileList("ftp://" + ftpServerIP + "/" + path, WebRequestMethods.Ftp.ListDirectory);
        }
        public string[] GetFileList()//上面的代码示例了如何从ftp服务器上获得文件列表  
        {
            return GetFileList("ftp://" + ftpServerIP + "/", WebRequestMethods.Ftp.ListDirectory);
        }

        public string Upload(string filename,string floder) //上面的代码实现了从ftp服务器上载文件的功能  
        {
            FileInfo fileInf = new FileInfo(filename);
            string uri = "ftp://" + ftpServerIP + "/" + floder + "/" +fileInf.Name;
            Connect(uri);//连接           
            // 默认为true，连接不会被关闭  
            // 在一个命令之后被执行  
            reqFTP.KeepAlive = false;
            // 指定执行什么命令  
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            // 上传文件时通知服务器文件的大小  
            reqFTP.ContentLength = fileInf.Length;
            // 缓冲大小设置为kb  
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;
            // 打开一个文件流(System.IO.FileStream) 去读上传的文件  
            FileStream fs = fileInf.OpenRead();
            try
            {
                // 把上传的文件写入流  
                Stream strm = reqFTP.GetRequestStream();
                // 每次读文件流的kb  
                contentLen = fs.Read(buff, 0, buffLength);
                // 流内容没有结束  
                while (contentLen != 0)
                {
                    // 把内容从file stream 写入upload stream  
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }
                // 关闭两个流  
                strm.Close();
                fs.Close();
                return uri;
            }
            catch (Exception ex)
            {
                return "Upload Error" + ex.Message;
            }
        }
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="filePath">下载到本地的路径</param>
        /// <param name="fileName">服务器上的文件名字</param>
        /// <param name="floder">服务器上文件所在目录的根目录</param>
        /// <returns></returns>
        public string Download(string filePath, string fileName, string floder)////上面的代码实现了从ftp服务器下载文件的功能  
        {
            try
            {
                String onlyFileName = Path.GetFileName(fileName);
                string newFileName = filePath.Replace('/','\\') + "\\" + onlyFileName;
                if (File.Exists(newFileName))
                {
                    File.Delete(newFileName);
                    //return "本地文件" + newFileName + "已存在,无法下载";
                }
                if (!File.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                    //File.Create(filePath);
                }
                string url = "ftp://" + ftpServerIP + "/" + floder + "/" + fileName;
                Connect(url);//连接   
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];
                readCount = ftpStream.Read(buffer, 0, bufferSize);
                FileStream outputStream = new FileStream(newFileName, FileMode.Create);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }
                ftpStream.Close();
                outputStream.Close();
                response.Close();

                return newFileName;
            }
            catch (Exception ex)
            {
                return "因" + ex.Message + ",无法下载";
            }
        }
        //删除文件  
        public void DeleteFileName(string fileName, string floder)
        {
            try
            {
                FileInfo fileInf = new FileInfo(fileName);
                string uri = "ftp://" + ftpServerIP + "/" + floder +"/"+fileInf.Name;
                Connect(uri);//连接           
                // 默认为true，连接不会被关闭  
                // 在一个命令之后被执行  
                reqFTP.KeepAlive = false;
                // 指定执行什么命令  
                reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "删除错误");
            }
        }
        //创建目录  
        public string MakeDir(string dirName)
        {
            try
            {
                string uri = "ftp://" + ftpServerIP + "/" + dirName;
                Connect(uri);//连接        
                reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                response.Close();
                return "";
            }
            catch (WebException ex)
            {
                return "[Make Dir]" + ex.Message;
            }
        }
        //删除目录  
        public void delDir(string dirName)
        {
            try
            {
                string uri = "ftp://" + ftpServerIP + "/" + dirName;
                Connect(uri);//连接        
                reqFTP.Method = WebRequestMethods.Ftp.RemoveDirectory;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //获得文件大小  
        public long GetFileSize(string filename)
        {
            long fileSize = 0;
            try
            {
                FileInfo fileInf = new FileInfo(filename);
                string uri = "ftp://" + ftpServerIP + "/" + fileInf.Name;
                Connect(uri);//连接        
                reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                fileSize = response.ContentLength;
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return fileSize;
        }
        
        /// <summary>
        /// 获取ftp文件最后更改时间
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <param name="floder">文件夹</param>
        /// <returns>DateTime</returns>
        public DateTime GetFileModifyDateTime(string filename, string floder)
        {
            FileInfo fileInf = new FileInfo(filename);
            string url = "ftp://" + ftpServerIP + "/" + floder + "/" + fileInf.Name; ;
            Connect(url);//连接       
            reqFTP.Method = WebRequestMethods.Ftp.GetDateTimestamp;

            FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();

            DateTime dt = response.LastModified;

            response.Close();
            response = null;

            return dt;
        }

        
        /// <summary>
        /// ftp上文件是否存在
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <param name="floder">文件所在文件夹</param>
        /// <returns>bool true=〉存在</returns>
        public bool DirectoryExist(string filename, string floder)
        {
            FileInfo fileInf = new FileInfo(filename);
            string url = "ftp://" + ftpServerIP + "/" + floder + "/" + fileInf.Name; ;
            Connect(url);//连接     


            try
            {
                FtpWebResponse response;
                response = (FtpWebResponse)reqFTP.GetResponse();
                response.Close();

                return true;
            }
            catch (Exception ex)
            {

                string e = ex.Message;
                return false;
            }
        }
        //文件改名  
        public void Rename(string currentFilename, string newFilename, string floder)
        {
            try
            {
                FileInfo fileInf = new FileInfo(currentFilename);
                string uri = "ftp://" + ftpServerIP + "/" + floder +"/"+ fileInf.Name;
                Connect(uri);//连接  
                reqFTP.Method = WebRequestMethods.Ftp.Rename;
                reqFTP.RenameTo = newFilename;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                //Stream ftpStream = response.GetResponseStream();  
                //ftpStream.Close();  
                response.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        //链接是否成功
        public void IsConnectSucceed(string currentFilename, string floder)
        {
            FileInfo fileInf = new FileInfo(currentFilename);
            string url = "ftp://" + ftpServerIP + "/"+floder + "/" + fileInf.Name;
            Connect(url);//连接     
            try
            {
                FtpWebResponse response;
                response = (FtpWebResponse)reqFTP.GetResponse();
                response.Close();
                return;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("基础连接已经关闭"))
                {
                    IsConnectSucceed(currentFilename, floder);
                }
            }
        }

        //获得文件明晰  
        public string[] GetFilesDetailList()
        {
            return GetFileList("ftp://" + ftpServerIP + "/", WebRequestMethods.Ftp.ListDirectoryDetails);
        }
        //获得文件明晰  
        public string[] GetFilesDetailList(string path)
        {
            return GetFileList("ftp://" + ftpServerIP + "/" + path, WebRequestMethods.Ftp.ListDirectoryDetails);
        }
    }
}
