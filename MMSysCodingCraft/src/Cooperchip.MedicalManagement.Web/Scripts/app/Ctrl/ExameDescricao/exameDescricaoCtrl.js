
(function () {
    'use strict';

    // ---/  ExameDescricao

    app.controller("exameDescricaoCtrl",
        ['$scope', 'exameDescricaoService',
            function ($scope, exameDescricaoService) {

                $scope.divexamedescricao = false;
                $scope.titulo = "Lista de Descricao de Exames";


                function obterTodosOsExameDescricaos() {
                    var examedescricaosData = exameDescricaoService.ObterDescricoes();
                    examedescricaosData.then(function (examedescricao) {
                        $scope.examedescricaos = examedescricao.data;
                        $scope.Acao = "";
                    }, function () {
                        toastr["error"]("Erro ao obter examedescricaos", "MedicalManagement-Sys");
                    }
                    );
                };


                // obter por id
                // Habilita DIV para Edição de registros
                $scope.obterPorId = function (examedescricao) {
                    var examedescricaoData = exameDescricaoService.ObterExamesPorId(examedescricao.ExameDescricaoId);
                    examedescricaoData.then(function (examedescricao) {
                        $scope.examedescricao = examedescricao.data;

                        $scope.Acao = "Atualizar";
                        $scope.divexamedescricao = true;
                    }, function () {
                        toastr["error"]("Erro ao obter examedescricao por id!", "MedicalManagement-Sys");
                    });
                };


                // Habilita DIV para Adição de registros
                $scope.incluirExameDescricaoDiv = function () {
                    $scope.examedescricao = {};
                    $scope.examedescricaoForm.$setPristine();
                    $scope.Acao = "Adicionar";
                    $scope.divexamedescricao = true;
                };



                $scope.ExcluirExameDescricao = function (examedescricao) {
                    var examedescricaoData = exameDescricaoService.ExcluirExames(examedescricao.ExameDescricaoId);
                    examedescricaoData.then(function (data) {
                        if (data.status === 200) {
                            toastr["warning"]("ExameDescricao excluído com sucesso!", "MedicalManagement-Sys");
                            obterTodosOsExameDescricaos();
                        }
                    }, function () {
                        toastr["error"]("Erro ao excluir examedescricao!", "MedicalManagement-Sys");
                    });
                };





                $scope.AdicionarEditarPrecaucaoContato = function () {
                    var examedescricaoData = null;
                    var _examedescricao = {
                        Exame: $scope.examedescricao.Exame
                    };
                    var valorAcao = $scope.Acao;
                    if (valorAcao === "Atualizar") {
                        _examedescricao.ExameDescricaoId = $scope.examedescricao.ExameDescricaoId;
                        examedescricaoData = exameDescricaoService.AtualizarExames(_examedescricao);
                        examedescricaoData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("ExameDescricao alterado com sucesso!", "MedicalManagement-Sys");
                                obterTodosOsExameDescricaos();
                                $scope.divexamedescricao = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao editar examedescricao!", "MedicalManagement-Sys");
                        });
                    } else if (valorAcao === "Adicionar") {
                        examedescricaoData = exameDescricaoService.AdicionarExames(_examedescricao);
                        examedescricaoData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("ExameDescricao Adicionado com sucesso!", "MedicalManagement-Sys");
                                obterTodosOsExameDescricaos();
                                $scope.divexamedescricao = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao Adicionar examedescricao!", "MedicalManagement-Sys");
                        });
                    }
                };


                $scope.cancelaEdicao = function () {
                    $scope.Acao = "";
                    $scope.divexamedescricao = false;
                    $scope.examedescricaoForm.$setPristine();
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



                obterTodosOsExameDescricaos();


            }]);
}());


