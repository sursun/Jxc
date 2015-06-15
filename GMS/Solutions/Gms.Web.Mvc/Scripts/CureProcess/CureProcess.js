
var CureProcess;
if (!CureProcess) {
    CureProcess = {};
}

//
//加工过程
//
CureProcess.Init = function () {
    
    $('#cureprocess_list').datagridEx({
        toolbar: '#toolbar',
        fit: true,
        rownumbers: true,
        singleSelect: true,
        columns: [[
            {field: 'Name',title: '名称',width: 100},
            {field: 'DescString',title: '描述(很重要)',width: 200},
            {field: 'AreaPrice',title: '面积单价',width: 80},
            {field: 'EdgePrice',title: '边长单价',width: 80},
            {field: 'Note',title: '备注',width: 300}

        ]],
        onSelect: function (rowIndex, rowData) {
            if (rowData != null) {
                $('#process_selected_id').val(rowData.Id);
                $('#process_selected_name').val(rowData.Name);
                $('#process_selected_desc').val(rowData.DescString);
            }

        }
    });

    $("#btnAdd").click(function () {
        
        $("#cureprocess_edit_content").load("/CureProcess/Edit", { id: 0 }, function () {
            showDlg();
        });

    });

    $("#btnEdit").click(function () {

        var rec = $('#cureprocess_list').datagridEx("getSelected");

        if (rec == null) {
            return;
        }

        $("#cureprocess_edit_content").load("/CureProcess/Edit", { id: rec.Id }, function () {

            showDlg();

        });

    });

    var showDlg = function () {
        var dlg = $("#cureprocess_edit");
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
            title: "加工过程",
            buttons: [
                {
                    text: '保存',
                    iconCls: 'icon-ok',
                    handler: function () {

                        var formOptions = {
                            defaultbefore: false,
                            beforeSubmit: function (arr, $form) {
                                var result = $form.valid();
                                return result;
                            },
                            success: function (data) {

                                if (data.success) {
                                    $.messager.alert('提示', '保存成功', 'info');
                                    dlg.dialog('close');
                                    $('#cureprocess_list').datagridEx('reload');
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
                    handler: function () {
                        dlg.dialog('close');
                    }
                }
            ]
        });
    };


};

