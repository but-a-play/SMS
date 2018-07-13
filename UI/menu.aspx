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
            <asp:Panel ID="Panel3" runat="server" Width="606px">
                <asp:MultiView ID="mv" runat="server" ActiveViewIndex="1">
                    <asp:View ID="v_Department" runat="server">
                        <asp:GridView ID="gv_Department" runat="server" AutoGenerateColumns="False" DataKeyNames="dept_No" Width="599px" AllowSorting="True" OnRowCommand="gv_Department_RowCommand">
                            <Columns>
                                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" HeaderText="操作" />
                                <asp:BoundField DataField="dept_No" HeaderText="部门编号" ReadOnly="True" SortExpression="dept_No" />
                                <asp:BoundField DataField="dept_Name" HeaderText="部门名称" SortExpression="dept_Name" />
                            </Columns>
                            <EmptyDataTemplate>
                            </EmptyDataTemplate>

                        </asp:GridView>
                        <asp:DetailsView ID="dv_Department" runat="server" AutoGenerateRows="False" DataKeyNames="dept_No" DefaultMode="Insert" Height="50px" OnItemInserted="dv_Department_ItemInserted" Width="262px">
                            <Fields>
                                <asp:BoundField DataField="dept_No" HeaderText="部门编号" ReadOnly="True" SortExpression="dept_No" />
                                <asp:BoundField DataField="dept_Name" HeaderText="部门名称" SortExpression="dept_Name" />
                                <asp:CommandField ButtonType="Button" ShowInsertButton="True" />
                            </Fields>
                        </asp:DetailsView>
                    </asp:View>
                    <asp:View ID="v_Job" runat="server">
                        <asp:GridView ID="gv_Job" runat="server" AutoGenerateColumns="False" Width="598px" AllowSorting="True" OnRowCommand="gv_Job_RowCommand" OnRowUpdating="gv_Job_RowUpdating" OnRowCancelingEdit="gv_Job_RowCancelingEdit" OnRowEditing="gv_Job_RowEditing" OnRowUpdated="gv_Job_RowUpdated" OnRowDeleting="gv_Job_RowDeleting">
                            <Columns>
                                <asp:CommandField ButtonType="Button" HeaderText="操作" ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                                <asp:BoundField DataField="job_Name" HeaderText="岗位名称" SortExpression="job_Name" />
                                <asp:BoundField DataField="job_No" HeaderText="岗位编号" SortExpression="job_No" />
                            </Columns>
                            <EmptyDataTemplate>
                            </EmptyDataTemplate>
                        </asp:GridView>
                        <asp:DetailsView ID="dv_Job" runat="server" AutoGenerateRows="False" DataKeyNames="job_No" DefaultMode="Insert" Height="50px" OnItemInserted="dv_Job_ItemInserted" Width="246px" OnItemInserting="dv_Job_ItemInserting">
                            <Fields>
                                <asp:BoundField DataField="job_No" HeaderText="岗位编号" ReadOnly="True" SortExpression="job_No" />
                                <asp:BoundField DataField="job_Name" HeaderText="岗位名称" SortExpression="job_Name" />
                                <asp:CommandField ButtonType="Button" ShowInsertButton="True" />
                            </Fields>
                        </asp:DetailsView>
                    </asp:View>
                    <asp:View ID="v_Staff" runat="server">
                        <asp:GridView ID="gv_Staff" runat="server" AutoGenerateColumns="False" DataKeyNames="staff_No,dept_No,job_No" Width="599px" AllowSorting="True">
                            <Columns>
                                <asp:CommandField ButtonType="Button" HeaderText="操作" ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                                <asp:BoundField DataField="staff_No" HeaderText="工号" ReadOnly="True" SortExpression="staff_No" />
                                <asp:BoundField DataField="staff_Name" HeaderText="姓名" SortExpression="staff_Name" />
                                <asp:BoundField DataField="staff_IsOnJob" HeaderText="是否在职" SortExpression="staff_IsOnJob" />
                                <asp:BoundField DataField="dept_Name" HeaderText="部门名称" SortExpression="dept_Name" />
                                <asp:BoundField DataField="job_Name" HeaderText="岗位名称" SortExpression="job_Name" />
                            </Columns>
                        </asp:GridView>
                        <asp:DetailsView ID="dv_Staff" runat="server" AutoGenerateRows="False" DataKeyNames="staff_No,dept_No,job_No" DefaultMode="Insert" Height="50px" Width="236px">
                            <Fields>
                                <asp:BoundField DataField="staff_No" HeaderText="工号" ReadOnly="True" SortExpression="staff_No" />
                                <asp:BoundField DataField="staff_Name" HeaderText="姓名" SortExpression="staff_Name" />
                                <asp:BoundField DataField="staff_IsOnJob" HeaderText="是否在职" SortExpression="staff_IsOnJob" />
                                <asp:TemplateField HeaderText="岗位名称">
                                    <EditItemTemplate>
                                        <asp:HiddenField ID="job_No" runat="server" Value='<%#Bind("job_Name")  %>' />
                                        <asp:DropDownList ID="job_Name" runat="server" Width="90px" AutoPostBack="true"/></EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("job_Name").ToString() %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="部门名称">
                                    <EditItemTemplate>
                                        <asp:HiddenField ID="dept_No" runat="server" Value='<%#Bind("部门名称")  %>' />
                                        <asp:DropDownList ID="dept_Names" runat="server" Width="90px" AutoPostBack="true"/></EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("部门名称").ToString() %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowInsertButton="True" />
                            </Fields>
                        </asp:DetailsView>
                    </asp:View>
                </asp:MultiView>
            </asp:Panel>

        </div>
    </form>
</body>
</html>
