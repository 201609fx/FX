
var Cert = new Object();
Cert._tbFixBus;//维修业务范围Table对象
Cert._tbFixBusName;//特约维修业务品牌Table对象
Cert._tbPesonInfo;//人员信息
Cert._tbFixTool;//维修安装设备
Cert._tbDocumInfo;//送审资料信息


//前端添加数据到 维修业务范围table
Cert.addFrontFixBus = function () {
    var busType = $("#selFixBusType option:selected").text();
    if (busType == "请选择类别") {
        alert("未选择\"维修业务类型范围\"");
    }
    var tbody = Cert._tbFixBus.find("tbody").eq(0);
    var htmlStr = tbody.html();
    htmlStr += "<tr><td>" + busType + "</td><td><div class='btn btn-default'>删除</div></td></tr>";
    tbody.html(htmlStr);
}
Cert.delFontFixBus = function (vThis) {
    
}

//前端添加数据到 特约维修业务品牌table
Cert.addFrontFixBusName = function () {
    var busName = $("#tbxFixBusName").val();
    if (busName && busName.length > 0) {
        busName.trim();
    } else {
        alert("未输入\"特约维修业务品牌\"");
    }
    var tbody = Cert._tbFixBusName.find("tbody").eq(0);
    var htmlStr = tbody.html();
    htmlStr += "<tr><td>" + busName + "</td><td><div class='btn btn-default'>删除</div></td></tr>";
    tbody.html(htmlStr);
}

//前端添加数据到 人员信息table
Cert.addFrontPesonInfos = function () {
    var personType = $(".rdoPesonType:checked").val();
    var name = $("#tbxName").val().trim();
    var eduLevel = $("#selEduLevel option:selected").text();
    var post = $("#tbxPost").val().trim();
    var certName = $("#tbxCertName").val().trim();
    var certNo = $("#tbxCertNo").val().trim();
    var mark = $("#tbxMark").val().trim();

    var rowStr = "<tr>";
    rowStr += "<td title='" + personType + "'>" + personType + "</td>";
    rowStr += "<td title='" + name + "'>" + name + "</td>";
    rowStr += "<td title='" + eduLevel + "'>" + eduLevel + "</td>";
    rowStr += "<td title='" + post + "'>" + post + "</td>";
    rowStr += "<td title='" + certName + "'>" + certName + "</td>";
    rowStr += "<td title='" + certNo + "'>" + certNo + "</td>";
    rowStr += "<td title='" + mark + "'>" + mark + "</td>";
    rowStr += "<td><div class='btn btn-default'>删除</div></td>";
    rowStr += "</tr>";

    var tbody = Cert._tbPesonInfo.find("tbody").eq(0);
    var htmlStr = tbody.html();
    htmlStr += rowStr;
    tbody.html(htmlStr);
}
Cert.delFontPesonInfos = function () {

}

//前端添加数据到 维修安装设备table
Cert.addFrontFixTool = function () {
    var toolType = $(".rdoToolType:checked").val();
    var toolName = $("#tbxToolName").val().trim();
    var toolNumber = $("#tbxToolNumber").val().trim();
    var toolCount = $("#tbxToolCount").val().trim();

    var rowStr = "<tr>";
    rowStr += "<td title='" + toolType + "'>" + toolType + "</td>";
    rowStr += "<td title='" + toolName + "'>" + toolName + "</td>";
    rowStr += "<td title='" + toolNumber + "'>" + toolNumber + "</td>";
    rowStr += "<td title='" + toolCount + "'>" + toolCount + "</td>";
    rowStr += "<td><div class='btn btn-default'>删除</div></td>";
    rowStr += "</tr>";

    var tbody = Cert._tbFixTool.find("tbody").eq(0);
    var htmlStr = tbody.html();
    htmlStr += rowStr;
    tbody.html(htmlStr);
}
Cert.delFontFixTool = function () {

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


});