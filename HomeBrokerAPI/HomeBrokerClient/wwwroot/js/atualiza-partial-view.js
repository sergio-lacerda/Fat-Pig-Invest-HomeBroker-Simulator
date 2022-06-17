/* Creating a timer to reload the partial view data each N seconds */

// timer in miliseconds to reload partial view
var timer_miliseconds = 5000;

// parameter for pvOfertas action method (if it have any)
var ticker = '';

// This function gets the input value (txt-parametro) and stores it
// at the global var 'parametro', so the function 'atualiza_Partial_View'
// can use it to create the MVC URI.
function atualiza_param() {
    ticker = $("#inTicker").val();
}

// This function gets values from an action and updates a specific DIV:
//     * pController - Name of the Controller
//     * pAction - Name of the Action Method
//     * pDiv - Id of the DIV to be updated
function atualiza_Partial_View(pController, pAction, pDiv) {
    var actionUrl = window.location.origin + '/' + pController + '/' + pAction;

    // Only for pvOfertas action method
    if (pAction =="pvOfertas" && ticker != '' && ticker != null && ticker != undefined)
        actionUrl = actionUrl + '/' + ticker;

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

// Setting the timer to get data and update the partial views
$(document).ready(function () {
    setInterval('atualiza_Partial_View("Home", "pvMinhasAcoes", "#divPvMinhasAcoes")', timer_miliseconds);
    setInterval('atualiza_Partial_View("Home", "pvOfertas", "#divPvOfertas")', timer_miliseconds);
    setInterval('atualiza_Partial_View("Home", "pvOrdens", "#divPvOrdens")', timer_miliseconds);
})


