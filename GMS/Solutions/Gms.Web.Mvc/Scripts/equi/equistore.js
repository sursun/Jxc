
var EquiStore;
if (!EquiStore) {
    EquiStore = {};
}

EquiStore.In = function () {
    
    var features = 'dialogHeight=720px; dialogWidth=900px; center=yes;location=0; resizable=0; status=0';

    $('#equi_in_search_list').datagridEx({
        toolbar: '#toolbar',
        pagination: true,
        singleSelect: true,
        columns: [
            [
                {
                    field: 'CodeNo',
                    title: '入库单号',
                    width: 110,
                    formatter: function(value, row, index) {
                        if (row.Id) {
                            return "<a  href='#'>" + value + "</a>";
                        } else {
                            return "";
                        }
                    }
                },
                { field: 'EquiFromName', title: '来源', width: 60 },
                { field: 'Price', title: '总价格', width: 100 },
                { field: 'UserName', title: '入库人', width: 100 },
                { field: 'CreateDateTimeString', title: '入库时间', width: 140 },
                { field: 'Note', title: '备注', width: 200 }
            ]
        ],
        onClickCell: function(rowIndex, field, value) {
            if (field != "CodeNo")
                return false;

            //if (value < 1)
            //    return false;

            var row = $("#equi_in_search_list").datagrid('getRows')[rowIndex];

            if (row == null)
                return false;

            var vReturnValue = window.showModalDialog('/EquiStore/EditIn?id=' + row.Id, '', features);
            if (vReturnValue != undefined) {
                $('#equi_in_search_list').datagridEx("reload");
            }

            return false;
        }
    });

    $("#btnAdd").click(function() {

        var vReturnValue = window.showModalDialog('/EquiStore/EditIn?id=0', '', features);
        if (vReturnValue != undefined) {
            $('#equi_in_search_list').datagridEx("reload");
        }

    });

};

EquiStore.EditIn = function () {

    $('#equi_in_list').datagrid({
        toolbar: '#toolbar',
        singleSelect: true,
        columns: [
            [
                { field: 'EquiType', title: '物料类型', width: 100 },
                { field: 'Name', title: '名称', width: 100 },
                { field: 'Model', title: '型号', width: 100 },
                { field: 'Unit', title: '单位', width: 60 },
                { field: 'Quantity', title: '数量', width: 80, editor: 'text' },
                { field: 'Price', title: '单价(元)', width: 80, editor: 'text' }
            ]
        ],
        onDblClickRow: onDblClickRow
    });

    function onDblClickRow(index, row) {
        if (editIndex != index) {
            if (endEditing()) {
                $('#equi_in_list').datagrid('selectRow', index)
                .datagrid('beginEdit', index);
                editIndex = index;
            } else {
                $('#equi_in_list').datagrid('selectRow', editIndex);
            }
        } else {
            endEditing();
        }
    };

    var editIndex = undefined;
    function endEditing() {

        if (editIndex != undefined) {

            if ($('#equi_in_list').datagrid('validateRow', editIndex)) {

                $('#equi_in_list').datagrid('endEdit', editIndex);
                editIndex = undefined;

                //
                //计算总价
                //
                var totalPrice = 0;
                var dataRows = $('#equi_in_list').datagrid('getData').rows;
                for (var i in dataRows) {
                    var row = dataRows[i];
                    var p = parseFloat(row.Price);
                    var q = parseFloat(row.Quantity);
                    totalPrice += (p * q);
                }

                $("#Price").val(totalPrice.toFixed(2));

            } else {
                return false;
            }
        }

        return true;
    };

    function insertRow(rowItem) {

        if (!endEditing()) {
            return false;
        }

        var rows = $('#equi_in_list').datagrid('getData').rows;
        for (var index in rows) {
            if (rowItem.Id == rows[index].Id) {
                alert("此物料已经存在！");
                return false;
            }
        }
        
        $('#equi_in_list').datagrid('insertRow', {
            index: 0, // index start with 0
            row: rowItem
        });
    };

    $("#btnAdd").click(function() {

        if (!endEditing()) {
            return false;
        }

        $("#selcet_equi_dlg_content").attr("src", "/Equipment/Index");

        var opt = {
            title: '物料信息',
            width: 700,
            height: 500,
            buttons: [
                {
                    text: '确定',
                    iconCls: 'icon-ok',
                    handler: function() {
                        var equiContents = $("#selcet_equi_dlg_content").contents();
                        
                        insertRow({
                            Id: equiContents.find("#equi_selected_id").val(),
                            EquiType: equiContents.find("#equi_selected_type").val(),
                            Name: equiContents.find("#equi_selected_name").val(),
                            Model: equiContents.find("#equi_selected_model").val(),
                            Unit: equiContents.find("#equi_selected_unit").val(),
                            Price:equiContents.find("#equi_selected_price").val()
                        });
                        

                        $("#selcet_equi_dlg").dialog('close');
                    }
                }, {
                    text: '取消',
                    iconCls: 'icon-cancel',
                    handler: function() {
                        $("#selcet_equi_dlg").dialog('close');
                    }
                }
            ]
        };

        $("#selcet_equi_dlg").show();
        $("#selcet_equi_dlg").dialog(opt);

        return false;
    });

    $("#btnDel").click(function () {
        var row = $('#equi_in_list').datagrid("getSelected");
        var index = $('#equi_in_list').datagrid("getRowIndex", row);
        $('#equi_in_list').datagrid("deleteRow", index);
    });

    $("#btnSave").click(function () {

        if (!endEditing()) {
            return false;
        }
        
        var datagridData = $('#equi_in_list').datagrid('getData');

        var aToStr = JSON.stringify(datagridData.rows);

        var id = $("#Id").val();
        var codeno = $("#CodeNo").val();
        var equifrom = $("#EquiFrom").val();
        var note = $("#Note").val();
        var price = $("#Price").val();

        $.post("/EquiStore/StoreInSaveOrUpdate", {
            id: id,
            codeno: codeno,
            equifromid: equifrom,
            note: note,
            price: price,
            equis: aToStr
        }, function(data) {
            if (data.success) {

                //alert("保存成功！");
                window.returnValue = "true";
                window.close();

            } else {
                alert(data.data);
            }
        }, "json");
    });
};

EquiStore.Out = function () {

    var features = 'dialogHeight=720px; dialogWidth=900px; center=yes;location=0; resizable=0; status=0';

    $('#equi_out_search_list').datagridEx({
        toolbar: '#toolbar',
        pagination: true,
        singleSelect: true,
        columns: [[
            {
                field: 'CodeNo',
                title: '出库单号',
                width: 110,
                formatter: function(value, row, index) {
                    if (row.Id) {
                        return "<a  href='#'>" + value + "</a>";
                    } else {
                        return "";
                    }
                }
            },
            { field: 'EquiToName', title: '用途', width: 60 },
            { field: 'Price', title: '总价格', width: 100 },
            { field: 'UserName', title: '出库人', width: 100 },
            { field: 'CreateDateTimeString', title: '出库时间', width: 140 },
            { field: 'Note', title: '备注', width: 200 }
        ]],
        onClickCell: function (rowIndex, field, value) {
            if (field != "CodeNo")
                return false;

            var row = $("#equi_out_search_list").datagrid('getRows')[rowIndex];

            if (row == null)
                return false;

            var vReturnValue = window.showModalDialog('/EquiStore/EditOut?id=' + row.Id, '', features);
            if (vReturnValue != undefined) {
                $('#equi_out_search_list').datagridEx("reload");
            }

            return false;
        }
    });

    $("#btnAdd").click(function () {

        var vReturnValue = window.showModalDialog('/EquiStore/EditOut?id=0', '', features);
        if (vReturnValue != undefined) {
            $('#equi_out_search_list').datagridEx("reload");
        }

    });
    
};

EquiStore.EditOut = function () {

    $('#equi_out_list').datagrid({
        toolbar: '#toolbar',
        singleSelect: true,
        columns: [
            [
                { field: 'EquiType', title: '物料类型', width: 100 },
                { field: 'Name', title: '名称', width: 100 },
                { field: 'Model', title: '型号', width: 100 },
                { field: 'Unit', title: '单位', width: 60 },
                { field: 'Quantity', title: '数量', width: 80, editor: 'text' },
                { field: 'Price', title: '单价(元)', width: 80, editor: 'text' }
            ]
        ],
        onDblClickRow: onDblClickRow
    });

    function onDblClickRow(index, row) {
        if (editIndex != index) {
            if (endEditing()) {
                $('#equi_out_list').datagrid('selectRow', index)
                .datagrid('beginEdit', index);
                editIndex = index;
            } else {
                $('#equi_out_list').datagrid('selectRow', editIndex);
            }
        } else {
            endEditing();
        }
    };

    var editIndex = undefined;
    function endEditing() {

        if (editIndex != undefined) {

            if ($('#equi_out_list').datagrid('validateRow', editIndex)) {

                $('#equi_out_list').datagrid('endEdit', editIndex);
                editIndex = undefined;

                //
                //计算总价
                //
                var totalPrice = 0;
                var dataRows = $('#equi_out_list').datagrid('getData').rows;
                for (var i in dataRows) {
                    var row = dataRows[i];
                    var p = parseFloat(row.Price);
                    var q = parseFloat(row.Quantity);
                    totalPrice += (p * q);
                }

                $("#Price").val(totalPrice.toFixed(2));

            } else {
                return false;
            }
        }

        return true;
    };

    function insertRow(rowItem) {

        if (!endEditing()) {
            return false;
        }

        var rows = $('#equi_out_list').datagrid('getData').rows;
        for (var index in rows) {
            if (rowItem.Id == rows[index].Id) {
                alert("此物料已经存在！");
                return false;
            }
        }

        $('#equi_out_list').datagrid('insertRow', {
            index: 0, // index start with 0
            row: rowItem
        });
    };

    $("#btnAdd").click(function () {

        if (!endEditing()) {
            return false;
        }

        $("#selcet_equi_dlg_content").attr("src", "/Equipment/Index");

        var opt = {
            title: '物料信息',
            width: 700,
            height: 500,
            buttons: [
                {
                    text: '确定',
                    iconCls: 'icon-ok',
                    handler: function () {
                        var equiContents = $("#selcet_equi_dlg_content").contents();

                        insertRow({
                            Id: equiContents.find("#equi_selected_id").val(),
                            EquiType: equiContents.find("#equi_selected_type").val(),
                            Name: equiContents.find("#equi_selected_name").val(),
                            Model: equiContents.find("#equi_selected_model").val(),
                            Unit: equiContents.find("#equi_selected_unit").val(),
                            Price: equiContents.find("#equi_selected_price").val()
                        });


                        $("#selcet_equi_dlg").dialog('close');
                    }
                }, {
                    text: '取消',
                    iconCls: 'icon-cancel',
                    handler: function () {
                        $("#selcet_equi_dlg").dialog('close');
                    }
                }
            ]
        };

        $("#selcet_equi_dlg").show();
        $("#selcet_equi_dlg").dialog(opt);

        return false;
    });

    $("#btnDel").click(function() {
        var row = $('#equi_out_list').datagrid("getSelected");
        var index = $('#equi_out_list').datagrid("getRowIndex",row);
        $('#equi_out_list').datagrid("deleteRow", index);
    });

    $("#btnSave").click(function () {

        if (!endEditing()) {
            return false;
        }

        var datagridData = $('#equi_out_list').datagrid('getData');

        var aToStr = JSON.stringify(datagridData.rows);

        var id = $("#Id").val();
        var codeno = $("#CodeNo").val();
        var equito = $("#EquiTo").val();
        var note = $("#Note").val();
        var price = $("#Price").val();
        
        $.post("/EquiStore/StoreOutSaveOrUpdate", {
            id: id,
            codeno: codeno,
            equitoid: equito,
            note: note,
            price: price,
            equis: aToStr
        }, function (data) {
            if (data.success) {

                //alert("保存成功！");
                window.returnValue = "true";
                window.close();

            } else {
                alert(data.data);
            }
        }, "json");
    });
};


