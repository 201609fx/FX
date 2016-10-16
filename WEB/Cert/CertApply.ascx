<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CertApply.ascx.cs" Inherits="Cert_CertApply" %>
<link href="../public/bootstrap3.3.5/css/bootstrap.css" rel="stylesheet" />
<link href="../public/font-awesome-4.4.0/css/font-awesome.css" rel="stylesheet" />
<script src="../public/jquery1.11.3/jquery1.11.3.min.js"></script>
<script src="../public/bootstrap3.3.5/js/bootstrap.js"></script>

<script src="../jscript/CretForm.js"></script>

<style>
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
    }
</style>
<div class="certForm" id="certForm">
    <div class="row ">
        <div class="col-md-12">
            <table width="725" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="13">
                        <img src="../images/lb6.gif" width="13" height="32" /></td>
                    <td width="150" background="../images/lb7.gif" class="text-bla-b-14">
                        <asp:Label runat="server" ID="lblSortName">初次申请</asp:Label></td>
                    <td align="right" background="../images/lb7.gif" class="text-hui-12">首页 >>  证书办理</td>
                    <td width="13">
                        <img src="../images/lb8.gif" width="13" height="32" /></td>
                </tr>
            </table>
        </div>
    </div>

    <div class="row clearfix">
        <div class="col-md-12 column">
            <div class="form-horizontal" role="form">

                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">企业基本信息</h3>
                    </div>
                    <div class="panel-body">

                        <div class="form-group">
                            <label for="tbxCommanyName" class="col-xs-3 control-label">企业名称(全称)</label>
                            <div class="col-xs-9">
                                <input type="text" class="form-control" id="tbxCommanyName" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="tbxAddress" class="col-xs-3 control-label">经营地址</label>
                            <div class="col-xs-9 ">
                                <input type="text" class="form-control" id="tbxAddress" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="tbxContentPerson" class="col-xs-3 control-label">联系人</label>
                            <div class="col-xs-4 ">
                                <input type="text" class="form-control" id="tbxContentPerson" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="tbxPhoneNo" class="col-xs-3 control-label">固定电话</label>
                            <div class="col-xs-4 ">
                                <input type="text" class="form-control" id="tbxPhoneNo" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="tbxTelNo" class="col-xs-3 control-label">移动电话</label>
                            <div class="col-xs-4 ">
                                <input type="text" class="form-control" id="tbxTelNo" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="tbxCodeNo" class="col-xs-3 control-label">邮编</label>
                            <div class="col-xs-4 ">
                                <input type="text" class="form-control" id="tbxCodeNo" />
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="tbxFaxNo" class="col-xs-3 control-label">传真</label>
                            <div class="col-xs-4 ">
                                <input type="text" class="form-control" id="tbxFaxNo" />
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-xs-3 control-label ">所属区域</label>
                            <div class="col-xs-4 row">
                                <select class="form-control">
                                    <option value="福田">福田</option>
                                    <option value="罗湖">罗湖</option>
                                    <option value="南山">南山</option>
                                    <option value="龙岗">龙岗</option>
                                    <option value="宝安">宝安</option>
                                    <option value="盐田">盐田</option>
                                    <option value="光明新区">光明新区</option>
                                    <option value="坪山新区">坪山新区</option>
                                    <option value="大鹏新区">大鹏新区</option>
                                    <option value="龙华新区">龙华新区</option>
                                </select>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="tbxAllArea" class="col-xs-3 control-label">营业面积</label>
                            <div class="col-xs-4 ">
                                <input type="text" class="form-control" id="tbxAllArea" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="tbxAllPerson" class="col-xs-3 control-label">企业总人数</label>
                            <div class="col-xs-4 ">
                                <input type="text" class="form-control" id="tbxAllPerson" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="tbxOwner" class="col-xs-3 control-label">法人代表</label>
                            <div class="col-xs-4 ">
                                <input type="text" class="form-control" id="tbxOwner" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="tbxOwnerNo" class="col-xs-3 control-label">联系电话</label>
                            <div class="col-xs-4 ">
                                <input type="text" class="form-control" id="tbxOwnerNo" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="tbxFixer" class="col-xs-3 control-label">维修人员人数</label>
                            <div class="col-xs-4 ">
                                <input type="text" class="form-control" id="tbxFixer" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="tbxInstaller" class="col-xs-3 control-label">安装人员人数</label>
                            <div class="col-xs-4 ">
                                <input type="text" class="form-control" id="tbxInstaller" />
                            </div>
                        </div>
                    </div>
                </div>

                <div class="panel  panel-default ">
                    <div class="panel-heading">
                        <h3 class="panel-title">维修业务范围</h3>
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <label for="tbxInstaller" class="col-xs-3 control-label">维修业务类型范围</label>
                            <div class="col-xs-4 ">
                                <table class="table table-bordered table-hover" id="tbFixBus">
                                    <tbody>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="tbxInstaller" class="col-xs-3 control-label"></label>
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



                        <div class="form-group">
                            <label for="tbxInstaller" class="col-xs-3 control-label">特约维修业务品牌</label>
                            <div class="col-xs-4 ">
                                <table class="table table-bordered table-hover" id="tbFixBusName">
                                    <tbody>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="tbxInstaller" class="col-xs-3 control-label"></label>
                            <div class="col-xs-6 ">
                                <input type="text" class="form-control" id="tbxFixBusName" />
                            </div>
                            <div class="col-xs-3">
                                <div class="btn btn-primary" id="btnAddFixBusName">添加</div>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        人员状况
                        <div class="btn btn-info" id="btnShowdivPersonAdd" style="float: right; margin-right: 100px; padding: 2px 12px;">添加</div>
                    </div>
                    <div class="panel-body">
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

                        <div class="divPersonAdd" id="divPersonAdd" style="display: none">

                            <div class="form-group">
                                <label class="col-xs-2 control-label ">人员类型</label>
                                <div class="col-xs-10 row ">
                                    <label class="radio-inline">
                                        <input class="rdoPesonType" type="radio" name="userType" checked="checked" value="管理/专业技术人员">管理/专业技术人员
                                    </label>
                                    <label class="radio-inline">
                                        <input class="rdoPesonType" type="radio" name="userType" value="安装/维修人员">安装/维修人员
                                    </label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="tbxMgName" class="col-xs-2 control-label">姓名</label>
                                <div class="col-xs-4 ">
                                    <input type="text" class="form-control" id="tbxName" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="tbxInstaller" class="col-xs-2 control-label">学历</label>
                                <div class="col-xs-4 ">
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
                            <div class="form-group">
                                <label for="tbxInstaller" class="col-xs-2 control-label">岗位</label>
                                <div class="col-xs-4 ">
                                    <input type="text" class="form-control" id="tbxPost" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="tbxInstaller" class="col-xs-2 control-label">证书名</label>
                                <div class="col-xs-4 ">
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
                            <div class="form-group">
                                <label for="tbxInstaller" class="col-xs-2 control-label">证书编号</label>
                                <div class="col-xs-4 ">
                                    <input type="text" class="form-control" id="tbxCertNo" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="tbxInstaller" class="col-xs-2 control-label">备注</label>
                                <div class="col-xs-4 ">
                                    <input type="text" class="form-control" id="tbxMark" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-offset-2 col-sm-10">
                                    <div class="btn btn-primary" id="btnAddPerson">
                                        保存
                                    </div>
                                    <div class="btn btn-default" style="margin-left: 50px" id="btnAddPersonCancel">
                                        取消
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>

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

                        <div class="divToolAdd" id="divToolAdd" style="display:none">

                            <div class="form-group">
                                <label class="col-xs-2 control-label ">设备类型</label>
                                <div class="col-xs-10 row ">
                                    <label class="radio-inline">
                                        <input class="rdoToolType" type="radio" name="toolType" checked="checked" value="交通工具">交通工具
                                    </label>
                                    <label class="radio-inline">
                                        <input class="rdoToolType" type="radio" name="toolType" value="其它仪器">其它仪器
                                    </label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="tbxToolName" class="col-xs-2 control-label">设备名称</label>
                                <div class="col-xs-4 ">
                                    <input type="text" class="form-control" id="tbxToolName" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="tbxToolNumber" class="col-xs-2 control-label">设备型号</label>
                                <div class="col-xs-4 ">
                                    <input type="text" class="form-control" id="tbxToolNumber" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="tbxToolCount" class="col-xs-2 control-label">设备数量</label>
                                <div class="col-xs-4 ">
                                    <input type="text" class="form-control" id="tbxToolCount" />
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-sm-offset-2 col-sm-10">
                                    <div class="btn btn-primary" id="btnToolAdd">
                                          保存
                                    </div>
                                    <div class="btn btn-default" style="margin-left: 50px" id="btnAddToolAddCancel">
                                        取消
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

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
                                    <input type="text" value="0" id="gvCSFile_ctl02_txtNum" />
                                </td>
                            </tr>
                            <tr>
                                <td>2
                                </td>
                                <td>企业维修人员相关资职证书复印件
                                </td>
                                <td>
                                    <input type="text" value="0" id="gvCSFile_ctl03_txtNum" />
                                </td>
                            </tr>
                            <tr>
                                <td>3
                                </td>
                                <td>对顾客明示的服务承诺具体条文
                                </td>
                                <td>
                                    <input type="text" value="0" id="gvCSFile_ctl04_txtNum" />
                                </td>
                            </tr>
                            <tr>
                                <td>4
                                </td>
                                <td>企业内部管理制度
                                </td>
                                <td>
                                    <input type="text" value="0" id="gvCSFile_ctl05_txtNum" />
                                </td>
                            </tr>
                            <tr>
                                <td>5
                                </td>
                                <td>维修单据样本（合同）
                                </td>
                                <td>
                                    <input type="text" value="0" id="gvCSFile_ctl06_txtNum" />
                                </td>
                            </tr>
                            <tr>
                                <td>6
                                </td>
                                <td>其它资料
                                </td>
                                <td>
                                    <input type="text" value="0" id="gvCSFile_ctl07_txtNum" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-xs-2 "></label>
                    <div class="col-xs-4 sub-btn row">
                        <div class="btn btn-primary" type="submit">提交</div>
                        <div class="btn btn-default" type="submit">保存</div>
                        <div class="btn btn-default" type="submit">打印</div>
                    </div>
                </div>
            </div>
        </div>
    </div>



    <div style="display: none">
        <div id="applyNo">
            <asp:Literal runat="server" ID="litApplyNo"></asp:Literal>
        </div>
        <asp:Label runat="server" ID="lblID" Visible="false"></asp:Label>
    </div>
</div>
