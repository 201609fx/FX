using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SZMA.DataLayer;

public partial class Service_command : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lock (this)
            {
                string result = null;
                if (Request["cmd"] != null)
                {
                    switch (Request["cmd"])
                    {
                        //管理维修业务类型
                        case "addBusType":
                            result = ManageBusType("add");
                            break;
                        case "delBusType":
                            result = ManageBusType("del");
                            break;
                        case "getBusType":
                            result = ManageBusType("get");
                            break;

                        //管理特约维修业务品牌
                        case "addBusName":
                            result = ManageBusName("add");
                            break;
                        case "delBusName":
                            result = ManageBusName("del");
                            break;
                        case "getBusName":
                            result = ManageBusName("get");
                            break;

                        //管理人员
                        case "addPerson":
                            result = ManagePerson("add");
                            break;
                        case "delPerson":
                            result = ManagePerson("del");
                            break;
                        case "getPerson":
                            result = ManagePerson("get");
                            break;

                        //管理设备
                        case "addTool":
                            result = ManageTool("add");
                            break;
                        case "delTool":
                            result = ManageTool("del");
                            break;
                        case "getTool":
                            result = ManageTool("get");
                            break;

                        //企业信息
                        case "addCompanyInfo":
                            result = ManageCompanyInfo("save");
                            break;
                        case "getCompanyInfo":
                            result = ManageCompanyInfo("get");
                            break;

                        //送审资料
                        case "getDocumInfo":
                            result = ManagerDocumInfo("get");
                            break;
                        case "updateDocumInfo":
                            result =ManagerDocumInfo("update");
                            break;
                        //检查晋级申请是否合规
                        case "checkLevel":
                            result = CheckLevel();
                            break;
                        default:
                            break;
                    }
                }
                if (result != null)
                {
                    // Response.ContentType = "text/x-json";
                    Response.Clear();
                    Response.Write(result);
                    Response.End();
                }
            }

        }
    }

    private string CheckLevel()
    {
        string msg = "0#";
        bool levelOk = true;

        string oldCertNo = Page.Request["oldCertNo"];
        if (!string.IsNullOrEmpty(oldCertNo))
        {
            oldCertNo = oldCertNo.Trim();
            try
            {

                string str = oldCertNo.TrimEnd().Substring(oldCertNo.Length - 1, 1).ToLower();
                if (str=="a")
                {
                    levelOk = false;
                    return "1#证书 "+oldCertNo+" 是一级证书，不需要再提交晋级申请，若证书即将过期请点击'初次申请'";
                }
            }
            catch (Exception)
            { 

            }

            //确定时间是否在允许申请范围内
            string sqlStr = "select top 1 * from [szwr].[dbo].[MainSC] where CertNO='" + oldCertNo + "' order by CreateTime desc";
            DataSet ds = Common.SelectByPager(sqlStr);
            if (ds.Tables.Count>0)
            {
                if (ds.Tables[0].Rows.Count>0)
                {
                    //获取创建时间
                    try
                    {
                        string dateTimeStr = ds.Tables[0].Rows[0]["CreateTime"].ToString();
                        if (!string.IsNullOrEmpty(dateTimeStr))
                        {
                            DateTime dateTime = Convert.ToDateTime(dateTimeStr);
                            TimeSpan ts = DateTime.Now - dateTime;
                            if (ts.Days>60||ts.Days<-60)
                            {
                                return "1#证书 "+oldCertNo+" 不在可申请晋级时间范围："+dateTime.AddMonths(10).GetDateTimeFormats('D')[0].ToString()+"~"+dateTime.AddMonths(14).GetDateTimeFormats('D')[0].ToString();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        
                    }
                }
                else
                {
                    return "1#证书 "+oldCertNo+" 不存在，请检查";
                }
            }
        }


        return msg;
    }


    private int CheckUser(string cretNo)
    {
        //string cretNo = GetPageParam(Page, "cretNo");
        //if (string.IsNullOrEmpty(cretNo))
        //{
        //    return "-1"; ;
        //}

        int count = 0;
        string dateTimeStr = DateTime.Now.AddMonths(-3).ToShortDateString().ToString();
        string sqlStr = "select * FROM employee where certNO ='" + cretNo + "' and CreateTime > '" + dateTimeStr + "'";
        DataSet ds = Common.SelectByPager(sqlStr);
        if (ds.Tables.Count>0)
        {
            count = ds.Tables[0].Rows.Count;
        }
        return count;
    }

    private string ManagerDocumInfo(string p)
    {
        string msg = "";
        
        int recc = 0;
        switch (p)
        {
            case "get":
                string id = GetPageParam(Page, "id");
                DataSet dsCSFile = Common.Pager("CSFileDict],[CSlist", "CSlist.ID,CSlist.Num,CSFileDict.Name,CSFileDict.ID as cID", "cID", 100, 1, false, "CSlist.MainSCID='" + id + "' and CSlist.CSFileID=CSFileDict.ID ",
                                            out recc);
                if (recc > 0)
                {
                //msg:是否成功#是否晋级申请#是否审核通过#dt初始化数据
                    msg += "0#";
                    msg += JsonConvert.SerializeObject(dsCSFile.Tables[0]);
                }
                else
                {
                    msg = "1#未获取到数据";//失败
                }
                break;

            case "update":
                string docId = GetPageParam(Page, "id");
                string numValue = GetPageParam(Page, "numValue");
                int num = 0;
                int doc = 0;
                try
                {
                    num = Convert.ToInt32(numValue);
                    doc = Convert.ToInt32(docId);
                    CSFileDAL MyDAL = new CSFileDAL();
                    int rtn = MyDAL.Update(numValue, docId);
                    if (rtn>0)
                    {
                        msg = "0#保存成功";//成功
                    }
                }
                catch (Exception)
                {
                    msg = "1#参数不正确";//失败
                }                
                break;
            default:
                break;
        }


        return msg;
    }

    private string ManageCompanyInfo(string p)
    {
        string msg = "";
        string id = GetPageParam(Page, "id");
        MainSCTempDAL obj = new MainSCTempDAL();
        int i = getTypeID();//申请、晋级

        switch (p)
        {
            case "save":
                string saveType = GetPageParam(Page, "saveType"); ; //添加参数 判断是保存还是提交 以作不同提示

                string cmName = GetPageParam(Page, "cmName");
                string cmAddress = GetPageParam(Page, "cmAddress");
                string cmContacts = GetPageParam(Page, "cmContacts");
                string cmPhoneNo = GetPageParam(Page, "cmPhoneNo");
                string cmTelNo = GetPageParam(Page, "cmTelNo");
                string cmCodeNo = GetPageParam(Page, "cmCodeNo");
                string cmFaxNo = GetPageParam(Page, "cmFaxNo");
                string cmZone = GetPageParam(Page, "cmZone");
                string cmAllArea = GetPageParam(Page, "cmAllArea");
                string cmAllPerson = GetPageParam(Page, "cmAllPerson");
                string cmOwner = GetPageParam(Page, "cmOwner");
                string cmOwnerNo = GetPageParam(Page, "cmOwnerNo");
                string cmFixer = GetPageParam(Page, "cmFixer");
                string cmInstaller = GetPageParam(Page, "cmInstaller");
                string oldCertNo = GetPageParam(Page, "oldCertNo");
                string newCertNo = GetPageParam(Page, "newCertNo");

                if (obj.Update(cmZone, cmName, cmAddress, cmCodeNo, cmContacts, cmPhoneNo, cmTelNo, cmFaxNo,
                      cmOwner, cmOwnerNo, cmAllArea, cmAllPerson, cmFixer, cmInstaller, i, "",
                      DateTime.Now, 4, "", oldCertNo, newCertNo, id) > 0)
                {
                    string url = "Default.aspx?m=CompanyView&id=" + id + "&saveType=" + saveType;
                    msg = "0#" + url;
                }
                else
                {
                    msg = "1#保存失败!!!" + id;
                }
                break;
            case "get": 
                int recc;
                DataSet ds =
                   Common.Pager("MainSCTemp", "*", "ID", 100, 1, true, "ID='" + id + "'",
                                out recc);
                if (recc > 0)
                {
                //msg:是否成功#是否晋级申请#是否审核通过#dt初始化数据
                    msg += "0#";
                    //晋级申请
                    if (ds.Tables[0].Rows[0]["type"].ToString() == "2" || (i == 2))
                    {
                        msg += "0#";
                        //pnlCert.Visible = true;
                        //pnlSummary.Visible = true;
                        //Label1.Text = "晋级申请";
                    }
                    else
                    {
                        msg += "1#";
                    }
                    //审核通过
                    if (ds.Tables[0].Rows[0]["InsertFlag"].ToString() == "2")///审核通过后不能修改
                    {
                        msg += "0#";
                        //pnlSuggest.Visible = true;
                        //lblSuggest.Text = ds.Tables[0].Rows[0]["Suggest"].ToString();
                    }
                    else
                    {
                        msg += "1#";
                    }
                    msg += JsonConvert.SerializeObject(ds.Tables[0]) ;
                }
                else
                {
                    msg = "1#";//失败
                }
                break;

            default:
                break;
        }





        return msg;
    }
    private int getTypeID()
    {
        int rtn = 1;
        try
        {
            rtn = int.Parse(GetPageParam(Page, "type"));
        }
        catch
        {
        }
        return rtn;
    }


    /// <summary>
    /// 管理设备
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    private string ManageTool(string p)
    {
        string msg = "";
        string id = GetPageParam(Page, "id");
        string toolType = GetPageParam(Page, "toolType"); //1:交通工具 2:其它仪器设备
        string toolName = GetPageParam(Page, "toolName");
        string toolNumber = GetPageParam(Page, "toolNumber");
        string toolCount = GetPageParam(Page, "toolCount");

        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(toolType))
        {
            return "参数错误.";
        }

        equipmentDAL MyDAL = new equipmentDAL();
        int rtn = 0;

        switch (p)
        {
            case "add":
                if (string.IsNullOrEmpty(toolName) || string.IsNullOrEmpty(toolNumber) || string.IsNullOrEmpty(toolCount))
                {
                    return "参数错误:填写不完全";
                }
                rtn = MyDAL.Insert(toolName, toolCount, toolNumber, toolType, id);

                if (rtn > 0)
                {
                    msg = "0#成功";
                }
                else
                {
                    msg = "1#失败";
                }

                break;
            case "del":
                rtn = MyDAL.Delete(id, toolType, toolName, toolNumber);
                if (rtn > 0)
                {
                    msg = "0#成功";
                }
                else
                {
                    msg = "1#失败";
                }
                break;
            case "get":
                int recc;
                DataSet dsElist1 =
               Common.Pager("equipment", "ID,Num,des,Type,Model,MainSCID", "ID", 100, 1, true, "MainSCID='" + id + "' and Type=" + toolType + " and InsertFlag=1",
                            out recc);
                if (dsElist1!=null&&dsElist1.Tables.Count>0)
                {
                    msg = JsonConvert.SerializeObject(dsElist1.Tables[0]);
                }
                break;
            default:
                break;
        }
        return msg;
    }

    //管理人员
    private string ManagePerson(string p)
    {
        string msg = "";
        string id = GetPageParam(Page, "id");
        string personTypeId = GetPageParam(Page, "personTypeId"); //1:管理/专业技术人员 2:安装/维修人员
        string name = GetPageParam(Page, "name");
        string eduLevel = GetPageParam(Page, "eduLevel");
        string post = GetPageParam(Page, "post");
        string certName = GetPageParam(Page, "certName");
        string certNo = GetPageParam(Page, "certNo");
        string mark = GetPageParam(Page, "mark");

        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(personTypeId))
        {
            return "1#参数错误.";
        }

        EmployeeDAL MyDAL = new EmployeeDAL();
        int rtn = 0;

        switch (p)
        {
            case "add":
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(eduLevel) || string.IsNullOrEmpty(post) || string.IsNullOrEmpty(certName) || string.IsNullOrEmpty(certNo))
                {
                    return "1#参数错误:填写不完全";
                }

                //验证证书是否在最近3个月内存在
                int t = CheckUser(certNo);
                if (t>0)
                {
                    msg = "1#该人员最近已被添加过，不允许重复添加.";
                    return msg;
                }


                rtn = MyDAL.Insert(name, eduLevel, post, certNo, certName, "0", mark, personTypeId, id);

                if (rtn > 0)
                {
                    msg = "0#成功";
                }
                else
                {
                    msg = "1#失败";
                }

                break;
            case "del":
                rtn = MyDAL.Delete(name, eduLevel, post, id, personTypeId);
                if (rtn > 0)
                {
                    msg = "0#成功";
                }
                else
                {
                    msg = "1#失败";
                }
                break;
            case "get":
                int recc;
                DataSet dsMemployee =
                    Common.Pager("employee", "ID,Name,educational,Eposition,certNO,remark,CertName,CertType,(select CertName from Dict_Cert where Dict_Cert.ID=employee.CertType) as dictCertName", "ID", 100, 1, false, "MainSCID='" + id + "' and Type=" + personTypeId + " and InsertFlag=1",
                                 out recc);
                if (dsMemployee != null && dsMemployee.Tables.Count > 1)
                {
                    msg = JsonConvert.SerializeObject(dsMemployee.Tables[0]);
                }
                break;
            default:
                break;
        }
        return msg;
    }

    /// <summary>
    /// 管理特约维修业务品牌
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    private string ManageBusName(string p)
    {
        string msg = "";
        string id = GetPageParam(Page, "id");
        string busName = "";

        if (string.IsNullOrEmpty(id))
        {
            return "参数错误.";
        }

        OperateSADAL MyDAL = new OperateSADAL();
        int rtn = 0;

        switch (p)
        {
            case "add":
                busName=GetPageParam(Page, "busName");
                if (string.IsNullOrEmpty(busName))
                {
                    return "busName参数错误.";
                }
                rtn = MyDAL.Insert(id, busName);
                if (rtn > 0)
                {
                    msg = "0#成功";
                }
                else
                {
                    msg = "1#失败";
                }

                break;
            case "del":
                busName = GetPageParam(Page, "busName");
                if (string.IsNullOrEmpty(busName))
                {
                    return "busName参数错误.";
                }
                rtn = MyDAL.Delete(id, busName);
                if (rtn > 0)
                {
                    msg = "0#成功";
                }
                else
                {
                    msg = "1#失败";
                }
                break;
            case "get":
                int recc = 0;
                DataSet ds =
                Common.Pager("OperateSA", "ID,brand,MainSCID", "ID", 100, 1, false, "MainSCID='" + id + "'",
                             out recc);
                if (ds!=null&&ds.Tables.Count>1)
                {
                    msg = JsonConvert.SerializeObject(ds.Tables[0]);
                }
                
                break;
            default:
                break;
        }


        return msg;
    }



    /// <summary>
    /// 管理维修业务范围类型
    /// </summary>
    /// <returns></returns>
    private string ManageBusType(string op)
    {
        string msg = "";
        string id = GetPageParam(Page, "id");
        

        if (string.IsNullOrEmpty(id) )
        {
            return "参数错误.";
        }
        string busTypeId="";

        OperationMainDAL MyDAL = new OperationMainDAL();
        int rtn = 0;

        switch (op)
        {
            case "add":
                busTypeId = GetPageParam(Page, "busTypeId");
                rtn = MyDAL.Insert(id, busTypeId, "", DateTime.Now);
                if (rtn > 0)
                {
                    msg = "0#添加成功";
                }
                else
                {
                    msg = "1#添加失败";
                }

                break;
            case "del":
               busTypeId = GetPageParam(Page, "busTypeId");
                rtn = MyDAL.Delete(id, busTypeId);
                if (rtn > 0)
                {
                    msg = "0#成功";
                }
                else
                {
                    msg = "1#失败";
                }

                break;

            case "get":
                int recc;
                DataSet ds =
                    Common.Pager("OperationMain", "ID,ProductID,MainSCID,(select CN_Name from dict_product where ID=OperationMain.ProductID) as ProductName", "ID", 100, 1, false, "MainSCID='" + id + "'",
                                 out recc);
                if (ds != null && ds.Tables.Count > 1)
                {
                    msg = JsonConvert.SerializeObject(ds.Tables[0]);
                }
                break;

            default:
                break;
        }


        return msg;
    }



    #region 获取参数相关 GET/POST
    public static string GetPageParam(Page page, string key)
    {
        string value = "";
        if (string.IsNullOrEmpty(key) || page == null)
        {
            return "";
        }
        try
        {
            value = page.Request[key];
        }
        catch (Exception ex)
        {

        }
        return value;
    }
    #endregion
}