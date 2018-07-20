using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using Model;
using BLL;

namespace UI
{
    public partial class StaffPage : System.Web.UI.Page
    {
        private Staff staffService = null;
        private Department deptService = null;
        private Job jobService = null;
        private Log logService = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            staffService = new Staff();
            deptService = new Department();
            jobService = new Job();
            logService = new Log();

            if (!Page.IsPostBack)
            {
                gvStaff.DataSource = staffService.QueryDS(null);
                gvStaff.DataBind();

                DropDownList jobNames = dvStaff.FindControl("jobNames") as DropDownList;
                jobNames.DataSource = jobService.QueryNames();
                jobNames.DataBind();
                jobNames.Items.Insert(0, new ListItem("--请选择--"));

                DropDownList deptNames = dvStaff.FindControl("deptNames") as DropDownList;
                deptNames.DataSource = deptService.QueryNames();
                deptNames.DataBind();
                deptNames.Items.Insert(0, new ListItem("--请选择--"));

                ddlStaffNos.DataSource = staffService.QueryNos();
                ddlStaffNos.DataBind();
                ddlStaffNos.Items.Insert(0, new ListItem("--请选择--"));

                ddlStaffNames.DataSource = staffService.QueryNames();
                ddlStaffNames.DataBind();
                ddlStaffNames.Items.Insert(0, new ListItem("--请选择--"));

                ddlDeptNames.DataSource = deptService.QueryNames();
                ddlDeptNames.DataBind();
                ddlDeptNames.Items.Insert(0, new ListItem("--请选择--"));

                ddlJobNames.DataSource = jobService.QueryNames();
                ddlJobNames.DataBind();
                ddlJobNames.Items.Insert(0, new ListItem("--请选择--"));

                ddlStaffIsOnJob.Items.Insert(0, new ListItem("--请选择--"));
                ddlStaffIsOnJob.Items.Insert(1, new ListItem("在职", "True"));
                ddlStaffIsOnJob.Items.Insert(2, new ListItem("离职", "False"));

                string logMsg = "查询所有职工信息";
                logService.AddQueryLog(logMsg);

            }

        }

        protected void gvStaff_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvStaff.EditIndex = -1;
            gvStaff.DataSource = staffService.QueryDS(null);
            gvStaff.DataBind();
        }

        protected void gvStaff_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvStaff_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string delNo = gvStaff.Rows[e.RowIndex].Cells[1].Text.Trim();
            bool delResult = staffService.Delete(delNo);
            if (delResult)
            {
                string logMsg = "工号为" + delNo + "的员工成功办理离职";
                logService.AddDeleteLog(logMsg);
                gvStaff.DataSource = staffService.QueryDS(null);
                gvStaff.DataBind();
            }
            else
            {
                string script = "<script> alert('职工离职失败！') </script>";
                Page.RegisterStartupScript("", script);
            }
        }

        protected void gvStaff_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvStaff.EditIndex = e.NewEditIndex;
            string oldJobName = (gvStaff.Rows[gvStaff.EditIndex].FindControl("lblEditJob") as Label).Text.Trim();
            string oldDeptName = (gvStaff.Rows[gvStaff.EditIndex].FindControl("lblEditDept") as Label).Text.Trim();
            gvStaff.DataSource = staffService.QueryDS(null);
            gvStaff.DataBind();
            (gvStaff.Rows[gvStaff.EditIndex].FindControl("ddlEditJobs") as DropDownList).Items.FindByText(oldJobName).Selected = true;
            (gvStaff.Rows[gvStaff.EditIndex].FindControl("ddlEditDepts") as DropDownList).Items.FindByText(oldDeptName).Selected = true;
        }

        protected void gvStaff_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }

        protected void gvStaff_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            StaffInfo staffInfo = new StaffInfo();
            staffInfo.No = gvStaff.Rows[e.RowIndex].Cells[1].Text.Trim();
            staffInfo.Name = (gvStaff.Rows[e.RowIndex].Cells[2].Controls[0] as TextBox).Text.Trim();
            staffInfo.IsOnJob = bool.Parse((gvStaff.Rows[e.RowIndex].Cells[3].Controls[1] as DropDownList).Text.Trim());
            staffInfo.DeptNo = (gvStaff.Rows[e.RowIndex].Cells[4].Controls[1] as DropDownList).Text.Trim();
            staffInfo.JobNo = (gvStaff.Rows[e.RowIndex].Cells[5].Controls[1] as DropDownList).Text.Trim();

            staffService.Modify(staffInfo);
            gvStaff.EditIndex = -1;
            gvStaff.DataSource = staffService.QueryDS(null);
            gvStaff.DataBind();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            StaffInfo staffInfo = new StaffInfo();
            staffInfo.No = (dvStaff.Rows[0].Controls[1].Controls[0] as TextBox).Text.Trim();
            staffInfo.Name = (dvStaff.Rows[1].Controls[1].Controls[0] as TextBox).Text.Trim();
            staffInfo.IsOnJob = bool.Parse((dvStaff.FindControl("staff_IsOnJobs") as DropDownList).Text.Trim());
            staffInfo.DeptNo = (dvStaff.FindControl("dept_No") as HiddenField).Value.Trim();
            staffInfo.JobNo = (dvStaff.FindControl("job_No") as HiddenField).Value.Trim();

            bool addResult = staffService.Add(staffInfo);
            if (addResult)
            {
                string logMsg = "工号为" + staffInfo.No + "的员工成功入职";
                logService.AddNewLog(logMsg);
                Response.Redirect(Request.Url.ToString());

            }
            else
            {
                string script = "<script> alert('添加的信息已存在，请检查！') </script>";
                Page.RegisterStartupScript("", script);
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            (dvStaff.Rows[0].Controls[1].Controls[0] as TextBox).Text = "";
            (dvStaff.Rows[1].Controls[1].Controls[0] as TextBox).Text = "";
            (dvStaff.FindControl("staff_IsOnJobs") as DropDownList).ClearSelection();
            (dvStaff.FindControl("staff_IsOnJobs") as DropDownList).Items[0].Selected = true;
            (dvStaff.FindControl("jobNames") as DropDownList).ClearSelection();
            (dvStaff.FindControl("jobNames") as DropDownList).Items[0].Selected = true;
            (dvStaff.FindControl("deptNames") as DropDownList).ClearSelection();
            (dvStaff.FindControl("deptNames") as DropDownList).Items[0].Selected = true;
        }

        protected void queryJobNo(object sender, EventArgs e)
        {
            string jobName = (dvStaff.FindControl("jobNames") as DropDownList).Text.Trim();

            if (jobName.Length != 0)
            {

                (dvStaff.FindControl("job_No") as HiddenField).Value = jobService.QueryNo(jobName);
            }
            else
            {
                (dvStaff.FindControl("job_No") as HiddenField).Value = "";
            }

        }

        protected void queryDeptNo(object sender, EventArgs e)
        {
            string deptName = (dvStaff.FindControl("deptNames") as DropDownList).Text.Trim();

            if (deptName.Length != 0)
            {

                (dvStaff.FindControl("dept_No") as HiddenField).Value = deptService.QueryNo(deptName);
            }
            else
            {
                (dvStaff.FindControl("dept_No") as HiddenField).Value = "";
            }
        }

        protected void gvStaff_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string isOnJob = e.Row.Cells[3].Text.Trim();
                if (isOnJob == "False")
                {
                    e.Row.Cells[3].Text = "离职";
                }
                else if (isOnJob == "True")
                {
                    e.Row.Cells[3].Text = "在职";
                }
                CheckBox chk = (CheckBox)e.Row.FindControl("chk");
                e.Row.Attributes["onclick"] = chk.ClientID + ".checked=!" + chk.ClientID + ".checked;";
                //停止事件冒泡，防止选中状态混乱
                chk.Attributes["onclick"] = "window.event.cancelBubble = true;";

                if (e.Row.RowState == DataControlRowState.Edit || e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
                {
                    DropDownList ddlEditOnJob = e.Row.FindControl("ddlEditOnJob") as DropDownList;
                    if (ddlEditOnJob != null)
                    {
                        ddlEditOnJob.Items.Insert(0, new ListItem("在职", "True"));
                        ddlEditOnJob.Items.Insert(1, new ListItem("离职", "False"));
                    }

                    DropDownList ddlEditJobs = e.Row.FindControl("ddlEditJobs") as DropDownList;
                    if (ddlEditJobs != null)
                    {
                        ArrayList jobList = jobService.GetJobList();
                        ddlEditJobs.Items.Insert(0, new ListItem());
                        int index = 1;
                        foreach (JobInfo job in jobList)
                        {
                            ddlEditJobs.Items.Insert(index, new ListItem(job.Name, job.No));
                            ++index;
                        }

                    }

                    DropDownList ddlEditDepts = e.Row.FindControl("ddlEditDepts") as DropDownList;
                    if (ddlEditDepts != null)
                    {
                        ArrayList deptList = deptService.GetDeptList();
                        ddlEditDepts.Items.Insert(0, new ListItem());
                        int index = 1;
                        foreach (DepartmentInfo dept in deptList)
                        {
                            ddlEditDepts.Items.Insert(index, new ListItem(dept.Name, dept.No));
                            ++index;
                        }

                    }
                }
            }

        }

        /// <summary>
        /// gvStaff下方的编辑按钮的触发事件
        /// 获取gvStaff中的选中项集合
        /// </summary>
        protected DataTable getSelectedRows()
        {
            DataTable tbSelectRows = new DataTable();
            tbSelectRows.Columns.Add(new DataColumn("staff_No"));
            tbSelectRows.Columns.Add(new DataColumn("staff_Name"));

            GridViewRowCollection rows = gvStaff.Rows;
            foreach (GridViewRow row in rows)
            {
                bool isChecked = (row.FindControl("chk") as CheckBox).Checked;
                if (isChecked)
                {
                    DataRow newRow = tbSelectRows.NewRow();
                    newRow["staff_No"] = row.Cells[1].Text.Trim();
                    newRow["staff_Name"] = row.Cells[2].Text.Trim();
                    tbSelectRows.Rows.Add(newRow);
                }
            }

            return tbSelectRows;
        }


        private void chklStaffLoad()
        {
            chklStaff.Items.Clear();
            DataTable dt = getSelectedRows();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string name = row["staff_Name"].ToString();
                    string no = row["staff_No"].ToString();
                    chklStaff.Items.Add(new ListItem(name, no));
                }
            }

        }

        private void rbtnlDeptLoad()
        {
            rbtnlDept.Items.Clear();
            DataTable dt = deptService.QueryByDT(null);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {

                    string name = row["dept_Name"].ToString();
                    string no = row["dept_No"].ToString();
                    rbtnlDept.Items.Add(new ListItem(name, no));
                }
            }
        }

        protected void editSubmit(object sender, EventArgs e)
        {
            string deptNo = rbtnlDept.SelectedValue.Trim();
            ArrayList staffList = new ArrayList();
            foreach (ListItem li in chklStaff.Items)
            {
                if (li.Selected)
                {
                    staffList.Add(li.Value);
                    string logMsg = "工号为" + li.Value + "的员工成功调岗到" + rbtnlDept.SelectedItem.Text;
                    logService.AddModifyLog(logMsg);
                }
            }

            staffService.ModifyDept(staffList, deptNo);


            Response.Redirect(Request.Url.ToString());
        }

      

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            chklStaffLoad();
            rbtnlDeptLoad();
            divNewBlock.Attributes["style"] = "display:block";

        }

        protected void btnQueryStaff_Click(object sender, EventArgs e)
        {
            string staffNo = ddlStaffNos.Text.Trim();
            string staffName = ddlStaffNames.Text.Trim();
            string jobName = ddlJobNames.Text.Trim();
            string deptName = ddlDeptNames.Text.Trim();
            string isOnJobStr = ddlStaffIsOnJob.Text.Trim();
            bool? isOnJob = null;
            //需要对string做bool转换
            if (isOnJobStr.Length > 0 && isOnJobStr != "--请选择--")
            {
                isOnJob = bool.Parse(isOnJobStr);
            }

            Dictionary<string, object> paramsMap = new Dictionary<string, object>();
            if (staffNo.Length != 0)
            {
                paramsMap.Add("staff_No", staffNo);
            }
            if (staffName.Length != 0)
            {
                paramsMap.Add("staff_Name", staffName);
            }
            if (jobName.Length != 0)
            {
                paramsMap.Add("job_Name", jobName);
            }
            if (deptName.Length != 0)
            {
                paramsMap.Add("dept_Name", deptName);
            }
            if (isOnJob != null)
            {
                paramsMap.Add("staff_IsOnJob", isOnJob);
            }

            gvStaff.DataSource = staffService.QueryDS(paramsMap);
            gvStaff.DataBind();
        }

        protected void btnLoadNew_Click(object sender, EventArgs e)
        {
            divNewStaff.Attributes["style"] = "display:block";
        }

        protected void gvStaff_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvStaff.PageIndex = e.NewPageIndex;
            gvStaff.DataSource = staffService.QueryDS(null);
            gvStaff.DataBind(); 
        }
    }
}