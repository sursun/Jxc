
var GlassStore;
if (!GlassStore) {
    GlassStore = {};
}

GlassStore.StoreInit = function () {

    $('#glassstore_search_list').datagrid({
        toolbar: '#toolbar',
        pagination: true,
        singleSelect:true,
        columns: [[
            {
                field: 'GlassTypeString', title: '玻璃品种', width: 100,
                formatter: function (value, row, index) {
                    return row.GlassTypeString + row.ThicknessString;
                }
            },
            { field: 'LongEdge', title: '长边', width: 100 },
            { field: 'ShortEdge', title: '短边', width: 100 },
            { field: 'Quantity', title: '数量', width: 100 },
            { field: 'Area', title: '总面积', width: 100 },
            { field: 'Note', title: '备注', width: 100 }
        ]],
        onSelect: function (rowIndex, rowData) {
            if (rowData != null) {
                $('#glassstore_selected_id').val(rowData.Id);
                $('#glassstore_selected_type').val(rowData.GlassTypeString);
                $('#glassstore_selected_thickness').val(rowData.ThicknessString);
                $('#glassstore_selected_longedge').val(rowData.LongEdge);
                $('#glassstore_selected_shortedge').val(rowData.ShortEdge);
                $('#glassstore_selected_amount').val(rowData.Amount);
            }
        }
    });

};

GlassStore.StoreChangeInit = function () {
    
    
    $('#storechange_search_list').datagridEx({
        toolbar: '#toolbar',
        pagination: true,
        singleSelect:true,
        columns: [[
            { field: 'GlassTypeString', title: '玻璃品种', width: 100 },
            { field: 'LongAndShort', title: '规格', width: 100 },
            { field: 'GlassUsageString', title: '用途', width: 100 },
            { field: 'OrderCodeNo', title: '订单编号', width: 100 },
            { field: 'Quantity', title: '数量', width: 100 },
            { field: 'UserName', title: '登记员', width: 100 },
            { field: 'CreateTimeString', title: '创建日期', width: 100 },
            { field: 'Note', title: '备注', width: 100 }
        ]]
    });

};

GlassStore.StoreAdd = function () {

    $('#btnSubmit').click(function() {
        var formOptions = {
            defaultbefore: false,
            dataType: 'json',
            success: function(data, status, xhr, $form) {

                if (data.success) {
                    $.messager.alert('提示', '保存成功', 'info');

                } else {
                    $.messager.alert('错误', '保存失败：' + data.data, 'error');
                }
            }
        };
        
        $('#StoreAdd').submitForm(formOptions);
    });

};

GlassStore.StoreDelete = function () {

    var initInput = function () {
        $("#GlassStore_Id").val("");
        $("#GlassStore_Name").val("");

        $("#GlassStore_Amount").text("");
        
        $("#Order_Id").val("");
        $("#Order_CodeNo").val("");
    };

    initInput();

    $("#select_store").click(function () {

        $("#selcet_store_dlg_content").attr("src", "/GlassStore/Index");

        var opt = {
            title: '库存信息',
            width: 650,
            height: 400,
            buttons: [{
                text: '确定',
                iconCls: 'icon-ok',
                handler: function () {
                    var glassstoreContents = $("#selcet_store_dlg_content").contents();

                    $("#GlassStore_Id").val(glassstoreContents.find("#glassstore_selected_id").val());
                    var storeShow = glassstoreContents.find("#glassstore_selected_type").val();
                    storeShow += glassstoreContents.find("#glassstore_selected_thickness").val();
                    storeShow += "【";
                    storeShow += glassstoreContents.find("#glassstore_selected_longedge").val();
                    storeShow += " * ";
                    storeShow += glassstoreContents.find("#glassstore_selected_shortedge").val();
                    storeShow += "】";
                    $("#GlassStore_Name").val(storeShow);
                    
                    $("#GlassStore_Amount").text(glassstoreContents.find("#glassstore_selected_amount").val());

                    $("#selcet_store_dlg").dialog('close');
                }
            }, {
                text: '取消',
                iconCls: 'icon-cancel',
                handler: function () {
                    $("#selcet_store_dlg").dialog('close');
                }
            }]
        };

        $("#selcet_store_dlg").show();
        $("#selcet_store_dlg").dialog(opt);

        return false;

    });
    
    $("#select_order").click(function () {

        $("#selcet_order_dlg_content").attr("src", "/Order/Index");

        var opt = {
            title: '订单信息',
            width: 650,
            height: 400,
            buttons: [{
                text: '确定',
                iconCls: 'icon-ok',
                handler: function () {
                    var glassstoreContents = $("#selcet_order_dlg_content").contents();

                    $("#Order_Id").val(glassstoreContents.find("#order_selected_id").val());
                    $("#Order_CodeNo").val(glassstoreContents.find("#order_selected_codeno").val());

                    $("#selcet_order_dlg").dialog('close');
                }
            }, {
                text: '取消',
                iconCls: 'icon-cancel',
                handler: function () {
                    $("#selcet_order_dlg").dialog('close');
                }
            }]
        };

        $("#selcet_order_dlg").show();
        $("#selcet_order_dlg").dialog(opt);

        return false;

    });


    $('#btnSubmit').click(function() {
        var formOptions = {
            defaultbefore: false,
            dataType: 'json',
            success: function(data, status, xhr, $form) {

                if (data.success) {
                    $.messager.alert('提示', '保存成功', 'info');
                    initInput();

                } else {
                    $.messager.alert('错误', '保存失败：' + data.data, 'error');
                }
            }
        };
        
        $('#StoreDelete').submitForm(formOptions);
    });

};