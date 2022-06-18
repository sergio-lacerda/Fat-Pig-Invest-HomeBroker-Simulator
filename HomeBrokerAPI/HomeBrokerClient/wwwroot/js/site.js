function ofertasTicker() {

    return false;
}


function atualizaTotal() {
    var pQtd = $('#inAmount').val();
    var pPreco = $('#inPrice').val();
    var pTotal = 0;

    if ($.isNumeric(pQtd) && $.isNumeric(pPreco) && (pQtd > 0) && (pPreco > 0)) {
        pTotal = pQtd * pPreco;        
    }
    $('#inTotal').val(parseFloat(pTotal).toFixed(2));
}

function validaDados() {
    var pData = $('#inDate').val();
    var pTicker = $('#inTickerOrder').val();
    var pQtd = $('#inAmount').val();
    var pPreco = $('#inPrice').val();
    var pAssinatura = $('#inSign').val();
}
