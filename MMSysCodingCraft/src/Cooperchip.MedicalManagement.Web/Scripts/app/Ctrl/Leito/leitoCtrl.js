
(function () {
    'use strict';

    //--/ Leito Ctrl

    app.controller("leitoCtrl",
        ['$scope', 'leitoService',
            function ($scope, leitoService) {

                $scope.divleito = false;
                $scope.titulo = "Lista de Leitos";


                function obterTodosOsLeitos() {
                    var leitosData = leitoService.ObterLeitos();
                    leitosData.then(function (leito) {
                        $scope.leitos = leito.data;
                        $scope.Acao = "";
                    }, function () {
                        toastr["error"]("Erro ao obter leitos", "MedicalManagement-Sys");
                    }
                    );
                };


                // obter por id
                // Habilita DIV para Edição de registros
                $scope.obterPorId = function (leito) {
                    var leitoData = leitoService.ObterLeitoPorId(leito.LeitoId);
                    leitoData.then(function (leito) {
                        $scope.leito = leito.data;

                        $scope.Acao = "Atualizar";
                        $scope.divleito = true;
                    }, function () {
                        toastr["error"]("Erro ao obter leito por id!", "MedicalManagement-Sys");
                    });
                };


                // Habilita DIV para Adição de registros
                $scope.incluirLeitoDiv = function () {
                    $scope.leito = {};
                    $scope.leitoForm.$setPristine();
                    $scope.Acao = "Adicionar";
                    $scope.divleito = true;
                };



                $scope.ExcluirLeito = function alert_it(leito) {
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
                            apagarRegistro(leito)
                            swal("EXCLUÍDO!", "O registro foi deletado com sucesso.", "success");
                        });
                }


                var apagarRegistro = function (leito) {
                    var leitoData = leitoService.ExcluirLeito(leito.LeitoId);
                    leitoData.then(function (data) {
                        if (data.status === 200) {
                            toastr["warning"]("Leito excluído com sucesso!", "MedicalManagement-Sys");
                            obterTodosOsLeitos();
                        }
                    }, function () {
                        toastr["error"]("Erro ao excluir leito!", "MedicalManagement-Sys");
                    });
                };





                $scope.AdicionarEditarLeito = function () {
                    var leitoData = null;
                    var _leito = {
                        Nome: $scope.leito.Nome,
                        EspecificacaoDoLeito: $scope.leito.EspecificacaoDoLeito,
                        Ativo: $scope.leito.Ativo
                    };
                    var valorAcao = $scope.Acao;
                    if (valorAcao === "Atualizar") {
                        _leito.LeitoId = $scope.leito.LeitoId;
                        leitoData = leitoService.AtualizarLeito(_leito);
                        leitoData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("Leito alterado com sucesso!", "MedicalManagement-Sys");
                                obterTodosOsLeitos();
                                $scope.divleito = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao editar leito!", "MedicalManagement-Sys");
                        });
                    } else if (valorAcao === "Adicionar") {
                        leitoData = leitoService.AdicionarLeito(_leito);
                        leitoData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("Leito Adicionado com sucesso!", "MedicalManagement-Sys");
                                obterTodosOsLeitos();
                                $scope.divleito = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao Adicionar leito!", "MedicalManagement-Sys");
                        });
                    }
                };


                $scope.cancelaEdicao = function () {
                    $scope.Acao = "";
                    $scope.divleito = false;
                    $scope.leitoForm.$setPristine();
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



                obterTodosOsLeitos();


            }
        ]);
}());