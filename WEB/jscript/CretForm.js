
var Cert = new Object();
Cert._tbFixBus;//维修业务范围Table对象
Cert._tbFixBusName;//特约维修业务品牌Table对象
Cert._tbPesonInfo;//人员信息
Cert._tbFixTool;//维修安装设备
Cert._tbDocumInfo;//送审资料信息


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


    var tbody = Cert._tbFixBus.find("tbody").eq(0);
    var htmlStr = tbody.html();
    htmlStr += "<tr><td>" + busType + "</td><td><div class='btn btn-default btnDel'>删除</div></td></tr>";
    tbody.html(htmlStr);
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

    var tbody = Cert._tbFixBusName.find("tbody").eq(0);
    var htmlStr = tbody.html();
    htmlStr += "<tr><td>" + busName + "</td><td><div class='btn btn-default btnDel'>删除</div></td></tr>";
    tbody.html(htmlStr);
}

//前端添加数据到 人员信息table
Cert.addFrontPesonInfos = function () {
    var personType = $(".rdoPesonType:checked").val();
    var name = $("#tbxName").val().trim();
    var eduLevel = $("#selEduLevel option:selected").text().trim();
    var post = $("#tbxPost").val().trim();
    var certName = $("#tbxCertName option:selected").text().trim();
    var certNo = $("#tbxCertNo").val().trim();
    var mark = $("#tbxMark").val().trim();

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

    var rowStr = "<tr>";
    rowStr += "<td title='" + personType + "'>" + personType + "</td>";
    rowStr += "<td title='" + name + "'>" + name + "</td>";
    rowStr += "<td title='" + eduLevel + "'>" + eduLevel + "</td>";
    rowStr += "<td title='" + post + "'>" + post + "</td>";
    rowStr += "<td title='" + certName + "'>" + certName + "</td>";
    rowStr += "<td title='" + certNo + "'>" + certNo + "</td>";
    rowStr += "<td title='" + mark + "'>" + mark + "</td>";
    rowStr += "<td><div class='btn btn-default btnDel'>删除</div></td>";
    rowStr += "</tr>";

    var tbody = Cert._tbPesonInfo.find("tbody").eq(0);
    var htmlStr = tbody.html();
    htmlStr += rowStr;
    tbody.html(htmlStr);
}


//前端添加数据到 维修安装设备table
Cert.addFrontFixTool = function () {
    var toolType = $(".rdoToolType:checked").val();
    var toolName = $("#tbxToolName").val().trim();
    var toolNumber = $("#tbxToolNumber").val().trim();
    var toolCount = $("#tbxToolCount").val().trim();

    var erreMsg = "";
    if (!Cert.checkEmptyOrNull(toolType)) {
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





    var rowStr = "<tr>";
    rowStr += "<td title='" + toolType + "'>" + toolType + "</td>";
    rowStr += "<td title='" + toolName + "'>" + toolName + "</td>";
    rowStr += "<td title='" + toolNumber + "'>" + toolNumber + "</td>";
    rowStr += "<td title='" + toolCount + "'>" + toolCount + "</td>";
    rowStr += "<td><div class='btn btn-default btnDel'>删除</div></td>";
    rowStr += "</tr>";

    var tbody = Cert._tbFixTool.find("tbody").eq(0);
    var htmlStr = tbody.html();
    htmlStr += rowStr;
    tbody.html(htmlStr);
}

//前端添加数据到 送审资料信息table
Cert.addFrontDocumInfo = function () {

}
Cert.delFontDocumInfo = function () {

}





$(document).ready(function () {
    Cert._tbFixBus = $("#tbFixBus");
    Cert._tbFixBusName = $("#tbFixBusName"); 
    Cert._tbPesonInfo = $("#tbPesonInfo");
    Cert._tbFixTool = $("#tbFixTool");
    Cert._tbDocumInfo = $("#tbDocumInfo");


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

});