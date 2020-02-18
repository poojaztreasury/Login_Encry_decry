using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ns
{
    public interface Iuser
    {
        string uname
        { get; set; }
            
        string upass
        { get; set; }
    }
   public  class PrpRegis:Iuser
    {
        string prpuname;
        string prpupass;

        public string uname
        {
            get
            {
                return prpuname;
            }
            set
            {
                prpuname=value;
            }
        }
        public string upass
        {
            get
            {
                return prpupass;
            }
            set
            {
                 prpupass=value;
            }
        }
    }
    public abstract  class abcon
    {
       public SqlConnection con = new SqlConnection();
       // con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
      public abcon()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

        }

    }
    public class Regis:abcon
    {
        public int savedata(PrpRegis p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("savedata", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@un", p.uname);
            cmd.Parameters.AddWithValue("@up", EncodePasswordToBase64(p.upass));
            int a = cmd.ExecuteNonQuery();
            return a;
           /* if (a != 0)
            {

                Response.Write("registered!!");
            }
            else
            {
                Response.Write("not registered");
            } */
        }
        public string checkusr(PrpRegis p)
        {
            string dpass=" ";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("checkuser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@un", p.uname);
            // cmd.Parameters.AddWithValue("@up", DecodeFrom64(TextBox2.Text));
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                
                 dpass = DecodeFrom64(dr[1].ToString());
                

            }
            return dpass;

        }
        private static string EncodePasswordToBase64(string password) //encode method
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
        public string DecodeFrom64(string encodedData) //decode method
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }

    }

}
