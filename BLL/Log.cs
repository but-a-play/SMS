using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using DALFactory;
using Model;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace BLL
{
    public class Log
    {
        private ILog sqlLog = DataAccess.CreateLog();
        public bool AddLog(LogInfo logInfo)
        {
            return sqlLog.AddLogInfo(logInfo);
        }

        public DataSet Query(Dictionary<string, object> paramsMap)
        {
            return sqlLog.GetLogInfoDS(paramsMap);
        }

        public bool AddQueryLog(string logMsg)
        {
            LogInfo logInfo = new LogInfo();
            logInfo.OperateNo = 4;
            logInfo.LogTime = DateTime.Now.ToString();
            logInfo.LogMsg = logMsg;
            return AddLog(logInfo);
        }

        public bool AddNewLog(string logMsg)
        {
            LogInfo logInfo = new LogInfo();
            logInfo.OperateNo = 1;
            logInfo.LogTime = DateTime.Now.ToString();
            logInfo.LogMsg = logMsg;
            return AddLog(logInfo);
        }

        public bool AddDeleteLog(string logMsg)
        {
            LogInfo logInfo = new LogInfo();
            logInfo.OperateNo = 2;
            logInfo.LogTime = DateTime.Now.ToString();
            logInfo.LogMsg = logMsg;
            return AddLog(logInfo);
        }

        public bool AddModifyLog(string logMsg)
        {
            LogInfo logInfo = new LogInfo();
            logInfo.OperateNo = 3;
            logInfo.LogTime = DateTime.Now.ToString();
            logInfo.LogMsg = logMsg;
            return AddLog(logInfo);
        }
    }
}
