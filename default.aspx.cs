using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class data_lsit_Default : System.Web.UI.Page
{
    public Int32 index = 1;
    public Int32 size = 20; //设置每页显示多少条记录

    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.QueryString["page"]!=null)
            index =Convert.ToInt32(Request.QueryString["page"].ToString());
        Int32 datacount = access.connection.OleDbHelper.ExecuteCommand("SELECT id FROM art Distance");

        //select * from (select top "+ size +" * from (select top "+startcount+" * from art" order by id desc) order by id) order by id desc
        
        Int32 startcount = index * size;
        string sql = "select * from (select top " + size + " * from (select top " + startcount + " * from art order by id) order by id desc) order by id";
        DataTable dt = access.connection.OleDbHelper.GetDataSet(sql);
        art_list.DataSource = dt;
        art_list.DataBind();
        Int32 allpage = Convert.ToInt32(Math.Ceiling((double) datacount / (double)size));
        //Response.Write(allpage + "," + datacount + "," + size);
        pages2.showthanklist(datacount, allpage, index, "/data_list/default.aspx?", size);
    }
}
