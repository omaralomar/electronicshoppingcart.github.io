<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrackYourOrder.aspx.cs" Inherits="ShoppingHeart.TrackYourOrder" %>



<%@ Register src="ucCustomerOrder.ascx" tagname="ucCustomerOrder" tagprefix="uc1" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <uc1:ucCustomerOrder ID="ucCustomerOrder1" runat="server" />

        </div>
    </form>
</body>
</html>
