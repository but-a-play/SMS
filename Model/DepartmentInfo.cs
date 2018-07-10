using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 部门类
    /// </summary>
    public class DepartmentInfo
    {
        public DepartmentInfo()
        {

        }

        private string no;
        /// <summary>
        /// 部门编号
        /// </summary>
        public string No
        {
            get { return no; }
            set { no = value; }
        }

        private string name;
        /// <summary>
        /// 部门名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
