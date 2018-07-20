<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="UI.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        #Panel2 {
            float: left;
        }

        #Panel3 {
            float: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Panel ID="Panel2" runat="server" Width="144px">
                <asp:TreeView ID="tv_Menu" runat="server" OnSelectedNodeChanged="tv_Menu_SelectedNodeChanged" Width="148px">
                    <Nodes>
                        <asp:TreeNode Text="人员管理" Value="人员管理">
                            <asp:TreeNode Text="职工信息管理" Value="职工信息管理"></asp:TreeNode>
                            <asp:TreeNode Text="部门信息管理" Value="部门信息管理"></asp:TreeNode>
                            <asp:TreeNode Text="岗位信息管理" Value="岗位信息管理"></asp:TreeNode>
                        </asp:TreeNode>
                    </Nodes>
                </asp:TreeView>
            </asp:Panel>
            <asp:Panel ID="Panel3" runat="server" Width="1000px" Height="1000px">
                <asp:MultiView ID="mv" runat="server" ActiveViewIndex="1">
                    <asp:View ID="v_Job" runat="server">
                        <iframe frameborder="0" scrolling="yes" src="/JobPage.aspx" style="height: 100%; visibility: inherit; width: 100%; z-index: 1;"></iframe>
                    </asp:View>
                    <asp:View ID="v_Department" runat="server">
                        <iframe frameborder="0" scrolling="yes" src="/DepartmentPage.aspx" style="height: 100%; visibility: inherit; width: 100%; z-index: 1;"></iframe>
                    </asp:View>
                    <asp:View ID="v_Staff" runat="server">
                        <iframe frameborder="0" scrolling="yes" src="/StaffPage.aspx" style="height: 100%; visibility: inherit; width: 100%; z-index: 1;"></iframe>
                    </asp:View>
                    
                </asp:MultiView>
            </asp:Panel>

        </div>
    </form>
</body>
</html>
