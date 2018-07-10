
(function () {
    'use strict';

    // PrecaucaoGoticula

    app.controller("precaucaoGoticulaCtrl",
        ['$scope', 'precaucaoGoticulaService',
            function ($scope, precaucaoGoticulaService) {

                $scope.divprecaucaogoticula = false;
                $scope.titulo = "Lista de Precaução Goticulas";


                function obterTodosOsPrecaucaoGoticulas() {
                    var precaucaogoticulasData = precaucaoGoticulaService.ObterPrecaucaoGoticulas();
                    precaucaogoticulasData.then(function (precaucaogoticula) {
                        $scope.precaucaogoticulas = precaucaogoticula.data;
                        $scope.Acao = "";
                    }, function () {
                        toastr["error"]("Erro ao obter precaucaogoticulas", "MedicalManagement-Sys");
                    }
                    );
                };


                // obter por id
                // Habilita DIV para Edição de registros
                $scope.obterPorId = function (precaucaogoticula) {
                    var precaucaogoticulaData = precaucaoGoticulaService.ObterPrecaucaoGoticulaPorId(precaucaogoticula.PrecaucaoGoticulaId);
                    precaucaogoticulaData.then(function (precaucaogoticula) {
                        $scope.precaucaogoticula = precaucaogoticula.data;

                        $scope.Acao = "Atualizar";
                        $scope.divprecaucaogoticula = true;
                    }, function () {
                        toastr["error"]("Erro ao obter precaucaogoticula por id!", "MedicalManagement-Sys");
                    });
                };


                // Habilita DIV para Adição de registros
                $scope.incluirPrecaucaoGoticulaDiv = function () {
                    $scope.precaucaogoticula = {};
                    $scope.precaucaogoticulaForm.$setPristine();
                    $scope.Acao = "Adicionar";
                    $scope.divprecaucaogoticula = true;
                };



                $scope.ExcluirPrecaucaoGoticula = function alert_it(precaucaogoticula) {
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
                            apagarRegistro(precaucaogoticula)
                            swal("EXCLUÍDO!", "O registro foi deletado com sucesso.", "success");
                        });
                }


                var apagarRegistro = function (precaucaogoticula) {
                    var precaucaogoticulaData = precaucaoGoticulaService.ExcluirPrecaucaoGoticula(precaucaogoticula.PrecaucaoGoticulaId);
                    precaucaogoticulaData.then(function (data) {
                        if (data.status === 200) {
                            toastr["warning"]("PrecaucaoGoticula excluído com sucesso!", "MedicalManagement-Sys");
                            obterTodosOsPrecaucaoGoticulas();
                        }
                    }, function () {
                        toastr["error"]("Erro ao excluir precaucaogoticula!", "MedicalManagement-Sys");
                    });
                };





                $scope.AdicionarEditarPrecaucaoGoticula = function () {
                    var precaucaogoticulaData = null;
                    var _precaucaogoticula = {
                        Nome: $scope.precaucaogoticula.Nome,
                        Descricao: $scope.precaucaogoticula.Descricao,
                        Ativo: $scope.precaucaogoticula.Ativo
                    };
                    var valorAcao = $scope.Acao;
                    if (valorAcao === "Atualizar") {
                        _precaucaogoticula.PrecaucaoGoticulaId = $scope.precaucaogoticula.PrecaucaoGoticulaId;
                        precaucaogoticulaData = precaucaoGoticulaService.AtualizarPrecaucaoGoticula(_precaucaogoticula);
                        precaucaogoticulaData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("PrecaucaoGoticula alterado com sucesso!", "MedicalManagement-Sys");
                                obterTodosOsPrecaucaoGoticulas();
                                $scope.divprecaucaogoticula = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao editar precaucaogoticula!", "MedicalManagement-Sys");
                        });
                    } else if (valorAcao === "Adicionar") {
                        precaucaogoticulaData = precaucaoGoticulaService.AdicionarPrecaucaoGoticula(_precaucaogoticula);
                        precaucaogoticulaData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("PrecaucaoGoticula Adicionado com sucesso!", "MedicalManagement-Sys");
                                obterTodosOsPrecaucaoGoticulas();
                                $scope.divprecaucaogoticula = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao Adicionar precaucaogoticula!", "MedicalManagement-Sys");
                        });
                    }
                };


                $scope.cancelaEdicao = function () {
                    $scope.Acao = "";
                    $scope.divprecaucaogoticula = false;
                    $scope.precaucaogoticulaForm.$setPristine();
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



                obterTodosOsPrecaucaoGoticulas();


            }
        ]);
}());