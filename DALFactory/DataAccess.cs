using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using SQLServerDAL;
using System.Reflection;

namespace DALFactory
{
    public class DataAccess
    {
        /// <summary>
        /// 数据集名称
        /// </summary>
        private static readonly string AssemblyName = "SQLServerDAL";
        /// <summary>
        /// 数据库名称
        /// </summary>
        //private static readonly string db = "Sqlserver";

        public static ISQLDepartment CreateDepartment()
        {
            string className = AssemblyName + ".Department";
            return Assembly.Load(AssemblyName).CreateInstance(className) as ISQLDepartment;
        }
        public static ISQLJob CreateJob()
        {
            string className = AssemblyName + ".Job";
            return Assembly.Load(AssemblyName).CreateInstance(className) as ISQLJob;
        }
        public static ISQLStaff CreateStaff()
        {
            string className = AssemblyName + ".Staff";
            return Assembly.Load(AssemblyName).CreateInstance(className) as ISQLStaff;
        }
    }
}
