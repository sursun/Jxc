
var Equipment;
if (!Equipment) {
    Equipment = {};
}

Equipment.Init = function () {
    
    $('#equi_search_list').datagridEx({
        toolbar: '#toolbar',
        pagination: true,
        singleSelect: true,
        columns: [[
            { field: 'EquiType', title: '物料类型', width: 100 },
            { field: 'Name', title: '名称', width: 100 },
            { field: 'Model', title: '型号', width: 100 },
            { field: 'Unit', title: '单位', width: 60 },
            { field: 'Quantity', title: '库存', width: 80 },
            { field: 'Price', title: '单价(元)', width: 80 },
            { field: 'Note', title: '备注', width: 140 }
        ]],
        onSelect: function (rowIndex, rowData) {
            if (rowData != null) {
                $('#equi_selected_id').val(rowData.Id);
                $('#equi_selected_type').val(rowData.EquiType);
                $('#equi_selected_name').val(rowData.Name);
                $('#equi_selected_model').val(rowData.Model);
                $('#equi_selected_unit').val(rowData.Unit);
                $('#equi_selected_price').val(rowData.Price);
            }

        }
    });
    
};

Equipment.Warning = function () {

    $('#equi_search_list').datagridEx({
        toolbar: '#toolbar',
        pagination: true,
        singleSelect: true,
        columns: [[
            { field: 'EquiType', title: '物料类型', width: 100 },
            { field: 'Name', title: '名称', width: 100 },
            { field: 'Model', title: '型号', width: 100 },
            { field: 'Unit', title: '单位', width: 60 },
            { field: 'Quantity', title: '库存', width: 80 },
            { field: 'MinQuantity', title: '预警数量', width: 80 },
            { field: 'Price', title: '单价(元)', width: 80 },
            { field: 'Note', title: '备注', width: 140 }
        ]]
    });

};