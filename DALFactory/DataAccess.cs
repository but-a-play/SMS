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

        public static IDepartment CreateDepartment()
        {
            string className = AssemblyName + ".Department";
            return Assembly.Load(AssemblyName).CreateInstance(className) as IDepartment;
        }
        public static IJob CreateJob()
        {
            string className = AssemblyName + ".Job";
            return Assembly.Load(AssemblyName).CreateInstance(className) as IJob;
        }
        public static IStaff CreateStaff()
        {
            string className = AssemblyName + ".Staff";
            return Assembly.Load(AssemblyName).CreateInstance(className) as IStaff;
        }

        public static ILog CreateLog()
        {
            string className = AssemblyName + ".Log";
            return Assembly.Load(AssemblyName).CreateInstance(className) as ILog;
        }
    }
}
