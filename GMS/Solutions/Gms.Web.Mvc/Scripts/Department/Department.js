
var Department;
if (!Department) {
    Department = {};
}

Department.Init = function () {
    
    $('#department_tree').treegrid({
        toolbar: '#toolbar',
        idField: 'Id',
        treeField: 'Name',
        columns: [
        [
            { title: '名称', field: 'Name', width: 100 },
            { title: '编码', field: 'CodeNo', width: 100 },
            { title: '备注', field: 'Note', width: 200 }
        ]
        ]
    });

    $("#btnAdd").click(function () {

        var rec = $('#department_tree').treegrid("getSelected");

        var parentId = 0;
        if (rec != null) {
            parentId = rec.Id;
        }

        $("#department_edit_content").load("/Department/Edit", { parentid: parentId }, function () {

            showDlg();

        });

    });

    $("#btnEdit").click(function () {
        
        var rec = $('#department_tree').treegrid("getSelected");

        if (rec == null) {
            return;
        }

        $("#department_edit_content").load("/Department/Edit", { id: rec.Id }, function () {

            showDlg();

        });

    });

    var showDlg = function() {
        var dlg = $("#department_edit");
        dlg.show();

        //隐藏需要隐藏的元素
        $('.addhide,.edithide').show();
        $('*[isrequired]', dlg).validatebox({ required: true });
        $('.easyui-combotree[isrequired]', dlg).combotree({ required: true });

        $('.edithide', dlg).hide();
        $('.edithide  *[isrequired]', dlg).validatebox({ required: false });
        $('.edithide  .easyui-combotree[isrequired]', dlg).combotree({ required: false });
        $('.editdisabled', dlg).attr("disabled", true);

        $(':hidden[isrequired]').validatebox({ required: false });

        dlg.dialog({
            title: "部门信息",
            buttons: [
                {
                    text: '保存',
                    iconCls: 'icon-ok',
                    handler: function() {

                        var formOptions = {
                            defaultbefore: false,
                            beforeSubmit: function(arr, $form) {
                                var result = $form.valid();
                                return result;
                            },
                            success: function(data) {

                                if (data.success) {
                                    $.messager.alert('提示', '保存成功', 'info');
                                    dlg.dialog('close');
                                    $('#department_tree').treegrid('reload');
                                } else {
                                    $.messager.alert('错误', '保存失败：' + data.data, 'error');
                                }
                            }
                        };

                        formOptions.dataType = 'json';

                        $('form', dlg).submitForm(formOptions);
                    }
                }, {
                    text: '取消',
                    iconCls: 'icon-cancel',
                    handler: function() {
                        dlg.dialog('close');
                    }
                }
            ]
        });
    };

    $("#btnDelete").click(function () {

        var rec = $('#department_tree').treegrid("getSelected");

        if (rec == null) {
            return;
        }

        $.post("/Department/Delete", { id: rec.Id }, function (data) {
            if (data.success) {

                $.messager.alert('提示', '删除成功！', 'info', function () {
                    $('#department_tree').treegrid('reload');
                });
            } else {
                $.messager.alert('错误', '删除失败：' + data.data, 'error');
            }
        }, 'json');

    });

    $("#btnUnSelect").click(function () {

        $('#department_tree').treegrid("unselectAll");

    });
};

Department.Select = function () {


    $('#department_tree').treegrid({
        idField: 'Id',
        treeField: 'Name',
        columns: [
        [
            { title: '名称', field: 'Name', width: 100 },
            { title: '编码', field: 'CodeNo', width: 100 },
            { title: '备注', field: 'Note', width: 200 }
        ]
        ],
        onSelect: function (rowIndex, rowData) {
            if (rowData != null) {
                $('#department_selected_Id').val(rowData.Id);
                $('#department_selected_Name').val(rowData.Name);
            }
        }
    });
};

