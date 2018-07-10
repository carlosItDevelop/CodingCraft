// ---/  Estatística da Dashboard --

(function () {

    'use strict';

    app.controller("dashboardCtrl",
        ['$scope', '$filter', '$http',
            function ($scope, $filter, $http) {

                $scope.estadopacientes = [];

                $scope.estavel = 0;         // 1
                $scope.observacao = 0;      // 2
                $scope.critico = 0;         // 3
                $scope.semavaliacao = 0;    // 4

                $scope.total = 0;

                $scope.niveldeevolucao = "";

                var carregaEstadopaciente = function () {
                    $http.get("/Home/GetEstadoPaciente").success(function (data) {
                        //debugger;
                        $scope.estadopacientes = data;
                        var numRec = $scope.estadopacientes.length;
                        if (numRec > 0) {
                            while (numRec > 0) {
                                switch ($scope.estadopacientes[numRec - 1]) {
                                    case 1:
                                        $scope.estavel++;
                                        break;
                                    case 2:
                                        $scope.observacao++;
                                        break;
                                    case 3:
                                        $scope.critico++;
                                        break;
                                    case 4:
                                        $scope.semavaliacao++;
                                        break;
                                    default:
                                        $scope.semavaliacao++;
                                }
                                numRec--;
                            }
                        }




                        $scope.total = $scope.estavel + $scope.critico + $scope.observacao + $scope.semavaliacao;

                        if ((($scope.estavel + $scope.observacao) * 100 / $scope.total) >= 70) {
                            $scope.niveldeevolucao = "Evolução em alta";
                        } else {
                            $scope.niveldeevolucao = "Déficit de Evolução";
                        }

                    }).error(function (data) {
                        toastr["error"]("Erro ao carregar Estado dos Pacientes!", "MedicalManagement-Sys");
                    });
                };

                carregaEstadopaciente();

            }]);

})();