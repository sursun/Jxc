
var CommonCode;
if (!CommonCode) {
    CommonCode = {};
}

CommonCode.Init = function () {

    $("#tabCommonCode").tabs({
        onSelect: function (title, index) {
            var tab = $("#tabCommonCode").tabs("getTab", index);

            var src = $("iframe", tab).attr("src");
            if (src == undefined || src.length < 2) {
                var url = $("iframe", tab).attr("url");
                $("iframe", tab).attr("src",url);
            }
        }
    });
};

CommonCode.TypeInfo = function (extName) {

    var cols = [
        [
            { title: '名称', field: 'Name', width: 100 },
            { title: '编码', field: 'CodeNo', width: 100 },
            { title: '备注', field: 'Note', width: 200 }
        ]
    ];

    if (extName == "Khdj") {
        cols = [
            [
                { title: '名称', field: 'Name', width: 100 },
                { title: '编码', field: 'CodeNo', width: 100 },
                { title: '折扣', field: 'ParamDecimal', width: 100 },
                { title: '备注', field: 'Note', width: 200 }
            ]
        ];
    }


    $('#commoncode_tree').treegrid({
        toolbar: '#toolbar',
        idField: 'Id',
        treeField: 'Name',
        columns: cols
    });

    $("#btnAdd").click(function () {
        var tp = $("#commonCodeType").val();
        var rec = $('#commoncode_tree').treegrid("getSelected");

        var parentId = 0;
        if (rec != null) {
            parentId = rec.Id;
        }

        $("#commoncode_edit_content").load("/CommonCode/Edit", { parentid: parentId, type: tp }, function() {

            showDlg();

        });

    });

    $("#btnEdit").click(function () {
        
        var rec = $('#commoncode_tree').treegrid("getSelected");

        if (rec == null) {
            return;
        }

        $("#commoncode_edit_content").load("/CommonCode/Edit", { id: rec.Id}, function () {

            showDlg();

        });

    });

    var showDlg = function() {
        var dlg = $("#commoncode_edit");
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
            title: "字典信息",
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
                                    $('#commoncode_tree').treegrid('reload');
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

        var rec = $('#commoncode_tree').treegrid("getSelected");

        if (rec == null) {
            return;
        }

        $.post("/CommonCode/Delete", { id: rec.Id }, function (data) {
            if (data.success) {

                $.messager.alert('提示', '删除成功！', 'info', function () {
                    $('#commoncode_tree').treegrid('reload');
                });
            } else {
                $.messager.alert('错误', '删除失败：' + data.data, 'error');
            }
        }, 'json');

    });

    $("#btnUnSelect").click(function () {

        $('#commoncode_tree').treegrid("unselectAll");

    });
};

CommonCode.Select = function (extName) {

    var cols = [
        [
            { title: '名称', field: 'Name', width: 100 },
            { title: '编码', field: 'CodeNo', width: 100 },
            { title: '备注', field: 'Note', width: 200 }
        ]
    ];

    if (extName == "Khdj") {
        cols = [
            [
                { title: '名称', field: 'Name', width: 100 },
                { title: '编码', field: 'CodeNo', width: 100 },
                { title: '折扣', field: 'ParamDecimal', width: 100 },
                { title: '备注', field: 'Note', width: 200 }
            ]
        ];
    }

    $('#commoncode_tree').treegrid({
        toolbar: '#toolbar',
        idField: 'Id',
        treeField: 'Name',
        columns: cols,
        onSelect: function (rowData) {
            if (rowData != null) {
                $('#commoncode_selected_Id').val(rowData.Id);
                $('#commoncode_selected_Name').val(rowData.Name);
                $('#commoncode_selected_FullName').val(rowData.FullName);
            }

        }
    });

 
};

