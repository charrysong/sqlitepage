using System;
using System.Web.UI.WebControls;

public partial class tools_page : System.Web.UI.UserControl
{
    //设置分页参数
    public int pagesize = 10; //设置每页显示多少条记录
    public string pagehtml = "";
    public int pagenum = 8;//设置每个分组有多少页码
    int startindex = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    public void showthanklist(int datacound,int pagecout, int curpage, string cururl,int pagesize)
    {

        //分页核心代码
        PagedDataSource pagedata = new PagedDataSource();
        //DataTable dt = LoadRepeater(id.ToString());

        int half = 1;
        while ((half + 1) * 2 < pagenum) { half++; }
        int start = 1;
        int end = 1;

        if (curpage > pagecout || curpage < 1) curpage = 1;
        pagedata.CurrentPageIndex = curpage - 1;
        //如果页面总数小于分组数量.
        if (pagenum >= pagecout)
        { end = pagecout; getPageindex(start, end, curpage, cururl, pagesize); }
        else
        {
            if (curpage - half > 0)
            {

                start = curpage - half;
                if (curpage + half > pagecout)
                {
                    start = pagecout - pagenum + 1;
                    end = pagecout;
                }
                else
                    end = curpage + half;

            }
            else
            {
                start = 1;
                end = pagenum > pagecout ? pagecout : pagenum;
            }

            getPageindex(start, end, curpage, cururl, pagesize);
        }
        jlcount.Text = Convert.ToString(datacound);
        crpage.Text = Convert.ToString(curpage);
        pgcount.Text = Convert.ToString(pagecout);
        if (pagecout == 1) //如果只有一个分组
        {
            HLpre.CssClass = "prefalse";
            HLnext.CssClass = "nextfalse";
            HLfst.CssClass = "fstfalse";
            HLlst.CssClass = "lstfalse";
        }
        else if (curpage == pagecout && curpage > 1)//如果当前分组是最后一个分组
        {

            HLpre.Enabled = true;
            HLnext.Enabled = false;
            HLpre.NavigateUrl = cururl + "page=" + (curpage - 1);
            HLfst.Enabled = true;
            HLfst.NavigateUrl = cururl + "page=1";
            HLfst.Enabled = true;
            HLfst.NavigateUrl = cururl + "page=1";
            HLnext.CssClass = "nextfalse";
            HLlst.CssClass = "lstfalse";
        }
        else if (curpage == 1 && curpage < pagecout)
        {
            HLpre.Enabled = false;
            HLnext.Enabled = true;
            HLfst.Enabled = false;
            HLlst.Enabled = true;
            HLlst.NavigateUrl = cururl + "page=" + Convert.ToString(pagecout);
            HLnext.NavigateUrl = cururl + "page=" + (curpage + 1);
            HLfst.CssClass = "fstfalse";
            HLpre.CssClass = "prefalse";
        }
        if (curpage > 1 && curpage < pagecout)//如果当前分组处在中间
        {
            HLpre.Enabled = true;
            HLpre.NavigateUrl = cururl + "page=" + (curpage - 1);
            HLnext.NavigateUrl = cururl + "page=" + (curpage + 1);
            HLnext.Enabled = true;
            HLfst.Enabled = true;
            HLfst.NavigateUrl = cururl + "page=1";
            HLlst.Enabled = true;
            HLlst.NavigateUrl = cururl + "page=" + Convert.ToString(pagecout);
        }
    }
    //设置分页样式
    private void getPageindex(int start, int end, int curpage,string cururl,int pagesize)
    {
        pagehtml = "";
        for (int i = start; i <= end - 1; i++)
        {
            if (curpage == i) { pagehtml += "<b href='" + cururl + "page=" + Convert.ToString(i + startindex - 1) + "' class='aa" + Convert.ToString(i + startindex - 1) + "'>" + Convert.ToString(i + startindex - 1) + "</b>"; }
            else
                pagehtml += "<a href='" + cururl + "page=" + Convert.ToString(i + startindex - 1) + "' class='a" + Convert.ToString(i + startindex - 1) + "'>" + Convert.ToString(i + startindex - 1) + "</a>";


        }
        if (curpage == end) { pagehtml += "<b id='lastid' href='" + cururl + "page=" + Convert.ToString(end + startindex - 1) + "' class='aa" + Convert.ToString(end + startindex - 1) + "'>" + Convert.ToString(end + startindex - 1) + "</b>"; }
        else
        {
            pagehtml += "<a id='lastid' href='" + cururl + "page=" + Convert.ToString(end + startindex - 1) + "' class='a" + Convert.ToString(end + startindex - 1) + "'>" + Convert.ToString(end + startindex - 1) + "</a>";
        }
    } 
}
