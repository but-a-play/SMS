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
    public partial class LogPage : System.Web.UI.Page
    {
        private Log logService = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            logService = new Log();
            gvLog.DataSource = logService.Query(null);
            gvLog.DataBind();
        }

        protected void gvLog_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLog.PageIndex = e.NewPageIndex;
            Page_Load(sender, e);
        }
    }
}