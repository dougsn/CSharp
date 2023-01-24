// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(".escolhaMes").on('change', function () {
    var mesId = $(".escolhaMes").val();

    $.ajax({
        url: "Despesas/GastoMes",
        method: "POST",
        data: { mesId: mesId },
        success: function (dados) {
            $("canvas#GraficoGastosMes").remove();
            $("div.GraficoGastosMes").append('<canvas id="GraficoGastosMes" style="height:400px;width:400px;"></canvas>');

            var ctx = document.getElementById('GraficoGastosMes').getContext('2d');

            var grafico = new Chart(ctx, {
                type: 'doughnut',

                data:
                {
                    labels: PegarTiposDespesas(dados),
                    datasets: [
                        {
                            label: "Gastos por despesa",
                            backgroundColor: PegarCores(dados.length),
                            hoverBackgroundColor: PegarCores(dados.length),
                            data: PegarValores(dados)
                        }
                    ]
                },
                options: {
                    responsive: false,
                    title: {
                        display: true,
                        text: "Gastos por despesa"
                    }
                }
            });
        }
    });
});



function CarregarDadosGastosMes() {
    var mesId = $(".escolhaMes").val();

    $.ajax({
        url: "Despesas/GastoMes",
        method: "POST",
        data: { mesId: mesId },
        success: function (dados) {
            $("canvas#GraficoGastosMes").remove();
            $("div.GraficoGastosMes").append('<canvas id="GraficoGastosMes" style="height:400px;width:400px;"></canvas>');

            var ctx = document.getElementById('GraficoGastosMes').getContext('2d');

            var grafico = new Chart(ctx, {
                type: 'doughnut',

                data:
                {
                    labels: PegarTiposDespesas(dados),
                    datasets: [
                        {
                            label: "Gastos por despesa",
                            backgroundColor: PegarCores(dados.length),
                            hoverBackgroundColor: PegarCores(dados.length),
                            data: PegarValores(dados)
                        }
                    ]
                },
                options: {
                    responsive: false,
                    title: {
                        display: true,
                        text: "Gastos por despesa"
                    }
                }
            });
        }
    });
};
function CarregarDadosGastosTotais() {

    $.ajax({
        url: 'Despesas/GastosTotais',
        method: 'POST',
        success: function (dados) {
            new Chart(document.getElementById("GraficoGastosTotais"), {
                type: 'line',

                data: {
                    labels: PegarMeses(dados),

                    datasets: [{
                        label: "Total gasto",
                        data: PegarValores(dados),
                        backgroundColor: "#ecf0f1",
                        borderColor: "#2980b9",
                        fill: false,
                        spanGaps: false
                    }]
                },
                options: {
                    title: {
                        display: true,
                        text: "Total gasto"
                    }
                }
            });
        }
    });
}
$(".escolhaMes").on('change', function () {
    var mesId = $(".escolhaMes").val();

    $.ajax({
        url: "Despesas/GastosTotaisMes",
        method: "POST",
        data: { mesId: mesId },
        success: function (dados) {
            $("canvas#GraficoGastoTotalMes").remove();
            $("div.GraficoGastoTotalMes").append('<canvas id="GraficoGastoTotalMes" style="height:400px;width:400px;"></canvas>');

            var ctx = document.getElementById('GraficoGastoTotalMes').getContext('2d');

            var grafico = new Chart(ctx, {
                type: 'doughnut',

                data:
                {
                    labels: ['Restante', 'Total gasto'],
                    datasets: [
                        {
                            label: "Total gasto",
                            backgroundColor: ["#27ae60", "#c0392b"],
                            data: [(dados.salario - dados.valorTotalGasto), dados.valorTotalGasto]
                        }
                    ]
                },
                options: {
                    responsive: false,
                    title: {
                        display: true,
                        text: "Total gasto no M�s"
                    }
                }
            });
        }
    });
});

function CarregarDadosGastosTotaisMes() {

    $.ajax({
        url: "Despesas/GastosTotaisMes",
        method: "POST",
        data: { mesId: 1 },
        success: function (dados) {
            $("canvas#GraficoGastoTotalMes").remove();
            $("div.GraficoGastoTotalMes").append('<canvas id="GraficoGastoTotalMes" style="height:400px;width:400px;"></canvas>');

            var ctx = document.getElementById('GraficoGastoTotalMes').getContext('2d');

            var grafico = new Chart(ctx, {
                type: 'doughnut',

                data:
                {
                    labels: ['Restante', 'Total gasto'],
                    datasets: [
                        {
                            label: "Total gasto",
                            backgroundColor: ["#27ae60", "#c0392b"],
                            data: [(dados.salario - dados.valorTotalGasto), dados.valorTotalGasto]
                        }
                    ]
                },
                options: {
                    responsive: false,
                    title: {
                        display: true,
                        text: "Total gasto no M�s"
                    }
                }
            });
        }
    });
}
function PegarValores(dados) {
    var valores = [];
    var tamanho = dados.length;
    var indice = 0;

    while (indice < tamanho) {
        valores.push(dados[indice].valores);
        indice++;
    }

    return valores;
}

function PegarTiposDespesas(dados) {

    var labels = [];
    var tamanho = dados.length;
    var indice = 0;

    while (indice < tamanho) {
        labels.push(dados[indice].tiposDespesas);
        indice++;
    }

    return labels;
}

function PegarMeses(dados) {
    var labels = [];
    var tamanho = dados.length;
    var indice = 0;
    while (indice < tamanho) {
        labels.push(dados[indice].nomeMeses[0]);
        indice++;
    }

    return labels;
}

function PegarMeses(dados) {
    var labels = [];
    var tamanho = dados.length;
    var indice = 0;

    while (indice < tamanho) {
        labels.push(dados[indice].nomeMeses[0]);
        indice++
    }

    return labels;


}

function PegarCores(quantidade) {
    var cores = [];

    while (quantidade > 0) {
        var r = Math.floor(Math.random() * 255);
        var g = Math.floor(Math.random() * 255);
        var b = Math.floor(Math.random() * 255);

        cores.push("rgb(" + r + ", " + g + "," + b + ")");

        quantidade--;
    }
    return cores;
}