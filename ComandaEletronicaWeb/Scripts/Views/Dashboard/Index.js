$("#btnPesquisarProduto").click(function () {
    var palavra = "";
    if ($("#txtPalavraChaveProduto").val() === "") {
        palavra = "%";
    }
    else {
        palavra = $("#txtPalavraChaveProduto").val();
    }
    $("#divLoading").show(300);
    $.ajax({
        type: 'POST',
        url: '/Produto/ObterPorPalavraChave',
        data: { Palavra: palavra },
        success: function (result) {
            if (result !== null && result.length > 0) {
                PreencherTabela(result);
            }
            else {
                alert("Nenhum produto encontrado.");
            }
            $("#divLoading").hide(300);
        },
        error: function (XMLHttpRequest, txtStatus, errorThrown) {
            alert("Status: " + txtStatus); alert("Error: " + errorThrown);
            $("#divLoading").hide(300);
        }
    });
});

function PreencherTabela(dados) {
    var txt = '<thead>\
                <tr>\
                    <th>Nome</th>\
                    <th>Descricao</th>\
                    <th>Valor</th>\
                    <th></th>\
                    <th></th>\
                </tr>\
                </thead>\
                <tbody>';
    $.each(dados, function () {
        txt = txt +
            '<tr>' +
            '<td>' + this.Nome + '</td>' +
            '<td>' + this.Descricao + '</td>' +
            '<td>' + "R$ " + this.Valor + '</td>' +
            '<td><a role="button" class="btn btn-warning" href="javascript:Alterar(' + this.ProdutoId + ')">Alterar</a></td>' +
            '<td><a role="button" class="btn btn-danger" href="javascript:Excluir(' + this.ProdutoId + ')">Excluir</a></td>' +
            '</tr> '
    })
    txt = txt + '</tbody>';
    $("#tabelaProduto").html(txt);
}

$("#btnConfirmarProduto").click(function () {
    var msg = "";
    var produtoId = $("#txtProdutoId").val();
    var nome = $("#txtNome").val();
    var descricao = $("#txtDescricao").val();
    var valor = $("#txtValor").val().replace(",", ".");

    if (nome === "") {
        msg += "Por favor, informe um nome para o produto.<br />";
    }
    if (descricao === "") {
        msg += "Por favor, informe uma descrição para o produto.<br />";
    }
    if (valor === "") {
        msg += "Por favor, informe um valor para o produto.<br />";
    }
    if (msg.length > 0) {
        Mensagem("divAlertaNovoProduto", msg);
    }
    else {
        $("#divLoading").show(300);
        $.ajax({
            type: 'POST',
            url: '/Produto/Gravar',
            data: { ProdutoId: produtoId, Nome: nome, Descricao: descricao, Valor: valor },
            success: function (result) {
                $("#divLoading").hide(300);
                if (result.length > 0) {
                    Mensagem("divAlertaNovoProduto", result);
                }
                else {
                    LimparFormulario();
                    $.fancybox.close();
                }
            },
            error: function (XMLHttpRequest, txtStatus, errorThrown) {
                alert("Status: " + txtStatus); alert("Error: " + errorThrown);
                $("#divLoading").hide(300);
            }
        });
    }
});

function LimparFormulario() {
    $("#txtId").val("0");
    $("input[type='text']").val("");
    $("input[type='date']").val("0000-00-00");
    $("textarea").val("");
}

function Alterar(id) {
    $("#divLoading").show(300);
    $.ajax({
        type: 'POST',
        url: '/Produto/Obter',
        data: { Id: id},
        success: function (result) {
            if (result) {
                $("#divLoading").hide(300);
                $.fancybox.open({
                    src: '#formProduto',
                    type: 'inline'
                });
                $("#txtProdutoId").val(result.ProdutoId);
                $("#txtNome").val(result.Nome);
                $("#txtDescricao").val(result.Descricao);
                $("#txtValor").val(result.Valor);
            }
            else {
                $.fancybox.close();
            }
        },
        error: function (XMLHttpRequest, txtStatus, errorThrown) {
            alert("Status: " + txtStatus); alert("Error: " + errorThrown);
            $("#divLoading").hide(300);
        }
    });
}

function Excluir(id) {
    if (confirm("Excluir?")) {
        $.ajax({
            type: 'POST',
            url: '/Produto/Excluir',
            data: { Id: id },
            success: function (result) {
                if (result === "") {
                    alert("Produto excluído com sucesso.");
                    window.parent.location.href = "/Dashboard";
                }
                else {
                    Mensagem("divAlerta", result);
                }
            },
            error: function (XMLHttpRequest, txtStatus, errorThrown) {
                alert("Status: " + txtStatus); alert("Error: " + errorThrown);
                $("#divLoading").hide(300);
            }
        });
    }
}

//PULSEIRA
$("#btnPesquisarPulseira").click(function () {
    var palavra = "";
    if ($("#txtPalavraChavePulseira").val() === "") {
        palavra = "%";
    }
    else {
        palavra = $("#txtPalavraChavePulseira").val();
    }
    $("#divLoading").show(300);
    $.ajax({
        type: 'POST',
        url: '/Pulseira/ObterPorPalavraChave',
        data: { Palavra: palavra },
        success: function (result) {
            if (result !== null && result.length > 0) {
                PreencherTabelaPulseira(result);
            }
            else {
                alert("Nenhuma pulseira encontrada.");
            }
            $("#divLoading").hide(300);
        },
        error: function (XMLHttpRequest, txtStatus, errorThrown) {
            alert("Status: " + txtStatus); alert("Error: " + errorThrown);
            $("#divLoading").hide(300);
        }
    });
});

function PreencherTabelaPulseira(dados) {
    var txt = '<thead>\
                <tr>\
                    <th>Id</th>\
                    <th></th>\
                    <th></th>\
                </tr>\
                </thead>\
                <tbody>';
    $.each(dados, function () {
        txt = txt +
            '<tr>' +
            '<td>' + this.PulseiraId + '</td>' +
            '<td><a role="button" class="btn btn-danger" href="javascript:ExcluirPulseira(' + this.PulseiraId + ')">Excluir</a></td>' +
            '</tr> '
    })
    txt = txt + '</tbody>';
    $("#tabelaPulseira").html(txt);
}

$("#btnCadastrarPulseira").click(function () {
    var msg = "";
    if (msg.length > 0) {
        Mensagem("divAlertaNovoPulseira", msg);
    }
    else {
        $("#divLoading").show(300);
        $.ajax({
            type: 'POST',
            url: '/Pulseira/Gravar',
            data: { },
            success: function (result) {
                $("#divLoading").hide(300);
                if (result.length > 0) {
                    Mensagem("divAlertaNovoPulseira", result);
                }
                else {
                    LimparFormulario();
                    $.fancybox.close();
                }
            },
            error: function (XMLHttpRequest, txtStatus, errorThrown) {
                alert("Status: " + txtStatus); alert("Error: " + errorThrown);
                $("#divLoading").hide(300);
            }
        });
    }
});

function ExcluirPulseira(id) {
    if (confirm("Excluir?")) {
        $.ajax({
            type: 'POST',
            url: '/Pulseira/Excluir',
            data: { Id: id },
            success: function (result) {
                if (result === "") {
                    alert("Pulseira excluída com sucesso.");
                    window.parent.location.href = "/Dashboard";
                }
                else {
                    Mensagem("divAlerta", result);
                }
            },
            error: function (XMLHttpRequest, txtStatus, errorThrown) {
                alert("Status: " + txtStatus); alert("Error: " + errorThrown);
                $("#divLoading").hide(300);
            }
        });
    }
}