

(function () {
    'use strict';
    // ---/ Dieta

    app.controller("dietaCtrl",
        ['$scope', 'dietaService',
            function ($scope, dietaService) {

        $scope.divdieta = false;
        $scope.titulo = "Lista de Dietas";


        function obterTodosAsDietas() {
            var dietasData = dietaService.ObterTodas();
            dietasData.then(function (dieta) {
                $scope.dietas = dieta.data;
                $scope.Acao = "";
            }, function () {
                toastr["error"]("Erro ao obter dietas", "MedicalManagement-Sys");
            }
            );
        };


        // obter por id
        // Habilita DIV para Edição de registros
        $scope.obterPorId = function (dieta) {
            var dietaData = dietaService.GetDietaPorId(dieta.DietaId);
            dietaData.then(function (dieta) {
                $scope.dieta = dieta.data;

                $scope.Acao = "Atualizar";
                $scope.divdieta = true;
            }, function () {
                toastr["error"]("Erro ao obter dieta por id!", "MedicalManagement-Sys");
            });
        };



        // Habilita DIV para Adição de registros
        $scope.incluirDietaDiv = function () {
            $scope.dieta = {};
            $scope.dietaForm.$setPristine();
            $scope.Acao = "Adicionar";
            $scope.divdieta = true;
        };


        $scope.ExcluirDieta = function alert_it(dieta) {
            swal({
                title: "Tem certeza que deseja excluir este registro?",
                text: "Após a exclusão não será possível recuperá-lo!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Sim, Pode excluir!",
                closeOnConfirm: false
            },
                function () {
                    apagarRegistro(dieta)
                    swal("EXCLUÍDO!", "O registro foi deletado com sucesso.", "success");
                });
        }


        var apagarRegistro = function (dieta) {
            var dietaData = dietaService.Excluir(dieta.DietaId);
            dietaData.then(function (data) {
                if (data.status === 200) {
                    toastr["warning"]("Dieta excluído com sucesso!", "MedicalManagement-Sys");
                    obterTodosAsDietas();
                }
            }, function () {
                toastr["error"]("Erro ao excluir dieta!", "MedicalManagement-Sys");
            });
        };





        $scope.AdicionarEditarDieta = function () {
            var dietaData = null;
            var _dieta = {
                Descricao: $scope.dieta.Descricao
            };
            var valorAcao = $scope.Acao;
            if (valorAcao === "Atualizar") {
                _dieta.DietaId = $scope.dieta.DietaId;
                dietaData = dietaService.AtualizarDieta(_dieta);
                dietaData.then(function (data) {
                    if (data.status === 200) {
                        toastr["success"]("Dieta alterado com sucesso!", "MedicalManagement-Sys");
                        obterTodosAsDietas();
                        $scope.divdieta = false;
                    }
                }, function () {
                    toastr["error"]("Erro ao editar dieta!", "MedicalManagement-Sys");
                });
            } else if (valorAcao === "Adicionar") {
                dietaData = dietaService.AdicionarDieta(_dieta);

                dietaData.then(function (data) {
                    if (data.status === 200) {
                        toastr["success"]("Dieta Adicionado com sucesso!", "MedicalManagement-Sys");
                        obterTodosAsDietas();
                        $scope.divdieta = false;
                    }
                }, function () {
                    toastr["error"]("Erro ao Adicionar dieta!", "MedicalManagement-Sys");
                });
            }
        };


        $scope.cancelaEdicao = function () {
            $scope.Acao = "";
            $scope.divdieta = false;
            $scope.dietaForm.$setPristine();
        };

        //  ----/ Otimizar, tornando o mais genérico possível e tentar numa única função --- //
        $scope.inibeBtnAtualizar = function () {
            if (($scope.Acao === "Atualizar") || ($scope.Acao === "Adicionar")) {
                return true;
            }
            return false;
        };

        $scope.inibeBtnAdicionar = function () {
            if (($scope.Acao === "Atualizar") || ($scope.Acao === "Adicionar")) {
                return true;
            }
            return false;
        };


        $scope.inibeBtnExcluir = function () {
            if (($scope.Acao === "Atualizar") || ($scope.Acao === "Adicionar")) {
                return true;
            }
            return false;
        };
        //  ----/ Otimizar, tornando o mais genérico possível e tentar numa única função --- //




        $scope.ordenarPor = function (campo) {
            $scope.criterioDeOrdenacao = campo;
            $scope.direcaoDaOrdenacao = !$scope.direcaoDaOrdenacao;
        };



        obterTodosAsDietas();


    }]);

}());