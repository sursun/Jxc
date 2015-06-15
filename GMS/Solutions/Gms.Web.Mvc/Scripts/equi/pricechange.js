
var EquiPriceChange;
if (!EquiPriceChange) {
    EquiPriceChange = {};
}

EquiPriceChange.Init = function () {
    
    $('#equi_search_list').datagridEx({
        toolbar: '#toolbar',
        pagination: true,
        singleSelect: true,
        columns: [[
            { field: 'EquiType', title: '物料类型', width: 100 },
            { field: 'EquiName', title: '名称', width: 140 },
            { field: 'EquiModel', title: '型号', width: 100 },
            { field: 'Quantity', title: '原库存量', width: 140 },
            { field: 'OldPrice', title: '原价格', width: 100 },
            { field: 'NewPrice', title: '新价格', width: 140 },
            { field: 'UserName', title: '操作人', width: 100 },
            { field: 'CreateDateTimeString', title: '变动时间', width: 140 }
        ]]
    });

};
