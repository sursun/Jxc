
var Contact;
if (!Contact) {
    Contact = {};
}

Contact.Init = function () {

    $('#contact_search_list').datagridEx({
        toolbar: '#toolbar',
        pagination: true,
        singleSelect:true,
        columns: [[
            { field: 'Name', title: '姓名', width: 100 },
            { field: 'Mobile', title: '手机号码', width: 100 },
            { field: 'IsDefault', title: '默认联系方式', width: 100 },
            { field: 'Note', title: '备注', width: 100 }
        ]]
    });

};
