﻿/*
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
        return false;
    }

    if (!$.isNumeric(pQtd) || (pQtd <= 0)) {
        $('#errorMessage').html("A quantidade deve ser um valor numérico positivo!");
        $('#errorMessage').show();
        return false;
    }

    if ((pQtd % 100) != 0) {
        $('#errorMessage').html("Mercado fracionário não permitido. Informe quantidades de lote padrão!");
        $('#errorMessage').show();
        return false;
    }

    if (!$.isNumeric(pPreco) || (pPreco <= 0)) {
        $('#errorMessage').html("O preço deve ser um valor numérico positivo!");
        $('#errorMessage').show();
        return false;
    }

    if (pAssinatura === "") {
        $('#errorMessage').html("Informe a assinatura eletrônica!");
        $('#errorMessage').show();
        return false;
    }
    
}
