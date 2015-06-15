
var Print;
if (!Print) {
    Print = {};
}

Print.Init = function () {
    
    $("#btnPrint").click(function () {
        
        window.document.body.innerHTML = $("#PrintData").html();
        window.print();

        return false;
    });

    
};
