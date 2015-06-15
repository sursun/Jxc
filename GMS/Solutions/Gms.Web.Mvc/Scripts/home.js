var Home;
if (!Home) {
    Home = {};
}

Home.Init = function () {
    
    
    $('#funTree').tree({
        onClick: function (node) {
            if (node.attributes == undefined || node.attributes.url == undefined)
                return true;

            var unique = true;
            
            if (node.attributes != undefined && node.attributes.unique != undefined) {
                unique = node.attributes.unique;
            }
            
            addNewTab(node.text, node.attributes.url, unique);
            
            return false;
        }
    });
   
};

var addNewTab = function (title, url, unique) {

    var tabContent = "<iframe style='width: 100%;height:98%;border: none;'></iframe>";

    if (unique) {
        //
        //如果存在，直接选中
        //
        if ($('#mainTab').tabs('exists', title)) {
            $('#mainTab').tabs('select', title);
            return true;
        }

    } else {
        //
        //如果存在，后面加数字1,2,3.。。。。
        //
        var tmpTitle = title;
        var index = 0;
        while ($('#mainTab').tabs('exists', tmpTitle)) {
            index++;
            tmpTitle = title + index;
        }

        title = tmpTitle;
        
    }

    $('#mainTab').tabs('add', {
        title: title,
        content: tabContent,
        closable: true,
        selected: true
    });

    $("iframe", $('#mainTab').tabs('getTab', title)).attr("src", url);

};


var closeSelectedTab = function () {
    var tab = $('#mainTab').tabs('getSelected');
    var index = $('#mainTab').tabs('getTabIndex', tab);
    $('#mainTab').tabs('close', index);
};