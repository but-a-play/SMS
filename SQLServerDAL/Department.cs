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
using System.Collections;

namespace SQLServerDAL
{
    public class Department : IDepartment
    {
        public bool AddDepartmentInfo(DepartmentInfo departmentInfo)
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "INSERT INTO Dept (dept_No, dept_Name) VALUES (@dept_No, @dept_Name)";
            SqlParameter[] sqlParas = new SqlParameter[]
            {
                new SqlParameter("@dept_No", departmentInfo.No),
                new SqlParameter("@dept_Name", departmentInfo.Name)
            };

            return SqlHelper.ExecuteNonQuery(connStr, CommandType.Text, sqlText, sqlParas) == 1;
        }

        public bool DeleteDepartmentInfo(string no)
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "DELETE FROM Dept WHERE dept_No = @dept_No";
            SqlParameter[] sqlParas = new SqlParameter[]
            {
                new SqlParameter("@dept_No", no)
            };

            return SqlHelper.ExecuteNonQuery(connStr, CommandType.Text, sqlText, sqlParas) == 1;
        }

        //public DepartmentInfo GetDepartmentInfo(string no)
        //{
        //    string connStr = SqlHelper.GetConnString();
        //    string sqlText = "SELECT * FROM Dept WHERE dept_No = @dept_No";
        //    SqlParameter[] sqlParas = new SqlParameter[]
        //    {
        //        new SqlParameter("@dept_No", no)
        //    };

        //    return SqlHelper.ExecuteScalar(connStr, CommandType.Text, sqlText, sqlParas) as DepartmentInfo;
        //}

        public bool ModifyDepartmentInfo(DepartmentInfo departmentInfo)
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "UPDATE Dept SET dept_Name = @dept_Name WHERE dept_No = @dept_No";
            SqlParameter[] sqlParas = new SqlParameter[]
            {
                new SqlParameter("@dept_No", departmentInfo.No),
                new SqlParameter("@dept_Name", departmentInfo.Name)
            };

            return SqlHelper.ExecuteNonQuery(connStr, CommandType.Text, sqlText, sqlParas) == 1;
        }

        public SqlDataReader GetDepartmentInfo(Dictionary<string, object> paramsMap)
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "SELECT * FROM Dept";
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

        public ArrayList GetDepartmentNos()
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "SELECT DISTINCT dept_No FROM Dept";
            DataSet ds = SqlHelper.ExecuteDataset(connStr, CommandType.Text, sqlText);
            ArrayList alst = new ArrayList();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                alst.Add(dr[0].ToString());
            }
            return alst;
        }

        public ArrayList GetDepartmentNames()
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "SELECT DISTINCT dept_Name FROM Dept";
            DataSet ds = SqlHelper.ExecuteDataset(connStr, CommandType.Text, sqlText);
            ArrayList alst = new ArrayList();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                alst.Add(dr[0].ToString());
            }
            return alst;
        }

        public string GetDeptNo(string name)
        {
            string connStr = SqlHelper.GetConnString();
            SqlParameter[] sqlParas = new SqlParameter[1]; 
            string sqlText = "SELECT dept_No FROM Dept";
            if (name != null && name.Length != 0)
            {
                sqlText += " WHERE Dept_Name = @Dept_Name";

                sqlParas[0] = new SqlParameter("@Dept_Name", name);
            }

            return SqlHelper.ExecuteScalar(connStr, CommandType.Text, sqlText, sqlParas).ToString();
        }

        public DataTable GetDepartmentByDT(Dictionary<string, object> paramsMap)
        {
            return SqlHelper.ConvertDataReaderToDataTable(GetDepartmentInfo(paramsMap));
        }

        public ArrayList GetDeptList()
        {

            SqlDataReader reader = GetDepartmentInfo(null);
            ArrayList deptList = new ArrayList();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    DepartmentInfo dept = new DepartmentInfo();
                    dept.No = reader["dept_No"].ToString().Trim();
                    dept.Name = reader["dept_Name"].ToString().Trim();
                    deptList.Add(dept);
                }
            }

            return deptList;
        }
    }
}
