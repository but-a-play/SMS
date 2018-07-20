<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffPage.aspx.cs" Inherits="UI.StaffPage" %>

<!DOCTYPE>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>员工信息展示</title>
    <link type="text/css" rel="stylesheet" href="css/bootstrap.min.css?1" />
    <link type="text/css" rel="stylesheet" href="css/bootstrap-theme.min.css" />
</head>
<body>
    <form id="staff_form" runat="server">
        <div>


            <asp:Button ID="btnLoadNew" runat="server" OnClick="btnLoadNew_Click" Text="员工信息录入"  CssClass="btn btn-primary"/>
            <br />
            <br />
            <br />
            <asp:Label ID="lblStaffNo" runat="server" Text="工号"></asp:Label>
            <asp:DropDownList ID="ddlStaffNos" runat="server">
            </asp:DropDownList>
            <asp:Label ID="lblStaffNames" runat="server" Text="姓名"></asp:Label>
            <asp:DropDownList ID="ddlStaffNames" runat="server">
            </asp:DropDownList>
            <asp:Label ID="lblJobNames" runat="server" Text="岗位名称"></asp:Label>
            <asp:DropDownList ID="ddlJobNames" runat="server">
            </asp:DropDownList>
            <asp:Label ID="Label5" runat="server" Text="部门名称"></asp:Label>
            <asp:DropDownList ID="ddlDeptNames" runat="server">
            </asp:DropDownList>
            <asp:Label ID="Label6" runat="server" Text="是否在职"></asp:Label>
            <asp:DropDownList ID="ddlStaffIsOnJob" runat="server">
            </asp:DropDownList>
            <asp:Button ID="btnQueryStaff" runat="server" Text="查询" OnClick="btnQueryStaff_Click" />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="调岗" Width="41px" />
            <br />
            <asp:GridView ID="gvStaff" runat="server" AutoGenerateColumns="false"  DataKeyNames="staff_No,dept_No,job_No" Width="1031px" AllowSorting="True" OnRowCancelingEdit="gvStaff_RowCancelingEdit" OnRowCommand="gvStaff_RowCommand" OnRowDeleting="gvStaff_RowDeleting" OnRowEditing="gvStaff_RowEditing" OnRowUpdated="gvStaff_RowUpdated" OnRowUpdating="gvStaff_RowUpdating" OnRowDataBound="gvStaff_RowDataBound" AllowPaging="True" OnPageIndexChanging="gvStaff_PageIndexChanging" PageSize="5">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="40px" HeaderText="选择" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chk" />
                        </ItemTemplate>

                        <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="staff_No" HeaderText="工号" ReadOnly="True" SortExpression="staff_No" />
                    <asp:BoundField DataField="staff_Name" HeaderText="姓名" SortExpression="staff_Name" />

                    <asp:TemplateField HeaderText="是否在职" SortExpression="staff_IsOnJob">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlEditOnJob" runat="server">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblEditOnJob" runat="server" Text='<%# (bool)Eval("staff_IsOnJob") ? "在职":"离职" %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="部门名称" SortExpression="dept_Name">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlEditDepts" runat="server">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblEditDept" runat="server" Text='<%# Eval("dept_Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="岗位名称" SortExpression="job_Name">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlEditJobs" runat="server">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblEditJob" runat="server" Text='<%# Eval("job_Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:CommandField ButtonType="Button" HeaderText="操作" ShowDeleteButton="True" ShowEditButton="True" />
                </Columns>
            </asp:GridView>
        </div>

        <!--弹出层，-->
        <div id="divNewBlock" runat="server" style="display: none; width: 100%; text-align: center;" class="modal">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title" id="myModalLabel">职工调岗</h4>
                    </div>
                    <div class="modal-body" style="height: 80%;">
                        <div class="panel panel-default" style="position: absolute; width: 49%;">
                            <div class="panel-heading">
                                <h3 class="panel-title">StaffList
                                </h3>
                            </div>
                            <div class="panel-body">
                                <asp:CheckBoxList ID="chklStaff" runat="server"></asp:CheckBoxList>
                            </div>
                            <div class="panel-footer">
                                Panel footer
                            </div>
                        </div>
                        <div class="panel panel-default" style="width: 49%; float: right;">
                            <div class="panel-heading">
                                <h3 class="panel-title">DeptList
                                </h3>
                            </div>
                            <div class="panel-body">
                                <asp:RadioButtonList ID="rbtnlDept" runat="server"></asp:RadioButtonList>

                            </div>
                            <div class="panel-footer">
                                Panel footer
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" onclick="HideBlock()">关闭</button>
                        <button type="button" class="btn btn-primary" runat="server" onserverclick="editSubmit">调岗</button>
                    </div>
                </div>
            </div>
        </div>

        <div id="divNewStaff" runat="server" style="display: none; width: 100%; text-align: center;" class="modal">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title" id="myModalLabel">职工入职信息填写</h4>
                    </div>
                    <div class="modal-body" style="height: 30%;">
                        <div class="panel panel-default" style="position: absolute; width: 96%;">
                            <div class="panel-heading">
                                <h3 class="panel-title">NewStaff
                                </h3>
                            </div>
                            <div class="panel-body">
                                <asp:DetailsView ID="dvStaff" runat="server" AutoGenerateRows="False" DataKeyNames="staff_No,dept_No,job_No" DefaultMode="Insert" Height="60px" Width="100%">
                                    <Fields>
                                        <asp:BoundField DataField="staff_No" HeaderText="工号" ReadOnly="True" SortExpression="staff_No" />
                                        <asp:BoundField DataField="staff_Name" HeaderText="姓名" SortExpression="staff_Name" />
                                        <asp:TemplateField HeaderText="是否在职">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="staff_IsOnJobs" runat="server" Width="90px" AutoPostBack="true">
                                                    <asp:ListItem Value="True">在职</asp:ListItem>
                                                    <asp:ListItem Value="False">离职</asp:ListItem>
                                                </asp:DropDownList>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblIsOnJob" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="岗位名称">
                                            <EditItemTemplate>
                                                <asp:HiddenField ID="job_No" runat="server" />
                                                <asp:DropDownList ID="jobNames" runat="server" Width="90px" AutoPostBack="true" OnSelectedIndexChanged="queryJobNo" />
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblJobName" runat="server" Text='<%# Eval("job_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="部门名称">
                                            <EditItemTemplate>
                                                <asp:HiddenField ID="dept_No" runat="server" />
                                                <asp:DropDownList ID="deptNames" runat="server" Width="90px" AutoPostBack="true" OnSelectedIndexChanged="queryDeptNo" />
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblDeptName" runat="server" Text='<%# Eval("dept_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Fields>
                                </asp:DetailsView>
                                
                                <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="清空" />
                            </div>
                            <div class="panel-footer">
                                Panel footer
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" onclick="HideBlock()">关闭</button>
                        <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="员工信息录入" CssClass="btn btn-primary"></asp:Button>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
<script type="text/javascript" src="scripts/jquery.min.js"></script>
<script type="text/javascript" src="scripts/bootstrap.min.js"></script>
<script type="text/javascript">
    function HideBlock() {
        $('#divNewBlock').attr("style", "display:none");
        $('#divNewStaff').attr("style", "display:none");
        return false;
    }

</script>

</html>
