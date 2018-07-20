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

        protected void Page_Load(object sender, EventArgs e)
        {

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

       

      
    }
}