using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using zzLib;
using Start.DBUtility;
using Start.info;
namespace Start.DAL
{
    /// <summary>
    /// 数据访问类:yf_activity
    /// </summary>
     
    public partial class yf_activity
	{
        private string databaseprefix; //数据库表名前缀


        public yf_activity()
		{
           

        }
       
          
        
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "yf_activity"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from yf_activity");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Models.yf_activity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into yf_activity(");
			strSql.Append("title,img_url,html_url,content,starttime,endtime,youraddress,click,is_lock,add_time,filed1,filed2,filed3,filed4)");
			strSql.Append(" values (");
			strSql.Append("@title,@img_url,@html_url,@content,@starttime,@endtime,@youraddress,@click,@is_lock,@add_time,@filed1,@filed2,@filed3,@filed4)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,100),
					new SqlParameter("@img_url", SqlDbType.VarChar,100),
					new SqlParameter("@html_url", SqlDbType.VarChar,100),
					new SqlParameter("@content", SqlDbType.Text),
					new SqlParameter("@starttime", SqlDbType.VarChar,50),
					new SqlParameter("@endtime", SqlDbType.VarChar,50),
					new SqlParameter("@youraddress", SqlDbType.VarChar,255),
					new SqlParameter("@click", SqlDbType.Int,4),
					new SqlParameter("@is_lock", SqlDbType.Int,4),
					new SqlParameter("@add_time", SqlDbType.VarChar,50),
					new SqlParameter("@filed1", SqlDbType.VarChar,255),
					new SqlParameter("@filed2", SqlDbType.VarChar,255),
					new SqlParameter("@filed3", SqlDbType.VarChar,255),
					new SqlParameter("@filed4", SqlDbType.VarChar,255)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.img_url;
			parameters[2].Value = model.html_url;
			parameters[3].Value = model.content;
			parameters[4].Value = model.starttime;
			parameters[5].Value = model.endtime;
			parameters[6].Value = model.youraddress;
			parameters[7].Value = model.click;
			parameters[8].Value = model.is_lock;
			parameters[9].Value = model.add_time;
			parameters[10].Value = model.filed1;
			parameters[11].Value = model.filed2;
			parameters[12].Value = model.filed3;
			parameters[13].Value = model.filed4;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Models.yf_activity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update yf_activity set ");
			strSql.Append("title=@title,");
			strSql.Append("img_url=@img_url,");
			strSql.Append("html_url=@html_url,");
			strSql.Append("content=@content,");
			strSql.Append("starttime=@starttime,");
			strSql.Append("endtime=@endtime,");
			strSql.Append("youraddress=@youraddress,");
			strSql.Append("click=@click,");
			strSql.Append("is_lock=@is_lock,");
			strSql.Append("add_time=@add_time,");
			strSql.Append("filed1=@filed1,");
			strSql.Append("filed2=@filed2,");
			strSql.Append("filed3=@filed3,");
			strSql.Append("filed4=@filed4");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,100),
					new SqlParameter("@img_url", SqlDbType.VarChar,100),
					new SqlParameter("@html_url", SqlDbType.VarChar,100),
					new SqlParameter("@content", SqlDbType.Text),
					new SqlParameter("@starttime", SqlDbType.VarChar,50),
					new SqlParameter("@endtime", SqlDbType.VarChar,50),
					new SqlParameter("@youraddress", SqlDbType.VarChar,255),
					new SqlParameter("@click", SqlDbType.Int,4),
					new SqlParameter("@is_lock", SqlDbType.Int,4),
					new SqlParameter("@add_time", SqlDbType.VarChar,50),
					new SqlParameter("@filed1", SqlDbType.VarChar,255),
					new SqlParameter("@filed2", SqlDbType.VarChar,255),
					new SqlParameter("@filed3", SqlDbType.VarChar,255),
					new SqlParameter("@filed4", SqlDbType.VarChar,255),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.img_url;
			parameters[2].Value = model.html_url;
			parameters[3].Value = model.content;
			parameters[4].Value = model.starttime;
			parameters[5].Value = model.endtime;
			parameters[6].Value = model.youraddress;
			parameters[7].Value = model.click;
			parameters[8].Value = model.is_lock;
			parameters[9].Value = model.add_time;
			parameters[10].Value = model.filed1;
			parameters[11].Value = model.filed2;
			parameters[12].Value = model.filed3;
			parameters[13].Value = model.filed4;
			parameters[14].Value = model.id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from yf_activity ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from yf_activity ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Models.yf_activity GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,title,img_url,html_url,content,starttime,endtime,youraddress,click,is_lock,add_time,filed1,filed2,filed3,filed4 from yf_activity ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Models.yf_activity model=new Models.yf_activity();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Models.yf_activity DataRowToModel(DataRow row)
		{
			Models.yf_activity model=new Models.yf_activity();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["img_url"]!=null)
				{
					model.img_url=row["img_url"].ToString();
				}
				if(row["html_url"]!=null)
				{
					model.html_url=row["html_url"].ToString();
				}
				if(row["content"]!=null)
				{
					model.content=row["content"].ToString();
				}
				if(row["starttime"]!=null)
				{
					model.starttime=row["starttime"].ToString();
				}
				if(row["endtime"]!=null)
				{
					model.endtime=row["endtime"].ToString();
				}
				if(row["youraddress"]!=null)
				{
					model.youraddress=row["youraddress"].ToString();
				}
				if(row["click"]!=null && row["click"].ToString()!="")
				{
					model.click=int.Parse(row["click"].ToString());
				}
				if(row["is_lock"]!=null && row["is_lock"].ToString()!="")
				{
					model.is_lock=int.Parse(row["is_lock"].ToString());
				}
				if(row["add_time"]!=null)
				{
					model.add_time=row["add_time"].ToString();
				}
				if(row["filed1"]!=null)
				{
					model.filed1=row["filed1"].ToString();
				}
				if(row["filed2"]!=null)
				{
					model.filed2=row["filed2"].ToString();
				}
				if(row["filed3"]!=null)
				{
					model.filed3=row["filed3"].ToString();
				}
				if(row["filed4"]!=null)
				{
					model.filed4=row["filed4"].ToString();
				}
			}
			return model;
		}
        //public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select * FROM yf_activity");
        //    if (strWhere.Trim() != "")
        //    {
        //        strSql.Append(" where " + strWhere);
        //    }
        //    recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
        //    return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        //}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Top(3) id,title,img_url,html_url,content,starttime,endtime,youraddress,click,is_lock,add_time,filed1,filed2,filed3,filed4 ");
			strSql.Append(" FROM yf_activity ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
              
			}
            strSql.Append("Order by id desc");
            return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,title,img_url,html_url,content,starttime,endtime,youraddress,click,is_lock,add_time,filed1,filed2,filed3,filed4 ");
			strSql.Append(" FROM yf_activity ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM yf_activity ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from yf_activity T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "yf_activity";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

