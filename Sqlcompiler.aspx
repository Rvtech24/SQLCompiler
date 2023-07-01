<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sqlcompiler.aspx.cs" Inherits="Sqlcompiler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 865px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="tbxquerypane" runat="server" Rows="15" TextMode="MultiLine" Width="100%" Font-Bold="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:TextBox ID="tbxrespane" runat="server" ReadOnly="True" Width="100%"></asp:TextBox>
                </td>
                <td align="center">
                    <asp:Button ID="btnrun" runat="server" Text="Run" OnClick="btnrun_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvresultpane" runat="server" Width="100%" AllowPaging="True" OnPageIndexChanging="gvresultpane_PageIndexChanging" OnSelectedIndexChanged="gvresultpane_SelectedIndexChanged" PageSize="4">
                    </asp:GridView>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
