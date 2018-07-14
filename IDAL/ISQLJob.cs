using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;

namespace IDAL
{
    /// <summary>
    /// JobInfo的数据库接口
    /// </summary>
    public interface ISQLJob: BaseISQL
    {
        /// <summary>
        /// 根据岗位编号查找JobInfo的数据库接口
        /// </summary>
        /// <param name="no">岗位编号</param>
        /// <returns>JobInfo</returns>
        JobInfo GetJobInfo(string no);

        /// <summary>
        /// 添加JobInfo的接口
        /// </summary>
        /// <param name="jobInfo">JobInfo实例</param>
        /// <returns>是否增加成功</returns>
        bool AddJobInfo(JobInfo jobInfo);

        /// <summary>
        /// 根据岗位编号删除JonInfo的接口
        /// </summary>
        /// <param name="no">岗位编号</param>
        /// <returns>是否删除成功</returns>
        bool DeleteJobInfo(string no);

        /// <summary>
        /// 根据JobInfo实例修改JobInfo
        /// </summary>
        /// <param name="jobInfo"></param>
        /// <returns>是否修改成功</returns>
        bool ModifyJobInfo(JobInfo jobInfo);

        /// <summary>
        /// 多记录查询
        /// </summary>
        /// <param name="paramsMap">查询条件</param>
        /// <returns></returns>
        SqlDataReader GetJobInfo(Dictionary<string, object> paramsMap);

        /// <summary>
        /// 获取岗位编号集合
        /// </summary>
        /// <returns></returns>
        Array GetJobNos();

        /// <summary>
        /// 获取岗位名称集合
        /// </summary>
        /// <returns></returns>
        Array GetJobNames();
    }
}
