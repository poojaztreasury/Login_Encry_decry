using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content : System.Web.UI.Page
{
  //  public Int32 count = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = "Welcome " + Session["ss"].ToString() ;
        Label2.Text = "0";
        
        if (IsPostBack==false)
        {
           ViewState["cvalue"]=0;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ViewState["cvalue"] = Convert.ToInt32(ViewState["cvalue"]) + 1;
        Label2.Text = ViewState["cvalue"].ToString();
       // Button btn = (Button)sender;
       // btn.Text = (Int32.Parse(btn.Text) + 1).ToString();
    }
}