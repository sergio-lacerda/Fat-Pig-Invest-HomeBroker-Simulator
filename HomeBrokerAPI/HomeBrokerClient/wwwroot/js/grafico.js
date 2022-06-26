google.charts.load('current', { 'packages': ['corechart'] });
google.charts.setOnLoadCallback(drawChart);

var chartData;
var auxData;

function drawChart() {
    if (chartData == '[]')
        auxData = [];

    if ((auxData == null) || (auxData == undefined) || (auxData.length==0)) {
        auxData = [['Tempo', 'Compra', 'Venda']];
        //auxData.push(['0', 0.00, 0.00]);
    }        
    
    if ((chartData != null) && (chartData != undefined) && (chartData!='[]')) {
        var ofertas = JSON.parse(chartData);

        if (auxData.length < 5) {
            for (var reg in ofertas) {
                var temp = [
                    ofertas[reg].tempo,
                    ofertas[reg].compra,
                    ofertas[reg].venda
                ];
                auxData.push(temp);
            }
        }
        else {
            var temp = [
                ofertas[ofertas.length - 1].tempo,
                ofertas[ofertas.length - 1].compra,
                ofertas[ofertas.length - 1].venda
            ];
            auxData.push(temp);

            if (auxData.length >= 15)
                auxData.splice(1,1);
        }                
    }

    var data = google.visualization.arrayToDataTable(auxData);

    var formatter = new google.visualization.NumberFormat({ decimalSymbol: ',', groupingSymbol: '.', prefix: 'R$ ' });
    formatter.format(data, 1);
    formatter.format(data, 2);

    var options = {
        //title: 'Company Performance',
        curveType: 'function',
        legend: { position: 'bottom' },
        vAxis: { format: 'currency' }
    };

    var chart = new google.visualization.LineChart(document.getElementById('curve_chart'));

    chart.draw(data, options);
}


function updateChart() {
    var ticker = $("#inTicker").val();
    var actionUrl = window.location.origin + '/Home/pvGrafico';

    // Only for pvOfertas action method
    if (ticker != '' && ticker != null && ticker != undefined)
        actionUrl = actionUrl + '/' + ticker;
    
    $.ajax({
        url: actionUrl,
        type: 'POST',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (data) {            
            chartData = JSON.stringify(data);
            drawChart();
            return false;
        }
    });

    return false;
}

// timer in miliseconds to reload partial view
var timer_miliseconds = 5000;

// Setting the timer to get data and update the partial view
$(document).ready(function () {
    setInterval('updateChart()', timer_miliseconds);
})