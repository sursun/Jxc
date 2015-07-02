
var Contact;
if (!Contact) {
    Contact = {};
}

Contact.Init = function () {

    var features = 'dialogHeight=420px; dialogWidth=800px; center=yes;location=0; resizable=0; status=0';

    $('#contact_search_list').datagridEx({
        toolbar: '#toolbar',
        pagination: true,
        singleSelect:true,
        columns: [[
            { field: 'Name', title: '姓名', width: 100 },
            { field: 'Mobile', title: '手机号码', width: 100 },
            { field: 'IsDefault', title: '默认联系方式', width: 100 },
            { field: 'Note', title: '备注', width: 100 }
        ]]
    });

    $("#btnAdd").click(function () {

        var relId = this.hash.substr(1);
        var vReturnValue = window.showModalDialog('/Contact/Edit?relationId=' + relId, '', features);
        if (vReturnValue != undefined) {
            $('#contact_search_list').datagridEx("reload");
        }

    });

    $("#btnEdit").click(function () {

        var rec = $('#contact_search_list').datagridEx("getSelected");

        if (rec == null) {
            return;
        }

        var vReturnValue = window.showModalDialog('/Contact/Edit?id=' + rec.Id, '', features);
        if (vReturnValue != undefined) {
            $('#contact_search_list').datagridEx("reload");
        }

    });

};

Contact.Edit = function () {

    $("#contactform").validate({
        onkeyup: false,
        onfocusout: false,
        rules: {
            Mobile: "required"
        },
        messages: {
            Mobile: "请输入手机号码"
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

    $("#btnSave").click(function () {

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

        $('#contactform').submitForm(formOptions);

    });

};
