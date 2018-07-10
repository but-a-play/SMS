using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    /// <summary>
    /// JobInfo的数据库接口
    /// </summary>
    public interface ISQLJob
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
    }
}
