/*
   This function saves the page as a PDF format file
 */
async function salvar_pdf() {
    var impressao = document.getElementById('nota-container');
    
    const opt = {
        margin: 10,
        filename: "Nota-de-negociacao.pdf",
        image: { type: "jpeg", quality: 0.98 },
        html2canvas: { scale: 2 },
        jsPDF: { unit: "mm", format: "A4", orientation: "portrait" }
    };

    await html2pdf().set(opt).from(impressao).save();
    return true;   
}
