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
    public class SQLStaff : ISQLStaff
    {
        public bool AddStaffInfo(StaffInfo staffInfo)
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "INSERT INTO Staff (staff_No, staff_Name, job_No, dept_No, staff_IsOnJob) VALUES (@staff_No, @staff_Name, @job_No, @dept_No, @staff_IsOnJob)";
            SqlParameter[] sqlParas = new SqlParameter[]
            {
                new SqlParameter("@staff_No", staffInfo.No),
                new SqlParameter("@staff_Name", staffInfo.Name),
                new SqlParameter("@job_No", staffInfo.JobNo),
                new SqlParameter("@dept_No", staffInfo.DeptNo),
                new SqlParameter("@staff_IsOnJob", staffInfo.IsOnJob)
            };

            return SqlHelper.ExecuteNonQuery(connStr, CommandType.Text, sqlText, sqlParas) == 1;
        }

        public bool DeleteStaffInfo(string no)
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "DELETE FROM Staff WHERE staff_No = @staff_No";
            SqlParameter[] sqlParas = new SqlParameter[]
            {
                new SqlParameter("@staff_No", no)
            };

            return SqlHelper.ExecuteNonQuery(connStr, CommandType.Text, sqlText, sqlParas) == 1;
        }

        public List<StaffInfo> GetStaffInfo(Dictionary<string, object> paramsMap)
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "SELECT Staff.staff_No, Staff.staff_Name, Staff.staff_IsOnJob, Dept.dept_No, Dept.dept_Name, Job.job_No, Job.job_Name FROM Staff INNER JOIN Dept ON Staff.dept_No = Dept.dept_No INNER JOIN Job ON Staff.job_No = Job.job_No";
            if (paramsMap.Count != 0)
            {
                sqlText += " WHERE ";
                int index = 0;
                foreach (KeyValuePair<string, object> kvPair in paramsMap )
                {
                    sqlText += (kvPair.Key + " = @" + kvPair.Key);
                    index++;
                    if(index != paramsMap.Count)
                    {
                        sqlText += " and ";
                    }
                }
            }

            return SqlHelper.ExecuteScalar(connStr, CommandType.Text, sqlText, sqlParas) as StaffInfo;
        }

        public StaffInfo GetStaffInfo(string no)
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "SELECT Staff.staff_No, Staff.staff_Name, Staff.staff_IsOnJob, Dept.dept_No, Dept.dept_Name, Job.job_No, Job.job_Name FROM Staff INNER JOIN Dept ON Staff.dept_No = Dept.dept_No INNER JOIN Job ON Staff.job_No = Job.job_No WHERE Staff.staff_No  = @staff_No";
            SqlParameter[] sqlParas = new SqlParameter[]
            {
                new SqlParameter("@staff_No", no)
            };

            return SqlHelper.ExecuteScalar(connStr, CommandType.Text, sqlText, sqlParas) as StaffInfo;
        }

        public bool ModifyStaffInfo(StaffInfo staffInfo)
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "UPDATE Staff SET staff_Name = @staff_Name, job_No = @job_No, dept_No = @dept_No, staff_IsOnJob = @staff_IsOnJob WHERE staff_No = @staff_No";
            SqlParameter[] sqlParas = new SqlParameter[]
            {
                new SqlParameter("@staff_No", staffInfo.No),
                new SqlParameter("@staff_Name", staffInfo.Name),
                new SqlParameter("@job_No", staffInfo.JobNo),
                new SqlParameter("@dept_No", staffInfo.DeptNo),
                new SqlParameter("@staff_IsOnJob", staffInfo.IsOnJob)
            };

            return SqlHelper.ExecuteNonQuery(connStr, CommandType.Text, sqlText, sqlParas) == 1;
        }
    }
}
