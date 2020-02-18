using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class login : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ns.Regis obj = new ns.Regis();
        ns.PrpRegis prpobj = new ns.PrpRegis();
        prpobj.uname = TextBox1.Text;
        string data = obj.checkusr(prpobj);
        if (TextBox2.Text == data)
        {
            Session["ss"] = prpobj.uname;
            Response.Redirect("content.aspx");
        }
        else
        {
            Response.Write("Wrongggggg");
        }
    }
            
        // SqlDataAdapter adp = new SqlDataAdapter("select * from tbuser",ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
       // string qry = "select * from tbuser where Username=@un";
       /* SqlCommand cmd = new SqlCommand("checkuser", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@un", TextBox1.Text);
       // cmd.Parameters.AddWithValue("@up", DecodeFrom64(TextBox2.Text));
        SqlDataReader dr = cmd.ExecuteReader();
       if( dr.HasRows)
        {
            dr.Read();
            // DecodeFrom64(dr[1]);
            //  Response.Redirect("content.aspx");
            //Response.Write(dr[0]);
           string dpass= DecodeFrom64(dr[1].ToString());
            
           if(TextBox2.Text== dpass)
            {
                Session["ss"] = dr[0].ToString();
                Response.Redirect("content.aspx");
            }

        }
       else
        {
            Response.Write("Wrongggggg");
        } */
    }

    

