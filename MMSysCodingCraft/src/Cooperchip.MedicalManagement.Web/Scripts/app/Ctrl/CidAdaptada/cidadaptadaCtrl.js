
(function () {
    'use strict';
    // cidAdaptadaCtrl


    app.controller("cidAdaptadaCtrl",
        ['$scope', 'cidAdaptadaService',
            function ($scope, cidAdaptadaService) {

                $scope.divcidadaptada = false;
                $scope.titulo = "Lista de CidAdaptadas";


                function obterTodosAsCidAdaptadas() {
                    var cidadaptadasData = cidAdaptadaService.ObterCidAdaptadas();
                    cidadaptadasData.then(function (cidadaptada) {
                        $scope.cidadaptadas = cidadaptada.data;
                        $scope.Acao = "";
                    }, function () {
                        toastr["error"]("Erro ao obter cidadaptadas", "MedicalManagement-Sys");
                    }
                    );
                };


                // obter por id
                // Habilita DIV para Edição de registros
                $scope.obterPorId = function (cidadaptada) {
                    var cidadaptadaData = cidAdaptadaService.GetCidAdaptadaPorId(cidadaptada.CidAdaptadaId);
                    cidadaptadaData.then(function (cidadaptada) {
                        $scope.cidadaptada = cidadaptada.data;

                        $scope.Acao = "Atualizar";
                        $scope.divcidadaptada = true;
                    }, function () {
                        toastr["error"]("Erro ao obter cid por id!", "MedicalManagement-Sys");
                    });
                };


                // Habilita DIV para Adição de registros
                $scope.incluirCidAdaptadaDiv = function () {
                    $scope.cidadaptada = {};
                    $scope.cidadaptadaForm.$setPristine();
                    $scope.Acao = "Adicionar";
                    $scope.divcidadaptada = true;
                };


                $scope.ExcluirCidAdaptada = function (cidadaptada) {
                    var cidadaptadaData = cidAdaptadaService.Excluir(cidadaptada.CidAdaptadaId);
                    cidadaptadaData.then(function (data) {
                        if (data.status === 200) {
                            toastr["warning"]("Cid excluído com sucesso!", "MedicalManagement-Sys");
                            obterTodosAsCidAdaptadas();
                        }
                    }, function () {
                        toastr["error"]("Erro ao excluir cid!", "MedicalManagement-Sys");
                    });
                };

                $scope.AdicionarEditarCidAdaptada = function () {
                    var cidadaptadaData = null;
                    var _cidadaptada = {
                        Codigo: $scope.cidadaptada.Codigo,
                        Diagnostico: $scope.cidadaptada.Diagnostico
                    };
                    var valorAcao = $scope.Acao;
                    if (valorAcao === "Atualizar") {
                        _cidadaptada.CidAdaptadaId = $scope.cidadaptada.CidAdaptadaId;
                        cidadaptadaData = cidAdaptadaService.AtualizarCidAdaptada(_cidadaptada);
                        cidadaptadaData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("CidAdaptada alterado com sucesso!", "MedicalManagement-Sys");
                                obterTodosAsCidAdaptadas();
                                $scope.divcidadaptada = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao editar cid!", "MedicalManagement-Sys");
                        });
                    } else if (valorAcao === "Adicionar") {
                        cidadaptadaData = cidAdaptadaService.Adicionar(_cidadaptada);
                        cidadaptadaData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("Cid Adicionado com sucesso!", "MedicalManagement-Sys");
                                obterTodosAsCidAdaptadas();
                                $scope.divcidadaptada = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao Adicionar cid!", "MedicalManagement-Sys");
                        });
                    }
                };


                $scope.cancelaEdicao = function () {
                    $scope.Acao = "";
                    $scope.divcidadaptada = false;
                    $scope.cidadaptadaForm.$setPristine();
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

                obterTodosAsCidAdaptadas();

            }]);
}());