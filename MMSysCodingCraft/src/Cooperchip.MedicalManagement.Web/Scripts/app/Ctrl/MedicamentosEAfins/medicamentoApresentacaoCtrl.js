
(function () {
    'use strict';

    // ---------------------------------------------------- //


    app.controller("MedicamentoApresentacaoCtrl",
        ['$scope', '$http',
            function ($scope, $http) {

                $scope.titulo = "Medicamento Apresentação";
                $scope.medicamentosapresentacao = [];
                $scope.medicamentos = [];

                var carregaMedicamentosApresentacao = function () {
                    $http.get("/MedicamentoApresentacao/GetMedicamentosApresentacao").success(function (data) {
                        $scope.medicamentosapresentacao = data;
                        //console.log(data);
                    }).error(function (data, status) {
                        toastr['error']('Erro carregando apresentacoes...', 'MedicalManagement-Sys');
                    });
                };



                $scope.adicionarMedicamentoApresentacao = function (medicamentoapresentacao) {
                    $http.post("/MedicamentoApresentacao/AddMedicamentoApresentacao", medicamentoapresentacao).success(function (data) {
                        delete $scope.medicamentoapresentacao;
                        $scope.medicamentoApresentacaoForm.$setPristine();
                        carregaMedicamentosApresentacao();
                        toastr["success"]("Apresentacao Adicionada com sucesso!", "MedicalManagement-Sys");
                    }).error(function (data, status) {
                        toastr["error"]("Erro ao adicionar Apresentacao!", "MedicalManagement-Sys");
                    });
                };


                $scope.alterarMedicamentoApresentacao = function (medicamentoapresentacao) {
                    medicamentoapresentacao.data = new Date();
                    $http.post("/MedicamentoApresentacao/UdtMedicamentoApresentacao/", medicamentoapresentacao.MedicamentoApresentacaoId).success(function (data) {
                        toastr["success"]("Apresentacao atualizada com sucesso!", "MedicalManagement-Sys");
                    }).error(function (data, status) {
                        toastr["error"]("Erro ao atualizar Apresentacao!", "MedicalManagement-Sys");
                    });
                };


                $scope.apagarMedicamentosApresentacao = function (medicamentosapresentacao) {
                    $scope.medicamentosapresentacao = medicamentosapresentacao.filter(function (medicamentoapresentacao) {
                        if (medicamentoapresentacao.selecionado) {
                            $http.post("/MedicamentoApresentacao/DelMedicamentosApresentacao/" + medicamentoapresentacao.MedicamentoApresentacaoId).success(function (data) {
                                toastr["warning"]("Apresentacao Excluída com sucesso!", "MedicalManagement-Sys");
                            }).error(function (data, status) {
                                toastr["error"]("Erro ao remover apresentacao!", "MedicalManagement-Sys");
                            });
                        };
                        if (!medicamentoapresentacao.selecionado) return medicamentoapresentacao;
                    });
                };

                carregaMedicamentosApresentacao();


                $scope.isMedicamentoApresentacaoSelecionado = function (medicamentosapresentacao) {
                    return medicamentosapresentacao.some(function (medicamentoapresentacao) {
                        return medicamentoapresentacao.selecionado;
                    });
                };


                $scope.ordenarPor = function (campo) {
                    $scope.criterioDeOrdenacao = campo;
                    $scope.direcaoDaOrdenacao = !$scope.direcaoDaOrdenacao;
                };



            }]);
}());
