using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using System.Configuration;
namespace DTcms.Web.admin.activity
{
    public partial class activity_edit : Web.UI.ManagePage
    {
        protected string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        private static string activityUrl = ConfigurationManager.AppSettings["activityUrl"];
        private static string resUrl = ConfigurationManager.AppSettings["resUrl"];
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                this.id = DTRequest.GetQueryInt("id");
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                //if (!new BLL.yf_activity().Exists(this.id))
                //{
                //    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                //    return;
                //}
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("activity_list", DTEnums.ActionEnum.View.ToString()); //检查权限
                TreeBind();
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 绑定类别=================================
        private void TreeBind()
        {
            this.ddlTypeId.Items.Clear();
            this.ddlTypeId.Items.Add(new ListItem("请选择位置...", ""));
            this.ddlTypeId.Items.Add(new ListItem("首页", "1"));
            this.ddlTypeId.Items.Add(new ListItem("教程", "2"));
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            //BLL.yf_activity bll = new BLL.yf_activity();
            //Model.yf_activity model = bll.GetModel(_id);
            //txtTitle.Text = model.title;
            ////txtTitle.Attributes.Remove("ajaxurl");
            //ddlTypeId.SelectedValue = model.type.ToString();
            //lblClick.Text = model.click.ToString();
            //txtImgUrl.Text = model.img_url;
            //rblStatus.SelectedValue = model.is_lock.ToString();
            //txtContent.Value = model.content;
            //lblRegTime.Text = model.add_time.ToString();

        }
        #endregion

        #region 增加操作=================================
        //private bool DoAdd()
        //{
        //    bool result = false;
        //    Model.yf_activity model = new Model.yf_activity();
        //    BLL.yf_activity bll = new BLL.yf_activity();

        //    model.type = int.Parse(ddlTypeId.SelectedValue);
        //    model.title = Utils.DropHTML(txtTitle.Text.Trim());
        //    model.is_lock = int.Parse(rblStatus.SelectedValue);
        //    string strImg = Utils.DropHTML(txtImgUrl.Text.Trim());
        //    model.img_url = strImg.Replace(resUrl, "");
        //    model.html_url = activityUrl;
        //    model.content = txtContent.Value;
        //    model.add_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        //    if (bll.Add(model))
        //    {
        //        AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加广告:" + model.title); //记录日志
        //        result = true;
        //    }
            //return result;
        //}
        #endregion

        #region 修改操作=================================
        //private bool DoEdit(int _id)
        //{
        //    bool result = false;
        //    BLL.yf_activity bll = new BLL.yf_activity();
        //    Model.yf_activity model = bll.GetModel(_id);

        //    model.type = int.Parse(ddlTypeId.SelectedValue);
        //    model.title = Utils.DropHTML(txtTitle.Text.Trim());
        //    model.is_lock = int.Parse(rblStatus.SelectedValue);
        //    string strImg = Utils.DropHTML(txtImgUrl.Text.Trim());
        //    if (strImg != model.img_url) {
        //        model.img_url = strImg.Replace(resUrl, "");
        //    }
            
        //    model.content = txtContent.Value;

        //    if (bll.Update(model))
        //    {
        //        AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改广告信息:" + model.title); //记录日志
        //        result = true;
        //    }
        //    return result;
        //}
        #endregion

        //保存
        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
        //    {
        //        ChkAdminLevel("activity_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
        //        if (!DoEdit(this.id))
        //        {
        //            JscriptMsg("保存过程中发生错误！", "", "Error");
        //            return;
        //        }
        //        JscriptMsg("修改广告成功！", "activity_list.aspx", "Success");
        //    }
        //    else //添加
        //    {
        //        ChkAdminLevel("activity_list", DTEnums.ActionEnum.Add.ToString()); //检查权限
        //        if (!DoAdd())
        //        {
        //            JscriptMsg("保存过程中发生错误！", "", "Error");
        //            return;
        //        }
        //        JscriptMsg("添加广告成功！", "activity_list.aspx", "Success");
        //    }
        //}
    }
}