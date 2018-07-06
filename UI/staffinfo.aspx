<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="staffinfo.aspx.cs" Inherits="UI.staffinfo" %>

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
    <div>
        <table id="dg" title="My Users" class="easyui-datagrid" style="width:550px;height:250px"
    		    url="get_users.php"
    		    toolbar="#toolbar"
    		    rownumbers="true" fitColumns="true" singleSelect="true">
    	    <thead>
    		    <tr>
    			    <th field="firstname" width="80">First Name</th>
    			    <th field="lastname" width="80">Last Name</th>
    			    <th field="phone" width="80">Phone</th>
    			    <th field="email" width="80">Email</th>
    		    </tr>
    	    </thead>
        </table>
        <div id="toolbar">
    	    <a href="#" class="easyui-linkbutton" iconCls="icon-add" plain="true" onclick="newUser()">New User</a>
    	    <a href="#" class="easyui-linkbutton" iconCls="icon-edit" plain="true" onclick="editUser()">Edit User</a>
    	    <a href="#" class="easyui-linkbutton" iconCls="icon-remove" plain="true" onclick="destroyUser()">Remove User</a>
        </div>
    </div>
    </form>
</body>
</html>
