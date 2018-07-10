
(function () {
    'use strict';

    // Precaucaos

    app.controller("crudprecaucaoCtrl",
        ['$scope', 'precaucaoService', 'tipodeprecaucaoService',
            function ($scope, precaucaoService, tipodeprecaucaoService) {

                $scope.divprecaucao = false;
                $scope.titulo = "Lista de Precaucões";

                $scope.precaucaos = [];
                $scope.tipoprecaucaos = [];


                function obterTodosAsPrecaucoes() {
                    var precaucaosData = precaucaoService.ObterPrecaucoes();
                    precaucaosData.then(function (precaucao) {
                        $scope.precaucaos = precaucao.data;
                        $scope.Acao = "";
                    }, function () {
                        toastr["error"]("Erro ao obter precaucaos", "MedicalManagement-Sys");
                    }
                    );
                };
                obterTodosAsPrecaucoes();


                function obterTiposDePrecaucao() {
                    var tipoprecaucaosData = tipodeprecaucaoService.ObterTiposPrecaucoes();
                    tipoprecaucaosData.then(function (tipoprecaucao) {
                        $scope.tipoprecaucaos = tipoprecaucao.data;
                        $scope.Acao = "";
                    }, function () {
                        toastr["error"]("Erro ao obter tipos de precauções", "MedicalManagement-Sys");
                    }
                    );
                };
                obterTiposDePrecaucao();




                // obter por id
                // Habilita DIV para Edição de registros
                $scope.obterPorId = function (precaucao) {
                    var precaucaoData = precaucaoService.ObterPrecaucaoPorId(precaucao.PrecaucaoId);
                    precaucaoData.then(function (precaucao) {
                        $scope.precaucao = precaucao.data;

                        $scope.Acao = "Atualizar";
                        $scope.divprecaucao = true;
                    }, function () {
                        toastr["error"]("Erro ao obter precaucao por id!", "MedicalManagement-Sys");
                    });
                };



                // Habilita DIV para Adição de registros
                $scope.incluirPrecaucaoDiv = function () {
                    $scope.precaucao = {};
                    $scope.precaucaoForm.$setPristine();
                    $scope.Acao = "Adicionar";
                    $scope.divprecaucao = true;
                };


                $scope.ExcluirPrecaucao = function alert_it(precaucao) {
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
                            apagarRegistro(precaucao)
                            swal("EXCLUÍDO!", "O registro foi deletado com sucesso.", "success");
                        });
                }


                var apagarRegistro = function (precaucao) {
                    var precaucaoData = precaucaoService.Excluir(precaucao.PrecaucaoId);
                    precaucaoData.then(function (data) {
                        if (data.status === 200) {
                            toastr["warning"]("Precaucao excluído com sucesso!", "MedicalManagement-Sys");
                            obterTodosAsPrecaucoes();
                        }
                    }, function () {
                        toastr["error"]("Erro ao excluir precaucao!", "MedicalManagement-Sys");
                    });
                };





                $scope.AdicionarEditarPrecaucao = function () {
                    var precaucaoData = null;
                    var _precaucao = {
                        Descricao: $scope.precaucao.Descricao,
                        IdTipoPrecaucao: $scope.precaucao.IdTipoPrecaucao
                    };
                    var valorAcao = $scope.Acao;
                    if (valorAcao === "Atualizar") {
                        _precaucao.PrecaucaoId = $scope.precaucao.PrecaucaoId;
                        precaucaoData = precaucaoService.AtualizarPrecaucao(_precaucao);
                        precaucaoData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("Precaucao alterado com sucesso!", "MedicalManagement-Sys");
                                obterTodosAsPrecaucoes();
                                $scope.divprecaucao = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao editar precaucao!", "MedicalManagement-Sys");
                        });
                    } else if (valorAcao === "Adicionar") {
                        precaucaoData = precaucaoService.AdicionarPrecaucao(_precaucao);

                        precaucaoData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("Precaucao Adicionado com sucesso!", "MedicalManagement-Sys");
                                obterTodosAsPrecaucoes();
                                $scope.divprecaucao = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao Adicionar precaucao!", "MedicalManagement-Sys");
                        });
                    }
                };


                $scope.cancelaEdicao = function () {
                    $scope.Acao = "";
                    $scope.divprecaucao = false;
                    $scope.precaucaoForm.$setPristine();
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


            }
        ]);
}());