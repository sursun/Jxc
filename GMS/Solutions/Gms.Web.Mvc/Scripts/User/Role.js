
var Role;
if (!Role) {
    Role = {};
}

Role.Init = function () {

    var oldSelectIndex = undefined;
    $('#role_list').datagridEx({
        toolbar: '#toolbar',
        singleSelect: true,
        columns: [[
            { field: 'RoleName', title: '角色名称' }
        ]],
        onSelect: function (rowIndex, rowData) {
            if (oldSelectIndex != undefined) {
                if (oldSelectIndex == rowIndex) {
                    return;
                }
            }
            
            oldSelectIndex = rowIndex;
            
            var baseurl = $('#roleAuth').attr('baseurl');
            $('#roleAuth').propertygrid({
                url: baseurl + "?rolename=" + rowData.RoleName,
                showGroup: true,
                scrollbarSize: 0
            });
        }
    });
    
    $('#roleAuth').propertygrid({
        columns: [[
        { field: 'name', title: '操作', width: 100 },
        { field: 'value', title: '行为', editor:{type:'checkbox',options:{on:'允许',off:''}},width: 100 }
        ]],
        onClickRow: onClickRow,
        onAfterEdit: onAfterEdit
    });

    var editIndex = undefined;

    function endEditing() {

        if (editIndex == undefined) {
            return true; }

        if ($('#roleAuth').propertygrid('validateRow', editIndex)) {

            //var ed = $('#roleAuth').propertygrid('getEditor', { index: editIndex, field: 'productid' });

            //var productname = $(ed.target).combobox('getText');

            //$('#roleAuth').propertygrid('getRows')[editIndex]['productname'] = productname;

            $('#roleAuth').propertygrid('endEdit', editIndex);

            editIndex = undefined;

            return true;

        } else {

            return false;

        }

    }

    function onClickRow(index) {

        if (editIndex != index) {

            if (endEditing()) {

                $('#roleAuth').propertygrid('selectRow', index).propertygrid('beginEdit', index);

                editIndex = index;

            } else {

                $('#roleAuth').propertygrid('selectRow', editIndex);

            }

        }

    }

    function onAfterEdit(rowIndex, rowData, changes) {
        if (changes.value == undefined) {
            return;
        }

        var bValue = true;
        if (changes.value == '') {
            bValue = false;
        }
        
        $.post("/Role/ChangeRoleAuth", { role: rowData.role, authType: rowData.group, actionPoint: rowData.name, bFlag: bValue }, function (data) {
            if (data.success) {
            } else {
                $.messager.alert('提示', '保存失败！');
            }
        }, 'json');
        
    }


    $('#RoleAdd').click(function () {
        alert("添加角色");
        
        //var gid = $(this).attr('forgid');
        //var grid = $('#' + gid);
        //var gform = $('#' + gid.substr(0, gid.length - 4) + 'edit');
        //var dlgTitle = "添加" + (gform.attr('dlgtitle') || '');


        //var pvalue = $(this).attr("parentid");

        //var url = grid.attr('edit');

        //$.post(url, { id: 0, parentid: pvalue }, function (data) {
        //    gform.gridform({ data: {}, title: dlgTitle, forgid: grid });

        return false;

    });

    //删除
    $('#RoleDel').live('click', function () {

        var grid = $('#' + $(this).attr('forgid'));
        var rec = grid.datagrid("getSelected");
        if (rec == null) {
            return false;
        }

        $.messager.confirm('提示', '确定要删除此角色信息吗？', function (b) {
            if (b) {
                var url = grid.attr('del');
                $.post(url, { roleName: rec.RoleName }, function (data) {
                    if (data.success) {

                        $.messager.alert('提示', '删除成功！', 'info', function () {
                            grid.datagrid('reload');
                        });
                    } else {
                        $.messager.alert('错误', '删除失败：' + data.data, 'error');
                    }
                }, 'json');
            }
        });
    });


};

