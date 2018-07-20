using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 用户操作类型
    /// </summary>
    public class OperateInfo
    {

        /// <summary>
        /// 操作类型编号
        /// </summary>
        private int operateNo;

        public int OperateNo
        {
            get { return operateNo; }
            set { operateNo = value; }
        }

        /// <summary>
        /// 操作类型名称
        /// </summary>
        private string operateName;

        public string OperateName
        {
            get { return operateName; }
            set { operateName = value; }
        }


    }
}
