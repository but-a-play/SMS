using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Model;
using IDAL;
using DALFactory;

namespace BLL
{
    public class Test
    {

        private ISQLJob sqlJob = DALFactor.CreateBaseISQL("JobInfo") as ISQLJob;
        public bool Add(JobInfo jobInfo)
        {
            return sqlJob.AddJobInfo(jobInfo);
        }

        public bool Delete(string jobNo)
        {
            return sqlJob.DeleteJobInfo(jobNo);
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
