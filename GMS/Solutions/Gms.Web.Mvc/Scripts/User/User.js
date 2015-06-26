
var User;
if (!User) {
    User = {};
}

User.Init = function () {

    var features = 'dialogHeight=420px; dialogWidth=800px; center=yes;location=0; resizable=0; status=0';
   
    $('#user_search_list').datagridEx({
        toolbar: '#toolbar',
        pagination: true,
        singleSelect: true,
        columns: [[
            { field: 'LoginName', title: '登录名', width: 100 },
            { field: 'RealName', title: '真实姓名', width: 100 },
            { field: 'Mobile', title: '手机号', width: 100 },
            { field: 'Note', title: '备注', width: 100 }
        ]],
        onSelect: function (rowIndex, rowData) {
            if (rowData != null) {
                $('#user_selected_Id').val(rowData.Id);
                $('#user_selected_LoginName').val(rowData.LoginName);
            }
        }
    });

    $("#btnAdd").click(function () {
        
        var vReturnValue = window.showModalDialog('/User/Edit', '', features);
        if (vReturnValue != undefined) {
            $('#user_search_list').datagridEx("reload");
        }

    });

    $("#btnEdit").click(function () {

        var rec = $('#user_search_list').datagridEx("getSelected");

        if (rec == null) {
            return;
        }

        var vReturnValue = window.showModalDialog('/User/Edit?id=' + rec.Id, '', features);
        if (vReturnValue != undefined) {
            $('#user_search_list').datagridEx("reload");
        }

    });

    $("#btnDelete").click(function () {

        var rec = $('#user_search_list').datagridEx("getSelected");

        if (rec == null) {
            return;
        }

        $.post("/User/Delete", { id: rec.Id }, function (data) {
            if (data.success) {

                $.messager.alert('提示', '删除成功！', 'info', function () {
                    $('#user_search_list').datagridEx('reload');
                });
            } else {
                $.messager.alert('错误', '删除失败：' + data.data, 'error');
            }
        }, 'json');

    });



    $("a.reset").live("click", function() {
        var rec = $('#user_search_list').datagrid("getSelected");
        if (rec == null) {
            return false;
        }
        
        $.post("/User/ResetPassword", { id: rec.Id }, function (data) {
            if (data.success) {
                $.messager.alert("提示", "密码重新重置为[" + data.data + "]");
            } else {
                $.messager.alert("提示", data.data);
            }
        },"json");

    });

  //----------------------------------------- 选择科室 -------------------------------------//
    $("#selectDept").live("click",function () {

        $("#selcet_dept_dlg_content").attr("src", "/Department/Select");

        var opt = {
            title: '选择部门',
            width: 300,
            height: 200,
            buttons: [{
                text: '确定',
                iconCls: 'icon-ok',
                handler: function () {
                    var deptContents = $("#selcet_dept_dlg_content").contents();

                    $("#Department_Id").val(deptContents.find("#dept_selected_Id").val());
                    $("#Department_Name").val(deptContents.find("#dept_selected_Name").val());
                 
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
};


User.Edit = function () {
    
    $.extend($.fn.validatebox.defaults.rules, {
        IdCard: {
            validator: function (value, param) {
                var bRet = IdCardValidate(value);

                if (bRet) {
                    var brith = getBrith(value);
                    var strBrith = brith.getFullYear();//getFullYear(); getMonth()//.getDate()
                    strBrith += "-";
                    strBrith += (brith.getMonth() + 1);
                    strBrith += "-";
                    strBrith += brith.getDate();

                    $(param[1]).datebox('setValue', strBrith);

                    var nSex = 0;
                    var strSex = maleOrFemalByIdCard(value);
                    if (strSex == "female") {
                        nSex = 1;
                    }

                    var selObj = document.getElementById(param[0]);

                    for (var i = 0; i < selObj.length; i++) {//给select赋值  
                        if (nSex == selObj.options[i].value) {
                            selObj.options[i].selected = true;
                        }
                    }

                }

                return bRet;
            },
            message: '身份证号无效！'
        }
    });

    $("#userform").validate({
        onkeyup: false,
        onfocusout: false,
        rules: {
            LoginName: "required",
            psw: "required",
            RealName: "required",
            Mobile: "required"
        },
        messages: {
            LoginName: "请输入编号",
            psw: "请输入密码",
            RealName: "请输入真实姓名",
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
    
    //----------------------------------------- 选择科室 -------------------------------------//
    $("#selectDept").live("click", function () {

        $("#selcet_dept_dlg_content").attr("src", "/Department/Select");

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

