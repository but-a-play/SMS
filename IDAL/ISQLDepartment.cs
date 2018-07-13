using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;

namespace IDAL
{
    public interface ISQLDepartment: BaseISQL
    {
        /// <summary>
        /// 根据部门编号查询部门信息
        /// </summary>
        /// <param name="no">部门编号</param>
        /// <returns>部门信息实例</returns>
        DepartmentInfo GetDepartmentInfo(string no);

        /// <summary>
        /// 增加部门
        /// </summary>
        /// <param name="departmentInfo">增加的部门信息</param>
        /// <returns>是否增加成功</returns>
        bool AddDepartmentInfo(DepartmentInfo departmentInfo);

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="no">待删除的部门编号</param>
        /// <returns>是否删除成功</returns>
        bool DeleteDepartmentInfo(string no);

        /// <summary>
        /// 修改部门信息
        /// </summary>
        /// <param name="departmentInfo">修改的部门信息</param>
        /// <returns>是否修改成功</returns>
        bool ModifyDepartmentInfo(DepartmentInfo departmentInfo);

        /// <summary>
        /// 多记录查询
        /// </summary>
        /// <param name="paramsMap">查询条件</param>
        /// <returns></returns>
        SqlDataReader GetDepartmentInfo(Dictionary<string, object> paramsMap);
    }
}
