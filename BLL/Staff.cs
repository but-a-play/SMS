﻿using System;
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
    public class Staff
    {
        private IStaff sqlStaff = DataAccess.CreateStaff();

        /// <summary>
        /// 增加人员信息
        /// 增加前需要注意重复信息的插入
        /// </summary>
        /// <param name="staffInfo">待插入的人员信息</param>
        /// <returns>bool</returns>
        public bool Add(StaffInfo staffInfo)
        {
            Dictionary<string, object> paramsMap = new Dictionary<string, object>();
            paramsMap.Add("staff_No", staffInfo.No);
            SqlDataReader reader = Query(paramsMap);
            if (!reader.Read())
            {
                return sqlStaff.AddStaffInfo(staffInfo);
            }
            else
            {
                return false;
            }

        }

      

        public bool Delete(string staffNo)
        {
            
            return sqlStaff.DeleteStaffInfo(staffNo);
        }

        public int Modify(StaffInfo staffInfo)
        {
            return sqlStaff.ModifyStaffInfo(staffInfo);
        }

        public SqlDataReader Query(Dictionary<string, object> paramsMap)
        {
            return sqlStaff.GetStaffInfo(paramsMap);
        }

        public DataSet QueryDS(Dictionary<string, object> paramsMap)
        {
            return sqlStaff.GetStaffInfoDS(paramsMap);
        }

        public ArrayList QueryNames()
        {
            return sqlStaff.GetStaffNames();
        }

        public ArrayList QueryNos()
        {
            return sqlStaff.GetStaffNos();
        }

        public void ModifyDept(ArrayList staffList, string deptNo)
        {
            sqlStaff.ModifyDept(staffList, deptNo);
        }
    }
}
