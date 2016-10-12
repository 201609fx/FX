<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CertApply.ascx.cs" Inherits="Cert_CertApply" %>
<%--<link href="../public/bootstrap3.3.5/css/bootstrap.css" rel="stylesheet" />--%>
<link href="../public/font-awesome-4.4.0/css/font-awesome.css" rel="stylesheet" />
<script src="../public/jquery1.11.3/jquery1.11.3.min.js"></script>
<script src="../public/bootstrap3.3.5/js/bootstrap.js"></script>

<style>
    .tbx{
        width:100%;
    }
    .number{
        width:50px;
    }
    .column{
        width:120px;
    }
</style>

<div>
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
            <td>
                <table width="725" border="0" align="right" cellpadding="0" cellspacing="0">
                    <tr>
                        <%--企业基本信息--%>
                        <td>
                            <table style="width: 100%">
                                <tr>
                                    <td class="column">企业名称(全称)</td>
                                    <td colspan="5">
                                        <input type="text" class="tbx"  id="tbxCommanyName" /></td>
                                </tr>
                                <tr>
                                    <td class="column">经营地址</td>
                                    <td colspan="5"><input type="text" class="tbx" id="tbxAddress" /></td>
                                </tr>
                                <tr>
                                    <td class="column">联系人</td>
                                    <td ><input type="text" class="tbx" id="tbxContentPerson" /></td>
                                    <td class="column">固定电话</td>
                                    <td><input type="text" class="tbx" id="tbxPhoneNo" /></td>
                                    <td class="column">移动电话</td>
                                    <td><input type="text" class="tbx" id="tbxTelNo" /></td>
                                </tr>
                                <tr>
                                    <td class="column">邮编</td>
                                    <td ><input type="text" class="tbx" id="tbxCodeNo" /></td>
                                    <td class="column">传真</td>
                                    <td colspan="3"><input type="text" class="tbx" id="tbxFaxNo" /></td>
                                </tr>
                                <tr>
                                    <td>所属区域</td>
                                    <td>
                                       <%--<asp:DropDownList runat="server" ID="ddlAreaID" DataTextField="Name" DataValueField="ID"></asp:DropDownList>--%>
                                    </td>
                                    <td>营业面积</td>
                                    <td><input type="text" class="tbx number" id="tbxAllArea" /></td>
                                    <td>企业总人数</td>
                                    <td><input type="text" class="tbx number" id="tbxAllPerson" /></td>
                                </tr>
                                <tr>
                                    <td>法人代表</td>
                                    <td><input type="text" class="tbx" id="tbxOwner" /></td>
                                    <td>联系电话</td>
                                    <td colspan="3"><input type="text" class="tbx" id="tbxOwnerNo" /></td>
                                </tr>
                                <tr>
                                    <td>维修人员人数</td>
                                    <td><input type="text" class="tbx number" id="tbxFixer" /></td>
                                    <td>安装人员人数</td>
                                    <td colspan="3"><input type="text"  class="tbx number" id="tbxInstaller" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5"></td>
                    </tr>
                    <tr>
                        <td colspan="5">维修业务范围</td>
                    </tr>
                    <tr>
                        <%--维修业务范围--%>
                        <td colspan="5">
                            <table style="width:100%">
                                <tr>
                                    <td>维修业务</td>
                                    <td>操作</td>
                                </tr>
                                <tr>
                                    <td>选择维修业务</td>
                                    <td><input type="button" id="btnAddFixBusiness" value="添加" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                           <label> <input type="checkbox"   checked="checked" />有特约维修业务</label>
                        </td>
                    </tr>
                    <tr>
                        <%--有特约维修业务--%>
                        <td colspan="5">
                            <table style="width:100%">
                                <tr>
                                    <td>特约维修业务品牌</td>
                                    <td>操作</td>
                                </tr>
                                <tr>
                                    <td><input type="text" class="tbx tnxSpecial" /></td>
                                    <td><input type="button" id="btnAddSpecial" value="添加" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="5">
                           <label>管理人员/专业技术人员状况</label>
                        </td>
                    </tr>
                    <tr>
                        <%--管理人员/专业技术人员状况--%>
                        <td colspan="5">
                            <table style="width:100%">
                                <tr>
                                    <td>姓名</td>
                                    <td>学历</td>
                                    <td>岗位</td>
                                    <td>证书名</td>
                                    <td>证书编号</td>
                                    <td>备注</td>
                                    <td>操作</td>
                                </tr>
                                <tr>
                                    <td><input type="text" class="tbx mgName"  /></td>
                                    <td><input type="text" class="tbx mgEdu" /></td>
                                    <td><input type="text" class="tbx mgPost" /></td>
                                    <td><select class="tbx mgCert"></select></td>
                                    <td><input type="text" class="tbx mgCertNo" /></td>
                                    <td><input type="text" class="tbx mgMark" /></td>
                                    <td><input type="button" id="btnAddManager" value="添加" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                     <tr>
                        <td colspan="5">
                           <label>安装/维修人员状况</label>
                        </td>
                    </tr>
                    <tr>
                        <%--安装/维修人员状况--%>
                        <td colspan="5">
                            <table style="width:100%">
                                <tr>
                                    <td>姓名</td>
                                    <td>学历</td>
                                    <td>岗位</td>
                                    <td>证书名</td>
                                    <td>证书编号</td>
                                    <td>备注</td>
                                    <td>操作</td>
                                </tr>
                                <tr>
                                    <td><input type="text" class="tbx mgName"  /></td>
                                    <td><input type="text" class="tbx mgEdu" /></td>
                                    <td><input type="text" class="tbx mgPost" /></td>
                                    <td><select class="tbx mgCert"></select></td>
                                    <td><input type="text" class="tbx mgCertNo" /></td>
                                    <td><input type="text" class="tbx mgMark" /></td>
                                    <td><input type="button" id="btnAddManager" value="添加" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <asp:Label runat="server" ID="lblID" Visible="false"></asp:Label>
</div>

<div style="display: none">
    <div id="applyNo">
        <asp:Literal runat="server" ID="litApplyNo"></asp:Literal>
    </div>
</div>
