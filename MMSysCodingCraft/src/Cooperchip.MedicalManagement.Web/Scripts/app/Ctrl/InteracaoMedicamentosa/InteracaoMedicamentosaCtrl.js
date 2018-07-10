
(function () {
    'use strict';

    // -----/ InteracaoMedicamentosa --

    app.controller("interacaoMedicamentosaCtrl",
        ['$scope', 'interacaoMedicamentosaService',
            function ($scope, interacaoMedicamentosaService) {

                $scope.divinteracaoMedicamentosa = false;
                $scope.titulo = "Lista de Interação Medicamentosa";
                $scope.genericos = [];


                /* ------/ prototype para retirar os 9 primeiros caracteres, 
                por o décimo em maiúculo e a partir daí imprimir ---------*/
                String.prototype.capitalize = function () {
                    return this.charAt(8).toUpperCase() + this.slice(9);
                }
                // ----/ ------/
                function obterTodosAsInteracaoMedicamentosas() {
                    var interacaoMedicamentosasData = interacaoMedicamentosaService.ObterTodas();
                    interacaoMedicamentosasData.then(function (interacaoMedicamentosa) {
                        $scope.interacaoMedicamentosas = interacaoMedicamentosa.data;
                        /*--/ Retirando a palavra Efeito: 
                        mais espaço e iniciando a Interação com Maiúculo --*/
                        var tam = interacaoMedicamentosa.data.length;
                        for (var i = 0; i < tam; i++) {
                            var intAux = interacaoMedicamentosa.data[i].Interacao.capitalize();
                            $scope.interacaoMedicamentosas[i].Interacao = intAux;
                            //if (i > 10) break;
                        }
                        /*-------------------------------------------------*/
                        $scope.Acao = "";
                    }, function () {
                        toastr["error"]("Erro ao obter interacaoMedicamentosas", "MedicalManagement-Sys");
                    }
                    );
                };
                // ------/ -----------------------------------------------------------------/





                // obter por id
                // Habilita DIV para Edição de registros
                $scope.obterPorId = function (interacaoMedicamentosa) {
                    var interacaoMedicamentosaData = interacaoMedicamentosaService.GetInteracaoMedicamentosaPorId(interacaoMedicamentosa.InteracaoMedicamentosaId);
                    interacaoMedicamentosaData.then(function (interacaoMedicamentosa) {
                        $scope.interacaoMedicamentosa = interacaoMedicamentosa.data;

                        $scope.Acao = "Atualizar";
                        $scope.divinteracaoMedicamentosa = true;
                    }, function () {
                        toastr["error"]("Erro ao obter interacaoMedicamentosa por id!", "MedicalManagement-Sys");
                    });
                };



                // Habilita DIV para Adição de registros
                $scope.incluirInteracaoMedicamentosaDiv = function () {
                    $scope.interacaoMedicamentosa = {};
                    $scope.interacaoMedicamentosaForm.$setPristine();
                    $scope.Acao = "Adicionar";
                    $scope.divinteracaoMedicamentosa = true;
                };



                $scope.ExcluirInteracaoMedicamentosa = function alert_it(interacaoMedicamentosa) {
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
                            apagarRegistro(interacaoMedicamentosa)
                            swal("EXCLUÍDO!", "O registro foi deletado com sucesso.", "success");
                        });
                }


                var apagarRegistro = function (interacaoMedicamentosa) {
                    var interacaoMedicamentosaData = interacaoMedicamentosaService.Excluir(interacaoMedicamentosa.InteracaoMedicamentosaId);
                    interacaoMedicamentosaData.then(function (data) {
                        if (data.status === 200) {
                            toastr["warning"]("InteracaoMedicamentosa excluído com sucesso!", "MedicalManagement-Sys");
                            obterTodosAsInteracaoMedicamentosas();
                        }
                    }, function () {
                        toastr["error"]("Erro ao excluir interacaoMedicamentosa!", "MedicalManagement-Sys");
                    });
                };

                $scope.AdicionarEditarInteracaoMedicamentosa = function () {
                    var interacaoMedicamentosaData = null;
                    var _interacaoMedicamentosa = {
                        IdMedicamentoA: $scope.interacaoMedicamentosa.IdMedicamentoA,
                        IdMedicamentoB: $scope.interacaoMedicamentosa.IdMedicamentoB,
                        Interacao: $scope.interacaoMedicamentosa.Interacao
                    };
                    var valorAcao = $scope.Acao;
                    if (valorAcao === "Atualizar") {
                        _interacaoMedicamentosa.InteracaoMedicamentosaId = $scope.interacaoMedicamentosa.InteracaoMedicamentosaId;
                        interacaoMedicamentosaData = interacaoMedicamentosaService.AtualizarInteracaoMedicamentosa(_interacaoMedicamentosa);
                        interacaoMedicamentosaData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("InteracaoMedicamentosa alterado com sucesso!", "MedicalManagement-Sys");
                                obterTodosAsInteracaoMedicamentosas();
                                $scope.divinteracaoMedicamentosa = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao editar interacaoMedicamentosa!", "MedicalManagement-Sys");
                        });
                    } else if (valorAcao === "Adicionar") {
                        interacaoMedicamentosaData = interacaoMedicamentosaService.AddInteracaoMedicamentosa(_interacaoMedicamentosa);
                        interacaoMedicamentosaData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("InteracaoMedicamentosa Adicionado com sucesso!", "MedicalManagement-Sys");
                                obterTodosAsInteracaoMedicamentosas();
                                $scope.divinteracaoMedicamentosa = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao Adicionar interacaoMedicamentosa!", "MedicalManagement-Sys");
                        });
                    }
                };


                $scope.cancelaEdicao = function () {
                    $scope.Acao = "";
                    $scope.divinteracaoMedicamentosa = false;
                    $scope.interacaoMedicamentosaForm.$setPristine();
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
                obterTodosAsInteracaoMedicamentosas();


            }
        ]);
}());