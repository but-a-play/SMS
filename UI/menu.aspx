<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Menu" %>

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
                <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" Width="148px">
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
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="1">
                    <asp:View ID="View1" runat="server">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="dept_No" DataSourceID="SqlDataSource1" Width="599px" AllowPaging="True" AllowSorting="True" OnRowCommand="GridView1_RowCommand">
                            <Columns>
                                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" HeaderText="操作" />
                                <asp:BoundField DataField="dept_No" HeaderText="部门编号" ReadOnly="True" SortExpression="dept_No" />
                                <asp:BoundField DataField="dept_Name" HeaderText="部门名称" SortExpression="dept_Name" />
                            </Columns>
                            <EmptyDataTemplate>
                            </EmptyDataTemplate>

                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SMSDBConnectionString %>" SelectCommand="SELECT * FROM [Dept]" DeleteCommand="DELETE FROM [Dept] WHERE [dept_No] = @dept_No" InsertCommand="INSERT INTO [Dept] ([dept_No], [dept_Name]) VALUES (@dept_No, @dept_Name)" UpdateCommand="UPDATE [Dept] SET [dept_Name] = @dept_Name WHERE [dept_No] = @dept_No">
                            <DeleteParameters>
                                <asp:Parameter Name="dept_No" Type="String" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="dept_No" Type="String" />
                                <asp:Parameter Name="dept_Name" Type="String" />
                            </InsertParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="dept_Name" Type="String" />
                                <asp:Parameter Name="dept_No" Type="String" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="dept_No" DataSourceID="SqlDataSource1" DefaultMode="Insert" Height="50px" OnItemInserted="DetailsView1_ItemInserted" Width="262px">
                            <Fields>
                                <asp:BoundField DataField="dept_No" HeaderText="部门编号" ReadOnly="True" SortExpression="dept_No" />
                                <asp:BoundField DataField="dept_Name" HeaderText="部门名称" SortExpression="dept_Name" />
                                <asp:CommandField ButtonType="Button" ShowInsertButton="True" />
                            </Fields>
                        </asp:DetailsView>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="job_No" DataSourceID="SqlDataSource2" Width="598px" AllowPaging="True" AllowSorting="True" OnRowCommand="GridView2_RowCommand">
                            <Columns>
                                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" ButtonType="Button" />
                                <asp:BoundField DataField="job_No" HeaderText="岗位编号" ReadOnly="True" SortExpression="job_No" />
                                <asp:BoundField DataField="job_Name" HeaderText="岗位名称" SortExpression="job_Name" />
                            </Columns>
                            <EmptyDataTemplate>
                            </EmptyDataTemplate>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SMSDBConnectionString %>" SelectCommand="SELECT * FROM [Job]" DeleteCommand="DELETE FROM [Job] WHERE [job_No] = @job_No" InsertCommand="INSERT INTO [Job] ([job_No], [job_Name]) VALUES (@job_No, @job_Name)" UpdateCommand="UPDATE [Job] SET [job_Name] = @job_Name WHERE [job_No] = @job_No">
                            <DeleteParameters>
                                <asp:Parameter Name="job_No" Type="String" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="job_No" Type="String" />
                                <asp:Parameter Name="job_Name" Type="String" />
                            </InsertParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="job_Name" Type="String" />
                                <asp:Parameter Name="job_No" Type="String" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                        <asp:DetailsView ID="DetailsView2" runat="server" AutoGenerateRows="False" DataKeyNames="job_No" DataSourceID="SqlDataSource2" DefaultMode="Insert" Height="50px" OnItemInserted="DetailsView2_ItemInserted" Width="246px">
                            <Fields>
                                <asp:BoundField DataField="job_No" HeaderText="岗位编号" ReadOnly="True" SortExpression="job_No" />
                                <asp:BoundField DataField="job_Name" HeaderText="岗位名称" SortExpression="job_Name" />
                                <asp:CommandField ButtonType="Button" ShowInsertButton="True" />
                            </Fields>
                        </asp:DetailsView>
                    </asp:View>
                    <asp:View ID="View3" runat="server">
                        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataKeyNames="staff_No,dept_No,job_No" DataSourceID="SqlDataSource3" Width="599px" AllowPaging="True" AllowSorting="True">
                            <Columns>
                                <asp:CommandField ButtonType="Button" HeaderText="操作" ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                                <asp:BoundField DataField="staff_No" HeaderText="工号" ReadOnly="True" SortExpression="staff_No" />
                                <asp:BoundField DataField="staff_Name" HeaderText="姓名" SortExpression="staff_Name" />
                                <asp:BoundField DataField="staff_IsOnJob" HeaderText="是否在职" SortExpression="staff_IsOnJob" />
                                <asp:BoundField DataField="dept_Name" HeaderText="部门名称" SortExpression="dept_Name" />
                                <asp:BoundField DataField="job_Name" HeaderText="岗位名称" SortExpression="job_Name" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SMSDBConnectionString %>" SelectCommand="SELECT Staff.staff_No, Staff.staff_Name, Staff.staff_IsOnJob, Dept.dept_No, Dept.dept_Name, Job.job_No, Job.job_Name FROM Staff INNER JOIN Dept ON Staff.dept_No = Dept.dept_No INNER JOIN Job ON Staff.job_No = Job.job_No" DeleteCommand="DELETE FROM [Staff] WHERE [staff_No] = @staff_No" InsertCommand="INSERT INTO [Staff] ([staff_No], [staff_Name], [job_No], [dept_No], [staff_IsOnJob]) VALUES (@staff_No, @staff_Name, @job_No, @dept_No, @staff_IsOnJob)" UpdateCommand="UPDATE [Staff] SET [staff_Name] = @staff_Name, [job_No] = @job_No, [dept_No] = @dept_No, [staff_IsOnJob] = @staff_IsOnJob WHERE [staff_No] = @staff_No">
                            <DeleteParameters>
                                <asp:Parameter Name="staff_No" Type="String" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="staff_No" Type="String" />
                                <asp:Parameter Name="staff_Name" Type="String" />
                                <asp:Parameter Name="job_No" Type="String" />
                                <asp:Parameter Name="dept_No" Type="String" />
                                <asp:Parameter Name="staff_IsOnJob" Type="String" />
                            </InsertParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="staff_Name" Type="String" />
                                <asp:Parameter Name="job_No" Type="String" />
                                <asp:Parameter Name="dept_No" Type="String" />
                                <asp:Parameter Name="staff_IsOnJob" Type="String" />
                                <asp:Parameter Name="staff_No" Type="String" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                        <asp:DetailsView ID="DetailsView3" runat="server" AutoGenerateRows="False" DataKeyNames="staff_No,dept_No,job_No" DataSourceID="SqlDataSource3" DefaultMode="Insert" Height="50px" Width="236px">
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
