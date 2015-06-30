
var Customer;
if (!Customer) {
    Customer = {};
}

Customer.Init = function () {

    var features = 'dialogHeight=420px; dialogWidth=800px; center=yes;location=0; resizable=0; status=0';

    $('#customer_search_list').datagridEx({
        toolbar: '#toolbar',
        pagination: true,
        singleSelect:true,
        columns: [[
            { field: 'Name', title: '姓名', width: 100 },
            { field: 'Mobile', title: '电话', width: 100 },
            { field: 'Company', title: '公司', width: 100 },
            { field: 'Address', title: '地址', width: 100 },
            { field: 'Note', title: '备注', width: 100 }//,
            //{
            //    field: 'Id', title: '操作', width: 100, formatter: function (value, row, index) {
            //        if (row.Id) {
            //            return "<a class='localedit' href='#" + row.Id + "' onclick='testfun()'>编辑</a>";
            //        } else {
            //            return "";
            //        }
            //    }
            //}
        ]]
    });

    $("#btnAdd").click(function () {

        var vReturnValue = window.showModalDialog('/Customer/Edit', '', features);
        if (vReturnValue != undefined) {
            $('#customer_search_list').datagridEx("reload");
        }

    });
};


Customer.Edit = function () {


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

        $("#selcet_dept_dlg_content").attr("src", "/CommonCode/Select");

        var opt = {
            title: '选择部门',
            width: 300,
            height: 200,
            buttons: [{
                text: '确定',
                iconCls: 'icon-ok',
                handler: function () {
                    var deptContents = $("#selcet_dept_dlg_content").contents();

                    $("#Department_Id").val(deptContents.find("#department_selected_Id").val());
                    $("#Department_Name").val(deptContents.find("#department_selected_Name").val());

                    $("#selcet_dept_dlg").dialog('close');
                }
            }, {
                text: '取消',
                iconCls: 'icon-cancel',
                handler: function () {
                    $("#selcet_dept_dlg").dialog('close');
                }
            }]
        };

        $("#selcet_dept_dlg").show();
        $("#selcet_dept_dlg").dialog(opt);

        return false;

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

        $('#userform').submitForm(formOptions);

    });

    //window.onunload = onunloadHandler;

    //function onunloadHandler() {
    //    window.returnValue = "false";
    //}

};




Customer.Select = function () {

    $('#customer_search_list').datagridEx({
        toolbar: '#toolbar',
        pagination: true,
        singleSelect:true,
        columns: [[
            { field: 'Name', title: '姓名', width: 100 },
            { field: 'Mobile', title: '电话', width: 100 },
            { field: 'Company', title: '公司', width: 100 },
            { field: 'Address', title: '地址', width: 100 },
            { field: 'Note', title: '备注', width: 100 }//,
            //{
            //    field: 'Id', title: '操作', width: 100, formatter: function (value, row, index) {
            //        if (row.Id) {
            //            return "<a class='localedit' href='#" + row.Id + "' onclick='testfun()'>编辑</a>";
            //        } else {
            //            return "";
            //        }
            //    }
            //}
        ]],
        onSelect: function (rowIndex, rowData) {
            if (rowData != null) {
                $('#customer_selected_id').val(rowData.Id);
                $('#customer_selected_name').val(rowData.Name);
                $('#customer_selected_mobile').val(rowData.Mobile);
                $('#customer_selected_company').val(rowData.Company);
                $('#customer_selected_note').val(rowData.Note);
            }
            
        }
    });

    $("#customerform").validate({
        onkeyup: false,
        onfocusout: false,
        rules: {
            Name: "required",
            Mobile: "required"
        },
        messages: {
            Name: "请输入姓名",
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

};
