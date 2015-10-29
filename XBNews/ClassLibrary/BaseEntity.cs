using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    [Serializable]
    public class BaseEntity
    {
        private int id;
        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int state;

        public virtual int State
        {
            get { return state; }
            set { state = value; }
        }

    }
}
