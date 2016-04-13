using System;
using System.Data;
using System.Collections.Generic;
using DTcms.Common;
using DTcms.Model;
using DTcms.DAL;
using DTcms.DBUtility;
namespace DTcms.BLL
{
    /// <summary>
    /// Tb_School
    /// </summary>
    public partial class Tb_School
    {
        //private readonly ITb_School dal = DataAccess.CreateTb_School();
        DTcms.DAL.Tb_School dal = new DTcms.DAL.Tb_School();

        public Tb_School()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// 
        //public int Add(DTcms.Model.Tb_School model)
        //{
            //return dal.Add(model);
        //}

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DTcms.Model.Tb_School model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int SchoolID)
        {

            return dal.Delete(SchoolID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string SchoolIDlist)
        {
            return dal.DeleteList(SchoolIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DTcms.Model.Tb_School GetModel(int SchoolID)
        {

            return dal.GetModel(SchoolID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public DTcms.Model.Tb_School GetModelByCache(int SchoolID)
        //{

        //    string CacheKey = "Tb_SchoolModel-" + SchoolID;
        //    //object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
        //    //if (objModel == null)
        //    //{
        //    //    try
        //    //    {
        //    //        objModel = dal.GetModel(SchoolID);
        //    //        if (objModel != null)
        //    //        {
        //    //            int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
        //    //            Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //    //        }
        //    //    }
        //        catch { }
        //    }
        //    //return (DTcms.Model.Tb_School)objModel;
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DTcms.Model.Tb_School> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DTcms.Model.Tb_School> DataTableToList(DataTable dt)
        {
            List<DTcms.Model.Tb_School> modelList = new List<DTcms.Model.Tb_School>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DTcms.Model.Tb_School model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

