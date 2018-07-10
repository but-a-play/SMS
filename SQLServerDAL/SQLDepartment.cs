﻿using System;
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
    public class SQLDepartment : ISQLDepartment
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

        public DepartmentInfo GetDepartmentInfo(string no)
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "SELECT * FROM Dept WHERE dept_No = @dept_No";
            SqlParameter[] sqlParas = new SqlParameter[]
            {
                new SqlParameter("@dept_No", no)
            };

            return SqlHelper.ExecuteScalar(connStr, CommandType.Text, sqlText, sqlParas) as DepartmentInfo;
        }

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
    }
}
