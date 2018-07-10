
(function () {

    'use strict';

    app.controller("LeitosPacientePainelCtrl",
        ['$scope',
            '$http',
            'pacienteService',
            '$uibModal',
            '$log',
            '$filter', function ($scope, $http, pacienteService, $uibModal, $log, $filter) {


                $scope.titulo = "Leitos / Pacientes";

                $scope.pacientes = [];
                $scope.leitos = [];

                $scope.paciente = {};

                $scope.totalReg = 0;


                function ctrlGetPaciente() {
                    var pacientesData = pacienteService.srvcObterPacientesRightSidebar();
                    pacientesData.then(function (paciente) {
                        $scope.pacientes = paciente.data;
                        $scope.totalReg = paciente.data.length;
                        $scope.Acao = "";
                        //toastr["success"]("Pacientes carregados com sucesso!", "MedicalManagement-Sys");
                    }, function () {
                        toastr["error"]("Erro ao obter pacientes", "MedicalManagement-Sys");
                    }
                    );
                };

                // Esta função só deve ser chamada quando houver atualização nos dados de Paciente.
                // Usar uma abordagem parecida com "ouvir" um evento para recarregar. Pode ser com
                // AngularJS, através da abordagem de $rootScope, #broadCast e #on ou C#, c/ Delegate.
                ctrlGetPaciente();



                $scope.pacienteselecinado = [];
                $scope.animationsEnabled = true;

                $scope.openPacienteLeito = function (size, id) {

                    $http.get("/Home/BuscaPacienteMenuRigthModal/" + id).success(function (data) {
                        //debugger;
                        $scope.pacienteselecinado = data;
                        //$scope.pacienteselecinado.DataNascimento = new Date($filter('jsonToDate')(data.DataNascimento)); 
                        //$scope.pacienteselecinado.DataInternacao = new Date($filter('jsonToDate')(data.DataInternacao));

                        var modalInstance = $uibModal.open({
                            animation: $scope.animationsEnabled,
                            templateUrl: 'ModalPacientesLeitos.html',
                            controller: 'ModalPacientesLeitosCtrl',
                            size: size,
                            resolve: {
                                pac: function () {
                                    return $scope.pacienteselecinado;
                                }
                            }
                        });

                        modalInstance.result.then(function () {
                        }, function () {
                        });

                    }).error(function (data, status) {
                        toastr["error"]("Erro na busca de Pacientes!", "MedicalManagement-Sys");
                    });

                };



                $scope.getCorEstado = function (estado) {
                    var cor = "";
                    switch (estado) {
                        case 1:
                            cor = "status status-online";
                            break;
                        case 2:
                            cor = "status status-obs";
                            break;
                        case 3:
                            cor = "status status-offline";
                            break;
                        case 4:
                            cor = "status status-nostatus";
                            break;
                        default:
                            cor = "status status-nostatus";
                            break;
                    }
                    return cor;
                };


                $scope.getNumLeitoFormatado = function (id) {

                    var idformatado = id.toString();

                    if (id < 10) {
                        return idformatado = "00" + id;
                    }
                    else if (id < 100) {
                        return idformatado = "0" + id;
                    }
                    else {
                        return idformatado;
                    }
                };

            }]);

})();