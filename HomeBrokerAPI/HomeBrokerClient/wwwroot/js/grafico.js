google.charts.load('current', { 'packages': ['corechart'] });
google.charts.setOnLoadCallback(drawChart);

var chartData;

function drawChart() {
    var auxData2 = Object.values(chartData);
    console.log(JSON.parse(auxData2));
        //JSON.parse(chartData);

    
    console.log(chartData);

    var auxData = [
            ['Year', 'Sales', 'Expenses'],
            ['2004', 1000, 400],
            ['2005', 1170, 460],
            ['2006', 660, 1120],
            ['2007', 1030, 540]
        ];

    var data = google.visualization.arrayToDataTable(auxData);

    var options = {
        //title: 'Company Performance',
        curveType: 'function',
        legend: { position: 'bottom' }
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
        success: function (data) {
            //console.table(data);
            chartData = data;
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