
(function () {
    'use strict';

    // ---------------------------------------------------- //

    app.controller("MedicamentoAjusteCtrl",
        ['$scope', '$http',
            function ($scope, $http) {

                $scope.titulo = "Medicamento Ajuste";
                $scope.medicamentosajuste = [];
                $scope.medicamentos = [];


                var carregaMedicamentosAjuste = function () {
                    $http.get("/MedicamentoAjustes/GetMedicamentosAjuste").success(function (data) {
                        $scope.medicamentosajuste = data;
                    }).error(function (data, status) {
                        toastr['error']('Erro carregando ajustes...', 'MedicalManagement-Sys');
                    });
                };
                carregaMedicamentosAjuste();




                $scope.adicionarMedicamentoAjuste = function (medicamentoajuste) {
                    $http.post("/MedicamentoAjustes/AddMedicamentoAjuste", medicamentoajuste).success(function (data) {
                        delete $scope.medicamentoajuste;
                        $scope.medicamentoAjusteForm.$setPristine();
                        carregaMedicamentosAjuste();
                        toastr["success"]("Ajuste Adicionado com sucesso!", "MedicalManagement-Sys");
                    }).error(function (data, status) {
                        toastr["error"]("Erro ao adicionar Ajuste!", "MedicalManagement-Sys");
                    });
                };


                $scope.alterarMedicamentoAjuste = function (medicamentoajuste) {
                    medicamentoajuste.data = new Date();
                    $http.post("/MedicamentoAjustes/UdtMedicamentoAjuste/", medicamentoajuste.MedicamentoAjustesId).success(function (data) {
                        toastr["success"]("Ajuste atualizado com sucesso!", "MedicalManagement-Sys");
                    }).error(function (data, status) {
                        toastr["error"]("Erro ao atualizar Ajuste!", "MedicalManagement-Sys");
                    });
                };


                $scope.apagarMedicamentosAjuste = function (medicamentosajuste) {
                    $scope.medicamentosajuste = medicamentosajuste.filter(function (medicamentoajuste) {
                        if (medicamentoajuste.selecionado) {
                            $http.post("/MedicamentoAjustes/DelMedicamentosAjuste/" + medicamentoajuste.MedicamentoAjustesId).success(function (data) {
                                toastr["warning"]("Ajuste Excluído com sucesso!", "MedicalManagement-Sys");
                            }).error(function (data, status) {
                                toastr["error"]("Erro ao remover ajuste!", "MedicalManagement-Sys");
                            });
                        };
                        if (!medicamentoajuste.selecionado) return medicamentoajuste;
                    });
                };


                $scope.isMedicamentoAjusteSelecionado = function (medicamentosajuste) {
                    return medicamentosajuste.some(function (medicamentoajuste) {
                        return medicamentoajuste.selecionado;
                    });
                };


                $scope.ordenarPor = function (campo) {
                    $scope.criterioDeOrdenacao = campo;
                    $scope.direcaoDaOrdenacao = !$scope.direcaoDaOrdenacao;
                };



            }
        ]);
}());
