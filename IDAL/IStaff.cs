﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace IDAL
{
    public interface IStaff
    {
        /// <summary>
        /// 根据工号查询职工信息
        /// </summary>
        /// <param name="no">工号</param>
        /// <returns>职工信息实例</returns>
        StaffInfo GetStaffInfo(string no);

        /// <summary>
        /// 增加职工
        /// </summary>
        /// <param name="staffInfo">增加的职工信息</param>
        /// <returns>是否增加成功</returns>
        bool AddStaffInfo(StaffInfo staffInfo);

        /// <summary>
        /// 删除职工
        /// </summary>
        /// <param name="no">待删除的职工工号</param>
        /// <returns>是否删除成功</returns>
        bool DeleteStaffInfo(string no);

        /// <summary>
        /// 修改职工信息
        /// </summary>
        /// <param name="staffInfo">修改的职工信息</param>
        /// <returns>是否修改成功</returns>
        int ModifyStaffInfo(StaffInfo staffInfo);

        SqlDataReader GetStaffInfo(Dictionary<string, object> paramsMap);

        ArrayList GetStaffNames();

        ArrayList GetStaffNos();

        void ModifyDept(ArrayList staffList, string deptNo);

        DataSet GetStaffInfoDS(Dictionary<string, object> paramsMap);

    }
}
