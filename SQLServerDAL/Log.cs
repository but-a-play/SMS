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
using System.Collections;

namespace SQLServerDAL
{
    public class Log : ILog
    {
        /// <summary>
        /// 增加日志记录
        /// </summary>
        /// <param name="logInfo"></param>
        public bool AddLogInfo(LogInfo logInfo)
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "INSERT INTO OperateLog (operate_No, log_Msg, log_Time) VALUES (@Operate_No, @Log_Msg, @Log_Time)";
            SqlParameter[] sqlParas = new SqlParameter[]
            {
                new SqlParameter("@Operate_No", logInfo.OperateNo),
                new SqlParameter("@Log_Msg", logInfo.LogMsg),
                new SqlParameter("@Log_Time", logInfo.LogTime)
            };

            return SqlHelper.ExecuteNonQuery(connStr, CommandType.Text, sqlText, sqlParas) == 1;
        }

        /// <summary>
        /// 查询日志
        /// </summary>
        /// <param name="paramsMap"></param>
        /// <returns></returns>
        public SqlDataReader GetLogInfo(Dictionary<string, object> paramsMap)
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "SELECT OperateLog.log_Id, OperateLog.operate_No, OperateLog.log_Msg, OperateLog.log_Time, Operate.operate_Name, Staff.staff_Name  FROM OperateLog INNER JOIN Operate ON OperateLog.operate_No = Operate.operate_No LEFT JOIN Staff On OperateLog.staffNo = Staff.staff_No";
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

            return SqlHelper.ExecuteReader(connStr, CommandType.Text, sqlText, sqlParas);
        }

        public DataSet GetLogInfoDS(Dictionary<string, object> paramsMap)
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "SELECT OperateLog.log_Id, OperateLog.operate_No, OperateLog.log_Msg, OperateLog.log_Time, Operate.operate_Name, Staff.staff_Name  FROM OperateLog INNER JOIN Operate ON OperateLog.operate_No = Operate.operate_No LEFT JOIN Staff On OperateLog.staffNo = Staff.staff_No";
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

        /// <summary>
        /// 查询日志
        /// 返回日志集合
        /// </summary>
        /// <param name="paramsMap"></param>
        /// <returns>ArrayList</returns>
        public ArrayList GetLogList(Dictionary<string, object> paramsMap)
        {
            SqlDataReader reader = GetLogInfo(null);
            ArrayList logList = new ArrayList();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    
                    LogInfo log = new LogInfo();
                    log.LogId = Int32.Parse(reader["log_Id"].ToString().Trim());
                    log.OperateNo = Int32.Parse(reader["operate_No"].ToString().Trim());
                    log.LogMsg = reader["log_Msg"].ToString().Trim();
                    log.LogTime = reader["log_Time"].ToString().Trim();
                    logList.Add(log);
                }
            }

            return logList;
        }
    }
}
