<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogPage.aspx.cs" Inherits="UI.LogPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="logPage" runat="server">
    <div>
        <br />
        <asp:Label ID="lblOperateType" runat="server" Text="操作类型"></asp:Label>
        <asp:DropDownList ID="ddlOperateType" runat="server">
        </asp:DropDownList>
        <asp:Label ID="lblStaffName" runat="server" Text="被操作人"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Width="73px"></asp:TextBox>
        <asp:Label ID="lblOperateTime" runat="server" Text="操作时间"></asp:Label>
        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        <br />
        <asp:GridView ID="gvLog" runat="server" AutoGenerateColumns="false" AllowPaging="True" OnPageIndexChanging="gvLog_PageIndexChanging" PageSize="5">
             <Columns>
                    
                    <asp:BoundField DataField="log_Id" HeaderText="日志编号" ReadOnly="True" SortExpression="log_Id" />
                    <asp:BoundField DataField="operate_Name" HeaderText="操作类型" SortExpression="operate_Name" />
                    <asp:BoundField DataField="log_Msg" HeaderText="日志详情" SortExpression="log_Msg" />
                    <asp:BoundField DataField="log_Time" HeaderText="操作时间" SortExpression="log_Time" />
                    <asp:BoundField DataField="staff_Name" HeaderText="被操作人" SortExpression="staff_Name" />
                </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
