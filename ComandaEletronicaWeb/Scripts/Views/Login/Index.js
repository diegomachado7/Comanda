$("#btnValidarAcesso").click(function () {
    var msg = "";
    var email = $("#txtEmail").val();
    var senha = $("#txtSenha").val();
    if (email === "") {
        msg = "Por favor, informe o e-mail para autenticação.<br />";
    }
    if (senha === "") {
        msg += "Por favor, informe uma senha para o processo de autenticação.";
    }
    if (msg.length > 0) {
        Mensagem("divAlerta", msg);
    }
    else {
        $("#divLoading").show(300);
        $.ajax({
            type: 'POST',
            url: '/Login/Validar',
            data: { Email: email, Senha: senha },
            success: function (result) {
                $("#divLoading").hide(300);
                if (result.length > 0) {
                    Mensagem("divAlerta", result);
                }
                else {
                    window.location.href = "/Dashboard";
                }
            },
            error: function (XMLHttpRequest, txtStatus, errorThrown) {
                alert("Status: " + txtStatus); alert("Error: " + errorThrown);
                $("#divLoading").hide(300);
            }
        });
    }
});