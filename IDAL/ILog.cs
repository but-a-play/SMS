using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace IDAL
{
    public interface ILog
    {
        /// <summary>
        /// 获取日志记录
        /// </summary>
        /// <returns></returns>
        ArrayList GetLogList(Dictionary<string, object> paramsMap);

        SqlDataReader GetLogInfo(Dictionary<string, object> paramsMap);

        bool AddLogInfo(LogInfo logInfo);

        DataSet GetLogInfoDS(Dictionary<string, object> paramsMap);
    }
}
