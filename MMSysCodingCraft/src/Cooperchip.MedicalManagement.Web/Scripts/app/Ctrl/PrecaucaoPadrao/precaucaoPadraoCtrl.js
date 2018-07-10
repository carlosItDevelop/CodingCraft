
(function () {
    'use strict';

    // ---/ ----- PrecaucaoPadrao -----

    app.controller("precaucaoPadraoCtrl",
        ['$scope', 'precaucaoPadraoService',
            function ($scope, precaucaoPadraoService) {

                $scope.divprecaucaopadrao = false;
                $scope.titulo = "Lista de Precaução Padrão";


                function obterTodosOsPrecaucaoPadraos() {
                    var precaucaopadraosData = precaucaoPadraoService.ObterPrecaucaoPadraos();
                    precaucaopadraosData.then(function (precaucaopadrao) {
                        $scope.precaucaopadraos = precaucaopadrao.data;
                        $scope.Acao = "";
                    }, function () {
                        toastr["error"]("Erro ao obter precaucaopadraos", "MedicalManagement-Sys");
                    }
                    );
                };


                // obter por id
                // Habilita DIV para Edição de registros
                $scope.obterPorId = function (precaucaopadrao) {
                    var precaucaopadraoData = precaucaoPadraoService.ObterPrecaucaoPadraoPorId(precaucaopadrao.PrecaucaoPadraoId);
                    precaucaopadraoData.then(function (precaucaopadrao) {
                        $scope.precaucaopadrao = precaucaopadrao.data;

                        $scope.Acao = "Atualizar";
                        $scope.divprecaucaopadrao = true;
                    }, function () {
                        toastr["error"]("Erro ao obter precaucaopadrao por id!", "MedicalManagement-Sys");
                    });
                };


                // Habilita DIV para Adição de registros
                $scope.incluirPrecaucaoPadraoDiv = function () {
                    $scope.precaucaopadrao = {};
                    $scope.precaucaopadraoForm.$setPristine();
                    $scope.Acao = "Adicionar";
                    $scope.divprecaucaopadrao = true;
                };



                $scope.ExcluirPrecaucaoPadrao = function alert_it(precaucaopadrao) {
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
                            apagarRegistro(precaucaopadrao)
                            swal("EXCLUÍDO!", "O registro foi deletado com sucesso.", "success");
                        });
                }


                var apagarRegistro = function (precaucaopadrao) {
                    var precaucaopadraoData = precaucaoPadraoService.ExcluirPrecaucaoPadrao(precaucaopadrao.PrecaucaoPadraoId);
                    precaucaopadraoData.then(function (data) {
                        if (data.status === 200) {
                            toastr["warning"]("PrecaucaoPadrao excluído com sucesso!", "MedicalManagement-Sys");
                            obterTodosOsPrecaucaoPadraos();
                        }
                    }, function () {
                        toastr["error"]("Erro ao excluir precaucaopadrao!", "MedicalManagement-Sys");
                    });
                };



                $scope.AdicionarEditarPrecaucaoPadrao = function () {
                    var precaucaopadraoData = null;
                    var _precaucaopadrao = {
                        Nome: $scope.precaucaopadrao.Nome,
                        Descricao: $scope.precaucaopadrao.Descricao,
                        Ativo: $scope.precaucaopadrao.Ativo
                    };
                    var valorAcao = $scope.Acao;
                    if (valorAcao === "Atualizar") {
                        _precaucaopadrao.PrecaucaoPadraoId = $scope.precaucaopadrao.PrecaucaoPadraoId;
                        precaucaopadraoData = precaucaoPadraoService.AtualizarPrecaucaoPadrao(_precaucaopadrao);
                        precaucaopadraoData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("PrecaucaoPadrao alterado com sucesso!", "MedicalManagement-Sys");
                                obterTodosOsPrecaucaoPadraos();
                                $scope.divprecaucaopadrao = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao editar precaucaopadrao!", "MedicalManagement-Sys");
                        });
                    } else if (valorAcao === "Adicionar") {
                        precaucaopadraoData = precaucaoPadraoService.AdicionarPrecaucaoPadrao(_precaucaopadrao);
                        precaucaopadraoData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("PrecaucaoPadrao Adicionado com sucesso!", "MedicalManagement-Sys");
                                obterTodosOsPrecaucaoPadraos();
                                $scope.divprecaucaopadrao = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao Adicionar precaucaopadrao!", "MedicalManagement-Sys");
                        });
                    }
                };


                $scope.cancelaEdicao = function () {
                    $scope.Acao = "";
                    $scope.divprecaucaopadrao = false;
                    $scope.precaucaopadraoForm.$setPristine();
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



                obterTodosOsPrecaucaoPadraos();


            }
        ]);
}());

