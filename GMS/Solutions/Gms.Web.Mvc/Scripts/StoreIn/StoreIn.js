
var StoreIn;
if (!StoreIn) {
    StoreIn = {};
}

StoreIn.Init = function () {

    var features = 'dialogHeight=480; dialogWidth=800; center=yes;location=0; resizable=0; status=0';

    $('#entity_search_list').datagridEx({
        toolbar: '#toolbar',
        pagination: true,
        singleSelect: true,
        fitColumns: true,
        columns: [
            [
                { field: 'CodeNo', title: '票号', width: 120,
                    formatter: function (value, row, index) {
                        
                        return "<a class='btnDetail' href='#" + row.Id + "' >" + value + "</a>";

                    } },
                {
                    field: 'OrderCode',
                    title: '单据编号',
                    width: 100
                },
                { field: 'OrderTimeStr', title: '单据日期', width: 100 },
                { field: 'StoreName', title: '仓库', width: 80 },
                { field: 'AccountName', title: '结算账户', width: 100 },
                { field: 'Amount', title: '本次应付款', width: 100 },

                { field: 'AmountPay', title: '本次付款', width: 100 },

                { field: 'Debt', title: '本次欠款', width: 100 },
                { field: 'Payer', title: '付款人', width: 100 },
                { field: 'Payee', title: '收款人', width: 100 },

                { field: 'SupplierName', title: '供应商', width: 100 },
                { field: 'BuyerName', title: '采购员', width: 100 },
                { field: 'StoreInTypeName', title: '入库类型', width: 100 },

                { field: 'AuditorName', title: '审核人', width: 100 },
                { field: 'AuditTimeString', title: '审核日期', width: 100 },
                { field: 'AuditState', title: '审核状态', width: 100 },
                
                { field: 'Note', title: '备注', width: 100 },
                { field: 'CreatorName', title: '登记人', width: 100 },
                { field: 'CreateTimeString', title: '登记日期', width: 100 }
            ]
        ]
    });

    $("#btnAdd").click(function () {
        
        var vReturnValue = window.showModalDialog('/StoreIn/Edit', '', features);
        if (vReturnValue != undefined) {
            $('#entity_search_list').datagridEx("reload");
        }

    });
    
    $("#btnEdit").click(function () {

        var rec = $('#entity_search_list').datagridEx("getSelected");

        if (rec == null ) {
            return;
        }

        var vReturnValue = window.showModalDialog('/StoreIn/Edit?id=' + rec.Id, '', features);
        if (vReturnValue != undefined) {
            $('#entity_search_list').datagridEx("reload");
        }

    });

    $(".btnDetail").live("click", function () {

        var nId = this.hash.substr(1);

        window.showModalDialog('/Goods/Detail?id=' + nId, '', features);

    });

};

StoreIn.Add = function () {

    $("#entityform").validate({
        onkeyup: false,
        onfocusout: false,
        rules: {
            OrderCode: "required",
        },
        messages: {
            OrderCode: "请输入单据编号"
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
        //window.location = '/StoreIn/Edit?id=1';
        //return;
        var formOptions = {
            defaultbefore: false,
            beforeSubmit: function (arr, $form) {
                var result = $form.valid();
                return result;
            },
            success: function (data) {

                if (data.success) {
                    //$.messager.alert('提示', '保存成功', 'info');
                   
                    window.location = '/StoreIn/Edit?id=' + data.data.Id;

                } else {
                    $.messager.alert('错误', '保存失败：' + data.data, 'error');
                }
            }
        };

        formOptions.dataType = 'json';

        $('#entityform').submitForm(formOptions);

    });
    
    $("#selectStore").live("click", function () {

        var nType = this.hash.substr(1);

        $("#selcet_item_dlg_content").attr("src", "/CommonCode/Select?type=" + nType);

        var opt = {
            title: '选择仓库',
            width: 680,
            height: 380,
            buttons: [{
                text: '确定',
                iconCls: 'icon-ok',
                handler: function () {
                    var deptContents = $("#selcet_item_dlg_content").contents();

                    var nId = deptContents.find("#commoncode_selected_Id").val();
                    var strName = deptContents.find("#commoncode_selected_FullName").val();

                    $("#Store_Id").val(nId);
                    $("#Store_Name").val(strName);
                     
                    $("#selcet_item_dlg").dialog('close');
                }
            }, {
                text: '取消',
                iconCls: 'icon-cancel',
                handler: function () {
                    $("#selcet_item_dlg").dialog('close');
                }
            }]
        };

        $("#selcet_item_dlg").show();
        $("#selcet_item_dlg").dialog(opt);

        return false;

    });

    $("#selectSupplier").live("click", function () {

        $("#selcet_item_dlg_content").attr("src", "/Supplier/Select");

        var opt = {
            title: '选择供应商',
            width: 680,
            height: 380,
            buttons: [{
                text: '确定',
                iconCls: 'icon-ok',
                handler: function () {
                    var deptContents = $("#selcet_item_dlg_content").contents();

                    var nId = deptContents.find("#supplier_selected_id").val();
                    var strName = deptContents.find("#supplier_selected_name").val();

                    $("#Supplier_Id").val(nId);
                    $("#Supplier_Name").val(strName);

                    $("#selcet_item_dlg").dialog('close');
                }
            }, {
                text: '取消',
                iconCls: 'icon-cancel',
                handler: function () {
                    $("#selcet_item_dlg").dialog('close');
                }
            }]
        };

        $("#selcet_item_dlg").show();
        $("#selcet_item_dlg").dialog(opt);

        return false;

    });

    $("#selectBuyer").live("click", function () {

        $("#selcet_item_dlg_content").attr("src", "/User/Select");

        var opt = {
            title: '选择采购员',
            width: 680,
            height: 380,
            buttons: [{
                text: '确定',
                iconCls: 'icon-ok',
                handler: function () {
                    var deptContents = $("#selcet_item_dlg_content").contents();

                    var nId = deptContents.find("#user_selected_Id").val();
                    var strName = deptContents.find("#user_selected_LoginName").val();

                    $("#Buyer_Id").val(nId);
                    $("#Buyer_Name").val(strName);

                    $("#selcet_item_dlg").dialog('close');
                }
            }, {
                text: '取消',
                iconCls: 'icon-cancel',
                handler: function () {
                    $("#selcet_item_dlg").dialog('close');
                }
            }]
        };

        $("#selcet_item_dlg").show();
        $("#selcet_item_dlg").dialog(opt);

        return false;

    });

};

StoreIn.Edit = function () {

    $("#entityform").validate({
        onkeyup: false,
        onfocusout: false,
        rules: {
            OrderCode: "required",
        },
        messages: {
            OrderCode: "请输入单据编号"
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

        $('#entityform').submitForm(formOptions);

    });

    $("#selectStore").live("click", function () {

        var nType = this.hash.substr(1);

        $("#selcet_item_dlg_content").attr("src", "/CommonCode/Select?type=" + nType);

        var opt = {
            title: '选择仓库',
            width: 680,
            height: 380,
            buttons: [{
                text: '确定',
                iconCls: 'icon-ok',
                handler: function () {
                    var deptContents = $("#selcet_item_dlg_content").contents();

                    var nId = deptContents.find("#commoncode_selected_Id").val();
                    var strName = deptContents.find("#commoncode_selected_FullName").val();

                    $("#Store_Id").val(nId);
                    $("#Store_Name").val(strName);

                    $("#selcet_item_dlg").dialog('close');
                }
            }, {
                text: '取消',
                iconCls: 'icon-cancel',
                handler: function () {
                    $("#selcet_item_dlg").dialog('close');
                }
            }]
        };

        $("#selcet_item_dlg").show();
        $("#selcet_item_dlg").dialog(opt);

        return false;

    });

    $("#selectSupplier").live("click", function () {

        $("#selcet_item_dlg_content").attr("src", "/Supplier/Select");

        var opt = {
            title: '选择供应商',
            width: 680,
            height: 380,
            buttons: [{
                text: '确定',
                iconCls: 'icon-ok',
                handler: function () {
                    var deptContents = $("#selcet_item_dlg_content").contents();

                    var nId = deptContents.find("#supplier_selected_id").val();
                    var strName = deptContents.find("#supplier_selected_name").val();

                    $("#Supplier_Id").val(nId);
                    $("#Supplier_Name").val(strName);

                    $("#selcet_item_dlg").dialog('close');
                }
            }, {
                text: '取消',
                iconCls: 'icon-cancel',
                handler: function () {
                    $("#selcet_item_dlg").dialog('close');
                }
            }]
        };

        $("#selcet_item_dlg").show();
        $("#selcet_item_dlg").dialog(opt);

        return false;

    });

    $("#selectBuyer").live("click", function () {

        $("#selcet_item_dlg_content").attr("src", "/User/Select");

        var opt = {
            title: '选择采购员',
            width: 680,
            height: 380,
            buttons: [{
                text: '确定',
                iconCls: 'icon-ok',
                handler: function () {
                    var deptContents = $("#selcet_item_dlg_content").contents();

                    var nId = deptContents.find("#user_selected_Id").val();
                    var strName = deptContents.find("#user_selected_LoginName").val();

                    $("#Buyer_Id").val(nId);
                    $("#Buyer_Name").val(strName);

                    $("#selcet_item_dlg").dialog('close');
                }
            }, {
                text: '取消',
                iconCls: 'icon-cancel',
                handler: function () {
                    $("#selcet_item_dlg").dialog('close');
                }
            }]
        };

        $("#selcet_item_dlg").show();
        $("#selcet_item_dlg").dialog(opt);

        return false;

    });

    $('#ccQuickAdd').combogrid({
        panelWidth: 500,
        delay: 500,
        mode: 'remote',
        url: '/Goods/GetByPinyin',
        idField: 'Id',
        textField: 'Name',
        columns: [[
            { field: 'CodeNo', title: '编码', width: 120 },
            { field: 'BarCode', title: '条码', width: 100 },
            { field: 'Name', title: '名称', width: 100 },
            { field: 'BrandName', title: '商品品牌', width: 100 },
            { field: 'Model', title: '规格型号', width: 100 },
            { field: 'UnitName', title: '单位', width: 100 }
        ]],
        onSelect: function (record) {
            insertRow(record);
        }
    });

    $('#entity_search_list').datagrid({
        toolbar: '#toolbar',
        singleSelect: true,
        columns: [
            [
                
                { field: 'GoodsModel.BarCode', title: '条码', width: 100 },
                { field: 'GoodsModel.Name', title: '名称', width: 80 },
                { field: 'GoodsModel.BrandName', title: '商品品牌', width: 100 },
                { field: 'GoodsModel.Model', title: '规格型号', width: 100 },
                { field: 'GoodsModel.UnitName', title: '单位', width: 100 },

                { field: 'Price', title: '单价', width: 100 },
                { field: 'Quantity', title: '数量', width: 100 },
                { field: 'TotalAomount', title: '总额', width: 100 },

                { field: 'Note', title: '备注', width: 100 }
            ]
        ]
    });

    $("#btnAddGoods").click(function () {

        $("#selcet_item_dlg_content").attr("src", "/Goods/Select");

        var opt = {
            title: '选择商品',
            width: 680,
            height: 380,
            buttons: [{
                text: '确定',
                iconCls: 'icon-ok',
                handler: function () {
                    var dlgContents = $("#selcet_item_dlg_content").contents();

                    var nId = dlgContents.find("#goods_selected_Id").val();
  
                    $("#selcet_item_dlg").dialog('close');

                    insertRow(nId);
                    
                }
            }, {
                text: '取消',
                iconCls: 'icon-cancel',
                handler: function () {
                    $("#selcet_item_dlg").dialog('close');
                }
            }]
        };

        $("#selcet_item_dlg").show();
        $("#selcet_item_dlg").dialog(opt);
        
        return false;
    });

    function insertRow(id) {

        alert(id);
        //return;
        //var rows = $('#disease_list').datagrid('getData').rows;
        //for (var index in rows) {
        //    if (id == rows[index].Id) {
        //        $.messager.alert("提示", "此商品已经存在！");
        //        return false;
        //    }
        //}

        //$.post("/Disease/GetDisease", { id: diseaseid }, function (data) {
        //    if (data.success) {

        //        $('#disease_list').datagrid('insertRow', {
        //            index: 0, // index start with 0
        //            row: data.data
        //        });
        //    }
        //}, "json");

    };
};


