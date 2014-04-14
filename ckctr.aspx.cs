﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZYNLPJPT.Model;
using ZYNLPJPT.DAL;

namespace ZYNLPJPT
{
    public partial class ckctr : System.Web.UI.Page
    {

        protected string[] allZyms;

        protected ZYKCView[] zykcViews;

        protected ZykcViewsWrapper zykcViewsWrapper=new ZykcViewsWrapper ();

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["yh"] == null)
            {
                this.Response.Redirect("Default.htm");
            }
            else
            {
                YH yh = (YH)Session["yh"];
                //验证用户是否是教师角色,无则没有查看配置权限
                YHJSView yhjsView = new YHJSView_DAL().GetModel(yh.YHBH.Trim());
                if (yhjsView.JSM.Trim() != "教师")
                {
                    Response.Redirect("ErrorPage.aspx?msg=对不起，系统配置出错，你没有查看出题人的权利&fh=false");
                }
                else
                {
                    string queryZym = null;

                    int xkbh = new JSTea_DAL().GetModel(yh.YHBH.Trim()).SSXK;
                    allZyms = new ZYKCView_DAL().GetArrayWithAllZyms("xkbh=" + xkbh);

                    if (Request["choosedMajor"] == null || Request["choosedMajor"].ToString() == "")
                    {
                        queryZym = allZyms[0];
                    }
                    else
                    {
                        queryZym = Request["choosedMajor"].ToString();
                        List<string> lists = allZyms.ToList();
                        lists.Remove(queryZym);
                        lists.Add(queryZym);
                        lists.Reverse();
                        allZyms = lists.ToArray();
                    }
                    zykcViews = new ZYKCView_DAL().GetArray("xkbh=" + xkbh + " and zym='" + queryZym.Trim() + "'");
                    zykcViewsWrapper.Zykcview = zykcViews;
                    int length = zykcViews.Length;
                    this.zykcViewsWrapper.CtTea=new string[length];
                    for (int i = 0; i < length; i++) {
                        this.zykcViewsWrapper.CtTea[i] = "出题人为：<br/><br/>";
                        string[] result = new CTView_DAL().getTeaNames(zykcViews[i].KCBH, zykcViews[i].ZYBH);
                        for (int j = 0; j < result.Length; j++) {
                            if (result[result.Length - 1] == "暂无" || j == (result.Length-1))
                            {
                                zykcViewsWrapper.CtTea[i] += result[j];
                            }
                            else {
                                zykcViewsWrapper.CtTea[i] += result[j] + ", ";
                            }
                        }
                        zykcViewsWrapper.CtTea[i] += "<br/>";
                    }

                }
            }
        }

        public class ZykcViewsWrapper
        {

            private ZYKCView[] zykcviews;

            public ZYKCView[] Zykcview
            {
                get { return zykcviews; }
                set { zykcviews = value; }
            }

            private string[] ctTeas;

            public string[] CtTea
            {
                get { return ctTeas; }
                set { ctTeas = value; }
            }
        }
    }
}