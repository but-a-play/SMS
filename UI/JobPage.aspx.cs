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
    public partial class JobPage : System.Web.UI.Page
    {
        private Job jobService = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                jobService = new Job();
                gvJob.DataSource = jobService.Query(null);
                gvJob.DataBind();

                dropJobNos.DataSource = jobService.QueryNos();
                dropJobNos.DataBind();
                dropJobNos.Items.Insert(0, new ListItem());

                dropJobNames.DataSource = jobService.QueryNames();
                dropJobNames.DataBind();
                dropJobNames.Items.Insert(0, new ListItem());
            }

        }

        protected void gvJob_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }

        protected void dvJob_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            gvJob.DataSource = jobService.Query(null);
            gvJob.DataBind();
        }

        protected void gvJob_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            JobInfo jobInfo = new JobInfo();
            jobInfo.No = (gvJob.Rows[e.RowIndex].Cells[2].Controls[0] as TextBox).Text.Trim();
            jobInfo.Name = (gvJob.Rows[e.RowIndex].Cells[1].Controls[0] as TextBox).Text.Trim();
            jobService.Modify(jobInfo);
            gvJob.EditIndex = -1;
            gvJob.DataSource = jobService.Query(null);
            gvJob.DataBind();
        }

        protected void gvJob_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvJob.EditIndex = e.NewEditIndex;
            gvJob.DataSource = jobService.Query(null);
            gvJob.DataBind();
        }

        protected void gvJob_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvJob.EditIndex = -1;
            gvJob.DataSource = jobService.Query(null);
            gvJob.DataBind();
        }

        protected void gvJob_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }

        /// <summary>
        /// 删除岗位信息
        /// 调用jobService完成删除
        /// 根据返回结果判断是否成功
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvJob_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string delNo = gvJob.Rows[e.RowIndex].Cells[2].Text.Trim();
            bool delResult = jobService.Delete(delNo);
            if (delResult)
            {
                gvJob.DataSource = jobService.Query(null);
                gvJob.DataBind();
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
        protected void dvJob_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            JobInfo jobInfo = new JobInfo();
            jobInfo.No = (dvJob.Rows[0].Controls[1].Controls[0] as TextBox).Text.Trim();
            jobInfo.Name = (dvJob.Rows[1].Controls[1].Controls[0] as TextBox).Text.Trim();
            bool addResult = jobService.Add(jobInfo);
            if (addResult)
            {
                gvJob.DataSource = jobService.Query(null);
                gvJob.DataBind();
            }
            else
            {
                string script = "<script> alert('添加的信息已存在，请检查！') </script>";
                Page.RegisterStartupScript("", script);
            }

        }

        protected void dvJob_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {

        }

        /// <summary>
        /// 岗位查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnQueryJob_Click(object sender, EventArgs e)
        {
            string jobNo = dropJobNos.Text.Trim();
            string jobName = dropJobNames.Text.Trim();
            Dictionary<string, object> paramsMap = new Dictionary<string, object>();
            if (jobNo.Length != 0)
            {
                paramsMap.Add("job_No", jobNo);
            }
            if (jobName.Length != 0)
            {
                paramsMap.Add("job_Name", jobName);
            }

            gvJob.DataSource = jobService.Query(paramsMap);
            gvJob.DataBind();


        }
    }
}