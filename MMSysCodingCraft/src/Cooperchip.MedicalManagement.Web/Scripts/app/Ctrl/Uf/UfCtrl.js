
(function () {
    'use strict';

    // Ufs

    app.controller("ufCtrl",
        ['$scope', 'ufService',
            function ($scope, ufService) {

                $scope.divuf = false;
                $scope.titulo = "Lista de Ufs";


                function obterTodosAsUfs() {
                    var ufsData = ufService.GetUf();
                    ufsData.then(function (uf) {
                        $scope.ufs = uf.data;
                        $scope.Acao = "";
                    }, function () {
                        toastr["error"]("Erro ao obter ufs", "MedicalManagement-Sys");
                    }
                    );
                };


                // obter por id
                // Habilita DIV para Edição de registros
                $scope.obterPorId = function (uf) {
                    var ufData = ufService.GetUfPorId(uf.UfId);
                    ufData.then(function (uf) {
                        $scope.uf = uf.data;

                        $scope.Acao = "Atualizar";
                        $scope.divuf = true;
                    }, function () {
                        toastr["error"]("Erro ao obter uf por id!", "MedicalManagement-Sys");
                    });
                };



                // Habilita DIV para Adição de registros
                $scope.incluirUfDiv = function () {
                    $scope.uf = {};
                    $scope.ufForm.$setPristine();
                    $scope.Acao = "Adicionar";
                    $scope.divuf = true;
                };



                $scope.ExcluirUf = function alert_it(uf) {
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
                            apagarRegistro(uf)
                            swal("EXCLUÍDO!", "O registro foi deletado com sucesso.", "success");
                        });
                }


                var apagarRegistro = function (uf) {
                    var ufData = ufService.Excluir(uf.UfId);
                    ufData.then(function (data) {
                        if (data.status === 200) {
                            toastr["warning"]("Uf excluído com sucesso!", "MedicalManagement-Sys");
                            obterTodosAsUfs();
                        }
                    }, function () {
                        toastr["error"]("Erro ao excluir uf!", "MedicalManagement-Sys");
                    });
                };





                $scope.AdicionarEditarUf = function () {
                    var ufData = null;
                    var _uf = {
                        Sigla: $scope.uf.Sigla,
                        Estado: $scope.uf.Estado,
                        CodigoEstado: $scope.uf.CodigoEstado
                    };
                    var valorAcao = $scope.Acao;
                    if (valorAcao === "Atualizar") {
                        _uf.UfId = $scope.uf.UfId;
                        ufData = ufService.AtualizarUf(_uf);
                        ufData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("Uf alterado com sucesso!", "MedicalManagement-Sys");
                                obterTodosAsUfs();
                                $scope.divuf = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao editar uf!", "MedicalManagement-Sys");
                        });
                    } else if (valorAcao === "Adicionar") {
                        ufData = ufService.AdicionarUf(_uf);

                        ufData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("Uf Adicionado com sucesso!", "MedicalManagement-Sys");
                                obterTodosAsUfs();
                                $scope.divuf = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao Adicionar uf!", "MedicalManagement-Sys");
                        });
                    }
                };


                $scope.cancelaEdicao = function () {
                    $scope.Acao = "";
                    $scope.divuf = false;
                    $scope.ufForm.$setPristine();
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



                obterTodosAsUfs();


            }
        ]);
})();