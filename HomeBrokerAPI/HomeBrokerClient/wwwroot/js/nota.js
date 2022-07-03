/*
   This function saves the page as a PDF format file
 */
async function salvar_pdf() {

    try {
        //const elemento = document.getElementById("nota-container");
        var pagina = '<!DOCTYPE html> ';
        pagina += '<html lang="pt-br"> ';
        pagina += '<head>  ';
        pagina += '<meta charset="utf-8"/> ';
        pagina += '<title> Nota de Negociação</title> ';
        pagina += '</head> ';
        pagina += '<body> ';
        pagina += elemento.innerHTML;
        pagina += ' </body> ';
        pagina += '</html> ';

        var win = window.open("", "Title", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,width=780,height=200,top=" + (screen.height - 400) + ",left=" + (screen.width - 840));
        win.document.body.innerHTML = pagina;

        pagina.scale = 0.7;

        const opt = {
            margin: 10,
            filename: "Nota-de-negociacao.pdf",
            image: { type: "jpeg", quality: 0.98 },
            html2canvas: { scale: 2 },
            jsPDF: { unit: "mm", format: "A4", orientation: "portrait" }
        };

        await html2pdf().set(opt).from(pagina).save();
        return true;
    }
    catch (e) {
        console.log("Deu ruim!");
    }

    
}
