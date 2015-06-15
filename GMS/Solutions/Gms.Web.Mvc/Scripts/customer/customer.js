
var Customer;
if (!Customer) {
    Customer = {};
}

Customer.Init = function () {

    $('#customer_search_list').datagridEx({
        toolbar: '#toolbar',
        pagination: true,
        singleSelect:true,
        columns: [[
            { field: 'Name', title: '姓名', width: 100 },
            { field: 'Mobile', title: '电话', width: 100 },
            { field: 'Company', title: '公司', width: 100 },
            { field: 'Address', title: '地址', width: 100 },
            { field: 'Note', title: '备注', width: 100 }//,
            //{
            //    field: 'Id', title: '操作', width: 100, formatter: function (value, row, index) {
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
                $('#customer_selected_id').val(rowData.Id);
                $('#customer_selected_name').val(rowData.Name);
                $('#customer_selected_mobile').val(rowData.Mobile);
                $('#customer_selected_company').val(rowData.Company);
                $('#customer_selected_note').val(rowData.Note);
            }
            
        }
    });

    $("#customerform").validate({
        onkeyup: false,
        onfocusout: false,
        rules: {
            Name: "required",
            Mobile: "required"
        },
        messages: {
            Name: "请输入姓名",
            Mobile: "请输入手机号码"
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

};

