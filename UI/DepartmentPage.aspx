<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartmentPage.aspx.cs" Inherits="UI.DepartmentPage" %>

<!DOCTYPE>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="departmentInfo_form" runat="server">
        <div>
            <asp:GridView ID="gvDepartment" runat="server" AutoGenerateColumns="False" DataKeyNames="dept_No" Width="599px" AllowSorting="True" OnRowCommand="gvDepartment_RowCommand" OnRowCancelingEdit="gvDepartment_RowCancelingEdit" OnRowDeleting="gvDepartment_RowDeleting" OnRowEditing="gvDepartment_RowEditing" OnRowUpdated="gvDepartment_RowUpdated" OnRowUpdating="gvDepartment_RowUpdating">
                <Columns>
                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" HeaderText="操作" />
                    <asp:BoundField DataField="dept_No" HeaderText="部门编号" ReadOnly="True" SortExpression="dept_No" />
                    <asp:BoundField DataField="dept_Name" HeaderText="部门名称" SortExpression="dept_Name" />
                </Columns>
                <EmptyDataTemplate>
                </EmptyDataTemplate>

            </asp:GridView>
            <asp:DetailsView ID="dvDepartment" runat="server" AutoGenerateRows="False" DataKeyNames="dept_No" DefaultMode="Insert" Height="50px" OnItemInserted="dvDepartment_ItemInserted" Width="262px" OnItemInserting="dvDepartment_ItemInserting" OnModeChanging="dvDepartment_ModeChanging">
                <Fields>
                    <asp:BoundField DataField="dept_No" HeaderText="部门编号" ReadOnly="True" SortExpression="dept_No" />
                    <asp:BoundField DataField="dept_Name" HeaderText="部门名称" SortExpression="dept_Name" />
                    <asp:CommandField ButtonType="Button" ShowInsertButton="True" />
                </Fields>
            </asp:DetailsView>
            <asp:Label ID="lblDeptNo" runat="server" Text="部门编号"></asp:Label>
            <asp:DropDownList ID="ddlDeptNos" runat="server">
            </asp:DropDownList>
            <br />
            <asp:Label ID="lblDeptName" runat="server" Text="部门名称"></asp:Label>
            <asp:DropDownList ID="ddlDeptNames" runat="server">
            </asp:DropDownList>
            <asp:Button ID="btnQueryDept" runat="server" OnClick="btnQueryDept_Click" Text="查询" />
            
        </div>
    </form>
</body>
</html>
