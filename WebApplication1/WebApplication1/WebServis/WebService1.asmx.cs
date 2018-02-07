using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication1.WebServis
{
    
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet OgrenciDondur(int Id)
        {
            string query = String.Format("SELECT ad FROM Sınıf WHERE Id = '{0}'", Id);
            return Sorgula(query);
        }
        public DataSet Sorgula(string query)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Ogrenci;Integrated Security=True");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.SelectCommand.ExecuteNonQuery();
            DataSet dt = new DataSet();
            da.Fill(dt);
            return dt;
        }
    }
}
