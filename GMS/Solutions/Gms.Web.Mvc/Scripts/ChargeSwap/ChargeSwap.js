
var ChargeSwap;
if (!ChargeSwap) {
    ChargeSwap = {};
}

ChargeSwap.Init = function () {

    var features = 'dialogHeight=800; dialogWidth=1000; center=yes;location=0; resizable=0; status=0';

    $('#customer_search_list').datagridEx({
        toolbar: '#toolbar',
        pagination: true,
        singleSelect:true,
        columns: [[
            { field: 'OrigAccountName', title: '源账户', width: 100 },
            { field: 'DestAccountName', title: '目的账户', width: 100 },
            { field: 'Amount', title: '记账金额', width: 100 },
            { field: 'CreatorName', title: '登记人', width: 100 },
            { field: 'CreateTimeString', title: '登记日期', width: 100 },
            { field: 'AuditState', title: '审核状态', width: 100 },
            { field: 'AuditorName', title: '审核人', width: 100 },
            { field: 'AuditTimeString', title: '审核日期', width: 100 },
            { field: 'AuditNote', title: '审核说明', width: 100 },
            { field: 'Note', title: '备注', width: 100 }
        ]]
    });

    $("#btnAdd").click(function () {

        var vReturnValue = window.showModalDialog('/ChargeSwap/Edit', '添加流转记账', features);
        if (vReturnValue != undefined) {
            $('#entity_search_list').datagridEx("reload");
        }

    });

    $("#btnEdit").click(function () {

        var rec = $('#entity_search_list').datagridEx("getSelected");

        if (rec == null) {
            return;
        }

        var vReturnValue = window.showModalDialog('/ChargeSwap/Edit?id=' + rec.Id, '查看流转记账', features);
        if (vReturnValue != undefined) {
            $('#entity_search_list').datagridEx("reload");
        }

    });

};


ChargeSwap.Edit = function () {


    $("#entityform").validate({
        onkeyup: false,
        onfocusout: false,
        rules: {
            CodeNo: "required",
            Name: "required"
        },
        messages: {
            CodeNo: "请输入编号",
            Name: "请输入姓名"
        }
        , showErrors: function (errorMap, errorList) {
            var message = '请完善以下内容后，再提交。\n';
            var errors = "";
            if (errorList.length > 0) {
                for (x = 0; x < errorList.length; x++) {
                    errors += "<br/>\u25CF " + errorList[x].message;
                }

                $.messager.alert("提示", message + errors);
            }

        }

    });

    //----------------------------------------- 选择账户 -------------------------------------//
    $("#selectAccount").live("click", function () {

        $("#selcet_acc_dlg_content").attr("src", "/Account/Select");

        var opt = {
            title: '选择账户',
            width: 680,
            height: 380,
            buttons: [{
                text: '确定',
                iconCls: 'icon-ok',
                handler: function () {
                    var deptContents = $("#selcet_acc_dlg_content").contents();

                    $("#Account_Id").val(deptContents.find("#account_selected_Id").val());
                    $("#Account_Name").val(deptContents.find("#account_selected_Name").val());

                    $("#selcet_acc_dlg").dialog('close');
                }
            }, {
                text: '取消',
                iconCls: 'icon-cancel',
                handler: function () {
                    $("#selcet_acc_dlg").dialog('close');
                }
            }]
        };

        $("#selcet_acc_dlg").show();
        $("#selcet_acc_dlg").dialog(opt);

        return false;

    });

    $("#btnSave2").click(function () {

        var formOptions = {
            defaultbefore: false,
            beforeSubmit: function (arr, $form) {
                var result = $form.valid();
                return result;
            },
            success: function (data) {

                if (data.success) {
                    $.messager.alert('提示', '保存成功', 'info');

                    window.returnValue = "true";
                    window.close();

                } else {
                    $.messager.alert('错误', '保存失败：' + data.data, 'error');
                }
            }
        };

        formOptions.dataType = 'json';

        $('#entityform').submitForm(formOptions);

    });

    $("#btnSave1").click(function () {

        var formOptions = {
            defaultbefore: false,
            beforeSubmit: function (arr, $form) {
                var result = $form.valid();
                return result;
            },
            success: function (data) {

                if (data.success) {
                    $.messager.alert('提示', '保存成功', 'info');
                    window.location = '/Customer/Edit?id=' + data.data.Id;
                } else {
                    $.messager.alert('错误', '保存失败：' + data.data, 'error');
                }
            }
        };

        formOptions.dataType = 'json';

        $('#entityform').submitForm(formOptions);

    });


    $('#tabCustomer').tabs({
        onSelect: function (title, index) {
            var tab = $("#tabCustomer").tabs("getTab", index);

            if (index == 1) {

                var cId = $("#Id").val();

                if (cId > 0) {

                    var src = $("iframe", tab).attr("src");
                    if (src == undefined || src.indexOf("Alert") > 0) {
                        var url = $("iframe", tab).attr("url");
                        $("iframe", tab).attr("src", url);
                    }

                }
            }

        }
       
    });

};

