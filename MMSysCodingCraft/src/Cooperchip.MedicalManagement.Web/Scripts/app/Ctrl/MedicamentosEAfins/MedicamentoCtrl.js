
(function () {
    'use strict';

    // ---------------------------------------------------- //

    app.controller("MedicamentoCtrl",
        ['$scope', '$http',
            function ($scope, $http) {

                $scope.titulo = "Lista de Medicamentos";
                $scope.medicamentos = [];

                var carregaMedicamentos = function () {
                    $http.get("/Medicamento/GetMedicamentos").success(function (data) {
                        $scope.medicamentos = data;
                    }).error(function (data, status) {
                        toastr['error']('Erro carregando os dados...', 'MedicalManagement-Sys');
                    });
                };



                $scope.adicionarMedicamento = function (medicamento) {
                    $http.post("/Medicamento/AddMedicamento", medicamento).success(function (data) {
                        delete $scope.medicamento;
                        $scope.medicamentoForm.$setPristine();
                        carregaMedicamentos();
                        toastr["success"]("Medicamento Adicionado com sucesso!", "MedicalManagement-Sys");
                    }).error(function (data, status) {
                        toastr["error"]("Erro ao adicionar Ajuste!", "MedicalManagement-Sys");
                    });
                };


                $scope.alterarMedicamento = function (medicamento) {
                    $http.post("/Medicamento/UdtMedicamento/", medicamento.MedicamentoId).success(function (data) {
                        toastr["success"]("Medicamento atualizado com sucesso!", "MedicalManagement-Sys");
                    }).error(function (data, status) {
                        toastr["error"]("Erro ao atualizar medicamento!", "MedicalManagement-Sys");
                    });
                };


                $scope.apagarMedicamentos = function (medicamentos) {
                    $scope.medicamentos = medicamentos.filter(function (medicamento) {
                        if (medicamento.selecionado) {
                            $http.post("/Medicamento/DelMedicamentos/" + medicamento.MedicamentoId).success(function (data) {
                                toastr["warning"]("Medicamento Excluído com sucesso!", "MedicalManagement-Sys");
                            }).error(function (data, status) {
                                toastr["error"]("Erro ao remover medicamento!", "MedicalManagement-Sys");
                            });
                        };
                        if (!medicamento.selecionado) return medicamento;
                    });
                };

                carregaMedicamentos();


                $scope.isMedicamentoSelecionado = function (medicamentos) {
                    return medicamentos.some(function (medicamento) {
                        return medicamento.selecionado;
                    });
                };


                $scope.ordenarPor = function (campo) {
                    $scope.criterioDeOrdenacao = campo;
                    $scope.direcaoDaOrdenacao = !$scope.direcaoDaOrdenacao;
                };


            }
        ]);
}());
