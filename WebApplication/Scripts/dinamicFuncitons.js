$(document).ready(function () {

    $('#filtroNumber').hide();
    $('#filtroText').hide();

    $("#selectFilter").on("click", function () {
        var selectedValue = $("#selectFilter").val();
        if (selectedValue == "PorNombre" || selectedValue == "PorPaisLab" || selectedValue == "PorTipoVac" || selectedValue == "PorNombreLab") {
            $('#filtroNumber').hide();
            $('#filtroNumber').attr('required', false);
            $('#filtroText').show();
            $('#filtroText').attr('required', true);
        }

    });
    
    $("#selectFilter").on("click", function () {
        var selectedValue = $("#selectFilter").val();
        if (selectedValue == "PorFaseAprob" || selectedValue == "PorTopeInferior" || selectedValue == "PorTopeSuperior") {
            $('#filtroText').hide();
            $('#filtroText').attr('required', false);
            $('#filtroNumber').show();
            $('#filtroNumber').attr('required', true);
        }
    });

    $("#ExportAlert").on("click", function () {
        alert('Archivos exportados en: corona-app\WebApplication\ExportTablas');
    });

});

function justNumbers(e) {
    var keynum = window.event ? window.event.keyCode : e.which;
    //if ((keynum == 8) || (keynum == 46))
    //return true;

    return /\d/.test(String.fromCharCode(keynum));
}