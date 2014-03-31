﻿/**  版本信息模板在安装目录下，可自行修改。
* XK_DAL.cs
*
* 功 能： N/A
* 类 名： XK_DAL
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/3/31 16:02:17   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZYNLPJPT.Utility;
namespace ZYNLPJPT.DAL
{
	/// <summary>
	/// 数据访问类:XK_DAL
	/// </summary>
	public partial class XK_DAL
	{
		public XK_DAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("XKBH", "XK"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int XKBH)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from XK");
			strSql.Append(" where XKBH=@XKBH ");
			SqlParameter[] parameters = {
					new SqlParameter("@XKBH", SqlDbType.Int,4)			};
			parameters[0].Value = XKBH;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ZYNLPJPT.Model.XK model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into XK(");
			strSql.Append("XKBH,XYBH,XKMC,XKFZR)");
			strSql.Append(" values (");
			strSql.Append("@XKBH,@XYBH,@XKMC,@XKFZR)");
			SqlParameter[] parameters = {
					new SqlParameter("@XKBH", SqlDbType.Int,4),
					new SqlParameter("@XYBH", SqlDbType.Int,4),
					new SqlParameter("@XKMC", SqlDbType.VarChar,50),
					new SqlParameter("@XKFZR", SqlDbType.VarChar,50)};
			parameters[0].Value = model.XKBH;
			parameters[1].Value = model.XYBH;
			parameters[2].Value = model.XKMC;
			parameters[3].Value = model.XKFZR;

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
		public bool Update(ZYNLPJPT.Model.XK model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update XK set ");
			strSql.Append("XYBH=@XYBH,");
			strSql.Append("XKMC=@XKMC,");
			strSql.Append("XKFZR=@XKFZR");
			strSql.Append(" where XKBH=@XKBH ");
			SqlParameter[] parameters = {
					new SqlParameter("@XYBH", SqlDbType.Int,4),
					new SqlParameter("@XKMC", SqlDbType.VarChar,50),
					new SqlParameter("@XKFZR", SqlDbType.VarChar,50),
					new SqlParameter("@XKBH", SqlDbType.Int,4)};
			parameters[0].Value = model.XYBH;
			parameters[1].Value = model.XKMC;
			parameters[2].Value = model.XKFZR;
			parameters[3].Value = model.XKBH;

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
		public bool Delete(int XKBH)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from XK ");
			strSql.Append(" where XKBH=@XKBH ");
			SqlParameter[] parameters = {
					new SqlParameter("@XKBH", SqlDbType.Int,4)			};
			parameters[0].Value = XKBH;

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
		public bool DeleteList(string XKBHlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from XK ");
			strSql.Append(" where XKBH in ("+XKBHlist + ")  ");
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
		public ZYNLPJPT.Model.XK GetModel(int XKBH)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 XKBH,XYBH,XKMC,XKFZR from XK ");
			strSql.Append(" where XKBH=@XKBH ");
			SqlParameter[] parameters = {
					new SqlParameter("@XKBH", SqlDbType.Int,4)			};
			parameters[0].Value = XKBH;

			ZYNLPJPT.Model.XK model=new ZYNLPJPT.Model.XK();
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
		public ZYNLPJPT.Model.XK DataRowToModel(DataRow row)
		{
			ZYNLPJPT.Model.XK model=new ZYNLPJPT.Model.XK();
			if (row != null)
			{
				if(row["XKBH"]!=null && row["XKBH"].ToString()!="")
				{
					model.XKBH=int.Parse(row["XKBH"].ToString());
				}
				if(row["XYBH"]!=null && row["XYBH"].ToString()!="")
				{
					model.XYBH=int.Parse(row["XYBH"].ToString());
				}
				if(row["XKMC"]!=null)
				{
					model.XKMC=row["XKMC"].ToString();
				}
				if(row["XKFZR"]!=null)
				{
					model.XKFZR=row["XKFZR"].ToString();
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
			strSql.Append("select XKBH,XYBH,XKMC,XKFZR ");
			strSql.Append(" FROM XK ");
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
			strSql.Append(" XKBH,XYBH,XKMC,XKFZR ");
			strSql.Append(" FROM XK ");
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
			strSql.Append("select count(1) FROM XK ");
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
				strSql.Append("order by T.XKBH desc");
			}
			strSql.Append(")AS Row, T.*  from XK T ");
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
			parameters[0].Value = "XK";
			parameters[1].Value = "XKBH";
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
