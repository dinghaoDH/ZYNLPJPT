﻿/**  版本信息模板在安装目录下，可自行修改。
* KCXZ.cs
*
* 功 能： N/A
* 类 名： KCXZ
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/3/31 16:02:14   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace ZYNLPJPT.Model
{
	/// <summary>
	/// KCXZ:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class KCXZ
	{
		public KCXZ()
		{}
		#region Model
		private int _kcxzbh;
		private string _kcxzmc;
		/// <summary>
		/// 
		/// </summary>
		public int KCXZBH
		{
			set{ _kcxzbh=value;}
			get{return _kcxzbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string KCXZMC
		{
			set{ _kcxzmc=value;}
			get{return _kcxzmc;}
		}
		#endregion Model

	}
}

