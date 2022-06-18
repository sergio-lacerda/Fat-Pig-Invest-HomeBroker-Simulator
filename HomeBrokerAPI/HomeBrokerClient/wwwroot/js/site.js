/*
  This function calculates and updates the Total information when
  amount or price is changed.
 */   
function atualizaTotal() {
    var pQtd = $('#inAmount').val();
    var pPreco = $('#inPrice').val();
    var pTotal = 0;

    if ($.isNumeric(pQtd) && $.isNumeric(pPreco) && (pQtd > 0) && (pPreco > 0)) {
        pTotal = pQtd * pPreco;        
    }
    $('#inTotal').val(parseFloat(pTotal).toFixed(2));
}

/*
  This function cleans Error Messages.
 */
function limpaMsgErro() {
    $('#errorMessage').hide();
}

/*
   This function checks for valid parameters before submitting form data 
 */
function validaDados(pTipo) {
    $('#errorMessage').hide();
    
    var pData = $('#inDate').val();
    var pTicker = $('#inTickerOrder').val().trim();
    var pQtd = $('#inAmount').val();
    var pPreco = $('#inPrice').val();
    var pAssinatura = $('#inSign').val().trim();

    if ($.isNumeric(pQtd)) {
        pQtd = parseInt(pQtd);
        $('#inAmount').val(pQtd);
    }

    if ($.isNumeric(pPreco)) {
        pPreco = parseFloat(pPreco).toFixed(2);
        $('#inPrice').val(pPreco);
    }        
    
    if (pTicker === "") {
        $('#errorMessage').html("Informe o código da ação (Ticker)!");
        $('#errorMessage').show();
        $('#inTickerOrder').focus();
        return false;
    }

    if (!$.isNumeric(pQtd) || (pQtd <= 0)) {
        $('#errorMessage').html("A quantidade deve ser um valor numérico positivo!");
        $('#errorMessage').show();
        $('#inAmount').focus();
        return false;
    }

    if ((pQtd % 100) != 0) {
        $('#errorMessage').html("Mercado fracionário não permitido. Informe quantidades de lote padrão!");
        $('#errorMessage').show();
        $('#inAmount').focus();
        return false;
    }

    if (!$.isNumeric(pPreco) || (pPreco <= 0)) {
        $('#errorMessage').html("O preço deve ser um valor numérico positivo!");
        $('#errorMessage').show();
        $('#inPrice').focus();
        return false;
    }

    if (pAssinatura === "") {
        $('#errorMessage').html("Informe a assinatura eletrônica!");
        $('#errorMessage').show();
        $('#inSign').focus();
        return false;
    }

    var inputOrder = {
        inputOrder:
            [
                IdCorretora = 47,
                Conta = 51001,
                Tipo = pTipo,
                Ticker = pTicker.toUpperCase(),
                Quantidade = pQtd,
                PrecoUnitario = parseFloat(pPreco)
            ]
    };

    console.log(inputOrder);


    /*
    var actionUrl = window.location.origin + '/' + pController + '/' + pAction;

    // Only for pvOfertas action method
    if (pAction == "pvOfertas" && ticker != '' && ticker != null && ticker != undefined)
        actionUrl = actionUrl + '/' + ticker;

    $.ajax({
        url: actionUrl,
        type: 'POST',
        dataType: 'html',
        cache: false,
        success: function (html) {
            $(pDiv).html(html);
        }
    });*/
    
}
