using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SqlClient;
using Model;
using IDAL;
using DBUtil;
using System.Data;

namespace SQLServerDAL
{
    public class Job : IJob
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

        //public JobInfo GetJobInfo(string no)
        //{
        //    string connStr = SqlHelper.GetConnString();
        //    string sqlText = "SELECT * FROM Job WHERE job_No = @job_No";
        //    SqlParameter[] sqlParas = new SqlParameter[]
        //    {
        //        new SqlParameter("@job_No", no)
        //    };

        //    return SqlHelper.ExecuteScalar(connStr, CommandType.Text, sqlText, sqlParas) as JobInfo;
        //}

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

        public ArrayList GetJobNos()
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "SELECT DISTINCT Job_No FROM Job";
            DataSet ds = SqlHelper.ExecuteDataset(connStr, CommandType.Text, sqlText);
            ArrayList alst = new ArrayList();

            foreach(DataRow dr in ds.Tables[0].Rows){
                alst.Add(dr[0].ToString());
            }
            return alst;
        }

        public ArrayList GetJobNames()
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "SELECT DISTINCT Job_Name FROM Job";
            DataSet ds = SqlHelper.ExecuteDataset(connStr, CommandType.Text, sqlText);
            ArrayList alst = new ArrayList();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                alst.Add(dr[0].ToString());
            }
            return alst;
        }

        public string GetJobNo(string name)
        {
            string connStr = SqlHelper.GetConnString();
            SqlParameter[] sqlParas = sqlParas = new SqlParameter[1]; 
            string sqlText = "SELECT Job_No FROM Job";
            if (name != null && name.Length != 0)
            {
                sqlText += " WHERE Job_Name = @Job_Name";

                sqlParas[0] = new SqlParameter("@Job_Name" , name);
            }

            return SqlHelper.ExecuteScalar(connStr, CommandType.Text, sqlText, sqlParas).ToString();
        }

        public ArrayList GetJobList()
        {
            SqlDataReader reader =  GetJobInfo(null);
            ArrayList jobList = new ArrayList();
            if (reader.HasRows)
            {
                
                while (reader.Read())
                {
                    JobInfo job = new JobInfo();
                    job.No = reader["job_No"].ToString().Trim();
                    job.Name = reader["job_Name"].ToString().Trim();
                    jobList.Add(job);
                }
            }

            return jobList;
        }
    }
}
