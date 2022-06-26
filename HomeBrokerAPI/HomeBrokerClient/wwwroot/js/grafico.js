google.charts.load('current', { 'packages': ['corechart'] });
google.charts.setOnLoadCallback(drawChart);

var chartData;
var auxData;
var lastValue;

function drawChart() {
    if (chartData == '[]')
        auxData = [];

    if ((auxData == null) || (auxData == undefined) || (auxData.length==0)) {
        auxData = [['Tempo', 'Compra', 'Venda']];
        auxData.push(['Sem dados', 0.00, 0.00]);
    }
        
    if ((chartData != null) && (chartData != undefined) && (chartData!='[]')) {
        var ofertas = JSON.parse(chartData);

        if (auxData.length < 5) {
            auxData = [['Tempo', 'Compra', 'Venda']];

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
                auxData.splice(1, 1);

            // Reseting data if range changes too much (probably ticker change)
            if (Math.abs(lastValue - ofertas[ofertas.length - 1].venda) >= 1.00) {
                auxData = [['Tempo', 'Compra', 'Venda']];
                auxData.push(['Sem dados', 0.00, 0.00]);
            }
            lastValue = ofertas[ofertas.length - 1].venda;
        }                
    }

    var data = google.visualization.arrayToDataTable(auxData);

    var options = {
        //title: 'Preços de compra e venda '+ ticker,
        curveType: 'function',
        legend: { position: 'bottom' },
        vAxis: {
            format: 'R$ #.00'
            //viewWindow: {
            //    min: 12.45,
            //    max: 12.55
            //}
            //ticks: [12.00, 12.25, 12.50, 12.75, 13.00]
        }
    };

    var chart = new google.visualization.LineChart(document.getElementById('curve_chart'));

    chart.draw(data, options);
}


function updateChart() {    
    var actionUrl = window.location.origin + '/Home/pvGrafico';

    // Only for pvOfertas action method (ticker is defined at atualiza-partial-view.js)
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