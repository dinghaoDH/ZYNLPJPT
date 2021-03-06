﻿/**  版本信息模板在安装目录下，可自行修改。
* XSYHView.cs
*
* 功 能： N/A
* 类 名： XSYHView
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/5/6 22:18:24   N/A    初版
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
	/// XSYHView:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class XSYHView
	{
		public XSYHView()
		{}
		#region Model
		private int _bjbh;
		private DateTime? _rxnf;
		private string _yhbh;
		private string _mm;
		private string _xm;
		private bool _xb;
		/// <summary>
		/// 
		/// </summary>
		public int BJBH
		{
			set{ _bjbh=value;}
			get{return _bjbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? RXNF
		{
			set{ _rxnf=value;}
			get{return _rxnf;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string YHBH
		{
			set{ _yhbh=value;}
			get{return _yhbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MM
		{
			set{ _mm=value;}
			get{return _mm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string XM
		{
			set{ _xm=value;}
			get{return _xm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool XB
		{
			set{ _xb=value;}
			get{return _xb;}
		}
		#endregion Model

	}
}

