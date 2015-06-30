
var Account;
if (!Account) {
    Account = {};
}

Account.Init = function () {

    $('#acc_search_list').datagridEx({
        toolbar: '#toolbar',
        pagination: true,
        singleSelect:true,
        columns: [[
            {field: 'CodeNo', title: '编码', width: 100},
            { field: 'Name', title: '名称', width: 100 },
            { field: 'CurAmount', title: '当前金额', width: 100 },
            { field: 'BaseAmount', title: '期初金额', width: 100 },
            { field: 'CreateTimeString', title: '建账日期', width: 100 },
            { field: 'Note', title: '备注', width: 100 }
        ]]
    });

};

Account.Select = function () {

    $('#acc_search_list').datagridEx({
        pagination: true,
        singleSelect:true,
        columns: [[
            {field: 'CodeNo', title: '编码', width: 100},
            { field: 'Name', title: '名称', width: 100 },
            { field: 'CurAmount', title: '当前金额', width: 100 },
            { field: 'BaseAmount', title: '期初金额', width: 100 },
            { field: 'CreateTimeString', title: '建账日期', width: 100 },
            { field: 'Note', title: '备注', width: 100 }
        ]],
        onSelect: function (rowIndex, rowData) {
            if (rowData != null) {
                $('#account_selected_Id').val(rowData.Id);
                $('#account_selected_Name').val(rowData.Name);
            }

        }
    });

};
