
var Order;
if (!Order) {
    Order = {};
}

Order.Init = function () {
    
    $("a.OrderInfo").live('click', function () {
        var rec = $("#order_search_list").datagrid("getSelected");
        if (rec == null) {
            return false;
        }
        
        var url = this.hash.substr(1, this.hash.length) + "?id=" + rec.Id;
        
        parent.addNewTab("修改订单" + rec.CodeNo,url,true);
        //window.location = url;
        
        return false;
    });
    
    $("a.OrderPrint").live('click', function () {
        var rec = $("#order_search_list").datagrid("getSelected");
        if (rec == null) {
            return false;
        }

        window.top.open(this.hash.substr(1, this.hash.length) + "?id=" + rec.Id);
        //window.location = this.hash.substr(1, this.hash.length) + "?id=" + rec.Id;
        
        return false;
    });    
    
    $('#order_search_list').datagridEx({
        toolbar: '#toolbar',
        pagination: true,
        singleSelect: true,
        columns: [[
            { field: 'CodeNo', title: '订单编号', width: 100 },
            { field: 'CustomerString', title: '客户信息', width: 140 },
            { field: 'RealTotalPrice', title: '实收金额', width: 100 },
            { field: 'DeliveryDate', title: '交货日期', width: 140 },
            { field: 'CreateUser', title: '录单员', width: 100 },
            { field: 'CreateTime', title: '创建日期', width: 140},
            { field: 'OrderState', title: '订单状态', width: 100 }//,
            //{
            //    field: 'OrderState', title: '操作', width: 100, formatter: function (value, row, index) {
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
                $('#order_selected_id').val(rowData.Id);
                $('#order_selected_codeno').val(rowData.CodeNo);

                loadDetail(rowData.Id);
            }
        }
    });

    function loadDetail(rowId) {
        $("#DetailDiv").attr("src", "/Order/Edit?isOnlyRead=true&id=" + rowId);

        $("#DetailDiv").show();

        $("#EmptyDiv").hide();
        
    }
};

Order.Edit = function () {

    

    //------------ 订单产品 --------------------------------//
    $('#oreder_products').datagrid({
        singleSelect: true,
        columns: [[
            { field: 'Name', title: '产品名称', width: 100 },
            { field: 'GlassTypeString', title: '玻璃品种', width: 140 },
            { field: 'ThicknessString', title: '玻璃厚度', width: 100 },
            {
                field: 'LongEdge', title: '规格', width: 140, formatter: function (value, row, index) {
                    return row.LongEdge + "*" + row.ShortEdge;
                }
            },
            { field: 'EdgeLength', title: '边长', width: 100 },
            { field: 'Area', title: '面积', width: 100 },
            { field: 'Quantity', title: '数量', width: 100 },
            { field: 'Price', title: '小计', width: 100 },
            { field: 'Note', title: '说明', width: 100 }
        ]]
    });

    $("#btnEditProducts").click(function () {

        var url = this.hash.substr(1);

        $("#edit_products_dlg_content").attr("src", url);

        var opt = {
            title: '产品信息',
            width: 1000,
            height: 600,
            onClose: function() {
                $('#oreder_products').datagrid("reload");
            }
            //buttons: [{
            //    text: '确定',
            //    iconCls: 'icon-ok',
            //    handler: function () {
            //        var customerContents = $("#selcet_customer_dlg_content").contents();

            //        $("#Customer_Id").val(customerContents.find("#customer_selected_id").val());
            //        $("#new_customer_name").val(customerContents.find("#customer_selected_name").val());
            //        $("#new_customer_mobile").val(customerContents.find("#customer_selected_mobile").val());
            //        $("#new_customer_company").val(customerContents.find("#customer_selected_company").val());

            //        //选择客户信息后，禁止编辑
            //        $("#new_customer_name").attr("disabled", true);
            //        $("#new_customer_mobile").attr("disabled", true);
            //        $("#new_customer_company").attr("disabled", true);

            //        $("#edit_products_dlg").dialog('close');
            //    }
            //}, {
            //    text: '取消',
            //    iconCls: 'icon-cancel',
            //    handler: function () {
            //        $("#edit_products_dlg").dialog('close');
            //    }
            //}]
        };

        $("#edit_products_dlg").show();
        $("#edit_products_dlg").dialog(opt);

        return false;

    });


    //------------保存订单基本信息--------------------------------//
    $("#btnsave").click(function () {
 
        $('#formorder').form('submit', {
            onSubmit: function (param) {
                param.Note = escape(editor.html());
                param.RealTotalPrice = $("input[name='RealTotalPrice']").val();
                param.TotalPrice = $("input[name='TotalPrice']").val();

            },
            success: function (data) {
                $.messager.alert('提示', '提交成功', 'info', function () {
                    //window.location.reload();
                    //window.history.back(-1);
                    
                    try {
                        parent.closeSelectedTab();
                    }
                    catch (err) {
                        window.location.href = document.referrer;
                    }
                    
                });
                
            }   
        });  

    });

    //----------------------------------------- 选择客户信息 -------------------------------------//
    
    $("#editCustomer").click(function() {
        $("#Customer_Id").val('0');

        $("#new_customer_name").attr("disabled", false);
        $("#new_customer_mobile").attr("disabled", false);
        $("#new_customer_company").attr("disabled", false);

    });
    
    $("#selectCustomer").click(function () {
       
        $("#selcet_customer_dlg_content").attr("src", "/Customer/Index");

        var opt = {
            title: '客户信息',
            width: 550,
            height:300,
            buttons: [{
                text: '确定',
                iconCls: 'icon-ok',
                handler: function () {
                    var customerContents = $("#selcet_customer_dlg_content").contents();
           
                    $("#Customer_Id").val(customerContents.find("#customer_selected_id").val());
                    $("#new_customer_name").val(customerContents.find("#customer_selected_name").val());
                    $("#new_customer_mobile").val(customerContents.find("#customer_selected_mobile").val());
                    $("#new_customer_company").val(customerContents.find("#customer_selected_company").val());
                    
                    //选择客户信息后，禁止编辑
                    $("#new_customer_name").attr("disabled", true);
                    $("#new_customer_mobile").attr("disabled", true);
                    $("#new_customer_company").attr("disabled", true);
                   
                    $("#selcet_customer_dlg").dialog('close');
                }
            }, {
                text: '取消',
                iconCls: 'icon-cancel',
                handler: function () {
                    $("#selcet_customer_dlg").dialog('close');
                }
            }]
        };
        
        $("#selcet_customer_dlg").show();
        $("#selcet_customer_dlg").dialog(opt);

        return false;

    });
    
    //----------------------------------------- 选择加工过程 -------------------------------------//
    $("#selectCureProcess").click(function () {

        $("#selcet_cureprocess_dlg_content").attr("src", "/CureProcess/Select");

        var opt = {
            title: '选择加工过程',
            width: 550,
            height: 300,
            buttons: [{
                text: '确定',
                iconCls: 'icon-ok',
                handler: function () {
                    var cureprocessContents = $("#selcet_cureprocess_dlg_content").contents();

                    $("#CureProcess_Id").val(cureprocessContents.find("#process_selected_id").val());
                    $("#CureProcess_Name").val(cureprocessContents.find("#process_selected_name").val());
                    $("#CureProcess_Desc").val(cureprocessContents.find("#process_selected_desc").val());

                    $("#selcet_cureprocess_dlg").dialog('close');
                }
            }, {
                text: '取消',
                iconCls: 'icon-cancel',
                handler: function () {
                    $("#selcet_cureprocess_dlg").dialog('close');
                }
            }]
        };

        $("#selcet_cureprocess_dlg").show();
        $("#selcet_cureprocess_dlg").dialog(opt);

        return false;

    });


    //---------备注编辑器---------------------------//
    var editor;
    KindEditor.ready(function (K) {

        editor = K.create('#Note', {
            uploadJson: '/Order/UploadFile',
            fileManagerJson: '/Order/FileManager',
            items : [
						'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|', 'emoticons', 'image'],
            afterChange: function() {
         
                var self = this;
                self.sync();

        }
        });
        
        editor.html(unescape(editor.html()));

    });
    
    //---------  附件删除  ---------------------------//
    $(".deletefile").live("click", function() {
        var url = this.hash.substr(1, this.hash.length);
        var item = $(this).parent(".file_item");

        $.post(url, {}, function (data) {
            if (data.success) {
                item.remove();
            }
        },"json");
    });
};

Order.View = function () {

    $('#product_search_list').datagrid({
        singleSelect: true,
        columns: [[
            { field: 'Name', title: '产品名称', width: 100 },
            { field: 'GlassTypeString', title: '玻璃品种', width: 140 },
            { field: 'ThicknessString', title: '玻璃厚度', width: 100 },
            { field: 'LongEdge', title: '规格', width: 140, formatter: function(value, row, index) {
                return row.LongEdge + "*" + row.ShortEdge;
            } },
            { field: 'EdgeLength', title: '边长', width: 100 },
            { field: 'Area', title: '面积', width: 100 },
            { field: 'Quantity', title: '数量', width: 100 },
            { field: 'Price', title: '小计', width: 100 },
            { field: 'Note', title: '说明', width: 100 }
        ]]
    });

    $('#productcure_search_list').datagrid({
        singleSelect: true,
        columns: [[
            { field: 'CureTypeName', title: '加工类型', width: 80 },
            { field: 'UserName', title: '加工人员', width: 80 },
            { field: 'CheckUserName', title: '负责人', width: 80 },
            { field: 'StartTimeString', title: '开始时间', width: 100 },
            { field: 'EndTimeString', title: '结束时间', width: 100 }
        ]]
    });

    $('#productcure_edit').dialog({
        title: '加工信息',
        height: 300,
        width: 400,
        closed: true,
        buttons: [{
            text: '保存',
            handler: function () {
                var formOptions = {
                    defaultbefore: false,
                    clear: false,
                    dataType: 'json',
                    success: function (data, status, xhr, $form) {

                        if (data.success) {
                            $.messager.alert('提示', '保存成功！');
                            $('#productcure_edit').dialog("close");
                            $('#productcure_search_list').datagrid("reload");
                        } else {
                            $.messager.alert('错误', '保存失败：' + data.data, 'error');
                        }
                    }
                };

                $("Form", $('#productcure_edit')).submitForm(formOptions);
            }
        }, {
            text: '关闭',
            handler: function () {
                $('#productcure_edit').dialog("close");
            }
        }]
    });

    $('#change_status_dlg').dialog({
        title: '修改订单状态',
        height: 150,
        width: 160,
        closed: true,
        buttons: [{
            text: '保存',
            handler: function () {
                var orderid = $("input[name='Order.Id']").val();
                var stat = $("select[name='OrderState']").val();
                $.post("/Order/ChangeState", { id: orderid,state: stat }, function (data) {
                    if (data.success) {

                        $.messager.alert('提示', '修改成功！');

                        window.location.reload();
                       // $('#change_status_dlg').dialog("close");

                    } else {
                        $.messager.alert('错误', '修改失败：' + data.data, 'error');
                    }
                },"json");
               
            }
        }, {
            text: '关闭',
            handler: function () {
                $('#change_status_dlg').dialog("close");
            }
        }]
    });

    $("#btnChangeStatus").click(function () {
        $('#change_status_dlg').dialog("open");
    });

    $("#btnAdd").click(function() {
        $('#productcure_edit').dialog("open");
    });

};