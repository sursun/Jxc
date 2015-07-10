
var Goods;
if (!Goods) {
    Goods = {};
}

Goods.Init = function () {

    var features = 'dialogHeight=480; dialogWidth=800; center=yes;location=0; resizable=0; status=0';

    $('#entity_search_list').datagridEx({
        toolbar: '#toolbar',
        pagination: true,
        singleSelect: true,
        fitColumns: true,
        columns: [
            [
                { field: 'CodeNo', title: '编码', width: 100 },
                {
                    field: 'BarCode',
                    title: '条码',
                    width: 100,
                    formatter: function (value, row, index) {
                        
                            return "<a class='btnDetail' href='#" + row.Id + "' >" + value + "</a>";
                        
                    }
                },
                { field: 'Name', title: '名称', width: 100 },
                { field: 'Pinyin', title: '简拼', width: 100 },
                { field: 'Model', title: '规格型号', width: 100 },
                { field: 'UnitName', title: '单位', width: 100 },
                { field: 'Quantity', title: '库存数量', width: 100 },
                { field: 'MinQuantity', title: '最低数量', width: 100 },
                { field: 'MaxQuantity', title: '最高数量', width: 100 },
                { field: 'BrandName', title: '品牌', width: 100 },
                { field: 'DisplayStandsName', title: '陈列架', width: 100 },
                { field: 'PurchasePrice', title: '进价', width: 100 },
                { field: 'RetailPrice', title: '零售价', width: 100 },
                { field: 'MinPrice', title: '最低限价', width: 100 },
                { field: 'IsBarginStr', title: '是否特价', width: 100 },
                { field: 'BarginPrice', title: '特价', width: 100 },
                { field: 'IsFreePriceStr', title: '允许前台改价销售', width: 100 },
                { field: 'PointBase', title: '积分金额', width: 100 },
                { field: 'GoodsStatusStr', title: '商品状态', width: 100 },
                { field: 'Note', title: '备注', width: 100 },
                { field: 'CreateTimeStr', title: '创建时间', width: 100 }
            ]
        ]
    });

    $("#btnAdd").click(function () {
        
        var vReturnValue = window.showModalDialog('/Goods/Edit', '', features);
        if (vReturnValue != undefined) {
            $('#entity_search_list').datagridEx("reload");
        }

    });
    
    $("#btnEdit").click(function () {

        var rec = $('#entity_search_list').datagridEx("getSelected");

        if (rec == null ) {
            return;
        }

        var vReturnValue = window.showModalDialog('/Goods/Edit?id=' + rec.Id, '', features);
        if (vReturnValue != undefined) {
            $('#entity_search_list').datagridEx("reload");
        }

    });

    $(".btnDetail").live("click", function () {

        var nId = this.hash.substr(1);

        window.showModalDialog('/Goods/Detail?id=' + nId, '', features);

    });

};

Goods.Edit = function () {

    $("#entityform").validate({
        onkeyup: false,
        onfocusout: false,
        rules: {
            CodeNo: "required",
            Name: "required"
        },
        messages: {
            CodeNo: "请输入编号",
            Name: "请输入商品名称"
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
    
    //----------------------------------------- 商品类别维护 -------------------------------------//
    $("#btnAddCategory").live("click", function () {
        var nType = this.hash.substr(1);
        $("#selcet_category_dlg_content").attr("src", "/CommonCode/Select?type=" + nType);

        var opt = {
            title: '选择商品类别',
            width: 680,
            height: 380,
            buttons: [{
                text: '确定',
                iconCls: 'icon-ok',
                handler: function () {
                    var deptContents = $("#selcet_category_dlg_content").contents();

                    var nId = deptContents.find("#commoncode_selected_Id").val();
                    var strName = deptContents.find("#commoncode_selected_FullName").val();

                    appendCategoryItem(nId,strName);

                    $("#selcet_category_dlg").dialog('close');
                }
            }, {
                text: '取消',
                iconCls: 'icon-cancel',
                handler: function () {
                    $("#selcet_category_dlg").dialog('close');
                }
            }]
        };

        $("#selcet_category_dlg").show();
        $("#selcet_category_dlg").dialog(opt);

        return false;

    });

    $(".deleteCategory").live("click", function () {
        $(this).parent().remove();
    });

    var appendCategoryItem = function (id, fullname) {

        removeCategoryItem(id);

        var htmlContent = "<div class='goods_category_item'><span>" + fullname + "</span> <input name='categorys' value='";
        htmlContent += id;
        htmlContent += "' style='display: none'/><a href='#' class='deleteCategory'>删除</a></div>";
        $("#btnAddCategory").before(htmlContent);
    };

    var removeCategoryItem = function (id) {
        $.each($("#btnAddCategory").parent().find("input"), function () {
            var destVal = $(this).val();

            if(id == destVal)
                $(this).parent().remove();
        });
        
    };
};

Goods.Select = function () {

    var features = 'dialogHeight=480; dialogWidth=800; center=yes;location=0; resizable=0; status=0';

    $('#entity_search_list').datagridEx({
        toolbar: '#toolbar',
        pagination: true,
        singleSelect: true,
        fitColumns: true,
        columns: [
            [
                { field: 'CodeNo', title: '编码', width: 100 },
                {
                    field: 'BarCode',
                    title: '条码',
                    width: 100,
                    formatter: function (value, row, index) {

                        return "<a class='btnDetail' href='#" + row.Id + "' >" + value + "</a>";

                    }
                },
                { field: 'Name', title: '名称', width: 100 },
                { field: 'Pinyin', title: '简拼', width: 100 },
                { field: 'Model', title: '规格型号', width: 100 },
                { field: 'UnitName', title: '单位', width: 100 },
                { field: 'Quantity', title: '库存数量', width: 100 },
                { field: 'MinQuantity', title: '最低数量', width: 100 },
                { field: 'MaxQuantity', title: '最高数量', width: 100 },
                { field: 'BrandName', title: '品牌', width: 100 },
                { field: 'DisplayStandsName', title: '陈列架', width: 100 },
                { field: 'PurchasePrice', title: '进价', width: 100 },
                { field: 'RetailPrice', title: '零售价', width: 100 },
                { field: 'MinPrice', title: '最低限价', width: 100 },
                { field: 'IsBarginStr', title: '是否特价', width: 100 },
                { field: 'BarginPrice', title: '特价', width: 100 },
                { field: 'IsFreePriceStr', title: '允许前台改价销售', width: 100 },
                { field: 'PointBase', title: '积分金额', width: 100 },
                { field: 'GoodsStatusStr', title: '商品状态', width: 100 },
                { field: 'Note', title: '备注', width: 100 },
                { field: 'CreateTimeStr', title: '创建时间', width: 100 }
            ]
        ],
        onSelect: function (rowIndex, rowData) {
            if (rowData != null) {
                $('#goods_selected_Id').val(rowData.Id);
                $('#goods_selected_Name').val(rowData.Name);
            }

        }
    });

    $(".btnDetail").live("click", function () {

        var nId = this.hash.substr(1);

        window.showModalDialog('/Goods/Detail?id=' + nId, '', features);

    });

};

