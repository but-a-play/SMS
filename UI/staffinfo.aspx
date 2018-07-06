<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffInfo.aspx.cs" Inherits="UI.StaffInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>员工信息展示</title>
    <link type="text/css" rel="stylesheet" href="css/easyui.css" />
    <link type="text/css" rel="stylesheet" href="css/icon.css" />
    <script type="text/javascript" src="scripts/jquery.min.js"></script>
    <script type="text/javascript" src="scripts/jquery.easyui.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="staff_No" DataSourceID="SqlDataSource1" Width="480px">
            <Columns>
                <asp:BoundField DataField="staff_No" HeaderText="工号" ReadOnly="True" SortExpression="staff_No" />
                <asp:BoundField DataField="staff_Name" HeaderText="姓名" SortExpression="staff_Name" />
                <asp:BoundField DataField="dept_Name" HeaderText="部门" SortExpression="dept_Name" />
                <asp:BoundField DataField="job_Name" HeaderText="岗位" SortExpression="job_Name" />
                <asp:BoundField DataField="staff_IsOnJob" HeaderText="是否在职" SortExpression="staff_IsOnJob" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="Button1" runat="server" Height="30px" OnClick="Button1_Click" Text="添加" Width="160px" />
        <asp:Button ID="Button2" runat="server" Height="30px" Text="删除" Width="160px" />
        <asp:Button ID="Button3" runat="server" Height="30px" Text="修改" Width="160px" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SMSDBConnectionString %>" SelectCommand="SELECT Staff.staff_No, Staff.staff_Name, Staff.staff_IsOnJob, Dept.dept_Name, Job.job_Name FROM Staff INNER JOIN Dept ON Staff.dept_No = Dept.dept_No INNER JOIN Job ON Staff.job_No = Job.job_No"></asp:SqlDataSource>
    </form>
</body>
</html>
