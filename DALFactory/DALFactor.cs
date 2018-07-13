using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using SQLServerDAL;

namespace DALFactory
{
    public class DALFactor
    {
        /// <summary>
        /// 返回SQLServerDAL实例
        /// </summary>
        /// <param name="className">查询的类名</param>
        /// <returns></returns>
        public static BaseISQL CreateBaseISQL(string className)
        {
            BaseISQL ISQL = null;
            switch (className)
            {
                case "JobInfo":
                    ISQL = new Job();
                    break;

                case "DepartmentInfo":
                    ISQL = new Department();
                    break;

                case "StaffInfo":
                    ISQL = new Staff();
                    break;

            }
            return ISQL;
        }
    }
}
