using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SZMA.DataLayer.User;
using SZMA.DataLayer;


public partial class LeftFrame_leftTree : SZMA.Core.Admin.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
            tvTree_databind2(); 
        }
    }
     protected void tvTree_databind()
     {
         SECU_OBJDAL obj = new SECU_OBJDAL();
         string gh = AdminUser.GH;
         DataSet dsUser = obj.selectFObjBySubAndGh(gh, Common.rjsystem);

         TreeNode tnUser = new TreeNode("<a class='link-02' title='维修监管' onclick=\"return showPage(this,'Home/default.aspx','0')\" style=\"cursor:hand\" ><img id='imgwx' src='../Control/tree-img/base.gif'>维修监管</a>");
         tnUser.Value = "0";
         tnUser.Checked = true;
         tnUser.ToolTip = "维修监管";
   
         TreeNode tnBuf;

         //if (dsUser.Tables[0].Rows.Count == 0)
         //{
         //    this.Response.Write("<script langauge='javascript'>window.parent.document.location.href='../NoRight.aspx'</script>");
         //    return;
         //}
         for(int i=0;i<dsUser.Tables[0].Rows.Count;i++)
         {
             tnBuf=new TreeNode();
             tnBuf.Collapse();
             tnBuf.Text = "<a class='link-02' title='" + dsUser.Tables[0].Rows[i]["OBJ_DESC"].ToString()
                 + "' onclick=\"return showPage(this,'" + dsUser.Tables[0].Rows[i]["URL"].ToString()
                + "','" + dsUser.Tables[0].Rows[i]["ID"].ToString()
                + "')\" style=\"cursor:hand\" >" + dsUser.Tables[0].Rows[i]["OBJ_DESC"].ToString()
                 + "</a>";
             tnBuf.ToolTip = dsUser.Tables[0].Rows[i]["OBJ_DESC"].ToString();
             tnBuf.Value = dsUser.Tables[0].Rows[i]["ID"].ToString();
             tnBuf.ImageUrl = "../Control/tree-img/folder.gif";
             tnBuf.ImageToolTip = dsUser.Tables[0].Rows[i]["OBJ_DESC"].ToString();
             tn_databind(tnBuf, dsUser.Tables[0].Rows[i]["OBJ_ID"].ToString(),gh);
             tnUser.ChildNodes.Add(tnBuf);
         }
         
         tv.Nodes.Clear();
         tv.Nodes.Add(tnUser);     
        
     }

    protected void tn_databind(TreeNode tn,string ParentID,string gh)
    {
        SECU_OBJDAL obj = new SECU_OBJDAL();
        DataSet dsUser = obj.selectSObjByPIDSubAndGh(gh, Common.rjsystem, ParentID);
        TreeNode tnBuf;
        for (int i = 0; i < dsUser.Tables[0].Rows.Count; i++)
        {
            tnBuf = new TreeNode();
            tnBuf.Text = "<a class='link-02' title='" + dsUser.Tables[0].Rows[i]["OBJ_DESC"].ToString()
                + "' onclick=\" javascript:return showPage(this,'" + dsUser.Tables[0].Rows[i]["URL"].ToString()
                + "','" + dsUser.Tables[0].Rows[i]["ID"].ToString()
                + "')\" style=\"cursor:hand\" >" + dsUser.Tables[0].Rows[i]["OBJ_DESC"].ToString()
                + "</a>";
            tnBuf.ToolTip = dsUser.Tables[0].Rows[i]["OBJ_DESC"].ToString();
            tnBuf.Value = dsUser.Tables[0].Rows[i]["ID"].ToString();
            tnBuf.ImageUrl = "../Control/tree-img/page.gif";
            tnBuf.ImageToolTip = dsUser.Tables[0].Rows[i]["OBJ_DESC"].ToString();
            tn.ChildNodes.Add(tnBuf);
        }
    }

    protected void tvTree_databind2()
    {
        string UserID = AdminUser.Username;
        TreeNode tnUser = new TreeNode("<a class='link-02' title='维修监管' onclick=\"return showPage('Home/default.aspx')\" style=\"cursor:hand\" >维修监管</a>");

        tnUser.Value = "0";
        tnUser.ImageUrl = "../Control/tree-img/base.gif";
        tnUser.ImageToolTip = "维修监管";
        tnUser.Checked = true;
        tnUser.ToolTip = "维修监管";
        tv.Nodes.Clear();
        tv.Nodes.Add(tnUser);



        ///首页
        TreeNode tnBuf;
        TreeNode tnchildBuf;
        tnBuf = new TreeNode();
        tnBuf.Collapse();
        tnBuf.Text = "<a class='link-02' title='任务提示' onclick=\"return showPage('Home/default.aspx')\" style=\"cursor:hand\" >任务提示</a>";

        tnBuf.ToolTip = "任务提示";
        tnBuf.Value = "任务提示";

        tnBuf.ImageUrl = "../Control/tree-img/folder.gif";
        tnBuf.ImageToolTip = "任务提示";
        tv.Nodes[0].ChildNodes.Add(tnBuf);


        ///机构简介
        //tnBuf = new TreeNode();

        //tnBuf.Collapse();
        //tnBuf.Text = "<a class='link-02' title='机构简介' onclick=\"return showPage('Introduction/default.aspx')\" style=\"cursor:hand\" >机构简介</a>";
        //tnBuf.ImageUrl = "../Control/tree-img/folder.gif";
        //tnBuf.ImageToolTip = "机构简介";
        //tnBuf.ToolTip = "机构简介";
        //tnBuf.Value = "机构简介";

        //tnchildBuf = new TreeNode();
        //tnchildBuf.Text = "<a class='link-02' title='机构简介' onclick=\"return showPage('Introduction/default.aspx')\" style=\"cursor:hand\" >机构简介</a>";
        //tnchildBuf.ImageUrl = "../Control/tree-img/page.gif";
        //tnchildBuf.ImageToolTip = "机构简介";
        //tnchildBuf.ToolTip = "机构简介";
        //tnchildBuf.Value = "机构简介";
        //tnBuf.ChildNodes.Add(tnchildBuf);


        //tnchildBuf = new TreeNode();
        //tnchildBuf.Text = "<a class='link-02' title='机构职能' onclick=\"return showPage('Law/NewsEdit.aspx?id=3&pid=1')\" style=\"cursor:hand\" >机构职能</a>";
        //tnchildBuf.ImageUrl = "../Control/tree-img/page.gif";
        //tnchildBuf.ImageToolTip = "机构职能";
        //tnchildBuf.ToolTip = "机构职能";
        //tnchildBuf.Value = "机构职能";
        //tnBuf.ChildNodes.Add(tnchildBuf);


        //tnchildBuf = new TreeNode();
        //tnchildBuf.Text = "<a class='link-02' title='机构设置' onclick=\"return showPage('Law/NewsEdit.aspx?id=4&pid=1')\" style=\"cursor:hand\" >机构设置</a>";
        //tnchildBuf.ImageUrl = "../Control/tree-img/page.gif";
        //tnchildBuf.ImageToolTip = "机构设置";
        //tnchildBuf.ToolTip = "机构设置";
        //tnchildBuf.Value = "机构设置";
        //tnBuf.ChildNodes.Add(tnchildBuf);

        //tnchildBuf = new TreeNode();
        //tnchildBuf.Text = "<a class='link-02' title='组织架构' onclick=\"return showPage('Law/NewsEdit.aspx?id=5&pid=1')\" style=\"cursor:hand\" >组织架构</a>";
        //tnchildBuf.ImageUrl = "../Control/tree-img/page.gif";
        //tnchildBuf.ImageToolTip = "组织架构";
        //tnchildBuf.ToolTip = "组织架构";
        //tnchildBuf.Value = "组织架构";
        //tnBuf.ChildNodes.Add(tnchildBuf);

        //tv.Nodes[0].ChildNodes.Add(tnBuf);

        ///办证指南
        tnBuf = new TreeNode();
        tnBuf.Collapse();
        tnBuf.Text = "<a class='link-02' title='办证指南' onclick=\"return showPage('Law/NewsEdit.aspx?id=6&pid=4')\" style=\"cursor:hand\" >办证指南</a>";
        tnBuf.ImageUrl = "../Control/tree-img/folder.gif";
        tnBuf.ImageToolTip = "办证指南";
        tnBuf.ToolTip = "办证指南";
        tnBuf.Value = "办证指南";

        tnchildBuf = new TreeNode();
        tnchildBuf.Text = "<a class='link-02' title='办事流程' onclick=\"return showPage('Law/NewsEdit.aspx?id=6&pid=4')\" style=\"cursor:hand\" >办事流程</a>";
        tnchildBuf.ImageUrl = "../Control/tree-img/page.gif";
        tnchildBuf.ImageToolTip = "办事流程";
        tnchildBuf.ToolTip = "办事流程";
        tnchildBuf.Value = "办事流程";
        tnBuf.ChildNodes.Add(tnchildBuf);


        tnchildBuf = new TreeNode();
        tnchildBuf.Text = "<a class='link-02' title='初次申请' onclick=\"return showPage('Law/NewsEdit.aspx?id=7&pid=4')\" style=\"cursor:hand\" >初次申请</a>";
        tnchildBuf.ImageUrl = "../Control/tree-img/page.gif";
        tnchildBuf.ImageToolTip = "初次申请";
        tnchildBuf.ToolTip = "初次申请";
        tnchildBuf.Value = "初次申请";
        tnBuf.ChildNodes.Add(tnchildBuf);


        tnchildBuf = new TreeNode();
        tnchildBuf.Text = "<a class='link-02' title='晋级申请' onclick=\"return showPage('Law/NewsEdit.aspx?id=8&pid=4')\" style=\"cursor:hand\" >晋级申请</a>";
        tnchildBuf.ImageUrl = "../Control/tree-img/page.gif";
        tnchildBuf.ImageToolTip = "晋级申请";
        tnchildBuf.ToolTip = "晋级申请";
        tnchildBuf.Value = "晋级申请";
        tnBuf.ChildNodes.Add(tnchildBuf);

        tnchildBuf = new TreeNode();
        tnchildBuf.Text = "<a class='link-02' title='表格下载' onclick=\"return showPage('Law/NewsEdit.aspx?id=9&pid=4')\" style=\"cursor:hand\" >表格下载</a>";
        tnchildBuf.ImageUrl = "../Control/tree-img/page.gif";
        tnchildBuf.ImageToolTip = "表格下载";
        tnchildBuf.ToolTip = "表格下载";
        tnchildBuf.Value = "表格下载";
        tnBuf.ChildNodes.Add(tnchildBuf);

        tv.Nodes[0].ChildNodes.Add(tnBuf);


        ///联系我们
        //tnBuf = new TreeNode();
        //tnBuf.Text = "<a class='link-02' title='联系我们' onclick=\"return showPage('Contact/default.aspx')\" style=\"cursor:hand\" >联系我们</a>";
        //tnBuf.ImageUrl = "../Control/tree-img/folder.gif";
        //tnBuf.ImageToolTip = "联系我们";
        //tnBuf.ToolTip = "联系我们";
        //tnBuf.Value = "联系我们";
        //tv.Nodes[0].ChildNodes.Add(tnBuf);

        ///政策法规
        //tnBuf = new TreeNode();
        //tnBuf.Collapse();
        //tnBuf.Text = "<a class='link-02' title='政策法规' onclick=\"return showPage('Law/default.aspx?pid=2')\" style=\"cursor:hand\" >政策法规</a>";
        //tnBuf.ImageUrl = "../Control/tree-img/folder.gif";
        //tnBuf.ImageToolTip = "政策法规";
        //tnBuf.ToolTip = "政策法规";
        //tnBuf.Value = "政策法规";

        //tnchildBuf = new TreeNode();
        //tnchildBuf.Text = "<a class='link-02' title='政策法规' onclick=\"return showPage('Law/default.aspx?pid=2')\" style=\"cursor:hand\" >政策法规</a>";
        //tnchildBuf.ImageUrl = "../Control/tree-img/page.gif";
        //tnchildBuf.ImageToolTip = "政策法规";
        //tnchildBuf.ToolTip = "政策法规";
        //tnchildBuf.Value = "政策法规";
        //tnBuf.ChildNodes.Add(tnchildBuf);

        //tnchildBuf = new TreeNode();
        //tnchildBuf.Text = "<a class='link-02' title='添加政策法规' onclick=\"return showPage('Law/NewsEdit.aspx?pid=2')\" style=\"cursor:hand\" >添加</a>";
        //tnchildBuf.ImageUrl = "../Control/tree-img/page.gif";
        //tnchildBuf.ImageToolTip = "添加政策法规";
        //tnchildBuf.ToolTip = "添加政策法规";
        //tnchildBuf.Value = "添加政策法规";
        //tnBuf.ChildNodes.Add(tnchildBuf);

        //tv.Nodes[0].ChildNodes.Add(tnBuf);


        ///公告
        tnBuf = new TreeNode();
        tnBuf.Collapse();
        tnBuf.Text = "<a class='link-02' title='公告栏' onclick=\"return showPage('Law/default.aspx?pid=3')\" style=\"cursor:hand\" >公告栏</a>";
        tnBuf.ImageUrl = "../Control/tree-img/folder.gif";
        tnBuf.ImageToolTip = "公告栏";
        tnBuf.ToolTip = "公告栏";
        tnBuf.Value = "公告栏";


        tnchildBuf = new TreeNode();
        tnchildBuf.Text = "<a class='link-02' title='公告列表' onclick=\"return showPage('Law/default.aspx?pid=3')\" style=\"cursor:hand\" >公告列表</a>";
        tnchildBuf.ImageUrl = "../Control/tree-img/page.gif";
        tnchildBuf.ImageToolTip = "公告列表";
        tnchildBuf.ToolTip = "公告列表";
        tnchildBuf.Value = "公告列表";
        tnBuf.ChildNodes.Add(tnchildBuf);

        tnchildBuf = new TreeNode();
        tnchildBuf.Text = "<a class='link-02' title='添加公告' onclick=\"return showPage('Law/NewsEdit.aspx?pid=3')\" style=\"cursor:hand\" >添加公告</a>";
        tnchildBuf.ImageUrl = "../Control/tree-img/page.gif";
        tnchildBuf.ImageToolTip = "添加公告";
        tnchildBuf.ToolTip = "添加公告";
        tnchildBuf.Value = "添加公告";
        tnBuf.ChildNodes.Add(tnchildBuf);

        tv.Nodes[0].ChildNodes.Add(tnBuf);


        ///工作区
        tnBuf = new TreeNode();
        tnBuf.Collapse();
        tnBuf.Text = "<a class='link-02' title='工作区' onclick=\"return showPage('workaround/FirstAuditing.aspx?tid=1')\" style=\"cursor:hand\" >工作区</a>";
        tnBuf.ImageUrl = "../Control/tree-img/folder.gif";
        tnBuf.ImageToolTip = "工作区";
        tnBuf.ToolTip = "工作区";
        tnBuf.Value = "工作区";


        tnchildBuf = new TreeNode();
        tnchildBuf.Text = "<a class='link-02' title='网上初审' onclick=\"return showPage('workaround/FirstAuditing.aspx?tid=1')\" style=\"cursor:hand\" >网上初审</a>";
        tnchildBuf.ImageUrl = "../Control/tree-img/page.gif";
        tnchildBuf.ImageToolTip = "网上初审";
        tnchildBuf.ToolTip = "网上初审";
        tnchildBuf.Value = "网上初审";
        tnBuf.ChildNodes.Add(tnchildBuf);

        tnchildBuf = new TreeNode();
        tnchildBuf.Text = "<a class='link-02' title='书面资料审核' onclick=\"return showPage('workaround/FirstCheck.aspx')\" style=\"cursor:hand\" >书面资料审核</a>";
        tnchildBuf.ImageUrl = "../Control/tree-img/page.gif";
        tnchildBuf.ImageToolTip = "书面资料审核";
        tnchildBuf.ToolTip = "书面资料审核";
        tnchildBuf.Value = "书面资料审核";
        tnBuf.ChildNodes.Add(tnchildBuf);

        tnchildBuf = new TreeNode();
        tnchildBuf.Text = "<a class='link-02' title='现场评审' onclick=\"return showPage('workaround/syndic.aspx')\" style=\"cursor:hand\" >现场评审</a>";
        tnchildBuf.ImageUrl = "../Control/tree-img/page.gif";
        tnchildBuf.ImageToolTip = "添加公告";
        tnchildBuf.ToolTip = "现场评审";
        tnchildBuf.Value = "现场评审";
        tnBuf.ChildNodes.Add(tnchildBuf);

        tnchildBuf = new TreeNode();
        tnchildBuf.Text = "<a class='link-02' title='评审结论' onclick=\"return showPage('workaround/Result.aspx')\" style=\"cursor:hand\" >评审结论</a>";
        tnchildBuf.ImageUrl = "../Control/tree-img/page.gif";
        tnchildBuf.ImageToolTip = "评审结论";
        tnchildBuf.ToolTip = "评审结论";
        tnchildBuf.Value = "评审结论";
        tnBuf.ChildNodes.Add(tnchildBuf);

        tnchildBuf = new TreeNode();
        tnchildBuf.Text = "<a class='link-02' title='处理通知书' onclick=\"return showPage('workaround/PromotionDeal.aspx')\" style=\"cursor:hand\" >处理通知书</a>";
        tnchildBuf.ImageUrl = "../Control/tree-img/page.gif";
        tnchildBuf.ImageToolTip = "处理通知书";
        tnchildBuf.ToolTip = "处理通知书";
        tnchildBuf.Value = "处理通知书";
        tnBuf.ChildNodes.Add(tnchildBuf);

        tnchildBuf = new TreeNode();
        tnchildBuf.Text = "<a class='link-02' title='报批申请' onclick=\"return showPage('workaround/approve.aspx')\" style=\"cursor:hand\" >报批申请</a>";
        tnchildBuf.ImageUrl = "../Control/tree-img/page.gif";
        tnchildBuf.ImageToolTip = "报批申请";
        tnchildBuf.ToolTip = "报批申请";
        tnchildBuf.Value = "报批申请";
        tnBuf.ChildNodes.Add(tnchildBuf);

        tnchildBuf = new TreeNode();
        tnchildBuf.Text = "<a class='link-02' title='查询' onclick=\"return showPage('workaround/Search.aspx')\" style=\"cursor:hand\" >查询</a>";
        tnchildBuf.ImageUrl = "../Control/tree-img/page.gif";
        tnchildBuf.ImageToolTip = "查询";
        tnchildBuf.ToolTip = "查询";
        tnchildBuf.Value = "查询";
        tnBuf.ChildNodes.Add(tnchildBuf);
        tv.Nodes[0].ChildNodes.Add(tnBuf);

        ///证书管理
        tnBuf = new TreeNode();
        tnBuf.Collapse();
        tnBuf.Text = "<a class='link-02' title='证书管理' onclick=\"return showPage('CertNO/default.aspx')\" style=\"cursor:hand\" >证书管理</a>";
        tnBuf.ImageUrl = "../Control/tree-img/folder.gif";
        tnBuf.ImageToolTip = "证书管理";
        tnBuf.ToolTip = "证书管理";
        tnBuf.Value = "证书管理";

        tnchildBuf = new TreeNode();
        tnchildBuf.Text = "<a class='link-02' title='证书发放' onclick=\"return showPage('CertNO/default.aspx')\" style=\"cursor:hand\" >证书发放</a>";
        tnchildBuf.ImageUrl = "../Control/tree-img/page.gif";
        tnchildBuf.ImageToolTip = "证书发放";
        tnchildBuf.ToolTip = "证书发放";
        tnchildBuf.Value = "证书发放";
        tnBuf.ChildNodes.Add(tnchildBuf);

        tnchildBuf = new TreeNode();
        tnchildBuf.Text = "<a class='link-02' title='证书查询' onclick=\"return showPage('CertNO/CertNOList.aspx')\" style=\"cursor:hand\" >证书查询</a>";
        tnchildBuf.ImageUrl = "../Control/tree-img/page.gif";
        tnchildBuf.ImageToolTip = "证书查询";
        tnchildBuf.ToolTip = "证书查询";
        tnchildBuf.Value = "证书查询";
        tnBuf.ChildNodes.Add(tnchildBuf);

        tnchildBuf = new TreeNode();
        tnchildBuf.Text = "<a class='link-02' title='高级查询' onclick=\"return showPage('CertNO/CertNOSearch.aspx')\" style=\"cursor:hand\" >高级查询</a>";
        tnchildBuf.ImageUrl = "../Control/tree-img/page.gif";
        tnchildBuf.ImageToolTip = "高级查询";
        tnchildBuf.ToolTip = "高级查询";
        tnchildBuf.Value = "高级查询";
        tnBuf.ChildNodes.Add(tnchildBuf);

        tv.Nodes[0].ChildNodes.Add(tnBuf);



        ///添加企业基本资料
        tnBuf = new TreeNode();
        tnBuf.Collapse();
        tnBuf.Text = "<a class='link-02' title='添加企业基本资料' onclick=\"return showPage('CompanyAdd/CompanyList.aspx')\" style=\"cursor:hand\" >添加企业基本资料</a>";
        tnBuf.ImageUrl = "../Control/tree-img/folder.gif";
        tnBuf.ImageToolTip = "添加企业基本资料";
        tnBuf.ToolTip = "添加企业基本资料";
        tnBuf.Value = "添加企业基本资料";

        tnchildBuf = new TreeNode();
        tnchildBuf.Text = "<a class='link-02' title='初次申请' onclick=\"return showPage('CompanyAdd/default.aspx')\" style=\"cursor:hand\" >初次申请</a>";
        tnchildBuf.ImageUrl = "../Control/tree-img/page.gif";
        tnchildBuf.ImageToolTip = "初次申请";
        tnchildBuf.ToolTip = "初次申请";
        tnchildBuf.Value = "初次申请";
        tnBuf.ChildNodes.Add(tnchildBuf);

        tnchildBuf = new TreeNode();
        tnchildBuf.Text = "<a class='link-02' title='晋级申请' onclick=\"return showPage('CompanyAdd/default.aspx?type=2')\" style=\"cursor:hand\" >晋级申请</a>";
        tnchildBuf.ImageUrl = "../Control/tree-img/page.gif";
        tnchildBuf.ImageToolTip = "晋级申请";
        tnchildBuf.ToolTip = "晋级申请";
        tnchildBuf.Value = "晋级申请";
        tnBuf.ChildNodes.Add(tnchildBuf);

        tnchildBuf = new TreeNode();
        tnchildBuf.Text = "<a class='link-02' title='简易录入' onclick=\"return showPage('CompanyAdd/AddSimple.aspx')\" style=\"cursor:hand\" >简易录入</a>";
        tnchildBuf.ImageUrl = "../Control/tree-img/page.gif";
        tnchildBuf.ImageToolTip = "简易录入";
        tnchildBuf.ToolTip = "简易录入";
        tnchildBuf.Value = "简易录入";
        tnBuf.ChildNodes.Add(tnchildBuf);

        tv.Nodes[0].ChildNodes.Add(tnBuf);



        ///统计
        tnBuf = new TreeNode();
        tnBuf.Text = "<a class='link-02' title='统计' onclick=\"return showPage('Stat/default.aspx')\" style=\"cursor:hand\" >统计</a>";
        tnBuf.ImageUrl = "../Control/tree-img/folder.gif";
        tnBuf.ImageToolTip = "统计";
        tnBuf.ToolTip = "统计";
        tnBuf.Value = "统计";
        tv.Nodes[0].ChildNodes.Add(tnBuf);




        /// 投诉受理

        //tnBuf = new TreeNode();
        //tnBuf.Text = "<a class='link-02' title='投诉受理' onclick=\"return showPage('workaround/Complain.aspx')\" style=\"cursor:hand\" >投诉受理</a>";
        //tnBuf.ImageUrl = "../Control/tree-img/folder.gif";
        //tnBuf.ImageToolTip = "投诉受理";
        //tnBuf.ToolTip = "投诉受理";
        //tnBuf.Value = "投诉受理";

        //tv.Nodes[0].ChildNodes.Add(tnBuf);

        ///系统管理
        tnBuf = new TreeNode();
        tnBuf.Collapse();
        tnBuf.Text = "<a class='link-02' title='系统管理' onclick=\"return showPage('UserSysAdmin/TaskNote.aspx')\" style=\"cursor:hand\" >系统管理</a>";
        tnBuf.ImageUrl = "../Control/tree-img/folder.gif";
        tnBuf.ImageToolTip = "系统管理";
        tnBuf.ToolTip = "系统管理";
        tnBuf.Value = "系统管理";

        tnchildBuf = new TreeNode();
        tnchildBuf.Text = "<a class='link-02' title='提示管理' onclick=\"return showPage('UserSysAdmin/TaskNote.aspx')\" style=\"cursor:hand\" >提示管理</a>";
        tnchildBuf.ImageUrl = "../Control/tree-img/page.gif";
        tnchildBuf.ImageToolTip = "提示管理";
        tnchildBuf.ToolTip = "提示管理";
        tnchildBuf.Value = "提示管理";
        tnBuf.ChildNodes.Add(tnchildBuf);

        tnchildBuf = new TreeNode();
        tnchildBuf.Text = "<a class='link-02' title='提示设置' onclick=\"return showPage('UserSysAdmin/DictTask.aspx')\" style=\"cursor:hand\" >提示设置</a>";
        tnchildBuf.ImageUrl = "../Control/tree-img/page.gif";
        tnchildBuf.ImageToolTip = "提示设置";
        tnchildBuf.ToolTip = "提示设置";
        tnchildBuf.Value = "提示设置";
        tnBuf.ChildNodes.Add(tnchildBuf);

        tnchildBuf = new TreeNode();
        tnchildBuf.Text = "<a class='link-02' title='用户组管理' onclick=\"return showPage('UserSysAdmin/UserGroupList.aspx')\" style=\"cursor:hand\" >用户组管理</a>";
        tnchildBuf.ImageUrl = "../Control/tree-img/page.gif";
        tnchildBuf.ImageToolTip = "用户组管理";
        tnchildBuf.ToolTip = "用户组管理";
        tnchildBuf.Value = "用户组管理";
        tnBuf.ChildNodes.Add(tnchildBuf);

        tnchildBuf = new TreeNode();
        tnchildBuf.Text = "<a class='link-02' title='用户管理' onclick=\"return showPage('UserSysAdmin/UserList.aspx')\" style=\"cursor:hand\" >用户管理</a>";
        tnchildBuf.ImageUrl = "../Control/tree-img/page.gif";
        tnchildBuf.ImageToolTip = "用户管理";
        tnchildBuf.ToolTip = "用户管理";
        tnchildBuf.Value = "用户管理";
        tnBuf.ChildNodes.Add(tnchildBuf);

        tnchildBuf = new TreeNode();
        tnchildBuf.Text = "<a class='link-02' title='退出登录' onclick=\"javascript:return logout()\" style=\"cursor:hand\" >退出登录</a>";
        tnchildBuf.ImageUrl = "../Control/tree-img/page.gif";
        tnchildBuf.ImageToolTip = "退出登录";
        tnchildBuf.ToolTip = "退出登录";
        tnchildBuf.Value = "退出登录";
        tnBuf.ChildNodes.Add(tnchildBuf);

        tv.Nodes[0].ChildNodes.Add(tnBuf);
        tv.Nodes[0].Expand();
    }
}
