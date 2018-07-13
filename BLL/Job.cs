using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using DALFactory;
using Model;
using System.Data.SqlClient;

namespace BLL
{
    public class Job
    {
        private ISQLJob sqlJob = DALFactor.CreateBaseISQL("JobInfo") as ISQLJob;

        /// <summary>
        /// 增加岗位信息
        /// 增加前需要注意重复信息的插入
        /// </summary>
        /// <param name="jobInfo">待插入的岗位信息</param>
        /// <returns>bool</returns>
        public bool Add(JobInfo jobInfo)
        {
            Dictionary<string, object> paramsMap = new Dictionary<string, object>();
            paramsMap.Add("job_No", jobInfo.No);
            SqlDataReader reader = Query(paramsMap);
            if (!reader.Read())
            {
                return sqlJob.AddJobInfo(jobInfo);
            }else
            {
                return false;
            }
            
        }

        /// <summary>
        /// 删除岗位信息
        /// 删除前需要注意是否有外表关联
        /// </summary>
        /// <param name="jobNo"></param>
        /// <returns></returns>
        public bool Delete(string jobNo)
        {
            Dictionary<string, object> paramsMap = new Dictionary<string, object>();
            paramsMap.Add("Job.job_No", jobNo);
            SqlDataReader reader = new Staff().Query(paramsMap);
            if (!reader.Read())
            {
                return sqlJob.DeleteJobInfo(jobNo);
            }
            else
            {
                return false;
            }
            
        }

        public bool Modify(JobInfo jobInfo)
        {
            return sqlJob.ModifyJobInfo(jobInfo);
        }

        public SqlDataReader Query(Dictionary<string, object> paramsMap)
        {
            return sqlJob.GetJobInfo(paramsMap);
        }
    }
}
