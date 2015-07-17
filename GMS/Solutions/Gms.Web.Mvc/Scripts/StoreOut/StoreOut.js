
var StoreOut;
if (!StoreOut) {
    StoreOut = {};
}

StoreOut.Init = function () {

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
                { field: 'Amount', title: '本次应收款', width: 100 },

                { field: 'AmountReceipt', title: '本次收款', width: 100 },

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
        
        var vReturnValue = window.showModalDialog('/StoreOut/Add', '', features);
        if (vReturnValue != undefined) {
            $('#entity_search_list').datagridEx("reload");
        }

    });
    
    $("#btnEdit").click(function () {

        var rec = $('#entity_search_list').datagridEx("getSelected");

        if (rec == null ) {
            return;
        }

        var vReturnValue = window.showModalDialog('/StoreOut/Edit?id=' + rec.Id, '', features);
        if (vReturnValue != undefined) {
            $('#entity_search_list').datagridEx("reload");
        }

    });

    $(".btnDetail").live("click", function () {

        var nId = this.hash.substr(1);

        window.showModalDialog('/StoreOut/Detail?id=' + nId, '', features);

    });

};

StoreOut.Audit = function () {

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
                { field: 'Amount', title: '本次应收款', width: 100 },

                { field: 'AmountReceipt', title: '本次收款', width: 100 },

                { field: 'Debt', title: '本次欠款', width: 100 },
                { field: 'Payer', title: '付款人', width: 100 },
                { field: 'Payee', title: '收款人', width: 100 },

                { field: 'SupplierName', title: '供应商', width: 100 },
                { field: 'BuyerName', title: '采购员', width: 100 },
                { field: 'StoreInTypeName', title: '入库类型', width: 100 },
                
                { field: 'Note', title: '备注', width: 100 },
                { field: 'CreatorName', title: '登记人', width: 100 },
                { field: 'CreateTimeString', title: '登记日期', width: 100 },
            {
                field: 'Pass', title: '通过', width: 100, formatter: function (value, row, index) {
                    if (row.Id) {
                        return "<a class='btnAudit' href='#1" + row.Id + "' >通过</a>";
                    } else {
                        return "";
                    }
                }
            },
            {
                field: 'NoPass', title: '不通过', width: 100, formatter: function (value, row, index) {
                    if (row.Id) {
                        return "<a class='btnAudit' href='#0" + row.Id + "'>不通过</a>";
                    } else {
                        return "";
                    }
                }
            }
            ]
        ]
    });

    $(".btnAudit").live("click", function () {
        var nPass = this.hash.substr(1, 1);
        var nId = this.hash.substr(2);

        $.post("/StoreOut/SaveAudit", { id: nId, pass: nPass }, function (data) {
            if (data.success) {

                $('#entity_search_list').datagridEx("reload");

            } else {
                $.messager.alert('错误', '审核失败：' + data.data, 'error');
            }
        }, 'json');
    });

    $(".btnDetail").live("click", function () {

        var nId = this.hash.substr(1);

        window.showModalDialog('/StoreOut/Detail?id=' + nId, '', features);

    });

};

StoreOut.Add = function () {

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
                    //$.messager.alert('提示', '保存成功', 'info');
                   
                    window.location = '/StoreOut/Edit?id=' + data.data.Id;

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

    $("#selectCustomer").live("click", function () {

        $("#selcet_item_dlg_content").attr("src", "/Customer/Select");

        var opt = {
            title: '选择客户',
            width: 680,
            height: 380,
            buttons: [{
                text: '确定',
                iconCls: 'icon-ok',
                handler: function () {
                    var deptContents = $("#selcet_item_dlg_content").contents();

                    var nId = deptContents.find("#customer_selected_id").val();
                    var strName = deptContents.find("#customer_selected_name").val();

                    $("#Customer_Id").val(nId);
                    $("#Customer_Name").val(strName);

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

    $("#selectSeller").live("click", function () {

        $("#selcet_item_dlg_content").attr("src", "/User/Select");

        var opt = {
            title: '选择销售员',
            width: 680,
            height: 380,
            buttons: [{
                text: '确定',
                iconCls: 'icon-ok',
                handler: function () {
                    var deptContents = $("#selcet_item_dlg_content").contents();

                    var nId = deptContents.find("#user_selected_Id").val();
                    var strName = deptContents.find("#user_selected_LoginName").val();

                    $("#Seller_Id").val(nId);
                    $("#Seller_Name").val(strName);

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

StoreOut.Edit = function () {

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

        if (!endEditing()) {
            return false;
        }

        var datagridData = $('#entity_search_list').datagrid('getData');

        var aToStr = JSON.stringify(datagridData.rows);

        $("#sgoods").val(aToStr);
        //var other = $("#Other").val();
        //var sport = $("#Sport").val();
        //var note = $("#Note").val();
        //var id = $("#treatmentId").val();


        //$.post("/Health/SaveOrUpdateTreatment", {
        //    treatmentid: id,
        //    medicates: aToStr,
        //    other: other,
        //    sport: sport,
        //    note: note
        //}, function (data) {
        //    if (data.success) {

        //        alert("保存成功！");

        //    } else {
        //        alert(data.data);
        //    }
        //}, "json");

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

    $("#selectCustomer").live("click", function () {

        $("#selcet_item_dlg_content").attr("src", "/Customer/Select");

        var opt = {
            title: '选择客户',
            width: 680,
            height: 380,
            buttons: [{
                text: '确定',
                iconCls: 'icon-ok',
                handler: function () {
                    var deptContents = $("#selcet_item_dlg_content").contents();

                    var nId = deptContents.find("#customer_selected_id").val();
                    var strName = deptContents.find("#customer_selected_name").val();

                    $("#Customer_Id").val(nId);
                    $("#Customer_Name").val(strName);

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

    $("#selectSeller").live("click", function () {

        $("#selcet_item_dlg_content").attr("src", "/User/Select");

        var opt = {
            title: '选择销售员',
            width: 680,
            height: 380,
            buttons: [{
                text: '确定',
                iconCls: 'icon-ok',
                handler: function () {
                    var deptContents = $("#selcet_item_dlg_content").contents();

                    var nId = deptContents.find("#user_selected_Id").val();
                    var strName = deptContents.find("#user_selected_LoginName").val();

                    $("#Seller_Id").val(nId);
                    $("#Seller_Name").val(strName);

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

    $("#selectAccount").live("click", function () {

        $("#selcet_item_dlg_content").attr("src", "/Account/Select");

        var opt = {
            title: '选择结算账户',
            width: 680,
            height: 380,
            buttons: [{
                text: '确定',
                iconCls: 'icon-ok',
                handler: function () {
                    var deptContents = $("#selcet_item_dlg_content").contents();

                    var nId = deptContents.find("#account_selected_Id").val();
                    var strName = deptContents.find("#account_selected_Name").val();

                    $("#Account_Id").val(nId);
                    $("#Account_Name").val(strName);

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
        textField: 'Pinyin',
        columns: [[
            { field: 'CodeNo', title: '编码', width: 120 },
            { field: 'BarCode', title: '条码', width: 100 },
            { field: 'Name', title: '名称', width: 100 },
            { field: 'BrandName', title: '商品品牌', width: 100 },
            { field: 'Model', title: '规格型号', width: 100 },
            { field: 'UnitName', title: '单位', width: 100 }
        ]],
        onSelect: function (record) {

            var g = $('#ccQuickAdd').combogrid('grid');	// get datagrid object
            var r = g.datagrid('getSelected');	// get the selected row
            insertRow(r.Id);
        }
    });

    $('#entity_search_list').datagrid({
        toolbar: '#toolbar',
        singleSelect: true,
        columns: [
            [
                { field: 'BarCode', title: '条码', width: 100 },
                { field: 'Name', title: '名称', width: 80 },
                { field: 'BrandName', title: '商品品牌', width: 100 },
                { field: 'Model', title: '规格型号', width: 100 },
                { field: 'UnitName', title: '单位', width: 100 },
                { field: 'Price', title: '单价', width: 100, editor: { type: "numberbox", options: { precision: 2 } } },
                { field: 'StoreGoodsQuantity', title: '数量', width: 100, editor: { type: "numberbox", options: { precision: 2 } } },
                { field: 'TotalAomount', title: '总额', width: 100 },
                { field: 'StoreGoodsNote', title: '备注', width: 100, editor: 'text' },
                {
                    field: 'Caozuo',
                    title: '操作',
                    width: 80,
                    formatter: function(value, row, index) {

                        return '<a href="#">移除</a>';

                    }
                }
            ]
        ],
        onClickCell: function(index, field, value) {

            if (field != "Caozuo") {
                return false;
            }

            if (endEditing()) {
                $(this).datagrid('deleteRow', index);
                //event.preventDefault();
            }

            return true;
        },
        onDblClickRow: onDblClickRow
    });

    function onDblClickRow(index, row) {
        if (editIndex != index) {
            if (endEditing()) {
                $('#entity_search_list').datagrid('selectRow', index)
                .datagrid('beginEdit', index);
                editIndex = index;
            } else {
                $('#entity_search_list').datagrid('selectRow', editIndex);
            }
        } else {
            endEditing();
        }
    };

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

    function insertRow(nId) {

        if (!endEditing()) {
            return false;
        }

        var rows = $('#entity_search_list').datagrid('getData').rows;
        for (var index in rows) {
            if (nId == rows[index].Id) {
                $.messager.alert("提示", "此商品已经存在！");
                return false;
            }
        }

        $.post("/Goods/GetGoods", { id: nId }, function (data) {
            if (data.success) {

                $('#entity_search_list').datagrid('insertRow', {
                    index: 0, // index start with 0
                    row: data.data
                });
            }
        }, "json");


    };

    var editIndex = undefined;
    function endEditing() {
        if (editIndex == undefined) {
            return true;
        }
        if ($('#entity_search_list').datagrid('validateRow', editIndex)) {
            var ed = $('#entity_search_list').datagrid('getEditor', { index: editIndex, field: 'Price' });
            var price = $(ed.target).numberbox('getValue');

            ed = $('#entity_search_list').datagrid('getEditor', { index: editIndex, field: 'StoreGoodsQuantity' });
            var quantity = $(ed.target).numberbox('getValue');

            var totalAomount = price * quantity;

            $('#entity_search_list').datagrid('getRows')[editIndex]['TotalAomount'] = totalAomount;

            //ed = $('#entity_search_list').datagrid('getEditor', { index: editIndex, field: 'DoseTypeName' });
            //var doseString = $(ed.target).combobox('getText');
            //$('#entity_search_list').datagrid('getRows')[editIndex]['DoseTypeName'] = doseString;

            $('#entity_search_list').datagrid('endEdit', editIndex);
            editIndex = undefined;
            return true;
        } else {
            return false;
        }
    };
};

StoreOut.Detail = function () {
 
    $('#entity_search_list').datagrid({
        toolbar: '#toolbar',
        singleSelect: true,
        columns: [
            [
                { field: 'BarCode', title: '条码', width: 100 },
                { field: 'Name', title: '名称', width: 80 },
                { field: 'BrandName', title: '商品品牌', width: 100 },
                { field: 'Model', title: '规格型号', width: 100 },
                { field: 'UnitName', title: '单位', width: 100 },
                { field: 'Price', title: '单价', width: 100 },
                { field: 'StoreGoodsQuantity', title: '数量', width: 100},
                { field: 'TotalAomount', title: '总额', width: 100 },
                { field: 'StoreGoodsNote', title: '备注', width: 100 }
            ]
        ]
    });

};
