
var Cert = new Object();
Cert._tbFixBus;//维修业务范围Table对象
Cert._tbFixBusName;//特约维修业务品牌Table对象
Cert._tbPesonInfo;//人员信息
Cert._tbFixTool;//维修安装设备
Cert._tbDocumInfo;//送审资料信息
Cert._ID;//申请单ID
Cert._ajaxUrl = "/service/command.aspx";

//验证是否为null
Cert.checkEmptyOrNull = function (str) {
    if (str && str.trim().length > 0) {
        return true;
    } else {
        return false;
    }
}
//验证是否为数字
Cert.checkIsNumber = function (str) {
    if (!str) {
        return false;
    }
    var reg = new RegExp("^[0-9]*$");
    if (!reg.test(str)) {
        return false;
    }
    return true;
}

Cert.getQueryParameter = function (paramToRetrieve) { var params = document.URL.split("?")[1].split("&"); var strParams = ""; for (var i = 0; i < params.length; i = i + 1) { var singleParam = params[i].split("="); if (singleParam[0] == paramToRetrieve) return singleParam[1]; } }



//前端添加数据到 维修业务范围table
Cert.addFrontFixBus = function () {
    var busType = $("#selFixBusType option:selected").text().trim();
    var busTypeID = $("#selFixBusType option:selected").val().trim();
    if (busType == "请选择类别") {
        alert("未选择\"维修业务类型范围\"");
        return;
    }

    //检测行是否已存在
    var trs = Cert._tbFixBus.find("tr");
    for (var i = 0; i < trs.length; i++) {
        var tr = trs.eq(i);
        if (tr.find("td").eq(0).text().trim() == busType || tr.find("td").eq(0).attr("title") == busTypeID) {
            alert("该类型已添加.");
            return;
        }
    }
    var busTypeId = $("#selFixBusType option:selected").val().trim();

    $.ajax({
        type: "post",
        url: Cert._ajaxUrl,
        cache: false,
        timeout: 60000,
        data: { cmd: "addBusType", id: Cert._ID, busTypeId: busTypeId },
        dataType: "text",
        success: function (data) {
            if (data) {
                if (data.split('#')[0] == "0") {
                    var tbody = Cert._tbFixBus.find("tbody").eq(0);
                    var htmlStr = tbody.html();
                    htmlStr += "<tr><td title='" + busTypeId + "'>" + busType + "</td><td><div class='btn btn-default btnDelBusType' onclick='Cert.delBusType($(this))'>删除</div></td></tr>";
                    tbody.html(htmlStr);
                } else {
                    alert("添加失败");
                }
            } else {
                alert("请求发生错误,请重试.");
            }
        },
        error: function () {
            if (console) {
                alert("请求发生错误");
            } else {
                alert("请求发生错误");
            }
        }
    });
}

Cert.delBusType = function (vThis) {
    var busTypeId = vThis.closest("tr").find("td").eq('0').attr("title");
    $.ajax({
        type: "post",
        url: Cert._ajaxUrl,
        cache: false,
        timeout: 60000,
        data: { cmd: "delBusType", id: Cert._ID, busTypeId: busTypeId },
        dataType: "text",
        success: function (data) {
            if (data) {
                if (data.split('#')[0] == "0") {
                    vThis.closest("tr").remove();
                } else {
                    alert("删除失败");
                }
            } else {
                alert("请求发生错误,请重试.");
            }
        },
        error: function () {
            if (console) {
                alert("请求发生错误");
            } else {
                alert("请求发生错误");
            }
        }
    });
}

Cert.getFixBusType = function () {
    $.ajax({
        type: "get",
        url: Cert._ajaxUrl,
        cache: false,
        timeout: 60000,
        data: { cmd: "getBusType", id: Cert._ID },
        dataType: "text",
        success: function (data) {
            if (data && data.trim() != "[]") {
                var jsonData = JSON.parse(data);
                if (jsonData.length > 0) {
                    var tbody = Cert._tbFixBus.find("tbody").eq(0);
                    var htmlStr = tbody.html();
                    for (var i = 0; i < jsonData.length; i++) {
                        var o = jsonData[i];
                        htmlStr += "<tr><td title='" + o.ProductID + "'>" + o.ProductName + "</td><td><div class='btn btn-default btnDelBusType' onclick='Cert.delBusType($(this))'>删除</div></td></tr>";
                    }
                    tbody.html(htmlStr);
                    Cert.disabledEdit();
                }
            } else {
                // alert("请求发生错误,请重试."); 没有数据
            }
        },
        error: function () {
        }
    });
}


//前端添加数据到 特约维修业务品牌table
Cert.addFrontFixBusName = function () {
    var busName = $("#tbxFixBusName").val();
    if (busName && busName.length > 0) {
        busName.trim();
    } else {
        alert("未输入\"特约维修业务品牌\"");
        return
    }

    //检测行是否已存在
    var trs = Cert._tbFixBusName.find("tr");
    for (var i = 0; i < trs.length; i++) {
        var tr = trs.eq(i);
        if (tr.find("td").eq(0).text().trim() == busName) {
            alert("该品牌已添加.");
            return;
        }
    }

    $.ajax({
        type: "post",
        url: Cert._ajaxUrl,
        cache: false,
        timeout: 60000,
        data: { cmd: "addBusName", id: Cert._ID, busName: busName },
        dataType: "text",
        success: function (data) {
            if (data) {
                if (data.split('#')[0] == "0") {
                    var tbody = Cert._tbFixBusName.find("tbody").eq(0);
                    var htmlStr = tbody.html();
                    htmlStr += "<tr><td>" + busName + "</td><td><div class='btn btn-default btnDelBusName' onclick='Cert.delBusName($(this))'>删除</div></td></tr>";
                    tbody.html(htmlStr);
                } else {
                    alert("添加失败");
                }
            } else {
                alert("请求发生错误,请重试.");
            }
        },
        error: function () {
            if (console) {
                alert("请求发生错误");
            } else {
                alert("请求发生错误");
            }
        }
    });
}

Cert.delBusName = function (vThis) {
    var busName = vThis.closest("tr").find("td").eq('0').text().trim();
    $.ajax({
        type: "post",
        url: Cert._ajaxUrl,
        cache: false,
        timeout: 60000,
        data: { cmd: "delBusName", id: Cert._ID, busName: busName },
        dataType: "text",
        success: function (data) {
            if (data) {
                if (data.split('#')[0] == "0") {
                    vThis.closest("tr").remove();
                } else {
                    alert("删除失败");
                }
            } else {
                alert("请求发生错误,请重试.");
            }
        },
        error: function () {
            if (console) {
                alert("请求发生错误");
            } else {
                alert("请求发生错误");
            }
        }
    });
}

Cert.getFixBusName = function () {
    $.ajax({
        type: "get",
        url: Cert._ajaxUrl,
        cache: false,
        timeout: 60000,
        data: { cmd: "getBusName", id: Cert._ID },
        dataType: "text",
        success: function (data) {
            if (data && data.trim() != "[]") {
                var jsonData = JSON.parse(data);
                if (jsonData.length > 0) {
                    var tbody = Cert._tbFixBusName.find("tbody").eq(0);
                    var htmlStr = tbody.html();
                    for (var i = 0; i < jsonData.length; i++) {
                        var o = jsonData[i];
                        htmlStr += "<tr><td>" + o.brand + "</td><td><div class='btn btn-default btnDelBusName' onclick='Cert.delBusName($(this))'>删除</div></td></tr>";
                    }
                    tbody.html(htmlStr);
                    Cert.disabledEdit();
                }
            } else {
                // alert("请求发生错误,请重试."); 没有数据
            }
        },
        error: function () {
        }
    });
}


//前端添加数据到 人员信息table
Cert.addFrontPesonInfos = function () {
    var personType = $(".rdoPesonType:checked").val();
    var personTypeId = 1;
    if (personType == "管理/专业技术人员") {
        personTypeId = 2;
    }

    var name = $("#tbxName").val().trim();
    var eduLevel = $("#selEduLevel option:selected").text().trim();
    var post = $("#tbxPost").val().trim();
    var certName = $("#tbxCertName option:selected").text().trim();
    var certNameVal = $("#tbxCertName option:selected").val().trim();
    var certNo = $("#tbxCertNo").val().trim();
    var mark = $("#tbxMark").val().trim();

    var markDisplay = mark;
    if (mark && mark.length > 3) {
        markDisplay = mark.substring(0, 3) + "..";
    }

    var erreMsg = "";
    if (!Cert.checkEmptyOrNull(personType)) {
        erreMsg += "人员类型;\n"
    }
    if (!Cert.checkEmptyOrNull(name)) {
        erreMsg += "姓名;\n"
    }
    if (!Cert.checkEmptyOrNull(eduLevel)) {
        erreMsg += "学历;\n"
    }
    if (!Cert.checkEmptyOrNull(post)) {
        erreMsg += "岗位;\n"
    }
    if (!Cert.checkEmptyOrNull(certName) || certName == "请选择证书") {
        erreMsg += "证书名称;\n"
    }
    if (!Cert.checkEmptyOrNull(certNo)) {
        erreMsg += "证书编号;\n"
    }
    if (Cert.checkEmptyOrNull(erreMsg)) {
        alert("以下信息输入不正确：\n" + erreMsg);
        return;
    }

    //检测行是否已存在
    var trs = Cert._tbPesonInfo.find("tr");
    for (var i = 0; i < trs.length; i++) {
        var tr = trs.eq(i);
        if (tr.find("td").eq(1).text().trim() == name) {
            alert("该用户已添加.");
            return;
        }
    }

    $.ajax({
        type: "post",
        url: Cert._ajaxUrl,
        cache: false,
        timeout: 60000,
        data: { cmd: "addPerson", id: Cert._ID, personTypeId: personTypeId, name: name, eduLevel: eduLevel, post: post, certName: certName, certNo: certNo, mark: mark },
        dataType: "text",
        success: function (data) {
            if (data) {
                if (data.split('#')[0] == "0") {
                    var rowStr = "<tr>";
                    rowStr += "<td title='" + personTypeId + "'>" + personType + "</td>";
                    rowStr += "<td title='" + name + "'>" + name + "</td>";
                    rowStr += "<td title='" + eduLevel + "'>" + eduLevel + "</td>";
                    rowStr += "<td title='" + post + "'>" + post + "</td>";
                    rowStr += "<td title='" + certNameVal + "'>" + certName + "</td>";
                    rowStr += "<td title='" + certNo + "'>" + certNo + "</td>";
                    rowStr += "<td title='" + mark + "'>" + markDisplay + "</td>";
                    rowStr += "<td><div class='btn btn-default btnDelPerson' onclick='Cert.delPerson($(this))'>删除</div></td>";
                    rowStr += "</tr>";
                    var tbody = Cert._tbPesonInfo.find("tbody").eq(0);
                    var htmlStr = tbody.html();
                    htmlStr += rowStr;
                    tbody.html(htmlStr);
                } else {
                    alert("添加失败,\n" + data.split('#')[1]);
                }
            } else {
                alert("请求发生错误,请重试.");
            }
        },
        error: function () {
            if (console) {
                alert("请求发生错误");
            } else {
                alert("请求发生错误");
            }
        }
    });
}
Cert.delPerson = function (vThis) {
    var personTypeId = vThis.closest("tr").find("td").eq('0').attr("title").trim();
    var name = vThis.closest("tr").find("td").eq('1').attr("title").trim();
    var eduLevel = vThis.closest("tr").find("td").eq('2').attr("title").trim();
    var post = vThis.closest("tr").find("td").eq('3').attr("title").trim();
    var certName = vThis.closest("tr").find("td").eq('4').attr("title").trim();
    var certNo = vThis.closest("tr").find("td").eq('5').attr("title").trim();
    $.ajax({
        type: "post",
        url: Cert._ajaxUrl,
        cache: false,
        timeout: 60000,
        data: { cmd: "delPerson", id: Cert._ID, personTypeId: personTypeId, name: name, eduLevel: eduLevel, post: post, certName: certName, certNo: certNo },
        dataType: "text",
        success: function (data) {
            if (data) {
                if (data.split('#')[0] == "0") {
                    vThis.closest("tr").remove();
                } else {
                    alert("删除失败");
                }
            } else {
                alert("请求发生错误,请重试.");
            }
        },
        error: function () {
            if (console) {
                alert("请求发生错误");
            } else {
                alert("请求发生错误");
            }
        }
    });
}
Cert.getPersonInfos = function () {
    $.ajax({
        type: "get",
        url: Cert._ajaxUrl,
        cache: false,
        timeout: 60000,
        data: { cmd: "getPerson", id: Cert._ID, personTypeId: "1" },
        dataType: "text",
        success: function (data) {
            if (data && data.trim() != "[]") {
                var jsonData = JSON.parse(data);
                if (jsonData.length > 0) {
                    var tbody = Cert._tbPesonInfo.find("tbody").eq(0);
                    var htmlStr = tbody.html();
                    for (var i = 0; i < jsonData.length; i++) {
                        var o = jsonData[i];
                        var markDisplay = o.remark;
                        if (o.remark && o.remark.length > 3) {
                            markDisplay = o.remark.substring(0, 3) + "..";
                        }
                        console.log(markDisplay);

                        var rowStr = "<tr>";
                        rowStr += "<td title='1'>管理/专业技术人员</td>";
                        rowStr += "<td title='" + o.Name + "'>" + o.Name + "</td>";
                        rowStr += "<td title='" + o.educational + "'>" + o.educational + "</td>";
                        rowStr += "<td title='" + o.Eposition + "'>" + o.Eposition + "</td>";
                        rowStr += "<td title='" + o.CertType + "'>" + o.CertName + "</td>";
                        rowStr += "<td title='" + o.certNO + "'>" + o.certNO + "</td>";
                        rowStr += "<td title='" + o.remark + "'>" + markDisplay + "</td>";
                        rowStr += "<td><div class='btn btn-default btnDelPerson' onclick='Cert.delPerson($(this))'>删除</div></td>";
                        rowStr += "</tr>";
                        htmlStr += rowStr;
                    }
                    tbody.html(htmlStr);
                    Cert.disabledEdit();
                }
            } else {
                // alert("请求发生错误,请重试."); 没有数据
            }
        },
        error: function () {
        }
    });
    $.ajax({
        type: "get",
        url: Cert._ajaxUrl,
        cache: false,
        timeout: 60000,
        data: { cmd: "getPerson", id: Cert._ID, personTypeId: "2" },
        dataType: "text",
        success: function (data) {
            if (data && data.trim() != "[]") {
                var jsonData = JSON.parse(data);
                if (jsonData.length > 0) {
                    var tbody = Cert._tbPesonInfo.find("tbody").eq(0);
                    var htmlStr = tbody.html();
                    for (var i = 0; i < jsonData.length; i++) {
                        var o = jsonData[i];
                        var markDisplay = o.remark;
                        if (o.remark && o.remark.length > 3) {
                            markDisplay = o.remark.substring(0, 3) + "..";
                        }

                        var rowStr = "<tr>";
                        rowStr += "<td title='2'>安装/维修人员</td>";
                        rowStr += "<td title='" + o.Name + "'>" + o.Name + "</td>";
                        rowStr += "<td title='" + o.educational + "'>" + o.educational + "</td>";
                        rowStr += "<td title='" + o.Eposition + "'>" + o.Eposition + "</td>";
                        rowStr += "<td title='" + o.CertType + "'>" + o.CertName + "</td>";
                        rowStr += "<td title='" + o.certNO + "'>" + o.certNO + "</td>";
                        rowStr += "<td title='" + o.remark + "'>" + markDisplay + "</td>";
                        rowStr += "<td><div class='btn btn-default btnDelPerson' onclick='Cert.delPerson($(this))'>删除</div></td>";
                        rowStr += "</tr>";
                        htmlStr += rowStr;
                    }
                    tbody.html(htmlStr);
                    Cert.disabledEdit();
                }
            } else {
                // alert("请求发生错误,请重试."); 没有数据
            }
        },
        error: function () {
        }
    });
}


//前端添加数据到 维修安装设备table
Cert.addFrontFixTool = function () {
    var toolType = $(".rdoToolType:checked").val();
    var toolTypeName = $(".rdoToolType:checked").attr("title").trim();
    var toolName = $("#tbxToolName").val().trim();
    var toolNumber = $("#tbxToolNumber").val().trim();
    var toolCount = $("#tbxToolCount").val().trim();

    var erreMsg = "";
    if (!Cert.checkEmptyOrNull(toolTypeName)) {
        erreMsg += "设备类型;\n"
    }
    if (!Cert.checkEmptyOrNull(toolName)) {
        erreMsg += "设备名称;\n"
    }
    if (!Cert.checkEmptyOrNull(toolNumber)) {
        erreMsg += "设备型号;\n"
    }
    if (!Cert.checkEmptyOrNull(toolCount) || !Cert.checkIsNumber(toolCount)) {
        erreMsg += "设备数量;\n"
    }
    if (Cert.checkEmptyOrNull(erreMsg)) {
        alert("以下信息输入不正确：\n" + erreMsg);
        return;
    }


    //检测行是否已存在 验证设备名称和型号同时相同则认为已添加
    var trs = Cert._tbFixTool.find("tr");
    for (var i = 0; i < trs.length; i++) {
        var exist = 0;
        var tr = trs.eq(i);
        if (tr.find("td").eq(1).text().trim() == toolName) {
            exist += 1;
        }
        if (tr.find("td").eq(2).text().trim() == toolNumber) {
            exist += 1;
        }
        if (exist > 1) {
            alert("该设备已添加.");
            return;
        }
    }

    $.ajax({
        type: "post",
        url: Cert._ajaxUrl,
        cache: false,
        timeout: 60000,
        data: { cmd: "addTool", id: Cert._ID, toolType: toolType, toolName: toolName, toolNumber: toolNumber, toolCount: toolCount },
        dataType: "text",
        success: function (data) {
            if (data) {
                if (data.split('#')[0] == "0") {
                    var rowStr = "<tr>";
                    rowStr += "<td title='" + toolType + "'>" + toolTypeName + "</td>";
                    rowStr += "<td title='" + toolName + "'>" + toolName + "</td>";
                    rowStr += "<td title='" + toolNumber + "'>" + toolNumber + "</td>";
                    rowStr += "<td title='" + toolCount + "'>" + toolCount + "</td>";
                    rowStr += "<td><div class='btn btn-default btnDelTool' onclick='Cert.delTool($(this))'>删除</div></td>";
                    rowStr += "</tr>";

                    var tbody = Cert._tbFixTool.find("tbody").eq(0);
                    var htmlStr = tbody.html();
                    htmlStr += rowStr;
                    tbody.html(htmlStr);
                } else {
                    alert("添加失败");
                }
            } else {
                alert("请求发生错误,请重试.");
            }
        },
        error: function () {
            if (console) {
                alert("请求发生错误");
            } else {
                alert("请求发生错误");
            }
        }
    });
}

Cert.delTool = function (vThis) {
    var toolType = vThis.closest("tr").find("td").eq('0').attr("title").trim();
    var toolName = vThis.closest("tr").find("td").eq('1').attr("title").trim();
    var toolNumber = vThis.closest("tr").find("td").eq('2').attr("title").trim();
    var toolCount = vThis.closest("tr").find("td").eq('3').attr("title").trim();
    $.ajax({
        type: "post",
        url: Cert._ajaxUrl,
        cache: false,
        timeout: 60000,
        data: { cmd: "delTool", id: Cert._ID, toolType: toolType, toolName: toolName, toolNumber: toolNumber },
        dataType: "text",
        success: function (data) {
            if (data) {
                if (data.split('#')[0] == "0") {
                    vThis.closest("tr").remove();
                } else {
                    alert("删除失败");
                }
            } else {
                alert("请求发生错误,请重试.");
            }
        },
        error: function () {
            if (console) {
                alert("请求发生错误");
            } else {
                alert("请求发生错误");
            }
        }
    });
}

Cert.getTool = function () {
    $.ajax({
        type: "get",
        url: Cert._ajaxUrl,
        cache: false,
        timeout: 60000,
        data: { cmd: "getTool", id: Cert._ID, toolType: "1" },
        dataType: "text",
        success: function (data) {
            if (data && data.trim() != "[]") {
                var jsonData = JSON.parse(data);
                if (jsonData.length > 0) {
                    var tbody = Cert._tbFixTool.find("tbody").eq(0);
                    var htmlStr = tbody.html();
                    for (var i = 0; i < jsonData.length; i++) {
                        var o = jsonData[i];
                        var rowStr = "<tr>";
                        rowStr += "<td title='1'>交通工具</td>";
                        rowStr += "<td title='" + o.des + "'>" + o.des + "</td>";
                        rowStr += "<td title='" + o.Model + "'>" + o.Model + "</td>";
                        rowStr += "<td title='" + o.Num + "'>" + o.Num + "</td>";
                        rowStr += "<td><div class='btn btn-default btnDelTool' onclick='Cert.delTool($(this))'>删除</div></td>";
                        rowStr += "</tr>";
                        htmlStr += rowStr;
                    }
                    tbody.html(htmlStr);
                    Cert.disabledEdit();
                }
            } else {
                // alert("请求发生错误,请重试."); 没有数据
            }
        },
        error: function () {
        }
    });
    $.ajax({
        type: "get",
        url: Cert._ajaxUrl,
        cache: false,
        timeout: 60000,
        data: { cmd: "getTool", id: Cert._ID, toolType: "2" },
        dataType: "text",
        success: function (data) {
            if (data && data.trim() != "[]") {
                var jsonData = JSON.parse(data);
                if (jsonData.length > 0) {
                    var tbody = Cert._tbFixTool.find("tbody").eq(0);
                    var htmlStr = tbody.html();
                    for (var i = 0; i < jsonData.length; i++) {
                        var o = jsonData[i];
                        var rowStr = "<tr>";
                        rowStr += "<td title='2'>其它仪器设备</td>";
                        rowStr += "<td title='" + o.des + "'>" + o.des + "</td>";
                        rowStr += "<td title='" + o.Model + "'>" + o.Model + "</td>";
                        rowStr += "<td title='" + o.Num + "'>" + o.Num + "</td>";
                        rowStr += "<td><div class='btn btn-default btnDelTool' onclick='Cert.delTool($(this))'>删除</div></td>";
                        rowStr += "</tr>";
                        htmlStr += rowStr;
                    }
                    tbody.html(htmlStr);
                }
            } else {
                // alert("请求发生错误,请重试."); 没有数据
            }
        },
        error: function () {
        }
    });
}



//弃用
//前端添加数据到 送审资料信息table
Cert.addFrontDocumInfo = function () {
    var num1 = $("#num1").val().trim();
    var num2 = $("#num2").val().trim();
    var num3 = $("#num3").val().trim()
    var num4 = $("#num4").val().trim();
    var num5 = $("#num5").val().trim();
    var num6 = $("#num6").val().trim();
    if (Cert.checkIsNumber(num1) &&
        Cert.checkIsNumber(num1) &&
        Cert.checkIsNumber(num1) &&
        Cert.checkIsNumber(num1) &&
        Cert.checkIsNumber(num1) &&
        Cert.checkIsNumber(num1)) {
        //ok

        //保存数据  返回是否成功.


    } else {
        alert("送审资料 填写数据异常");
        return false;
    }
}

//废弃
Cert.getCompanyInfo = function () {
    var id = $("#tbxApplyID").text().trim();
    var type = Cert.getQueryParameter(type);
    $.ajax({
        type: "get",
        url: Cert._ajaxUrl,
        async: true,
        cache: false,
        timeout: 60000,
        data: { cmd: "getCompanyInfo", id: Cert._ID, type: type },
        dataType: "text",
        success: function (data) {
            if (data) {
                //msg:是否成功#是否晋级申请#是否审核通过#dt初始化数据
                var msgArr = data.split("#");
                if (msgArr.length > 0) {
                    var succes = msgArr[0];
                    if (succes == "0") {
                        var upgrade = msgArr[1];
                        var passed = msgArr[2];
                        var dtStr = msgArr[3];
                        if (dtStr && dtStr.trim().length > 0) {
                            var jsonData = JSON.parse(dtStr);
                            console.log(jsonData);
                            var tr = jsonData[0];
                            $("#tbxCommanyName").val(tr.Company);
                            $("#tbxAddress").val(tr.address);
                            $("#tbxContacts").val(tr.contact);
                            $("#tbxPhoneNo").val(tr.phone);
                            $("#tbxTelNo").val(tr.mobile);
                            $("#tbxCodeNo").val(tr.code);
                            $("#tbxFaxNo").val(tr.fax);
                            $("#tbxZone").find("option[value=" + tr.Company + "]").attr("selected", true);
                            $("#tbxAllArea").val(tr.area);
                            $("#tbxAllPerson").val(tr.Anum);
                            $("#tbxOwner").val(tr.frdb);
                            $("#tbxOwnerNo").val(tr.ftel);
                            $("#tbxFixer").val(tr.Mnum);
                            $("#tbxInstaller").val(tr.Bnum);
                        }
                    } else {
                        //失败
                    }
                }

            } else {
                alert("没有数据");
            }
        },
        error: function () {
            if (console) {
                console.log("请求发生错误");
            } else {
                alert("请求发生错误");
            }
        }
    });






    //var cmName = $("#tbxCommanyName").val();
    //var cmAddress = $("#tbxAddress").val();
    //var cmContacts = $("#tbxContacts").val();
    //var cmPhoneNo = $("#tbxPhoneNo").val();
    //var cmTelNo = $("#tbxTelNo").val();
    //var cmCodeNo = $("#tbxCodeNo").val();
    //var cmFaxNo = $("#tbxFaxNo").val();
    //var cmZone = $("#tbxZone  option:selected").val().trim();
    //var cmAllArea = $("#tbxAllArea").val();
    //var cmAllPerson = $("#tbxAllPerson").val();
    //var cmOwner = $("#tbxOwner").val();
    //var cmOwnerNo = $("#tbxOwnerNo").val();
    //var cmFixer = $("#tbxFixer").val();
    //var cmInstaller = $("#tbxInstaller").val();

    ////验证
    //var erreMsg = "";
    //if (!Cert.checkEmptyOrNull(cmName)) {
    //    erreMsg += "企业名称;\n"
    //}
    //if (!Cert.checkEmptyOrNull(cmAddress)) {
    //    erreMsg += "经营地址i;\n"
    //}
    //if (!Cert.checkEmptyOrNull(cmContacts)) {
    //    erreMsg += "联系人;\n"
    //}
    //if (!Cert.checkEmptyOrNull(cmPhoneNo) || !Cert.checkIsNumber(cmPhoneNo)) {
    //    erreMsg += "固定电话;\n"
    //}
    //if (!Cert.checkEmptyOrNull(cmTelNo) || !Cert.checkIsNumber(cmTelNo)) {
    //    erreMsg += "移动电话;\n"
    //}
    //if (!Cert.checkEmptyOrNull(cmCodeNo) || !Cert.checkIsNumber(cmCodeNo)) {
    //    erreMsg += "邮编;\n"
    //}
    //if (!Cert.checkEmptyOrNull(cmFaxNo) || !Cert.checkIsNumber(cmFaxNo)) {
    //    erreMsg += "传真;\n"
    //}
    //if (!Cert.checkEmptyOrNull(cmZone)) {
    //    erreMsg += "所属区域;\n"
    //}
    //if (!Cert.checkEmptyOrNull(cmAllArea) || !Cert.checkIsNumber(cmAllArea)) {
    //    erreMsg += "营业面积;\n"
    //}
    //if (!Cert.checkEmptyOrNull(cmAllPerson) || !Cert.checkIsNumber(cmAllPerson)) {
    //    erreMsg += "企业总人数;\n"
    //}
    //if (!Cert.checkEmptyOrNull(cmOwner)) {
    //    erreMsg += "法人代表;\n"
    //}
    //if (!Cert.checkEmptyOrNull(cmOwnerNo) || !Cert.checkIsNumber(cmOwnerNo)) {
    //    erreMsg += "联系电话;\n"
    //}
    //if (!Cert.checkEmptyOrNull(cmFixer) || !Cert.checkIsNumber(cmFixer)) {
    //    erreMsg += "维修人员人数;\n"
    //}
    //if (!Cert.checkEmptyOrNull(cmInstaller) || !Cert.checkIsNumber(cmInstaller)) {
    //    erreMsg += "安装人员人数;\n"
    //}
    //if (Cert.checkEmptyOrNull(erreMsg)) {
    //    alert("以下信息输入不正确：\n" + erreMsg + "\n 请检查重新输入");
    //    return;
    //}


}
//废弃
Cert.saveCompanyInfo = function () {
    var cmName = $("#tbxCommanyName").val();
    var cmAddress = $("#tbxAddress").val();
    var cmContacts = $("#tbxContacts").val();
    var cmPhoneNo = $("#tbxPhoneNo").val();
    var cmTelNo = $("#tbxTelNo").val();
    var cmCodeNo = $("#tbxCodeNo").val();
    var cmFaxNo = $("#tbxFaxNo").val();
    var cmZone = $("#tbxZone  option:selected").val().trim();
    var cmAllArea = $("#tbxAllArea").val();
    var cmAllPerson = $("#tbxAllPerson").val();
    var cmOwner = $("#tbxOwner").val();
    var cmOwnerNo = $("#tbxOwnerNo").val();
    var cmFixer = $("#tbxFixer").val();
    var cmInstaller = $("#tbxInstaller").val();

    //验证
    var erreMsg = "";
    if (!Cert.checkEmptyOrNull(cmName)) {
        erreMsg += "企业名称;\n"
    }
    if (!Cert.checkEmptyOrNull(cmAddress)) {
        erreMsg += "经营地址i;\n"
    }
    if (!Cert.checkEmptyOrNull(cmContacts)) {
        erreMsg += "联系人;\n"
    }
    if (!Cert.checkEmptyOrNull(cmPhoneNo) || !Cert.checkIsNumber(cmPhoneNo)) {
        erreMsg += "固定电话;\n"
    }
    if (!Cert.checkEmptyOrNull(cmTelNo) || !Cert.checkIsNumber(cmTelNo)) {
        erreMsg += "移动电话;\n"
    }
    if (!Cert.checkEmptyOrNull(cmCodeNo) || !Cert.checkIsNumber(cmCodeNo)) {
        erreMsg += "邮编;\n"
    }
    if (!Cert.checkEmptyOrNull(cmFaxNo) || !Cert.checkIsNumber(cmFaxNo)) {
        erreMsg += "传真;\n"
    }
    if (!Cert.checkEmptyOrNull(cmZone)) {
        erreMsg += "所属区域;\n"
    }
    if (!Cert.checkEmptyOrNull(cmAllArea) || !Cert.checkIsNumber(cmAllArea)) {
        erreMsg += "营业面积;\n"
    }
    if (!Cert.checkEmptyOrNull(cmAllPerson) || !Cert.checkIsNumber(cmAllPerson)) {
        erreMsg += "企业总人数;\n"
    }
    if (!Cert.checkEmptyOrNull(cmOwner)) {
        erreMsg += "法人代表;\n"
    }
    if (!Cert.checkEmptyOrNull(cmOwnerNo) || !Cert.checkIsNumber(cmOwnerNo)) {
        erreMsg += "联系电话;\n"
    }
    if (!Cert.checkEmptyOrNull(cmFixer) || !Cert.checkIsNumber(cmFixer)) {
        erreMsg += "维修人员人数;\n"
    }
    if (!Cert.checkEmptyOrNull(cmInstaller) || !Cert.checkIsNumber(cmInstaller)) {
        erreMsg += "安装人员人数;\n"
    }
    if (Cert.checkEmptyOrNull(erreMsg)) {
        alert("以下信息输入不正确：\n" + erreMsg + "\n 请检查重新输入");
        return;
    }


}

Cert.disabledEdit = function () {
    if ("disabled" == $("#txtCompany").attr("disabled")) {
        //已提交 不允许修改

        $("#btnAddFixBus").remove();
        $("#btnAddFixBusName").remove();
        $("#btnShowdivPersonAdd").remove();
        $("#btnAddPerson").remove();
        $("#btnShowdivToolAdd").remove();
        $("#btnToolAdd").remove();

        $("#tbxFixBusName").remove();
        $("#selFixBusType").remove();

        $(".btnDelPerson").remove();
        $(".btnDelBusType").remove();
        $(".btnDelTool").remove();
        $(".btnDelBusName").remove();

        $("#tbDocumInfo").find("input").attr("disabled", "disabled");
        $(".saveZone").remove();

    }

}

//送审资料获取
Cert.getDocumInfo = function () {
    $.ajax({
        type: "get",
        url: Cert._ajaxUrl,
        cache: false,
        timeout: 60000,
        data: { cmd: "getDocumInfo", id: Cert._ID },
        dataType: "text",
        success: function (data) {
            if (data) {
                if (data.split('#')[0] == "0") {
                    var bodyStr = " <tr><th>序号</th><th>目录</th><th>份数</th></tr>";
                    var jsonData = JSON.parse(data.split('#')[1]);
                    for (var i = 0; i < jsonData.length; i++) {
                        var obj = jsonData[i];
                        bodyStr += "<tr>";
                        bodyStr += "<td style='display:none'>" + obj.ID + "</td>" + "<td>" + (i + 1) + "</td><td>" + obj.Name + "</td><td>" + "<input type='text' id='num1" + i + "' onmouseout='Cert.SaveDocumInfo($(this))' value='" + obj.Num + "' /></td>";
                        bodyStr += "</tr>";
                    }
                    $("#tbDocumInfo").html(bodyStr);
                } else {
                    alert("添加失败");
                }
            } else {
                alert("请求发生错误,请重试.");
            }
        },
        error: function () {
            if (console) {
                alert("请求发生错误");
            } else {
                alert("请求发生错误");
            }
        }
    });
}

//送审资料保存
Cert.SaveDocumInfo = function (vThis) {
    var numValue = vThis.val();
    var id = vThis.closest("tr").find("td").eq(1).text().trim();
    var docId = vThis.closest("tr").find("td").eq(0).text().trim();



    if (Cert.checkIsNumber(numValue) && Cert.checkIsNumber(id)) {
        //update
        $.ajax({
            type: "post",
            url: Cert._ajaxUrl,
            cache: false,
            timeout: 60000,
            data: { cmd: "updateDocumInfo", id: docId, numValue: numValue },
            dataType: "text",
            success: function (data) {
                if (data) {
                    if (data.split('#')[0] == "0") {

                    } else {
                        alert("添加失败");
                    }
                } else {
                    alert("请求发生错误,请重试.");
                }
            },
            error: function () {
                if (console) {
                    alert("请求发生错误");
                } else {
                    alert("请求发生错误");
                }
            }
        });



    } else {
        alert("送审资料 填写数据异常,序号：" + id);
        return;
    }
}

//验证企业基本信息是否填写完整
Cert.CheckcompanyBasicInfo = function () {
    var msg = "";
    try {
        var txtOldCertNO = $("#txtOldCertNO").val();
        
        if ((!txtOldCertNO || txtOldCertNO.length < 1) && txtOldCertNO != undefined) {
            msg += "原证书号未填写;\n";
        } else {
            $.ajax({
                type: "get",
                url: Cert._ajaxUrl,
                cache: false,
                timeout: 60000,
                data: { cmd: "checkLevel", oldCertNo: txtOldCertNO },
                dataType: "text",
                success: function (data) {
                    if (data) {
                        if (data.split('#')[0] == "0") {
                            $('.saveZone').removeAttr("style");
                        } else {
                            alert(data.split('#')[1]);
                            $('.saveZone').css("display", "none");
                            return;
                        }
                    } else {
                        // alert("请求发生错误,请重试.");
                    }
                },
                error: function () {
                    //if (console) {
                    //    alert("请求发生错误");
                    //} else {
                    //    alert("请求发生错误");
                    //}
                }
            });
        }
    } catch (e) { }
    //try {
    //    var txtNewCertNO = $("#txtNewCertNO").val();
    //    if ((!txtNewCertNO || txtNewCertNO.length < 1) && txtOldCertNO != undefined) {
    //        msg += "新证书号未填写;\n";
    //    }
    //} catch (e) { }
    try {
        var txtCompany = $("#txtCompany").val();
        if (!txtCompany || txtCompany.length < 1) {
            msg += "企业名称未填写;\n";
        }
    } catch (e) { }
    try {
        var txtAddress = $("#txtAddress").val();
        if (!txtAddress || txtAddress.length < 1) {
            msg += "经营地址未填写;\n";
        }
    } catch (e) { }
    try {
        var txtCode = $("#txtCode").val();
        if (!txtCode || txtCode.length < 1) {
            msg += "邮编未填写;\n";
        } else {
            if (!Cert.checkIsNumber(txtCode)) {
                msg += "邮编非数字;\n";
            }
        }
    } catch (e) { }
    try {
        var txtContact = $("#txtContact").val();
        if (!txtContact || txtContact.length < 1) {
            msg += "联系人未填写;\n";
        }
    } catch (e) { }
    try {
        var txtPhone = $("#txtPhone").val();
        if (!txtPhone || txtPhone.length < 1) {
            msg += "固定电话未填写;\n";
        } else {
            if (!Cert.checkIsNumber(txtPhone)) {
                msg += "固定电话非数字;\n";
            }
        }
    } catch (e) { }
    try {
        var txtMobile = $("#txtMobile").val();
        if (!txtMobile || txtMobile.length < 1) {
            msg += "移动电话未填写;\n";
        } else {
            if (!Cert.checkIsNumber(txtCode)) {
                msg += "移动电话非数字;\n";
            }
        }
    } catch (e) { }
    try {
        var txtFax = $("#txtFax").val();
        if (!txtFax || txtFax.length < 1) {
            msg += "传真未填写;\n";
        }
    } catch (e) { }
    try {
        var txtFrdb = $("#txtFrdb").val();
        if (!txtFrdb || txtFrdb.length < 1) {
            msg += "法人代表未填写;\n";
        }
    } catch (e) { }
    try {
        var txtFtel = $("#txtFtel").val();
        if (!txtFtel || txtFtel.length < 1) {
            msg += "联系电话未填写;\n";
        } else {
            if (!Cert.checkIsNumber(txtCode)) {
                msg += "联系电话非数字;\n";
            }
        }
    } catch (e) { }
    try {
        var txtArea = $("#txtArea").val();
        if (!txtArea || txtArea.length < 1) {
            msg += "营业面积未填写;\n";
        }
    } catch (e) { }


    try {
        var txtAnum = $("#txtAnum").val();
        if (!txtAnum || txtAnum.length < 1) {
            msg += "企业总人数未填写;\n";
        } else {
            if (!Cert.checkIsNumber(txtCode)) {
                msg += "企业总人数非数字;\n";
            }
        }
    } catch (e) { }
    try {
        var txtMnum = $("#txtMnum").val();
        if (!txtMnum || txtMnum.length < 1) {
            msg += "维修人员人数未填写;\n";
        } else {
            if (!Cert.checkIsNumber(txtCode)) {
                msg += "维修人员人数非数字;\n";
            }
        }
    } catch (e) { }
    try {
        var txtBnum = $("#txtBnum").val();
        if (!txtBnum || txtBnum.length < 1) {
            msg += "安装人员人数未填写;\n";
        } else {
            if (!Cert.checkIsNumber(txtCode)) {
                msg += "安装人员人数非数字;\n";
            }
        }
    } catch (e) { }
    try {
        var txtSummary = $("#txtSummary").val();
        if ((!txtSummary || txtSummary.length < 1) && txtOldCertNO != undefined) {
            msg += "企业总结未填写;\n";
        }
    } catch (e) { }

    if (Cert.checkEmptyOrNull(msg)) {
        alert(msg);
        $('.saveZone').css("display", "none");
        return;
    } else {
        $('.saveZone').removeAttr("style");
    }
}

$(document).ready(function () {
    Cert._tbFixBus = $("#tbFixBus");
    Cert._tbFixBusName = $("#tbFixBusName");
    Cert._tbPesonInfo = $("#tbPesonInfo");
    Cert._tbFixTool = $("#tbFixTool");
    Cert._tbDocumInfo = $("#tbDocumInfo");
    Cert._ID = $("#tbxApplyID").text().trim();//申请ID

    $("#btnAddFixBus").click(function () {
        Cert.addFrontFixBus();
    })
    $("#btnAddFixBusName").click(function () {
        Cert.addFrontFixBusName();
    })
    $("#btnAddPerson").click(function () {
        Cert.addFrontPesonInfos();
    })

    $("#btnToolAdd").click(function () {
        Cert.addFrontFixTool();
    })

    $("#certForm").on("click", ".btnDel", function () {
        $(this).closest("tr").remove();
    });

    $("#companyBasic").mouseleave(function () {
        Cert.CheckcompanyBasicInfo();
    });

    Cert.getDocumInfo();

    //页面加载完成后
    //判断当前状态 是新增or 修改 or 已审核
    var companyName = $("#txtCompany").val();
    //如果公司名称存在值，修改or已审核
    if (companyName && companyName.trim().length > 0) {
        //加载其他数据
        Cert.getFixBusType();//加载维修业务类型
        Cert.getFixBusName();//加载特约维修业务名称
        Cert.getPersonInfos();//加载人员信息
        Cert.getTool();//加载设备信息

    } else {
        //nothing
    }


    //显示人员添加面板
    $("#btnShowdivPersonAdd").click(function () {
        $("#divPersonAdd").css("display", "block");
    })
    $("#btnAddPersonCancel").click(function () {
        $("#divPersonAdd").css("display", "none");
    })

    //显示设备添加面板
    $("#btnShowdivToolAdd").click(function () {
        $("#divToolAdd").css("display", "block");
    })
    $("#btnAddToolAddCancel").click(function () {
        $("#divToolAdd").css("display", "none");
    })


    //Cert.getCompanyInfo();

});