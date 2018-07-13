using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

namespace UI
{
    public partial class Menu : System.Web.UI.Page
    {
        private Job jobService = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            jobService = new Job();
            if (!Page.IsPostBack)
            {
                gv_Job.DataSource = jobService.Query(null);
                gv_Job.DataBind();
            }

        }

        protected void tv_Menu_SelectedNodeChanged(object sender, EventArgs e)
        {
            if (tv_Menu.SelectedNode.Value == "职工信息管理")
            {
                mv.ActiveViewIndex = 2;
            }
            if (tv_Menu.SelectedNode.Value == "部门信息管理")
            {
                mv.ActiveViewIndex = 0;
            }
            if (tv_Menu.SelectedNode.Value == "岗位信息管理")
            {
                mv.ActiveViewIndex = 1;
            }
        }

        protected void gv_Department_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {
                gv_Department.DataSourceID = null;
                gv_Department.DataBind();
            }

        }

        protected void dv_Department_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            gv_Department.DataSourceID = "SqlDataSource1";
            gv_Department.DataBind();
        }

        protected void gv_Job_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {


            }
        }

        protected void dv_Job_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            gv_Job.DataSource = jobService.Query(null);
            gv_Job.DataBind();
        }

        protected void gv_Job_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            JobInfo jobInfo = new JobInfo();
            jobInfo.No = (gv_Job.Rows[e.RowIndex].Cells[2].Controls[0] as TextBox).Text.Trim();
            jobInfo.Name = (gv_Job.Rows[e.RowIndex].Cells[1].Controls[0] as TextBox).Text.Trim();
            jobService.Modify(jobInfo);
            gv_Job.EditIndex = -1;
            gv_Job.DataSource = jobService.Query(null);
            gv_Job.DataBind();
        }

        protected void gv_Job_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gv_Job_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv_Job.EditIndex = -1;
            gv_Job.DataSource = jobService.Query(null);
            gv_Job.DataBind();
        }

        protected void gv_Job_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }

        /// <summary>
        /// 删除岗位信息
        /// 调用jobService完成删除
        /// 根据返回结果判断是否成功
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gv_Job_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string delNo = gv_Job.Rows[e.RowIndex].Cells[2].Text.Trim();
            bool delResult = jobService.Delete(delNo);
            if (delResult)
            {
                gv_Job.DataSource = jobService.Query(null);
                gv_Job.DataBind();
            }
            else
            {
                string script = "<script> alert('目前该职位存在就职人员，请先对职工进行处理！') </script>";
                Page.RegisterStartupScript("", script);
            }

        }

        /// <summary>
        /// 添加岗位信息
        /// 调用jobService完成添加
        /// 根据返回结果判断是否成功
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dv_Job_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            JobInfo jobInfo = new JobInfo();
            jobInfo.No = (dv_Job.Rows[0].Controls[1].Controls[0] as TextBox).Text.Trim();
            jobInfo.Name = (dv_Job.Rows[1].Controls[1].Controls[0] as TextBox).Text.Trim();
            bool addResult = jobService.Add(jobInfo);
            if (addResult)
            {
                gv_Job.DataSource = jobService.Query(null);
                gv_Job.DataBind();
            }
            else
            {
                string script = "<script> alert('添加的信息已存在，请检查！') </script>";
                Page.RegisterStartupScript("", script);
            }

        }
    }
}