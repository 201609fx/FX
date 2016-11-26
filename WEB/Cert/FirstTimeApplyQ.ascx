<%@ Control Language="C#" EnableViewState="true" AutoEventWireup="true" CodeFile="FirstTimeApplyQ.ascx.cs" Inherits="Cert_FirstTimeApply" %>
<%@ Register Assembly="SZMA.Core" Namespace="SZMA.Core" TagPrefix="cc1" %>


<script language="javascript">
    function OpenPrint(id)
    {
        var features = 'width=900,height=700,scrollbars=yes,left=50,top=50,resizable=yes';
        var winName = '审批表打印';
        var Url = 'testPrint.aspx?id=' + id;
        var win = window.open(Url, winName, features);
        win.focus();
    }
            
             
</script>
<link href="../public/bootstrap3.3.5/css/bootstrap.css" rel="stylesheet" />
<link href="../public/font-awesome-4.4.0/css/font-awesome.css" rel="stylesheet" />
<style>
    .text-star-12 {
        font-family: "宋体";
        font-size: 12px;
        color: #ff0000;
    }

    .row {
        margin-right: 1px;
        margin-left: -1px;
    }

    .form-horizontal .form-group {
        margin-right: 0px;
        margin-left: 0px;
    }

    label.control-label {
        margin-bottom: 0;
        padding-top: 7px;
        font-size: 12px;
        color: #666;
        text-align: right;

        font-family: "宋体";
        font-size: 12px;
        color: #666666;
        text-indent: 6pt;
    }
</style>

<script src="../public/jquery1.11.3/jquery1.11.3.min.js"></script>
<script src="../public/bootstrap3.3.5/js/bootstrap.js"></script>

<script src="../jscript/CretForm.js"></script>

<table width="725" border="0" align="right" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <table width="725" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="13">
                        <img src="../images/lb6.gif" width="13" height="32" /></td>
                    <td width="150" background="../images/lb7.gif" class="text-bla-b-14">
                        <asp:Label runat="server" ID="Label1">初次申请</asp:Label></td>
                    <td align="right" background="../images/lb7.gif" class="text-hui-12">首页 >>  证书办理</td>
                    <td width="13">
                        <img src="../images/lb8.gif" width="13" height="32" /></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td height="6"></td>
    </tr>
    <tr>
        <td>
            <img src="../img/intro_body_1.gif" width="725" height="9"></td>
    </tr>
    <tr>
        <td>
            <table width="725" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="26">
                        <img src="../img/intro_body_2.gif" width="26" height="33"></td>
                    <td width="12" background="../img/intro_body_3.gif">
                        <img src="../img/ico3.gif" width="3" height="11"></td>
                    <td background="../img/intro_body_3.gif" class="bt-hui">
                        <asp:Label runat="server" ID="lblSortName">申请</asp:Label></td>
                    <td width="22">
                        <img src="../img/intro_body_4.gif" width="22" height="33"></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td height="410" valign="top" background="../img/intro_body_5.gif">
            <table width="700" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td>&nbsp;<asp:Label runat="server" ID="lblID" Visible="false"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <table width="680" border="0" cellpadding="1" cellspacing="1" class="text-b">
                            <tr>
                                <td colspan="8">
                                    <div class="panel panel-default " id="companyBasic">
                                        <div class="panel-heading">
                                            企业基本信息
                                        </div>
                                        <div class="panel-body">
                                            <div class="row">
                                                <table>
                                                    <asp:Panel runat="server" ID="pnlSuggest">
                                                        <tr class="companyInfo">
                                                            <td bgcolor="#f9f9f0" align="center">修改意见</td>
                                                            <td colspan="7" bgcolor="#f5f5f1">
                                                                <asp:Label runat="server" ID="lblSuggest"></asp:Label></td>
                                                        </tr>
                                                    </asp:Panel>
                                                    <asp:Panel runat="server" ID="pnlCert">
                                                        <tr class="companyInfo">
                                                            <td bgcolor="#f9f9f0" align="center" width="13%">原证书号</td>
                                                            <td colspan="3" bgcolor="#f5f5f1">
                                                                <asp:TextBox runat="server" ID="txtOldCertNO" ClientIDMode="Static" Width="100%"></asp:TextBox></td>
                                                            <td bgcolor="#f9f9f0" align="center"></td>
                                                            <td colspan="3" bgcolor="#f5f5f1">
                                                                <asp:TextBox runat="server" ID="txtNewCertNO" ClientIDMode="Static" Width="100%" Visible="false"></asp:TextBox></td>
                                                        </tr>
                                                    </asp:Panel>
                                                    <tr class="companyInfo">
                                                        <td bgcolor="#f9f9f0" align="center" width="13%">企业名称(全称)</td>
                                                        <td colspan="7" bgcolor="#f5f5f1">
                                                            <asp:TextBox runat="server" ID="txtCompany" ClientIDMode="Static" Width="100%"></asp:TextBox></td>
                                                    </tr>

                                                    <tr class="companyInfo">
                                                        <td bgcolor="#f9f9f0" align="center">经营地址</td>
                                                        <td colspan="5" bgcolor="#f5f5f1">
                                                            <asp:TextBox runat="server" ID="txtAddress" ClientIDMode="Static" Width="100%"></asp:TextBox></td>
                                                        <td bgcolor="#f9f9f0" align="center">邮编</td>
                                                        <td bgcolor="#f5f5f1">
                                                            <asp:TextBox runat="server" ID="txtCode" ClientIDMode="Static" Width="100%"></asp:TextBox></td>
                                                    </tr>
                                                    <tr class="companyInfo">
                                                        <td width="10%" bgcolor="#f9f9f0" align="center">联系人</td>
                                                        <td width="10%" bgcolor="#f5f5f1">
                                                            <asp:TextBox runat="server" ID="txtContact" ClientIDMode="Static" Width="100%"></asp:TextBox></td>
                                                        <td bgcolor="#f9f9f0" width="10%" align="center">固定电话</td>
                                                        <td bgcolor="#f5f5f1" width="12%">
                                                            <asp:TextBox runat="server" ID="txtPhone" ClientIDMode="Static" Width="100%"></asp:TextBox></td>
                                                        <td bgcolor="#f9f9f0" width="10%" align="center">移动电话</td>
                                                        <td bgcolor="#f5f5f1" width="18%">
                                                            <asp:TextBox runat="server" ID="txtMobile" ClientIDMode="Static" Width="100%"></asp:TextBox></td>
                                                        <td bgcolor="#f9f9f0" width="12%" align="center">传真</td>
                                                        <td bgcolor="#f5f5f1" width="18%">
                                                            <asp:TextBox runat="server" ID="txtFax" ClientIDMode="Static" Width="100%"></asp:TextBox></td>
                                                    </tr>

                                                    <tr class="companyInfo">
                                                        <td bgcolor="#f9f9f0" align="center">所属区域</td>
                                                        <td bgcolor="#f5f5f1">
                                                            <asp:DropDownList runat="server" ID="ddlAreaID" DataTextField="Name" DataValueField="ID"></asp:DropDownList></td>
                                                        <td bgcolor="#f9f9f0" align="center">法人代表</td>
                                                        <td bgcolor="#f5f5f1">
                                                            <asp:TextBox runat="server" ID="txtFrdb" ClientIDMode="Static" Width="100%"></asp:TextBox></td>
                                                        <td bgcolor="#f9f9f0" align="center">联系电话</td>
                                                        <td bgcolor="#f5f5f1">
                                                            <asp:TextBox runat="server" ID="txtFtel" ClientIDMode="Static" Width="100%"></asp:TextBox></td>
                                                        <td bgcolor="#f9f9f0" align="center">营业面积</td>
                                                        <td bgcolor="#f5f5f1">
                                                            <asp:TextBox runat="server" ID="txtArea" ClientIDMode="Static" Width="100%"></asp:TextBox></td>
                                                    </tr>

                                                    <tr class="companyInfo">
                                                        <td bgcolor="#f9f9f0" align="center">企业总人数</td>
                                                        <td bgcolor="#f5f5f1" colspan="2">
                                                            <asp:TextBox runat="server" ID="txtAnum" ClientIDMode="Static" Width="100%"></asp:TextBox></td>
                                                        <td bgcolor="#f9f9f0" align="center">维修人员人数</td>
                                                        <td bgcolor="#f5f5f1" colspan="2">
                                                            <asp:TextBox runat="server" ID="txtMnum" ClientIDMode="Static" Width="100%"></asp:TextBox></td>
                                                        <td bgcolor="#f9f9f0" align="center">安装人员人数</td>
                                                        <td bgcolor="#f5f5f1">
                                                            <asp:TextBox runat="server" ID="txtBnum" ClientIDMode="Static" Width="100%"></asp:TextBox></td>
                                                    </tr>
                                                    <asp:Panel ID="pnlSummary" runat="server">
                                                        <tr id="trSummary" class="companyInfo">
                                                            <%--<td colspan="8">
                                        <div class="row">
                                            <div class="form-group">
                                                <label class="col-xs-2 control-label ">企业总结</label>
                                                <div class="col-xs-10 ">
                                                    
                                                </div>
                                            </div>
                                        </div>
                                    </td>--%>

                                                            <td bgcolor="#f9f9f0" align="center">企业总结</td>
                                                            <td colspan="7" bgcolor="#f5f5f1">
                                                                <asp:TextBox runat="server" ID="txtSummary" ClientIDMode="Static" TextMode="MultiLine" Width="100%" Height="100"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </asp:Panel>
                                                </table>

                                            </div>
                                        </div>
                                    </div>

                                </td>
                            </tr>

                            <tr>

                                <td bgcolor="#f5f5f1" colspan="8">
                                    <div class="panel  panel-default ">
                                        <div class="panel-heading">
                                            <h3 class="panel-title">维修业务范围</h3>
                                        </div>
                                        <div class="panel-body">
                                            <div class="row">
                                                <div class="form-group">
                                                    <div for="tbxInstaller" class="col-xs-2 control-label">业务范围</div>
                                                    <div class="col-xs-4 ">
                                                        <table class="table-hover" id="tbFixBus">
                                                            <tbody>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="form-group">
                                                    <label class="col-xs-2"></label>
                                                    <div class="col-xs-6 ">
                                                        <select class="form-control" id="selFixBusType">
                                                            <option value="0">请选择类别</option>
                                                            <option value="8">A[安防设备]</option>
                                                            <option value="5">B[办公设备]</option>
                                                            <option value="12">J[教学仪器设备]</option>
                                                            <option value="7">J[计算机及外设]</option>
                                                            <option value="4">J[机电制冷设备]</option>
                                                            <option value="1">R[日用电器]</option>
                                                            <option value="11">T[通讯设备]</option>
                                                            <option value="6">W[网络设备]</option>
                                                            <option value="9">Z[照相摄影器材]</option>
                                                            <option value="abc">其他类</option>
                                                        </select>
                                                    </div>
                                                    <div class="col-xs-3">
                                                        <div class="btn btn-primary" id="btnAddFixBus">添加</div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="form-group ">
                                                    <div for="tbxInstaller" class="col-xs-2 control-label">特约品牌</div>
                                                    <div class="col-xs-4 ">
                                                        <table class="table-hover" id="tbFixBusName">
                                                            <tbody>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="form-group">
                                                    <label class="col-xs-2"></label>
                                                    <div class="col-xs-6 ">
                                                        <input type="text" class="form-control" id="tbxFixBusName" />
                                                    </div>
                                                    <div class="col-xs-3">
                                                        <div class="btn btn-primary" id="btnAddFixBusName">添加</div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </td>
                            </tr>






                            <tr>
                                <td colspan="8">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            人员状况
                        <div class="btn btn-info" id="btnShowdivPersonAdd" style="float: right; margin-right: 100px; padding: 2px 12px;">添加</div>
                                        </div>
                                        <div class="panel-body">
                                            <div class="row">
                                                <table class="table table-bordered table-hover" id="tbPesonInfo">
                                                    <thead>
                                                        <tr>
                                                            <th>人员类型</th>
                                                            <th>姓名</th>
                                                            <th>学历</th>
                                                            <th>岗位</th>
                                                            <th>证书名</th>
                                                            <th>证书编号</th>
                                                            <th>备注</th>
                                                            <th>操作</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                    </tbody>
                                                </table>
                                            </div>
                                            <div class="divPersonAdd" id="divPersonAdd" style="display: none">
                                                <div class="row">
                                                    <div class="form-group">
                                                        <div class="col-xs-2 control-label ">人员类型</div>
                                                        <div class="col-xs-8 ">
                                                            <div class="col-xs-6">
                                                                <label class="radio-inline">
                                                                    <input class="rdoPesonType" type="radio" name="userType" checked="checked" value="管理/专业技术人员">管理/专业技术人员
                                                                </label>
                                                            </div>
                                                            <div class="col-xs-6">
                                                                <label class="radio-inline">
                                                                    <input class="rdoPesonType" type="radio" name="userType" value="安装/维修人员">安装/维修人员
                                                                </label>
                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="form-group col-xs-6">
                                                        <div for="tbxName" class="col-xs-4 control-label">姓名</div>
                                                        <div class="col-xs-8">
                                                            <input type="text" class="form-control" id="tbxName" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group col-xs-6">
                                                        <div for="selEduLevel" class="col-xs-4 control-label">学历</div>
                                                        <div class="col-xs-8">
                                                            <select id="selEduLevel" class="form-control">
                                                                <option>博士后</option>
                                                                <option>博士</option>
                                                                <option>MBA/EMBA</option>
                                                                <option>硕士</option>
                                                                <option selected="selected">本科</option>
                                                                <option>大专</option>
                                                                <option>中专</option>
                                                                <option>中技</option>
                                                                <option>高中</option>
                                                                <option>初中</option>
                                                                <option>其他</option>
                                                            </select>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="form-group col-xs-6">
                                                        <div for="tbxPost" class="col-xs-4 control-label">岗位</div>
                                                        <div class="col-xs-8">
                                                            <input type="text" class="form-control" id="tbxPost" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group col-xs-6">
                                                        <div for="tbxCertName" class="col-xs-4 control-label">证书名</div>
                                                        <div class="col-xs-8 ">
                                                            <select class="form-control" id="tbxCertName">
                                                                <option value="0">请选择证书</option>
                                                                <option value="5">厂家上岗证书</option>
                                                                <option value="4">厂家培训证书</option>
                                                                <option value="3">劳动部门上岗证书</option>
                                                                <option value="2">劳动部门职业资格证书</option>
                                                                <option value="1">学历证书</option>
                                                                <option value="abc">其他证书</option>
                                                            </select>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="form-group col-xs-6">
                                                        <div for="tbxCertNo" class="col-xs-4 control-label">证书编号</div>
                                                        <div class="col-xs-8">
                                                            <input type="text" class="form-control" id="tbxCertNo" />
                                                        </div>
                                                    </div>

                                                </div>
                                                <div class="row">
                                                    <div class="form-group">
                                                        <div for="tbxMark" class="col-xs-2 control-label">备注</div>
                                                        <div class="col-xs-10">
                                                            <input type="text" class="form-control" id="tbxMark" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <p></p>
                                                    <div class="form-group">
                                                        <div class="col-sm-offset-3 col-sm-3">
                                                            <div class="btn btn-primary" id="btnAddPerson">
                                                                保存
                                                            </div>

                                                        </div>
                                                        <div class="col-sm-3">
                                                            <div class="btn btn-default" style="margin-left: 50px" id="btnAddPersonCancel">
                                                                取消
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr height="150">

                                <td colspan="8">
                                    <div class="panel panel-default ">
                                        <div class="panel-heading">
                                            维修安装作业设备<div class="btn btn-info" id="btnShowdivToolAdd" style="float: right; margin-right: 100px; padding: 2px 12px;">添加</div>
                                        </div>
                                        <div class="panel-body">
                                            <table class="table table-bordered table-hover" id="tbFixTool">
                                                <thead>
                                                    <tr>
                                                        <th style="width: 200px">设备类型</th>
                                                        <th>名称</th>
                                                        <th>型号</th>
                                                        <th>数量</th>
                                                        <th>管理</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                </tbody>
                                            </table>

                                            <div class="divToolAdd" id="divToolAdd" style="display: none">
                                                <div class="row">
                                                    <div class="form-group col-xs-6">
                                                        <div class="col-xs-4 control-label ">设备类型</div>
                                                        <div class="col-xs-8  ">
                                                            <div class="row">
                                                                <input class="rdoToolType" type="radio" name="toolType" checked="checked" value="1" title="交通工具">交通工具
                                                            </div>
                                                            <div class="row">
                                                                <input class="rdoToolType" type="radio" name="toolType" value="2" title="其它仪器">其它仪器
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="form-group col-xs-6">
                                                        <div for="tbxToolName" class="col-xs-4 control-label">设备名称</div>
                                                        <div class="col-xs-8 ">
                                                            <input type="text" class="form-control" id="tbxToolName" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">

                                                    <div class="form-group col-xs-6">
                                                        <div for="tbxToolNumber" class="col-xs-4 control-label">设备型号</div>
                                                        <div class="col-xs-8 ">
                                                            <input type="text" class="form-control" id="tbxToolNumber" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group col-xs-6">
                                                        <div for="tbxToolCount" class="col-xs-4 control-label">设备数量</div>
                                                        <div class="col-xs-8 ">
                                                            <input type="text" class="form-control" id="tbxToolCount" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <p></p>
                                                    <div class="form-group">
                                                        <div class="col-sm-offset-3 col-sm-3">
                                                            <div class="btn btn-primary" id="btnToolAdd">
                                                                保存
                                                            </div>

                                                        </div>
                                                        <div class="col-sm-3">
                                                            <div class="btn btn-default" style="margin-left: 50px" id="btnAddToolAddCancel">
                                                                取消
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="8">
                                    <div class="panel panel-default ">
                                        <div class="panel-heading">
                                            <h3 class="panel-title">送审资料</h3>
                                        </div>
                                        <div class="panel-body">
                                            <table class="table" id="tbDocumInfo">
                                                <tr>
                                                    <th>序号</th>
                                                    <th>目录</th>
                                                    <th>份数</th>
                                                </tr>
                                                <tr>
                                                    <td>1
                                                    </td>
                                                    <td>企业营业执照复印件
                                                    </td>
                                                    <td>
                                                        <input type="text" value="0" id="file1" runat="server" />
                                                        <%--<input type="text" value="0" id="num1" onmouseout="Cert.SaveDocumInfo($(this))" />--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>2
                                                    </td>
                                                    <td>企业维修人员相关资职证书复印件
                                                    </td>
                                                    <td><input type="text" value="0" id="file2" runat="server" />
                                                        <%--<input type="text" value="0" id="num2" onmouseout="Cert.SaveDocumInfo($(this))" />--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>3
                                                    </td>
                                                    <td>对顾客明示的服务承诺具体条文
                                                    </td>
                                                    <td>
                                                        <input type="text" value="0" id="file3" runat="server" />
                                                      <%--  <input type="text" value="0" id="num3" onmouseout="Cert.SaveDocumInfo($(this))" />--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>4 
                                                    </td>
                                                    <td>企业内部管理制度
                                                    </td>
                                                    <td>
                                                        <input type="text" value="0" id="file4" runat="server" />
                                                        <%--<input type="text" value="0" id="num4" onmouseout="Cert.SaveDocumInfo($(this))" />--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>5
                                                    </td>
                                                    <td>维修单据样本（合同）
                                                    </td>
                                                    <td>
                                                        <input type="text" value="0" id="file5" runat="server" />
                                                        <%--<input type="text" value="0" id="num5" onmouseout="Cert.SaveDocumInfo($(this))" />--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>6
                                                    </td>
                                                    <td>其它资料
                                                    </td>
                                                    <td>
                                                        <input type="text" value="0" id="file6" runat="server" />
                                                        <%--<input type="text" value="0" id="num6" onmouseout="Cert.SaveDocumInfo($(this))" />--%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label runat="server" Text="需要添加的数据请确保添加成功，*号项为必填项，请填写完整再进行提交！" CssClass="text-star-12"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr class="saveZone">
                    <td align="center">
                        <asp:Button ID="btnSum" runat="server" Text="提 交" OnClick="btnSum_Click" />
                        <asp:Button ID="btnOK" runat="server" Text="保 存" OnClick="btnOK_Click" />
                        <input type="button" value="打 印" onclick="OpenPrint('<%=lblID.Text %>    ')" />
                        <asp:Button ID="btnBack" Visible="false" runat="server" Text="返 回" OnClick="btnBack_Click" /></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <img src="../img/intro_body_6.gif" width="725" height="10"></td>
    </tr>
</table>

<div style="display: none">
    <%--status:编辑、已审批--%>
    <div id="status">
        <asp:Literal runat="server" ID="litStatus"></asp:Literal>
    </div>
    <div id="applyNo">
        <asp:Literal runat="server" ID="litApplyNo"></asp:Literal>
    </div>

    <div id="tbxApplyID">
        <asp:Label runat="server" ID="ApplyID"></asp:Label>
    </div>
    <div id="oldCertNO"></div>
</div>
