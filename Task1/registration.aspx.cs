using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class registration : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        if(con.State==ConnectionState.Closed)
        {
            con.Open();
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {

        /*
        
        SqlCommand cmd = new SqlCommand("savedata",con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@un", TextBox1.Text);
        cmd.Parameters.AddWithValue("@up", EncodePasswordToBase64(TextBox2.Text));
       int a= cmd.ExecuteNonQuery();
        
        if(a!=0)
        {
            
            Response.Write("registered!!");
        }
        else
        {
            Response.Write("not registered");
        }
        */
        ns.Regis obj = new ns.Regis();
        ns.PrpRegis objprp = new ns.PrpRegis();
        objprp.uname = TextBox1.Text;
        objprp.upass = TextBox2.Text;
        int a= obj.savedata(objprp);
        if (a != 0)
        {

            Response.Write("registered!!");
        }
        else
        {
            Response.Write("not registered");
        }
    }

    
    }