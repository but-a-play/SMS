using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Model;
using IDAL;
using DBUtil;

namespace SQLServerDAL
{
    public class Job : ISQLJob
    {
        public bool AddJobInfo(JobInfo jobInfo)
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "INSERT INTO Job (job_No, job_Name) VALUES (@job_No, @job_Name)";
            SqlParameter[] sqlParas = new SqlParameter[]
            {
                new SqlParameter("@job_No", jobInfo.No),
                new SqlParameter("@job_Name", jobInfo.Name)
            };
            
            return SqlHelper.ExecuteNonQuery(connStr, CommandType.Text, sqlText,sqlParas) == 1;
        }

        public bool DeleteJobInfo(string no)
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "DELETE FROM Job WHERE job_No = @job_No";
            SqlParameter[] sqlParas = new SqlParameter[]
            {
                new SqlParameter("@job_No", no)
            };

            return SqlHelper.ExecuteNonQuery(connStr, CommandType.Text, sqlText, sqlParas) == 1;
        }

        public JobInfo GetJobInfo(string no)
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "SELECT * FROM Job WHERE job_No = @job_No";
            SqlParameter[] sqlParas = new SqlParameter[]
            {
                new SqlParameter("@job_No", no)
            };

            return SqlHelper.ExecuteScalar(connStr, CommandType.Text, sqlText, sqlParas) as JobInfo;
        }

        public bool ModifyJobInfo(JobInfo jobInfo)
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "UPDATE Job SET job_Name = @job_Name WHERE job_No = @job_No";
            SqlParameter[] sqlParas = new SqlParameter[]
            {
                new SqlParameter("@job_No", jobInfo.No),
                new SqlParameter("@job_Name", jobInfo.Name)
            };

            return SqlHelper.ExecuteNonQuery(connStr, CommandType.Text, sqlText, sqlParas) == 1;
        }

        public SqlDataReader GetJobInfo(Dictionary<string, object> paramsMap)
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "SELECT * FROM Job";
            SqlParameter[] sqlParas = null;
            if (paramsMap != null && paramsMap.Count != 0)
            {
                sqlText += " WHERE ";
                int index = 0;
                sqlParas = new SqlParameter[paramsMap.Count];
                foreach (KeyValuePair<string, object> kvPair in paramsMap)
                {
                    sqlText += (kvPair.Key + " = @" + kvPair.Key);
                    
                    if (index != paramsMap.Count - 1)
                    {
                        sqlText += " and ";
                    }
                    sqlParas[index] = new SqlParameter("@" + kvPair.Key, kvPair.Value);
                    index++;
                }
            }

            return SqlHelper.ExecuteReader(connStr, CommandType.Text, sqlText, sqlParas);
        }
    }
}
