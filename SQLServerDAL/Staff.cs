using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using Model;
using IDAL;
using DBUtil;

namespace SQLServerDAL
{
    public class Staff : IStaff
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

        public SqlDataReader GetStaffInfo(Dictionary<string, object> paramsMap)
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "SELECT Staff.staff_No, Staff.staff_Name, Staff.staff_IsOnJob, Dept.dept_No, Dept.dept_Name, Job.job_No, Job.job_Name FROM Staff LEFT JOIN Dept ON Staff.dept_No = Dept.dept_No LEFT JOIN Job ON Staff.job_No = Job.job_No";
            SqlParameter[] sqlParas = null;
            if (paramsMap != null && paramsMap.Count != 0)
            {
                sqlText += " WHERE ";
                int index = 0;
                sqlParas = new SqlParameter[paramsMap.Count];
                foreach (KeyValuePair<string, object> kvPair in paramsMap )
                {
                    string[] keys = kvPair.Key.Split('.');
                    string key = keys[keys.Length - 1];
                    sqlText += (kvPair.Key + " = @" + key);
                    
                    if(index != paramsMap.Count - 1)
                    {
                        sqlText += " and ";
                    }
                    sqlParas[index] = new SqlParameter("@" + key, kvPair.Value);
                    index++;
                }
            }

            return SqlHelper.ExecuteReader(connStr, CommandType.Text, sqlText, sqlParas);
        }

        public DataSet GetStaffInfoDS(Dictionary<string, object> paramsMap)
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "SELECT Staff.staff_No, Staff.staff_Name, Staff.staff_IsOnJob, Dept.dept_No, Dept.dept_Name, Job.job_No, Job.job_Name FROM Staff LEFT JOIN Dept ON Staff.dept_No = Dept.dept_No LEFT JOIN Job ON Staff.job_No = Job.job_No";
            SqlParameter[] sqlParas = null;
            if (paramsMap != null && paramsMap.Count != 0)
            {
                sqlText += " WHERE ";
                int index = 0;
                sqlParas = new SqlParameter[paramsMap.Count];
                foreach (KeyValuePair<string, object> kvPair in paramsMap)
                {
                    string[] keys = kvPair.Key.Split('.');
                    string key = keys[keys.Length - 1];
                    sqlText += (kvPair.Key + " = @" + key);

                    if (index != paramsMap.Count - 1)
                    {
                        sqlText += " and ";
                    }
                    sqlParas[index] = new SqlParameter("@" + key, kvPair.Value);
                    index++;
                }
            }

            return SqlHelper.ExecuteDataset(connStr, CommandType.Text, sqlText, sqlParas);
        }

        public StaffInfo GetStaffInfo(string no)
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "SELECT Staff.staff_No, Staff.staff_Name, Staff.staff_IsOnJob, Dept.dept_No, Dept.dept_Name, Job.job_No, Job.job_Name FROM Staff LEFT JOIN Dept ON Staff.dept_No = Dept.dept_No LEFT JOIN Job ON Staff.job_No = Job.job_No WHERE Staff.staff_No  = @staff_No";
            SqlParameter[] sqlParas = new SqlParameter[]
            {
                new SqlParameter("@staff_No", no)
            };

            return SqlHelper.ExecuteScalar(connStr, CommandType.Text, sqlText, sqlParas) as StaffInfo;
        }

        public int ModifyStaffInfo(StaffInfo staffInfo)
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

            return SqlHelper.ExecuteNonQuery(connStr, CommandType.Text, sqlText, sqlParas);
        }

        public ArrayList GetStaffNames()
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "SELECT DISTINCT Staff_Name FROM Staff";
            DataSet ds = SqlHelper.ExecuteDataset(connStr, CommandType.Text, sqlText);
            ArrayList alst = new ArrayList();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                alst.Add(dr[0].ToString());
            }
            return alst;
        }


        public ArrayList GetStaffNos()
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "SELECT DISTINCT Staff_No FROM Staff";
            DataSet ds = SqlHelper.ExecuteDataset(connStr, CommandType.Text, sqlText);
            ArrayList alst = new ArrayList();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                alst.Add(dr[0].ToString());
            }
            return alst;
        }


        /// <summary>
        /// 修改部门
        /// </summary>
        /// <param name="staffList"></param>
        /// <param name="deptNo"></param>
        public void ModifyDept(ArrayList staffList, string deptNo)
        {
            foreach(string staffNo in staffList)
            {
                ModifyStaffDept(staffNo, deptNo);
            }
        }

        private void ModifyStaffDept(string staffNo, string deptNo)
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "UPDATE Staff SET  dept_No = @Dept_No WHERE staff_No = @Staff_No";
            SqlParameter[] sqlParas = new SqlParameter[]
            {
                new SqlParameter("@Staff_No", staffNo),
                new SqlParameter("@Dept_No", deptNo)
            };

            SqlHelper.ExecuteNonQuery(connStr, CommandType.Text, sqlText, sqlParas);
        }
    }
}
