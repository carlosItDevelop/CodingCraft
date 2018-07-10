
(function () {
    'use strict';

// ---/ Alergia ----


app.controller("AlergiaCtrl", ['$scope', '$http', 'alergiaService', function ($scope, $http, alergiaService) {
    $scope.titulo = "Listagem de Alergia";

    $scope.alergias = [];

    var carregaAlergias = function () {
        alergiaService.success(function (data) {
            $scope.alergias = data;
        }).error(function (data, status) {
            toastr["error"]("Erro ao carregar alergia!", "MedicalManagement-Sys");
        });
    };




    $scope.alterarAlergia = function (alergia) {
        $http.post("/Alergia/UdtAlergia/", alergia.AlergiaId).success(function (data) {
            //    delete $scope.alergia;
            //    $scope.alergiaForm.$setPristine();
            //    carregaAlergias();
        }).error(function (data, status) {
            toastr["error"]("Erro ao alterar alergia!", "MedicalManagement-Sys");
        });
    };


    $scope.apagarAlergias = function (alergias) {
        $scope.alergias = alergias.filter(function (alergia) {
            if (alergia.selecionado) {
                $http.post("/Alergia/DelAlergias/" + alergia.AlergiaId).success(function (data) {
                    toastr["warning"]("Alergia excluído com sucesso!", "MedicalManagement-Sys");
                }).error(function (data, status) {
                    toastr["error"]("Erro ao excluir alergia!", "MedicalManagement-Sys");
                });
            }
            if (!alergia.selecionado) return alergia;
        });
    };



    $scope.isAlergiaSelecionado = function (alergias) {
        return alergias.some(function (alergia) {
            return alergia.selecionado;
        });
    };


    $scope.ordenarPor = function (campo) {
        $scope.criterioDeOrdenacao = campo;
        $scope.direcaoDaOrdenacao = !$scope.direcaoDaOrdenacao;
    };

    carregaAlergias();

}]);

})();