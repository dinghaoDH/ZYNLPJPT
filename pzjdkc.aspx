﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pzjdkc.aspx.cs" Inherits="ZYNLPJPT.pzjdkc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>配置阶段课程</title>
    <link rel="Stylesheet" type="text/css" href="Styles/default/easyui.css" />
    <link rel="Stylesheet" type="text/css" href="Styles/icon.css" /> 
     <script type="text/javascript" src="Scripts/jquery-1.8.0.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="Scripts/locale/easyui-lang-zh_CN.js"></script>
</head>
<body class="easyui-layout">         
<div region="north" border="true" style="height:40px;">
<form action="pzjdkc.aspx" method="post">
    <div id="content" name="content" style="padding:10px 10px 10px 400px">
        <label for="choosedMajor" style="width:200px;">选择需要设置的专业:</label>
        <select  id="choosedMajor" name="choosedMajor" style="width:200px;"   onchange="return submit()" >
            <% for (int i = 0; i < this.allZyms.Length; i++) {
                   Response.Write("<option>"+allZyms[i].ToString().Trim()+"</option>");
               } %>
        </select>
    </div>
    </form>
</div>
<div region="center" border="false">
 <div id="ctTea" class="easyui-window" title="配置阶段课程" data-options="modal:true,closed:true,iconCls:'icon-save'" style="width:500px;height:200px;padding:10px;">
 </div>
  <table id="mytable" class="easyui-datagrid"  fit="true" data-options="fitColumns:true" style="border:none;" border="false">
    	<thead>
    		<tr>
    			<th data-options="field:'njbh'" width="12">年级编号</th>
                <th data-options="field:'njmc',align:'center'" width="30">年级名称</th>
                 <th data-options="field:'jdbh'" width="12">阶段编号</th>  
                <th data-options="field:'jdmc',align:'center'" width="40">阶段名称</th>
                <th data-options="field:'xkmc',align:'center'" width="40">学科名称</th>
                <th data-options="field:'qsxq',align:'center'" width="30">阶段起始学期</th>
                <th data-options="field:'jzxq',align:'center'" width="30">阶段截止学期</th>
                <th data-options="field:'cpjdbz'" width="30">测评阶段备注</th>
                <th data-options="field:'button',align:'center'" width="50">配置阶段下设课程</th>
    		</tr>
    	</thead>
   		<tbody >
              <%
                   for (int i = 0; i < this.cpjdViews.Length; i++)
                   {
                       Response.Write("<tr >");
                       Response.Write("	<td >" + this.cpjdViews[i].NJBH + "</td>");
                       Response.Write("	<td >" + this.cpjdViews[i].NJMC+ "</td>");
                       Response.Write("  <td >" + this.cpjdViews[i].JDBH + "</td>");
                       Response.Write("	<td >" + this.cpjdViews[i].JDMC + "</td>");
                       Response.Write("	<td >" + this.cpjdViews[i].XKMC + "</td>");
                       Response.Write("	<td >" + this.cpjdViews[i].QSXQ + "</td>");
                       Response.Write("	<td >" + this.cpjdViews[i].JZXQ + "</td>");
                       Response.Write("	<td >" + this.cpjdViews[i].CPJDJJ + "</td>");
                       Response.Write("  <td><a id=\"A1\" href=\"javascript:void(0)\" class=\"easyui-linkbutton\" style=\"margin-top:10px; margin-bottom:10px;\" onclick=\"window.location.href='processAspx/cpjdData.aspx?njbh=" + this.cpjdViews[i].NJBH + "&zybh=" + this.cpjdViews[i].ZYBH + "&xkbh=" + this.cpjdViews[i].XKBH + "&jdbh=" + this.cpjdViews[i].JDBH + "&jdmc="+this.cpjdViews[i].JDMC+"&zym="+this.cpjdViews[i].ZYM.Trim()+"'\" >配置阶段下设课程</a></td>");
                       Response.Write("</tr>");
                   } %>
    	</tbody>
   	</table>     
</div>                
<script type="text/javascript">
    $(function () {
        $('#mytable').datagrid({
            pagination: false,
            pageList: [30],
            pageSize: 30,
            singleSelect: true,
        });
    });
</script>
</body>
</html>
