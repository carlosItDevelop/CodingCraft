
(function () {
    'use strict';

    // ---------------------------------------------------- //

    app.controller("MedicamentoPosologiaCtrl",
        ['$scope', '$http',
            function ($scope, $http) {

                $scope.titulo = "Medicamento Posologia";
                $scope.medicamentosposologia = [];
                $scope.medicamentos = [];



                var carregaMedicamentosPosologia = function () {
                    $http.get("/MedicamentoPosologia/GetMedicamentosPosologia").success(function (data) {
                        $scope.medicamentosposologia = data;
                    }).error(function (data, status) {
                        toastr['error']('Erro carregando posologias...', 'MedicalManagement-Sys');
                    });
                };



                $scope.adicionarMedicamentoPosologia = function (medicamentoposologia) {
                    $http.post("/MedicamentoPosologia/AddMedicamentoPosologia", medicamentoposologia).success(function (data) {
                        delete $scope.medicamentoposologia;
                        $scope.medicamentoPosologiaForm.$setPristine();
                        carregaMedicamentosPosologia();
                        toastr["success"]("Posologia Adicionada com sucesso!", "MedicalManagement-Sys");
                    }).error(function (data, status) {
                        toastr["error"]("Erro ao adicionar Posologia!", "MedicalManagement-Sys");
                    });
                };


                $scope.alterarMedicamentoPosologia = function (medicamentoposologia) {
                    medicamentoposologia.data = new Date();
                    $http.post("/MedicamentoPosologia/UdtMedicamentoPosologia/", medicamentoposologia.MedicamentoPosologiaId).success(function (data) {
                        toastr["success"]("Posologia atualizada com sucesso!", "MedicalManagement-Sys");
                    }).error(function (data, status) {
                        toastr["error"]("Erro ao atualizar Posologia!", "MedicalManagement-Sys");
                    });
                };


                $scope.apagarMedicamentosPosologia = function (medicamentosposologia) {
                    $scope.medicamentosposologia = medicamentosposologia.filter(function (medicamentoposologia) {
                        if (medicamentoposologia.selecionado) {
                            $http.post("/MedicamentoPosologia/DelMedicamentosPosologia/" + medicamentoposologia.MedicamentoPosologiaId).success(function (data) {
                                toastr["warning"]("Posologia Excluída com sucesso!", "MedicalManagement-Sys");
                            }).error(function (data, status) {
                                toastr["error"]("Erro ao remover posologia!", "MedicalManagement-Sys");
                            });
                        };
                        if (!medicamentoposologia.selecionado) return medicamentoposologia;
                    });
                };

                carregaMedicamentosPosologia();


                $scope.isMedicamentoPosologiaSelecionado = function (medicamentosposologia) {
                    return medicamentosposologia.some(function (medicamentoposologia) {
                        return medicamentoposologia.selecionado;
                    });
                };


                $scope.ordenarPor = function (campo) {
                    $scope.criterioDeOrdenacao = campo;
                    $scope.direcaoDaOrdenacao = !$scope.direcaoDaOrdenacao;
                };



            }
        ]);
}());
