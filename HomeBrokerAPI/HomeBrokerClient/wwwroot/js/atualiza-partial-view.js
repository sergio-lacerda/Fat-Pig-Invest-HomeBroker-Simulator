/* Creating a timer to reload the partial view data each x seconds */

function atualiza_Partial_View() {
    var actionUrl = window.location.origin + "/Home/pvMinhasAcoes";

    $.ajax({         
        url: actionUrl,
        type: 'POST',
        dataType: 'html',
        cache: false,
        success: function (html) {            
            $('#divPvMinhasAcoes').html(html);            
        }
    });

    
}

$(document).ready(function () {
    setInterval('atualiza_Partial_View()', 5000);
})