
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
    var reg = new RegExp("^[0-9]*$");
    if (!reg.test(str)) {
        return false;
    }
    return true;
}




//前端添加数据到 维修业务范围table
Cert.addFrontFixBus = function () {
    var busType = $("#selFixBusType option:selected").text().trim();
    if (busType == "请选择类别") {
        alert("未选择\"维修业务类型范围\"");
        return;
    }

    //检测行是否已存在
    var trs = Cert._tbFixBus.find("tr");
    for (var i = 0; i < trs.length; i++) {
        var tr = trs.eq(i);
        if (tr.find("td").eq(0).text().trim() == busType) {
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
                if (data.split('#')[0]=="0") {
                    var tbody = Cert._tbFixBus.find("tbody").eq(0);
                    var htmlStr = tbody.html();
                    htmlStr += "<tr><td title='" + busTypeId + "'>" + busType + "</td><td><div class='btn btn-default btnDelBusType' onclick='Cert.DelBusType($(this))'>删除</div></td></tr>";
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

Cert.DelBusType = function (vThis) {
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
                    htmlStr += "<tr><td>" + busName + "</td><td><div class='btn btn-default btnDelBusName' onclick='Cert.DelBusName($(this))'>删除</div></td></tr>";
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

Cert.DelBusName = function (vThis) {
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
    if (mark&&mark.length>3) {
        markDisplay = mark.substring(0, 3)+"..";
    }

    var erreMsg = "";
    if (!Cert.checkEmptyOrNull(personType)) {
        erreMsg+="人员类型;\n"
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
        if (tr.find("td").eq(1).text().trim()==name) {
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
                    rowStr += "<td><div class='btn btn-default btnDelPerson' onclick='Cert.DelPerson($(this))'>删除</div></td>";
                    rowStr += "</tr>";
                    var tbody = Cert._tbPesonInfo.find("tbody").eq(0);
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
Cert.DelPerson = function (vThis) {
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
    if (!Cert.checkEmptyOrNull(toolCount)||!Cert.checkIsNumber(toolCount)) {
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
        if (exist>1) {
            alert("该设备已添加.");
            return;
        }
    }

    $.ajax({
        type: "post",
        url: Cert._ajaxUrl,
        cache: false,
        timeout: 60000,
        data: { cmd: "addTool", id: Cert._ID, toolType: toolType, toolName: toolName, toolNumber: toolNumber, toolCount: toolCount},
        dataType: "text",
        success: function (data) {
            if (data) {
                if (data.split('#')[0] == "0") {
                    var rowStr = "<tr>";
                    rowStr += "<td title='" + toolType + "'>" + toolTypeName + "</td>";
                    rowStr += "<td title='" + toolName + "'>" + toolName + "</td>";
                    rowStr += "<td title='" + toolNumber + "'>" + toolNumber + "</td>";
                    rowStr += "<td title='" + toolCount + "'>" + toolCount + "</td>";
                    rowStr += "<td><div class='btn btn-default btnDelTool' onclick='Cert.DelTool($(this))'>删除</div></td>";
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

Cert.DelTool = function (vThis) {
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



//前端添加数据到 送审资料信息table
Cert.addFrontDocumInfo = function () {
    var num1 = $("#num1").val().trim();
    var num2 = $("#num2").val().trim();
    var num3 = $("#num3").val().trim()
    var num4 = $("#num4").val().trim();
    var num5 = $("#num5").val().trim();
    var num6 = $("#num6").val().trim();
    if (Cert.checkIsNumber(num1)&&
        Cert.checkIsNumber(num1)&&
        Cert.checkIsNumber(num1)&&
        Cert.checkIsNumber(num1)&&
        Cert.checkIsNumber(num1)&&
        Cert.checkIsNumber(num1)) {
        //ok

        //保存数据  返回是否成功.


    } else {
        alert("送审资料 填写数据异常");
        return false;
    }
}

Cert.getCompanyInfo = function () {
    var cmName = $("#tbxCommanyName").val();
    var cmAddress = $("#tbxAddress").val();
    var cmContentPerson = $("#tbxContentPerson").val();
    var cmPhoneNo = $("#tbxPhoneNo").val();
    var cmTelNo = $("#tbxTelNo").val();
    var cmCodeNo = $("#tbxCodeNo").val();
    var cmFaxNo = $("#tbxFaxNo").val();
    var cmZone = $("#tbxZone  option:selected").text().trim();
    var cmAllArea = $("#tbxAllArea").val();
    var cmAllPerson = $("#tbxAllPerson").val();
    var cmOwner = $("#tbxOwner").val();
    var cmOwnerNo = $("#tbxOwnerNo").val();
    var cmFixer = $("#tbxFixer").val();
    var cmInstaller = $("#tbxInstaller").val();


}





$(document).ready(function () {
    Cert._tbFixBus = $("#tbFixBus");
    Cert._tbFixBusName = $("#tbFixBusName"); 
    Cert._tbPesonInfo = $("#tbPesonInfo");
    Cert._tbFixTool = $("#tbFixTool");
    Cert._tbDocumInfo = $("#tbDocumInfo");
    Cert._ID = $("#applyNo").text().trim();//申请ID

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

});