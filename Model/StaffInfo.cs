using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 职工类
    /// </summary>
    public class StaffInfo
    {
        public StaffInfo()
        {

        }
        private string no;
        /// <summary>
        /// 工号
        /// </summary>
        public string No
        {
            get { return no; }
            set { no = value; }
        }

        private string name;
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string jobNo;
        /// <summary>
        /// 岗位编号
        /// </summary>
        public string JobNo
        {
            get { return jobNo; }
            set { jobNo = value; }
        }
        private string deptNo;
        /// <summary>
        /// 部门编号
        /// </summary>
        public string DeptNo
        {
            get { return deptNo; }
            set { deptNo = value; }
        }
        private bool isOnJob;
        /// <summary>
        /// 是否在职
        /// </summary>
        public bool IsOnJob
        {
            get { return IsOnJob; }
            set { IsOnJob = value; }
        }


    }
}
