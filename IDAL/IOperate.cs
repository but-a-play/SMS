using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    public interface IOperate
    {
        /// <summary>
        /// 获取对应编号的操作类型
        /// </summary>
        /// <param name="operateNo"></param>
        /// <returns></returns>
        OperateInfo GetOperateInfo(int operateNo);
    }
}
