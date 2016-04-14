using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using DTcms.BLL;
using System.Data;
using System.Text;

namespace DTcms.Web.Html
{
    public partial class Activity : System.Web.UI.Page
    {
      
        

        protected void Page_Load(object sender, EventArgs e)
        {

            

        }
    

        public  string GetHtml()
        {
            string id = Request.QueryString["id"];
            String ReturnContent = "";
            yf_activity Activity = new yf_activity();
       DataSet ds=   Activity.GetList("id="+id);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ReturnContent = ds.Tables[0].Rows[0]["content"].ToString();
            }
            else {


                ReturnContent = "没有内容";
            }

            return ReturnContent;

        }
            
            
    
    }
}