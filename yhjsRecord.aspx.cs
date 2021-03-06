﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZYNLPJPT.DAL;
using ZYNLPJPT.BLL;
using ZYNLPJPT.Model;
using ZYNLPJPT.Utility;
using System.Data;

namespace ZYNLPJPT
{
    public partial class yhjsRecord : System.Web.UI.Page
    {
       protected string yhbh;
       protected int length;
       protected JS2[] js_list;

        protected void Page_Load(object sender, EventArgs e)
        {
           yhbh = Request["yhbh"] == null ? null : Request["yhbh"].ToString();
            if (yhbh == "" || yhbh == null)
            {
               this.Response.Write("<script type='text/javascript'>window.parent.location='Default.htm'</script>");
                this.Response.End();
            }
            else
            {
                //yhbh = int.Parse(yhbh_str);
                DataSet ds = new YHJSB_DAL().GetList(" yhbh='"+yhbh+"'");
                length = ds.Tables[0].Rows.Count;
                js_list = new JS2[length];
                for (int i = 0; i < length; i++)
                {
                    js_list[i] = new JS2();
                    js_list[i] = new JSRole_DAL().GetModel(int.Parse(ds.Tables[0].Rows[i]["JSBH"].ToString()));
                  
                }

            }
        }
    }
}