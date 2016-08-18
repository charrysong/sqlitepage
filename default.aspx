<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="data_lsit_Default" %>
<%@ Register Src="pages_good.ascx" TagName="pages" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        /**page2**/
#page{border:1px solid #ddd;height:30px;line-height:30px;}
.vc{font-size:12px;padding:5px 10px;}

.vc a{color:#333}
.vc a:hover{border:1px solid #333;color:#f60;text-decoration:none;}
.vc a,.vc b{float:left;width:20px;height:20px;line-height:20px;text-align:center;text-decoration:none;border:1px solid #ccc;font-family:'Microsoft YaHei';font-weight:normal;background:#e9eaf0;margin-right:5px;}
.vc b{float:left;background:#d20001;color:#fff;}
.vc em{float:right;font-style:normal;}
.vc p{float:left;}
.vc .pre,.vc .next,.vc .fst,.vc .lst{font-size:12px;font-weight:bold;text-decoration:none;margin:0 5px 0 0;display:block;width:20px;height:20px;font-family:宋体;}

.vc .pre:hover,.vc .pre,.vc .next:hover,.vc .next,.vc .prefalse,.vc .prefalse:hover,.vc .nextfalse,.vc .nextfalse:hover{background:url(/images/num.gif) no-repeat;font-family:宋体;}
.vc .fst,.vc .lst,.vc .fstfalse,.vc .fstfalse:hover,.vc .lstfalse,.vc .lstfalse:hover{background:url(/images/last_first.gif) no-repeat}
.vc .pre,.vc .pre:hover{background-position:0 0;}
.vc .next:hover,.vc .next{background-position: 0 bottom;}

.vc .fst{background-position:0 0;}
.vc .lst{background-position:0 bottom;}
.vc .prefalse,.vc .prefalse:hover,.vc .fstfalse,.vc .fstfalse:hover{background-position:right 0;border:1px solid #ccc;font-family:宋体;}
.vc .nextfalse,.vc .nextfalse:hover,.vc .lstfalse,.vc .lstfalse:hover{background-position:right -22px;border:1px solid #ccc;font-family:宋体;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <ul>
        <asp:Repeater ID="art_list" runat="server"><ItemTemplate><li><%# Eval("title")%></li></ItemTemplate></asp:Repeater>
    </ul>
        <uc1:pages ID="pages2" runat="server" />
    </form>
</body>
</html>
