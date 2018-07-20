using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 用户日志
    /// </summary>
    public class LogInfo
    {
        /// <summary>
        /// 日志编号
        /// </summary>
        private int logId;

        public int LogId
        {
            get { return logId; }
            set { logId = value; }
        }

        /// <summary>
        /// 操作编号
        /// </summary>
        private int operateNo;

        public int OperateNo
        {
            get { return operateNo; }
            set { operateNo = value; }
        }

        /// <summary>
        /// 日志描述
        /// </summary>
        private string logMsg;

        public string LogMsg
        {
            get { return logMsg; }
            set { logMsg = value; }
        }

        /// <summary>
        /// 用户操作时间。日志记录时间
        /// </summary>
        private string logTime;

        public string LogTime
        {
            get { return logTime; }
            set { logTime = value; }
        }


        private string staffNo;

        public string StaffNo
        {
            get { return staffNo; }
            set { staffNo = value; }
        }

    }
}
