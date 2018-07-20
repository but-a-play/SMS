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
    public partial class DepartmentPage : System.Web.UI.Page
    {
        private Department deptService = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            deptService = new Department();

            if (!Page.IsPostBack)
            {
                gvDepartment.DataSource = deptService.Query(null);
                gvDepartment.DataBind();

                ddlDeptNos.DataSource = deptService.QueryNos();
                ddlDeptNos.DataBind();
                ddlDeptNos.Items.Insert(0, new ListItem());

                ddlDeptNames.DataSource = deptService.QueryNames();
                ddlDeptNames.DataBind();
                ddlDeptNames.Items.Insert(0, new ListItem());
            }
                
        }
        protected void gvDepartment_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void dvDepartment_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            gvDepartment.DataSource = deptService.Query(null);
            gvDepartment.DataBind();
        }

        protected void btnQueryDept_Click(object sender, EventArgs e)
        {
            string deptNo = ddlDeptNos.Text.Trim();
            string deptName = ddlDeptNames.Text.Trim();
            Dictionary<string, object> paramsMap = new Dictionary<string, object>();
            if (deptNo.Length != 0)
            {
                paramsMap.Add("dept_No", deptNo);
            }
            if (deptName.Length != 0)
            {
                paramsMap.Add("dept_Name", deptName);
            }

            gvDepartment.DataSource = deptService.Query(paramsMap);
            gvDepartment.DataBind();
        }

        protected void gvDepartment_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string delNo = gvDepartment.Rows[e.RowIndex].Cells[1].Text.Trim();
            bool delResult = deptService.Delete(delNo);
            if (delResult)
            {
                gvDepartment.DataSource = deptService.Query(null);
                gvDepartment.DataBind();
            }
            else
            {
                string script = "<script> alert('目前该部门存在就职人员，请先对职工进行处理！') </script>";
                Page.RegisterStartupScript("", script);
            }
        }

        protected void dvDepartment_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {

        }

        protected void gvDepartment_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvDepartment.EditIndex = -1;
            gvDepartment.DataSource = deptService.Query(null);
            gvDepartment.DataBind();
        }

        protected void gvDepartment_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvDepartment.EditIndex = e.NewEditIndex;
            gvDepartment.DataSource = deptService.Query(null);
            gvDepartment.DataBind();
        }

        protected void gvDepartment_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }

        protected void gvDepartment_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DepartmentInfo deptInfo = new DepartmentInfo();
            deptInfo.No = (gvDepartment.Rows[e.RowIndex].Cells[1].Controls[0] as TextBox).Text.Trim();
            deptInfo.Name = (gvDepartment.Rows[e.RowIndex].Cells[2].Controls[0] as TextBox).Text.Trim();
            deptService.Modify(deptInfo);
            gvDepartment.EditIndex = -1;
            gvDepartment.DataSource = deptService.Query(null);
            gvDepartment.DataBind();
        }

        protected void dvDepartment_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            DepartmentInfo deptInfo = new DepartmentInfo();
            deptInfo.No = (dvDepartment.Rows[0].Controls[1].Controls[0] as TextBox).Text.Trim();
            deptInfo.Name = (dvDepartment.Rows[1].Controls[1].Controls[0] as TextBox).Text.Trim();
            bool addResult = deptService.Add(deptInfo);
            if (addResult)
            {
                gvDepartment.DataSource = deptService.Query(null);
                gvDepartment.DataBind();
            }
            else
            {
                string script = "<script> alert('添加的信息已存在，请检查！') </script>";
                Page.RegisterStartupScript("", script);
            }
        }
    }
}