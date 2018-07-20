<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobPage.aspx.cs" Inherits="UI.JobPage" %>

<!DOCTYPE>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="jobInfoForm" runat="server">
        <div>
            <asp:GridView ID="gvJob" runat="server" AutoGenerateColumns="False" Width="598px" AllowSorting="True" OnRowCommand="gvJob_RowCommand" OnRowUpdating="gvJob_RowUpdating" OnRowCancelingEdit="gvJob_RowCancelingEdit" OnRowEditing="gvJob_RowEditing" OnRowUpdated="gvJob_RowUpdated" OnRowDeleting="gvJob_RowDeleting">
                <Columns>
                    <asp:CommandField ButtonType="Button" HeaderText="操作" ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                    <asp:BoundField DataField="job_Name" HeaderText="岗位名称" SortExpression="job_Name" />
                    <asp:BoundField DataField="job_No" HeaderText="岗位编号" SortExpression="job_No" />
                </Columns>
                <EmptyDataTemplate>
                </EmptyDataTemplate>

            </asp:GridView>
            <asp:DetailsView ID="dvJob" runat="server" AutoGenerateRows="False" DataKeyNames="job_No" DefaultMode="Insert" Height="50px" OnItemInserted="dvJob_ItemInserted" Width="246px" OnItemInserting="dvJob_ItemInserting" OnModeChanging="dvJob_ModeChanging">
                <Fields>
                    <asp:BoundField DataField="job_No" HeaderText="岗位编号" ReadOnly="True" SortExpression="job_No" />
                    <asp:BoundField DataField="job_Name" HeaderText="岗位名称" SortExpression="job_Name" />
                    <asp:CommandField ButtonType="Button" ShowInsertButton="True" />
                </Fields>
            </asp:DetailsView>
            <asp:Label ID="lblJobNo" runat="server" Text="岗位编号"></asp:Label>
            <asp:DropDownList ID="dropJobNos" runat="server">
            </asp:DropDownList>
            <br />
            <asp:Label ID="lblJobName" runat="server" Text="岗位名称"></asp:Label>
            <asp:DropDownList ID="dropJobNames" runat="server">
            </asp:DropDownList>
            <asp:Button ID="btnQueryJob" runat="server" OnClick="btnQueryJob_Click" Text="查询" />
            
        </div>
    </form>
</body>
</html>
