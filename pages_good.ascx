<%@ Control Language="C#" AutoEventWireup="true" CodeFile="pages_good.ascx.cs" Inherits="tools_page" %>
<div class="vc clearfix"><p>当前第&nbsp;&nbsp;<asp:Label ID="crpage" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;页 / 共&nbsp;&nbsp;<asp:Label ID="pgcount" runat="server" Text=""></asp:Label>&nbsp;&nbsp;页&nbsp;&nbsp;总共<asp:Label ID="jlcount" runat="server" Text=""></asp:Label>条记录&nbsp;&nbsp;</p><em><asp:HyperLink ID="HLfst" runat="server" CssClass="fst"></asp:HyperLink><asp:HyperLink ID="HLpre" runat="server" CssClass="pre"></asp:HyperLink><%= pagehtml %><asp:HyperLink ID="HLnext" runat="server" CssClass="next"></asp:HyperLink><asp:HyperLink ID="HLlst" runat="server" CssClass="lst"></asp:HyperLink></em></div>
