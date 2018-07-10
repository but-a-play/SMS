using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            if (TreeView1.SelectedNode.Value == "职工信息管理")
            {
                MultiView1.ActiveViewIndex = 2;
            }
            if (TreeView1.SelectedNode.Value == "部门信息管理")
            {
                MultiView1.ActiveViewIndex = 0;
            }
            if (TreeView1.SelectedNode.Value == "岗位信息管理")
            {
                MultiView1.ActiveViewIndex = 1;
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {
                GridView1.DataSourceID = null;
                GridView1.DataBind();
            }

        }

        protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            GridView1.DataSourceID = "SqlDataSource1";
            GridView1.DataBind();
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {
                GridView2.DataSourceID = null;
                GridView2.DataBind();
            }
        }

        protected void DetailsView2_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            GridView2.DataSourceID = "SqlDataSource2";
            GridView2.DataBind();
        }
    }
}