using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using zzLib;


namespace Start.Controllers
{
    public class DataAccessLayerController : ApiController
    {
        private int Pagesize = 2;
        private string scuessMsg = "操作成功";
        private string errorMsg = "操作失败，请稍后再试";
        private static ArrayList nullList = new ArrayList();
        #region 得到产品列表
        [HttpPost]
        public HttpResponseMessage GetProductList(Models.dt_article model)
        {
            ReturnNode returnNode = new ReturnNode();
            int pageindex = model.sort_id;//假设为当前页
           
       Start.DAL.dt_article dal = new Start.DAL.dt_article();
          //  i_end = 当前页码 * 每页显示多少条;
           // i_inde = (当前页码 - 1) * 每页显示多少条 + 1;
            DataSet ds=dal.GetListByPage("", "", (pageindex-1)*(Pagesize+1), pageindex*Pagesize);

            if (ds != null)
            {

                ArrayList dataList = zzCommon.DataTableToList(ds.Tables[0]);
                returnNode.Code = 0;
                returnNode.Msg = scuessMsg;
                returnNode.Data = dataList;
            }

            else
            {
                returnNode.Code = 0;
                returnNode.Msg =errorMsg;
                returnNode.Data = nullList;
            }

            return zzCommon.GetObj2Json(returnNode);
          
            
        }
        #endregion
        #region 得到产品详情
        [HttpPost]
        public HttpResponseMessage GetProductDetail(Models.dt_article model)
        {
            ReturnNode returnNode = new ReturnNode();
            int id = model.id;//假设为当前页

            Start.DAL.dt_article dal = new Start.DAL.dt_article();
            //  i_end = 当前页码 * 每页显示多少条;
            // i_inde = (当前页码 - 1) * 每页显示多少条 + 1;
          Start.Models.dt_article modell = dal.GetModel(id);

            if (modell != null)
            {
              
                returnNode.Code = 0;
                returnNode.Msg = scuessMsg;
                returnNode.Data = modell;
            }

            else
            {
                returnNode.Code = 0;
                returnNode.Msg = errorMsg;
                returnNode.Data = nullList;
            }

            return zzCommon.GetObj2Json(returnNode);


        }
        #endregion 
        #region 测试接口
        [HttpPost]
        public HttpResponseMessage GetName()
        {
         String   retstr = "hello";
            return new HttpResponseMessage { Content = new StringContent(retstr, System.Text.Encoding.UTF8, "application/json") };
        }
        #endregion
        #region 得到轮播图
        [HttpPost]
        public HttpResponseMessage GetCarowSelPics()
        {
        
            ReturnNode returnNode = new ReturnNode();
          
            DAL.yf_activity dal = new DAL.yf_activity();
            DataSet ds= dal.GetList("");
        
            //  i_end = 当前页码 * 每页显示多少条;
            // i_inde = (当前页码 - 1) * 每页显示多少条 + 1;
         
            if (ds != null)
            {

                ArrayList dataList = zzCommon.DataTableToList(ds.Tables[0]);
                returnNode.Code = 0;
                returnNode.Msg = scuessMsg;
                returnNode.Data = dataList;
            }

            else
            {
                returnNode.Code = 0;
                returnNode.Msg = errorMsg;
                returnNode.Data = nullList;
            }

            return zzCommon.GetObj2Json(returnNode); ;
        }
        #endregion
    }
}
