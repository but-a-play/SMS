using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using DBUtil;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace SQLServerDAL
{
    public class Operate : IOperate
    {
        public OperateInfo GetOperateInfo(int operateNo)
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "SELECT * FROM Operate ";
            SqlParameter[] sqlParas = sqlParas = new SqlParameter[1];
            if (operateNo != 0)
            {
                sqlText += " WHERE operate_No = @Operate_No";

                sqlParas[0] = new SqlParameter("@Operate_No", operateNo);
            }

            SqlDataReader reader = SqlHelper.ExecuteReader(connStr, CommandType.Text, sqlText, sqlParas);
            OperateInfo operateInfo = new OperateInfo();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    operateInfo.OperateName = reader["operate_Name"].ToString().Trim();
                    operateInfo.OperateNo = operateNo;
                }
            }

            return operateInfo;
        }
    }
}
