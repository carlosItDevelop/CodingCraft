
(function () {
    'use strict';


    // Base De Conhecimento

    app.controller("baseDeConhecimentoCtrl",
        ['$scope', 'baseDeConhecimentoService',
            function ($scope, baseDeConhecimentoService) {

                $scope.divbaseDeConhecimento = false;
                $scope.titulo = "Lista de BaseDeConhecimentos";


                function obterTodosOsBaseDeConhecimentos() {
                    var baseDeConhecimentosData = baseDeConhecimentoService.ObterTodas();
                    baseDeConhecimentosData.then(function (baseDeConhecimento) {
                        $scope.baseDeConhecimentos = baseDeConhecimento.data;
                        $scope.Acao = "";
                    }, function () {
                        toastr["error"]("Erro ao obter baseDeConhecimentos", "MedicalManagement-Sys");
                    }
                    );
                };


                // obter por id
                // Habilita DIV para Edição de registros
                $scope.obterPorId = function (baseDeConhecimento) {
                    var baseDeConhecimentoData = baseDeConhecimentoService.GetBaseDeConhecimentoPorId(baseDeConhecimento.BaseDeConhecimentoId);
                    baseDeConhecimentoData.then(function (baseDeConhecimento) {
                        $scope.baseDeConhecimento = baseDeConhecimento.data;

                        $scope.Acao = "Atualizar";
                        $scope.divbaseDeConhecimento = true;
                    }, function () {
                        toastr["error"]("Erro ao obter baseDeConhecimento por id!", "MedicalManagement-Sys");
                    });
                };



                // Habilita DIV para Adição de registros
                $scope.incluirBaseDeConhecimentoDiv = function () {
                    $scope.baseDeConhecimento = {};
                    $scope.baseDeConhecimentoForm.$setPristine();
                    $scope.Acao = "Adicionar";
                    $scope.divbaseDeConhecimento = true;
                };



                $scope.ExcluirBaseDeConhecimento = function (baseDeConhecimento) {
                    var baseDeConhecimentoData = baseDeConhecimentoService.Excluir(baseDeConhecimento.BaseDeConhecimentoId);
                    baseDeConhecimentoData.then(function (data) {
                        if (data.status === 200) {
                            toastr["warning"]("BaseDeConhecimento excluído com sucesso!", "MedicalManagement-Sys");
                            obterTodosOsBaseDeConhecimentos();
                        }
                    }, function () {
                        toastr["error"]("Erro ao excluir baseDeConhecimento!", "MedicalManagement-Sys");
                    });
                };





                $scope.AdicionarEditarBaseDeConhecimento = function () {
                    var baseDeConhecimentoData = null;
                    var _baseDeConhecimento = {
                        Pergunta: $scope.baseDeConhecimento.Pergunta,
                        Resposta: $scope.baseDeConhecimento.Resposta
                    };
                    var valorAcao = $scope.Acao;
                    if (valorAcao === "Atualizar") {
                        _baseDeConhecimento.BaseDeConhecimentoId = $scope.baseDeConhecimento.BaseDeConhecimentoId;
                        baseDeConhecimentoData = baseDeConhecimentoService.AtualizarBaseDeConhecimento(_baseDeConhecimento);
                        baseDeConhecimentoData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("BaseDeConhecimento alterado com sucesso!", "MedicalManagement-Sys");
                                obterTodosOsBaseDeConhecimentos();
                                $scope.divbaseDeConhecimento = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao editar baseDeConhecimento!", "MedicalManagement-Sys");
                        });
                    } else if (valorAcao === "Adicionar") {
                        baseDeConhecimentoData = baseDeConhecimentoService.AdicionarBaseDeConhecimento(_baseDeConhecimento);

                        baseDeConhecimentoData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("BaseDeConhecimento Adicionado com sucesso!", "MedicalManagement-Sys");
                                obterTodosOsBaseDeConhecimentos();
                                $scope.divbaseDeConhecimento = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao Adicionar baseDeConhecimento!", "MedicalManagement-Sys");
                        });
                    }
                };


                $scope.cancelaEdicao = function () {
                    $scope.Acao = "";
                    $scope.divbaseDeConhecimento = false;
                    $scope.baseDeConhecimentoForm.$setPristine();
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



                obterTodosOsBaseDeConhecimentos();


            }]);

}());