using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class News: BaseEntity
    {
        private string subject;

        public virtual string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        private String newsContent;

        public virtual String NewsContent
        {
            get { return newsContent; }
            set { newsContent = value; }
        }
        private  long time;

        public virtual long Time
        {
            get { return time; }
            set { time = value; }
        }

    }
}
