/* Creating a timer to reload the partial view data each x seconds */

/*
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

*/

function atualiza_Partial_View(pHome, pAction, pDiv) {
    var actionUrl = window.location.origin + '/' + pHome + '/' + pAction;

    $.ajax({
        url: actionUrl,
        type: 'POST',
        dataType: 'html',
        cache: false,
        success: function (html) {
            $(pDiv).html(html);
        }
    });
}

$(document).ready(function () {
    setInterval('atualiza_Partial_View("Home", "pvMinhasAcoes", "#divPvMinhasAcoes")', 5000);
    setInterval('atualiza_Partial_View("Home", "pvOfertas", "#divPvOfertas")', 5000);
    setInterval('atualiza_Partial_View("Home", "pvOrdens", "#divPvOrdens")', 5000);
})


