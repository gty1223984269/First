using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;//Please add references
namespace DTcms.DAL
{
	/// <summary>
	/// 数据访问类:Tb_School
	/// </summary>
	public partial class Tb_School
	{
		public Tb_School()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("SchoolID", "Tb_School"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SchoolID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Tb_School");
			strSql.Append(" where SchoolID=@SchoolID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SchoolID", SqlDbType.Int,4)			};
			parameters[0].Value = SchoolID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DTcms.Model.Tb_School model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Tb_School(");
			strSql.Append("SchoolID,SchoolName,ProvinceID,CityID,CountyID,SchoolCode,ServerUrl,SchoolSite,EMSUrl,SchoolType,upSchoolID,TownsID,AutomaticLiveUrl,SchoolKey)");
			strSql.Append(" values (");
			strSql.Append("@SchoolID,@SchoolName,@ProvinceID,@CityID,@CountyID,@SchoolCode,@ServerUrl,@SchoolSite,@EMSUrl,@SchoolType,@upSchoolID,@TownsID,@AutomaticLiveUrl,@SchoolKey)");
			SqlParameter[] parameters = {
					new SqlParameter("@SchoolID", SqlDbType.Int,4),
					new SqlParameter("@SchoolName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProvinceID", SqlDbType.Int,4),
					new SqlParameter("@CityID", SqlDbType.Int,4),
					new SqlParameter("@CountyID", SqlDbType.Int,4),
					new SqlParameter("@SchoolCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ServerUrl", SqlDbType.NVarChar,50),
					new SqlParameter("@SchoolSite", SqlDbType.NVarChar,50),
					new SqlParameter("@EMSUrl", SqlDbType.NVarChar,100),
					new SqlParameter("@SchoolType", SqlDbType.SmallInt,2),
					new SqlParameter("@upSchoolID", SqlDbType.Int,4),
					new SqlParameter("@TownsID", SqlDbType.Int,4),
					new SqlParameter("@AutomaticLiveUrl", SqlDbType.VarChar,100),
					new SqlParameter("@SchoolKey", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.SchoolID;
			parameters[1].Value = model.SchoolName;
			parameters[2].Value = model.ProvinceID;
			parameters[3].Value = model.CityID;
			parameters[4].Value = model.CountyID;
			parameters[5].Value = model.SchoolCode;
			parameters[6].Value = model.ServerUrl;
			parameters[7].Value = model.SchoolSite;
			parameters[8].Value = model.EMSUrl;
			parameters[9].Value = model.SchoolType;
			parameters[10].Value = model.upSchoolID;
			parameters[11].Value = model.TownsID;
			parameters[12].Value = model.AutomaticLiveUrl;
			parameters[13].Value = model.SchoolKey;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(DTcms.Model.Tb_School model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Tb_School set ");
			strSql.Append("SchoolName=@SchoolName,");
			strSql.Append("ProvinceID=@ProvinceID,");
			strSql.Append("CityID=@CityID,");
			strSql.Append("CountyID=@CountyID,");
			strSql.Append("SchoolCode=@SchoolCode,");
			strSql.Append("ServerUrl=@ServerUrl,");
			strSql.Append("SchoolSite=@SchoolSite,");
			strSql.Append("EMSUrl=@EMSUrl,");
			strSql.Append("SchoolType=@SchoolType,");
			strSql.Append("upSchoolID=@upSchoolID,");
			strSql.Append("TownsID=@TownsID,");
			strSql.Append("AutomaticLiveUrl=@AutomaticLiveUrl,");
			strSql.Append("SchoolKey=@SchoolKey");
			strSql.Append(" where SchoolID=@SchoolID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SchoolName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProvinceID", SqlDbType.Int,4),
					new SqlParameter("@CityID", SqlDbType.Int,4),
					new SqlParameter("@CountyID", SqlDbType.Int,4),
					new SqlParameter("@SchoolCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ServerUrl", SqlDbType.NVarChar,50),
					new SqlParameter("@SchoolSite", SqlDbType.NVarChar,50),
					new SqlParameter("@EMSUrl", SqlDbType.NVarChar,100),
					new SqlParameter("@SchoolType", SqlDbType.SmallInt,2),
					new SqlParameter("@upSchoolID", SqlDbType.Int,4),
					new SqlParameter("@TownsID", SqlDbType.Int,4),
					new SqlParameter("@AutomaticLiveUrl", SqlDbType.VarChar,100),
					new SqlParameter("@SchoolKey", SqlDbType.NVarChar,50),
					new SqlParameter("@SchoolID", SqlDbType.Int,4)};
			parameters[0].Value = model.SchoolName;
			parameters[1].Value = model.ProvinceID;
			parameters[2].Value = model.CityID;
			parameters[3].Value = model.CountyID;
			parameters[4].Value = model.SchoolCode;
			parameters[5].Value = model.ServerUrl;
			parameters[6].Value = model.SchoolSite;
			parameters[7].Value = model.EMSUrl;
			parameters[8].Value = model.SchoolType;
			parameters[9].Value = model.upSchoolID;
			parameters[10].Value = model.TownsID;
			parameters[11].Value = model.AutomaticLiveUrl;
			parameters[12].Value = model.SchoolKey;
			parameters[13].Value = model.SchoolID;

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
		public bool Delete(int SchoolID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Tb_School ");
			strSql.Append(" where SchoolID=@SchoolID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SchoolID", SqlDbType.Int,4)			};
			parameters[0].Value = SchoolID;

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
		public bool DeleteList(string SchoolIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Tb_School ");
			strSql.Append(" where SchoolID in ("+SchoolIDlist + ")  ");
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
		public DTcms.Model.Tb_School GetModel(int SchoolID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SchoolID,SchoolName,ProvinceID,CityID,CountyID,SchoolCode,ServerUrl,SchoolSite,EMSUrl,SchoolType,upSchoolID,TownsID,AutomaticLiveUrl,SchoolKey from Tb_School ");
			strSql.Append(" where SchoolID=@SchoolID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SchoolID", SqlDbType.Int,4)			};
			parameters[0].Value = SchoolID;

			DTcms.Model.Tb_School model=new DTcms.Model.Tb_School();
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
		public DTcms.Model.Tb_School DataRowToModel(DataRow row)
		{
			DTcms.Model.Tb_School model=new DTcms.Model.Tb_School();
			if (row != null)
			{
				if(row["SchoolID"]!=null && row["SchoolID"].ToString()!="")
				{
					model.SchoolID=int.Parse(row["SchoolID"].ToString());
				}
				if(row["SchoolName"]!=null)
				{
					model.SchoolName=row["SchoolName"].ToString();
				}
				if(row["ProvinceID"]!=null && row["ProvinceID"].ToString()!="")
				{
					model.ProvinceID=int.Parse(row["ProvinceID"].ToString());
				}
				if(row["CityID"]!=null && row["CityID"].ToString()!="")
				{
					model.CityID=int.Parse(row["CityID"].ToString());
				}
				if(row["CountyID"]!=null && row["CountyID"].ToString()!="")
				{
					model.CountyID=int.Parse(row["CountyID"].ToString());
				}
				if(row["SchoolCode"]!=null)
				{
					model.SchoolCode=row["SchoolCode"].ToString();
				}
				if(row["ServerUrl"]!=null)
				{
					model.ServerUrl=row["ServerUrl"].ToString();
				}
				if(row["SchoolSite"]!=null)
				{
					model.SchoolSite=row["SchoolSite"].ToString();
				}
				if(row["EMSUrl"]!=null)
				{
					model.EMSUrl=row["EMSUrl"].ToString();
				}
				if(row["SchoolType"]!=null && row["SchoolType"].ToString()!="")
				{
					model.SchoolType=int.Parse(row["SchoolType"].ToString());
				}
				if(row["upSchoolID"]!=null && row["upSchoolID"].ToString()!="")
				{
					model.upSchoolID=int.Parse(row["upSchoolID"].ToString());
				}
				if(row["TownsID"]!=null && row["TownsID"].ToString()!="")
				{
					model.TownsID=int.Parse(row["TownsID"].ToString());
				}
				if(row["AutomaticLiveUrl"]!=null)
				{
					model.AutomaticLiveUrl=row["AutomaticLiveUrl"].ToString();
				}
				if(row["SchoolKey"]!=null)
				{
					model.SchoolKey=row["SchoolKey"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select SchoolID,SchoolName,ProvinceID,CityID,CountyID,SchoolCode,ServerUrl,SchoolSite,EMSUrl,SchoolType,upSchoolID,TownsID,AutomaticLiveUrl,SchoolKey ");
			strSql.Append(" FROM Tb_School ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
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
			strSql.Append(" SchoolID,SchoolName,ProvinceID,CityID,CountyID,SchoolCode,ServerUrl,SchoolSite,EMSUrl,SchoolType,upSchoolID,TownsID,AutomaticLiveUrl,SchoolKey ");
			strSql.Append(" FROM Tb_School ");
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
			strSql.Append("select count(1) FROM Tb_School ");
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
				strSql.Append("order by T.SchoolID desc");
			}
			strSql.Append(")AS Row, T.*  from Tb_School T ");
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
			parameters[0].Value = "Tb_School";
			parameters[1].Value = "SchoolID";
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

