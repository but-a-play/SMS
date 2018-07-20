using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using DALFactory;
using Model;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace BLL
{
    public class Department
    {
        private IDepartment sqlDepartment = DataAccess.CreateDepartment();

        /// <summary>
        /// 增加部门信息
        /// 增加前需要注意重复信息的插入
        /// </summary>
        /// <param name="departmentInfo">待插入的部门信息</param>
        /// <returns>bool</returns>
        public bool Add(DepartmentInfo departmentInfo)
        {
            Dictionary<string, object> paramsMap = new Dictionary<string, object>();
            paramsMap.Add("dept_No", departmentInfo.No);
            SqlDataReader reader = Query(paramsMap);
            if (!reader.Read())
            {
                return sqlDepartment.AddDepartmentInfo(departmentInfo);
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 删除部门信息
        /// 删除前需要注意是否有外表关联
        /// </summary>
        /// <param name="departmentNo"></param>
        /// <returns></returns>
        public bool Delete(string departmentNo)
        {
            Dictionary<string, object> paramsMap = new Dictionary<string, object>();
            paramsMap.Add("Dept.dept_No", departmentNo);
            SqlDataReader reader = new Staff().Query(paramsMap);
            if (!reader.Read())
            {
                return sqlDepartment.DeleteDepartmentInfo(departmentNo);
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="departmentInfo"></param>
        /// <returns></returns>
        public bool Modify(DepartmentInfo departmentInfo)
        {
            return sqlDepartment.ModifyDepartmentInfo(departmentInfo);
        }

        public SqlDataReader Query(Dictionary<string, object> paramsMap)
        {
            return sqlDepartment.GetDepartmentInfo(paramsMap);
        }

        public ArrayList QueryNos()
        {
            return sqlDepartment.GetDepartmentNos();
        }

        public ArrayList QueryNames()
        {
            return sqlDepartment.GetDepartmentNames();
        }

        public string QueryNo(string deptName)
        {
            return sqlDepartment.GetDeptNo(deptName);
        }

        public DataTable QueryByDT(Dictionary<string, object> paramsMap)
        {
            return sqlDepartment.GetDepartmentByDT(paramsMap);
        }

        public ArrayList GetDeptList()
        {
            return sqlDepartment.GetDeptList();
        }
    }
}
