using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.BLL;
using System.Data;
namespace DTcms.Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        DTcms.BLL.article_category bal = new DTcms.BLL.article_category();
        int i = 0;
        public string GetMenu()
        {  
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();
                dt=bal.GetAllList();
                foreach (DataRow dr in dt.Rows)
                {
                    string menu = dr["title"].ToString();
                    string id = dr["id"].ToString();
                    i= i + 1;
                 sb.Append("<li  class='Navigation'><a href='news_list.aspx?category_id="+dr["id"]+"'>"+menu+"<span id='"+i+"' style='display:none'>"+id+"</span></a></li>");
                }
        return sb.ToString();
            }
        public string Getcategory(string category)
        {
          
            DTcms.BLL.article_category balcategory = new DTcms.BLL.article_category();
            DataTable dtc = balcategory.GetAllList();
            if (category == "1")
            {
                category = dtc.Rows[0][2].ToString();
               
            }
            if (category == "2")
            {
                category = dtc.Rows[1][2].ToString();
            }
            if (category == "3")
            {
                category = dtc.Rows[2][2].ToString();
            }
            if (category == "4")
            {
                category = dtc.Rows[3][2].ToString();
            }
            if (category == "5")
            {
                category = dtc.Rows[4][2].ToString();
            }
            if (category == "6")
            {
                category = dtc.Rows[5][2].ToString();
            }
            return category;
        }
        public string GetArticel(string category)
        {
            DTcms.BLL.article_category balcategory = new DTcms.BLL.article_category();
            DataTable dtc = balcategory.GetAllList();
            if (category=="1")
            {
                category = dtc.Rows[0][0].ToString();
          string categorytitle = dtc.Rows[0][2].ToString();
            }
            if (category == "2")
            {
                category = dtc.Rows[1][0].ToString();
            }
            if (category == "3")
            {
                category = dtc.Rows[2][0].ToString();
            }
            if (category == "4")
            {
                category = dtc.Rows[3][0].ToString();
            }
            if (category == "5")
            {
                category = dtc.Rows[4][0].ToString();
            }
            if (category == "6")
            {
                category = dtc.Rows[5][0].ToString();
            }
                //string id1 = dtc.Rows[0][0].ToString();
                //string id2 = dtc.Rows[1][0].ToString();
                //string id3 = dtc.Rows[2][0].ToString();
                //string id4 = dtc.Rows[3][0].ToString();
                //string id5 = dtc.Rows[4][0].ToString();
                //string id6 = dtc.Rows[5][0].ToString();
            StringBuilder sb = new StringBuilder();
            DTcms.BLL.article bal = new DTcms.BLL.article();
            DataSet ds = bal.GetList(6, "category_id=" + category, "");
            DataTable dt=ds.Tables[0];
            foreach(DataRow dr in dt.Rows)
            {
                string title = dr["title"].ToString();
                string id = dr["id"].ToString();
                sb.Append("<li><a href='news_show.aspx?id="+id+"'>"+title+"</a></li>" );
            }
            return sb.ToString();
        }
    
    
    }
}