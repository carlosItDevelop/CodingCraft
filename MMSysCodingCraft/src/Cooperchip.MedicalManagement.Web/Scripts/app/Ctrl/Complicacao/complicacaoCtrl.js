

(function () {
    'use strict';

    // Complicacaos

    app.controller("complicacaoCtrl",
        ['$scope', 'complicacaoService',
            function ($scope, complicacaoService) {

                $scope.divcomplicacao = false;
                $scope.titulo = "Lista de Complicacaos";


                function obterTodosOsComplicacaos() {
                    var complicacaosData = complicacaoService.ObterTodas();
                    complicacaosData.then(function (complicacao) {
                        $scope.complicacaos = complicacao.data;
                        $scope.Acao = "";
                    }, function () {
                        toastr["error"]("Erro ao obter complicacaos", "MedicalManagement-Sys");
                    }
                    );
                };


                // obter por id
                // Habilita DIV para Edição de registros
                $scope.obterPorId = function (complicacao) {
                    var complicacaoData = complicacaoService.GetComplicacaoPorId(complicacao.ComplicacaoId);
                    complicacaoData.then(function (complicacao) {
                        $scope.complicacao = complicacao.data;

                        $scope.Acao = "Atualizar";
                        $scope.divcomplicacao = true;
                    }, function () {
                        toastr["error"]("Erro ao obter complicacao por id!", "MedicalManagement-Sys");
                    });
                };

                // Habilita DIV para Adição de registros
                $scope.incluirComplicacaoDiv = function () {
                    $scope.complicacao = {};
                    $scope.complicacaoForm.$setPristine();
                    $scope.Acao = "Adicionar";
                    $scope.divcomplicacao = true;
                };



                $scope.ExcluirComplicacao = function alert_it(complicacao) {
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
                            apagarRegistro(complicacao)
                            swal("EXCLUÍDO!", "O registro foi deletado com sucesso.", "success");
                        });
                }

                var apagarRegistro = function (complicacao) {
                    var complicacaoData = complicacaoService.Excluir(complicacao.ComplicacaoId);
                    complicacaoData.then(function (data) {
                        if (data.status === 200) {
                            toastr["warning"]("Complicacao excluído com sucesso!", "MedicalManagement-Sys");
                            obterTodosOsComplicacaos();
                        }
                    }, function () {
                        toastr["error"]("Erro ao excluir complicacao!", "MedicalManagement-Sys");
                    });
                };


                $scope.AdicionarEditarComplicacao = function () {
                    var complicacaoData = null;
                    var _complicacao = {
                        Descricao: $scope.complicacao.Descricao
                    };
                    var valorAcao = $scope.Acao;
                    if (valorAcao === "Atualizar") {
                        _complicacao.ComplicacaoId = $scope.complicacao.ComplicacaoId;
                        complicacaoData = complicacaoService.AtualizarComplicacao(_complicacao);
                        complicacaoData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("Complicacao alterado com sucesso!", "MedicalManagement-Sys");
                                obterTodosOsComplicacaos();
                                $scope.divcomplicacao = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao editar complicacao!", "MedicalManagement-Sys");
                        });
                    } else if (valorAcao === "Adicionar") {
                        complicacaoData = complicacaoService.AdicionarComplicacao(_complicacao);

                        complicacaoData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("Complicacao Adicionado com sucesso!", "MedicalManagement-Sys");
                                obterTodosOsComplicacaos();
                                $scope.divcomplicacao = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao Adicionar complicacao!", "MedicalManagement-Sys");
                        });
                    }
                };


                $scope.cancelaEdicao = function () {
                    $scope.Acao = "";
                    $scope.divcomplicacao = false;
                    $scope.complicacaoForm.$setPristine();
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

                obterTodosOsComplicacaos();

            }]);
}());