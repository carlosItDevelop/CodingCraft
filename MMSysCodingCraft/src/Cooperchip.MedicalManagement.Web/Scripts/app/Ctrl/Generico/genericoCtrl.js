
(function () {
    'use strict';

    // Genericos

    app.controller("genericoCtrl",
        ['$scope', 'genericoService',
            function ($scope, genericoService) {

                $scope.divgenerico = false;
                $scope.titulo = "Lista de Genéricos";


                function obterTodosOsGenericos() {
                    var genericosData = genericoService.ObterGenericos();
                    genericosData.then(function (generico) {
                        $scope.genericos = generico.data;
                        $scope.Acao = "";
                    }, function () {
                        toastr["error"]("Erro ao obter genericos", "MedicalManagement-Sys");
                    }
                    );
                };


                // obter por id
                // Habilita DIV para Edição de registros
                $scope.obterPorId = function (generico) {
                    var genericoData = genericoService.GetGenericoPorId(generico.GenericoId);
                    genericoData.then(function (generico) {
                        $scope.generico = generico.data;

                        $scope.Acao = "Atualizar";
                        $scope.divgenerico = true;
                    }, function () {
                        toastr["error"]("Erro ao obter generico por id!", "MedicalManagement-Sys");
                    });
                };



                // Habilita DIV para Adição de registros
                $scope.incluirGenericoDiv = function () {
                    $scope.generico = {};
                    $scope.genericoForm.$setPristine();
                    $scope.Acao = "Adicionar";
                    $scope.divgenerico = true;
                };



                $scope.ExcluirGenerico = function (generico) {
                    var genericoData = genericoService.Excluir(generico.GenericoId);
                    genericoData.then(function (data) {
                        if (data.status === 200) {
                            toastr["warning"]("Generico excluído com sucesso!", "MedicalManagement-Sys");
                            obterTodosOsGenericos();
                        }
                    }, function () {
                        toastr["error"]("Erro ao excluir generico!", "MedicalManagement-Sys");
                    });
                };





                $scope.AdicionarEditarGenerico = function () {
                    var genericoData = null;
                    var _generico = {
                        Descricao: $scope.generico.Descricao
                    };
                    var valorAcao = $scope.Acao;
                    if (valorAcao === "Atualizar") {
                        _generico.GenericoId = $scope.generico.GenericoId;
                        genericoData = genericoService.AtualizarGenerico(_generico);
                        genericoData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("Generico alterado com sucesso!", "MedicalManagement-Sys");
                                obterTodosOsGenericos();
                                $scope.divgenerico = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao editar generico!", "MedicalManagement-Sys");
                        });
                    } else if (valorAcao === "Adicionar") {
                        genericoData = genericoService.AdicionarGenerico(_generico);

                        genericoData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("Generico Adicionado com sucesso!", "MedicalManagement-Sys");
                                obterTodosOsGenericos();
                                $scope.divgenerico = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao Adicionar generico!", "MedicalManagement-Sys");
                        });
                    }
                };


                $scope.cancelaEdicao = function () {
                    $scope.Acao = "";
                    $scope.divgenerico = false;
                    $scope.genericoForm.$setPristine();
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



                obterTodosOsGenericos();


            }
        ]);
}());