/* Creating a timer to reload the partial view data each x seconds */

var timer_miliseconds = 5000;

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
    setInterval('atualiza_Partial_View("Home", "pvMinhasAcoes", "#divPvMinhasAcoes")', timer_miliseconds);
    setInterval('atualiza_Partial_View("Home", "pvOfertas", "#divPvOfertas")', timer_miliseconds);
    setInterval('atualiza_Partial_View("Home", "pvOrdens", "#divPvOrdens")', timer_miliseconds);
})


