using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.activity
{
    public partial class activity_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected int type;

        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = DTRequest.GetQueryString("keywords");
            this.type = DTRequest.GetQueryInt("type");

            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
               
                ChkAdminLevel("activity_list", DTEnums.ActionEnum.View.ToString()); //检查权限
                RptBind("id>0", "id desc");
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            
            txtKeywords.Text = this.keywords;
            BLL.yf_activity bll = new BLL.yf_activity();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("activity_list.aspx", "keywords={0}&page={1}&type={2}", this.keywords, "__id__", this.type.ToString());
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int _type, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            if (_type > 0)
            {
                strTemp.Append(" and type=" + _type);
            }
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and ( title like '%" + _keywords + "%')");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("activity_list_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

     

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("activity_list.aspx", "keywords={0}&type={1}", txtKeywords.Text, this.type.ToString()));
        }

        //筛选类别
        //protected void ddlGroupId_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Response.Redirect(Utils.CombUrlTxt("activity_list.aspx", "type={0}&keywords={1}",
                
        //}

        //设置分页数量

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("activity_list", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.yf_activity bll = new BLL.yf_activity();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(id))
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), "删除广告成功" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("activity_list.aspx", "keywords={0}&type={1}", this.keywords, this.type.ToString()), "Success");

        }
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("activity_list_page_size", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("activity_list.aspx", "keywords={0}&type={1}", this.keywords, this.type.ToString()));
        }

    
      
       

    }
}