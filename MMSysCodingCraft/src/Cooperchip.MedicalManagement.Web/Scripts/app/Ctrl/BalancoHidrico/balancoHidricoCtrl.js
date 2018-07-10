
(function () {
    'use strict';

    // ----------/ balancoHidricoCtrl ---------------------------- //


    app.controller("balancoHidricoCtrl",
        ['$scope', '$filter', '$http',
            function ($scope, $filter, $http) {

        $scope.titulo = "Balanço Hídrico nas Últimas 24 horas";
        $scope.balancohidricos = [];

        var idprontuario;
        var idpaciente;
        // Evento click simulado em outra controller,
        // via javaScript, => ProntuarioCtrl.js.
        $("#idPaciente").click(function () {
            idpaciente = $("#idPaciente").val();
            idprontuario = $("#ProntuarioId").val();
            if (idpaciente && idprontuario) {
                carregaBalancoHidricoPorId();
            };
        });


        // Puxa apenas os dados do paciente em questão
        // de um prontuário específico.
        var carregaBalancoHidricoPorId = function () {
            $http({
                url: '/Prontuario/GetBalancoHidricoPorId/',
                method: 'GET',
                params: {
                    idpc: idpaciente,
                    idpt: idprontuario
                }
            }).success(function (data) {
                $scope.balancohidricos = data;
            }).error(function (data, status) {
                toastr['error']('Erro carregando Balanço Hídrico...', 'MedicalManagement-Sys');
            });
        };


        $scope.adicionarBalancoHidrico = function (balancohidrico) {
            balancohidrico.PacienteId = idpaciente;
            balancohidrico.ProntuarioGuid = idprontuario;
            $http.post("/Prontuario/AddBalancoHidrico", balancohidrico).success(function (data) {
                delete $scope.balancohidrico;
                $scope.balancoHidricoForm.$setPristine();
                carregaBalancoHidricoPorId();
                toastr["success"]("Balanço Hídrico por Id Adicionada com sucesso!", "Medical Management - Sys");
            }).error(function (data, status) {
                toastr["error"]("Erro ao Adicionar Balanço Hídrico!", "Medical Management - Sys");
            });
        };


        $scope.alterarBalancoHidrico = function (balancohidrico) {
            $http.post("/Prontuario/UdtBalancoHidrico/", balancohidrico.BalancoHidricoId).success(function (data) {
                //    delete $scope.balancohidrico;
                //    $scope.balancoHidricoForm.$setPristine();
                //    carregaBalancoHidrico();
            }).error(function (data, status) {
                toastr["error"]("Erro ao Atualizar Balanço Hídrico!", "Medical Management - Sys");
            });
        };


        $scope.apagarBalancoHidricos = function (balancohidricos) {
            $scope.balancohidricos = balancohidricos.filter(function (balancohidrico) {
                if (balancohidrico.selecionado) {
                    $http.post("/Prontuario/DelBalancoHidrico/" + balancohidrico.BalancoHidricoId).success(function (data) {
                        toastr["warning"]("Exame de Imagem Excluída com sucesso!", "Medical Management - Sys");
                    }).error(function (data, status) {
                        toastr["error"]("Erro ao remover registro!", "Medical Management - Sys");
                    });
                };
                if (!balancohidrico.selecionado) return balancohidrico;
            });
        };

        $scope.isBalancoHidricoSelecionado = function (balancohidricos) {
            return balancohidricos.some(function (balancohidrico) {
                return balancohidrico.selecionado;
            });
        };


        $scope.ordenarPor = function (campo) {
            $scope.criterioDeOrdenacao = campo;
            $scope.direcaoDaOrdenacao = !$scope.direcaoDaOrdenacao;
        };

    }]);
})();