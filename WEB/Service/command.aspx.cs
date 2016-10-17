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
                msg = JsonConvert.SerializeObject(dsElist1);
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
            return "参数错误.";
        }

        EmployeeDAL MyDAL = new EmployeeDAL();
        int rtn = 0;

        switch (p)
        {
            case "add":
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(eduLevel) || string.IsNullOrEmpty(post) || string.IsNullOrEmpty(certName) || string.IsNullOrEmpty(certNo))
                {
                    return "参数错误:填写不完全";
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
                msg = JsonConvert.SerializeObject(dsMemployee);
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
        string busName = GetPageParam(Page, "busName");

        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(busName))
        {
            return "参数错误.";
        }

        OperateSADAL MyDAL = new OperateSADAL();
        int rtn = 0;

        switch (p)
        {
            case "add":
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
                msg = JsonConvert.SerializeObject(ds);
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
        string busTypeId = GetPageParam(Page, "busTypeId");

        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(busTypeId))
        {
            return "参数错误.";
        }


        OperationMainDAL MyDAL = new OperationMainDAL();
        int rtn = 0;

        switch (op)
        {
            case "add":
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
                rtn = MyDAL.Delete(id,busTypeId);
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
                msg = JsonConvert.SerializeObject(ds);
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