
(function () {
    'use strict';

    // ----/ Precaucao Aerozol -----

    app.controller("precaucaoAerozolCtrl",
        ['$scope', 'precaucaoAerozolService',
            function ($scope, precaucaoAerozolService) {

                $scope.divprecaucaoaerozol = false;
                $scope.titulo = "Lista de Precaução Aerozols";


                function obterTodosOsPrecaucaoAerozols() {
                    var precaucaoaerozolsData = precaucaoAerozolService.ObterPrecaucaoAerozols();
                    precaucaoaerozolsData.then(function (precaucaoaerozol) {
                        $scope.precaucaoaerozols = precaucaoaerozol.data;
                        $scope.Acao = "";
                    }, function () {
                        toastr["error"]("Erro ao obter precaucaoaerozols", "MedicalManagement-Sys");
                    }
                    );
                };


                // obter por id
                // Habilita DIV para Edição de registros
                $scope.obterPorId = function (precaucaoaerozol) {
                    var precaucaoaerozolData = precaucaoAerozolService.ObterPrecaucaoAerozolPorId(precaucaoaerozol.PrecaucaoAerozolId);
                    precaucaoaerozolData.then(function (precaucaoaerozol) {
                        $scope.precaucaoaerozol = precaucaoaerozol.data;

                        $scope.Acao = "Atualizar";
                        $scope.divprecaucaoaerozol = true;
                    }, function () {
                        toastr["error"]("Erro ao obter precaucaoaerozol por id!", "MedicalManagement-Sys");
                    });
                };


                // Habilita DIV para Adição de registros
                $scope.incluirPrecaucaoAerozolDiv = function () {
                    $scope.precaucaoaerozol = {};
                    $scope.precaucaoaerozolForm.$setPristine();
                    $scope.Acao = "Adicionar";
                    $scope.divprecaucaoaerozol = true;
                };



                $scope.ExcluirPrecaucaoAerozol = function alert_it(precaucaoaerozol) {
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
                            apagarRegistro(precaucaoaerozol)
                            swal("EXCLUÍDO!", "O registro foi deletado com sucesso.", "success");
                        });
                }



                var apagarRegistro = function (precaucaoaerozol) {
                    var precaucaoaerozolData = precaucaoAerozolService.ExcluirPrecaucaoAerozol(precaucaoaerozol.PrecaucaoAerozolId);
                    precaucaoaerozolData.then(function (data) {
                        if (data.status === 200) {
                            toastr["warning"]("PrecaucaoAerozol excluído com sucesso!", "MedicalManagement-Sys");
                            obterTodosOsPrecaucaoAerozols();
                        }
                    }, function () {
                        toastr["error"]("Erro ao excluir precaucaoaerozol!", "MedicalManagement-Sys");
                    });
                };





                $scope.AdicionarEditarPrecaucaoAerozol = function () {
                    var precaucaoaerozolData = null;
                    var _precaucaoaerozol = {
                        Nome: $scope.precaucaoaerozol.Nome,
                        Descricao: $scope.precaucaoaerozol.Descricao,
                        Ativo: $scope.precaucaoaerozol.Ativo
                    };
                    var valorAcao = $scope.Acao;
                    if (valorAcao === "Atualizar") {
                        _precaucaoaerozol.PrecaucaoAerozolId = $scope.precaucaoaerozol.PrecaucaoAerozolId;
                        precaucaoaerozolData = precaucaoAerozolService.AtualizarPrecaucaoAerozol(_precaucaoaerozol);
                        precaucaoaerozolData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("PrecaucaoAerozol alterado com sucesso!", "MedicalManagement-Sys");
                                obterTodosOsPrecaucaoAerozols();
                                $scope.divprecaucaoaerozol = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao editar precaucaoaerozol!", "MedicalManagement-Sys");
                        });
                    } else if (valorAcao === "Adicionar") {
                        precaucaoaerozolData = precaucaoAerozolService.AdicionarPrecaucaoAerozol(_precaucaoaerozol);
                        precaucaoaerozolData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("PrecaucaoAerozol Adicionado com sucesso!", "MedicalManagement-Sys");
                                obterTodosOsPrecaucaoAerozols();
                                $scope.divprecaucaoaerozol = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao Adicionar precaucaoaerozol!", "MedicalManagement-Sys");
                        });
                    }
                };


                $scope.cancelaEdicao = function () {
                    $scope.Acao = "";
                    $scope.divprecaucaoaerozol = false;
                    $scope.precaucaoaerozolForm.$setPristine();
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



                obterTodosOsPrecaucaoAerozols();


            }
        ]);
}());

