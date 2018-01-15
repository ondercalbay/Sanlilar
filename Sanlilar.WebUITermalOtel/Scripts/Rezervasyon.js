
function RezervasyonGonder() {
    var Ad = $("#txtAd").val();
    var Eposta = $("#txtEposta").val();
    var Telefon = $("#txtTelefon").val();
    var GirisTarihi = $("#txtGirisTarihi").val();
    var CikisTarihi = $("#txtCikisTarihi").val();    

    Data = 'action=RezervasyonGonder&Ad=' + Ad + 'Ad=' + Ad;

    $.ajax({
        cache: false,
        global: false,
        async: true,
        type: 'POST',
        dataType: "json",
        data: Data,
        url: '../ajax.aspx',
        beforeSend: function () {
            WaitingShow();
        },
        success: function (veri) {
            try {
                if (veri.hataId == 0) {
                    $('#mesaj_' + mesajId).remove();
                    var mesajAdet = $('#spnMesajAdet').html();
                    if (mesajAdet != "" && mesajAdet > 1) {
                        $('#spnMesajAdet').html(mesajAdet - 1);
                    }
                    else {
                        $('#spnMesajAdet').html("");
                    }
                } else {
                    Mesaj(veri.hataStr);
                }
                $('#wait').hide();
            } catch (e) {
                $('#wait').hide();
                Mesaj(e.Message);
            }
        },
        error: function (hata) {
            Hata(hata);
        },
        complete: function () {
            WaitingHide();
        }
    });
}