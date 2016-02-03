<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ServiceUI.aspx.cs" Inherits="ServiceUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {}
        .auto-style2 {
            margin-left: 80px;
        }
        .auto-style3 {}
        .auto-style4 {}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style2">
    
        <asp:Panel ID="Panel1" runat="server">
        </asp:Panel>
        <br />
        Mitchell Claim Web Service<br />
        <br />
        <asp:Image ID="Image1" runat="server" ImageUrl="https://lh4.googleusercontent.com/--mf44bpr_L0/AAAAAAAAAAI/AAAAAAAAADA/jVmOIoKmWrk/s0-c-k-no-ns/photo.jpg" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Request Claim by Xml File Link"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style1" Width="392px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="RequestClaim" runat="server" Text="Request" OnClick="Button1_Click" />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Status: "></asp:Label>
        <br />
        <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <br />
        _________________________________________________________________<br />
        <asp:Label ID="Label3" runat="server" Text="Read Claim by Claim Number"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style1" Width="392px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ReadClaim" runat="server" Text="Submit" OnClick="ReadClaim_Click" />
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Claim Number"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="claimNumlbl" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label5" runat="server" Text="First Name"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="FName" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Last Name"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="LName" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label10" runat="server" Text="Status"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Status" runat="server"></asp:Label>
&nbsp; <br />
        <asp:Label ID="Label8" runat="server" Text="Loss Date"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lossdate" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label11" runat="server" Text="Loss Info"></asp:Label>
        :<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="CoDlbl" runat="server" Text="Cause of Loss Code"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="CauseOfLossCode" runat="server"></asp:Label>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="rdlbl" runat="server" Text="Reported Date"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="reportDate" runat="server"></asp:Label>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Des" runat="server" Text="Description"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="desResult" runat="server"></asp:Label>
        <br />
        <br />
        Assigned Adjuster ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="aaID" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        Vehicles List<br />
        <br />
        <asp:ListBox ID="lstVehi" runat="server" CssClass="auto-style3" Height="172px" Width="523px"></asp:ListBox>
        <br />
        <br />
        _________________________________________________________________<br />
        Search Claim by Loss Date<br />
        <br />
        Date Begin:<br />
        <asp:TextBox ID="txtBegin" runat="server" CssClass="auto-style1" Width="392px"></asp:TextBox>
        <br />
        <br />
        Date End:<br />
        <asp:TextBox ID="txtEnd" runat="server" CssClass="auto-style1" Width="392px"></asp:TextBox>
        <br />
        <asp:Button ID="searchVehiClaim" runat="server" OnClick="searchVehiClaim_Click" Text="Search" />
        <br />
        <br />
        <asp:ListBox ID="lstClaim" runat="server" CssClass="auto-style3" Height="172px" Width="523px"></asp:ListBox>
        <br />
        <br />
        <br />
        ________________________________________________________________________________<br />
        Search Vehicles By Claim Number<br />
        <asp:TextBox ID="vehiClaim" runat="server" CssClass="auto-style1" Width="392px"></asp:TextBox>
&nbsp;&nbsp;
        <asp:Button ID="VehicleSearchByClaim" runat="server" OnClick="VehicleSearchByClaim_Click" Text="Search" />
        <br />
        <br />
        <asp:ListBox ID="lstVehiClaim" runat="server" CssClass="auto-style4" Height="134px" Width="527px"></asp:ListBox>
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
