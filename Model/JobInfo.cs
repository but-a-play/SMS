using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 岗位类
    /// </summary>
    public class JobInfo
    {
        public JobInfo()
        {

        }

        private string no;
        /// <summary>
        /// 岗位编号
        /// </summary>
        public string No
        {
            get { return no; }
            set { no = value; }
        }

        private string name;
        /// <summary>
        /// 岗位名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


    }
}
