using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Staff
    {
        public Staff()
        {

        }
        private string staffNo;
        /// <summary>
        /// 工号
        /// </summary>
        public string StaffNo
        {
            get { return staffNo; }
            set { staffNo = value; }
        }

        private string staffName;
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string StaffName
        {
            get { return staffName; }
            set { staffName = value; }
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
        private string staffIsOnJob;
        /// <summary>
        /// 是否在职
        /// </summary>
        public string StaffIsOnJob
        {
            get { return staffIsOnJob; }
            set { staffIsOnJob = value; }
        }


    }
}
