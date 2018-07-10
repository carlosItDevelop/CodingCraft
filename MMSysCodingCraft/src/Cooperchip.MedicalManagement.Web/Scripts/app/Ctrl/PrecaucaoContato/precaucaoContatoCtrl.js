
(function () {
    'use strict';


    // ---/  Precaucao Contato

    app.controller("precaucaoContatoCtrl",
        ['$scope', 'precaucaoContatoService',
            function ($scope, precaucaoContatoService) {

                $scope.divprecaucaocontato = false;
                $scope.titulo = "Lista de Precaução Contatos";


                function obterTodosOsPrecaucaoContatos() {
                    var precaucaocontatosData = precaucaoContatoService.ObterPrecaucaoContatos();
                    precaucaocontatosData.then(function (precaucaocontato) {
                        $scope.precaucaocontatos = precaucaocontato.data;
                        $scope.Acao = "";
                    }, function () {
                        toastr["error"]("Erro ao obter precaucaocontatos", "MedicalManagement-Sys");
                    }
                    );
                };


                // obter por id
                // Habilita DIV para Edição de registros
                $scope.obterPorId = function (precaucaocontato) {
                    var precaucaocontatoData = precaucaoContatoService.ObterPrecaucaoContatoPorId(precaucaocontato.PrecaucaoContatoId);
                    precaucaocontatoData.then(function (precaucaocontato) {
                        $scope.precaucaocontato = precaucaocontato.data;

                        $scope.Acao = "Atualizar";
                        $scope.divprecaucaocontato = true;
                    }, function () {
                        toastr["error"]("Erro ao obter precaucaocontato por id!", "MedicalManagement-Sys");
                    });
                };


                // Habilita DIV para Adição de registros
                $scope.incluirPrecaucaoContatoDiv = function () {
                    $scope.precaucaocontato = {};
                    $scope.precaucaocontatoForm.$setPristine();
                    $scope.Acao = "Adicionar";
                    $scope.divprecaucaocontato = true;
                };



                $scope.ExcluirPrecaucaoContato = function alert_it(precaucaocontato) {
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
                            apagarRegistro(precaucaocontato)
                            swal("EXCLUÍDO!", "O registro foi deletado com sucesso.", "success");
                        });
                }


                var apagarRegistro = function (precaucaocontato) {
                    var precaucaocontatoData = precaucaoContatoService.ExcluirPrecaucaoContato(precaucaocontato.PrecaucaoContatoId);
                    precaucaocontatoData.then(function (data) {
                        if (data.status === 200) {
                            toastr["warning"]("PrecaucaoContato excluído com sucesso!", "MedicalManagement-Sys");
                            obterTodosOsPrecaucaoContatos();
                        }
                    }, function () {
                        toastr["error"]("Erro ao excluir precaucaocontato!", "MedicalManagement-Sys");
                    });
                };





                $scope.AdicionarEditarPrecaucaoContato = function () {
                    var precaucaocontatoData = null;
                    var _precaucaocontato = {
                        Nome: $scope.precaucaocontato.Nome,
                        Descricao: $scope.precaucaocontato.Descricao,
                        Ativo: $scope.precaucaocontato.Ativo
                    };
                    var valorAcao = $scope.Acao;
                    if (valorAcao === "Atualizar") {
                        _precaucaocontato.PrecaucaoContatoId = $scope.precaucaocontato.PrecaucaoContatoId;
                        precaucaocontatoData = precaucaoContatoService.AtualizarPrecaucaoContato(_precaucaocontato);
                        precaucaocontatoData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("PrecaucaoContato alterado com sucesso!", "MedicalManagement-Sys");
                                obterTodosOsPrecaucaoContatos();
                                $scope.divprecaucaocontato = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao editar precaucaocontato!", "MedicalManagement-Sys");
                        });
                    } else if (valorAcao === "Adicionar") {
                        precaucaocontatoData = precaucaoContatoService.AdicionarPrecaucaoContato(_precaucaocontato);
                        precaucaocontatoData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("PrecaucaoContato Adicionado com sucesso!", "MedicalManagement-Sys");
                                obterTodosOsPrecaucaoContatos();
                                $scope.divprecaucaocontato = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao Adicionar precaucaocontato!", "MedicalManagement-Sys");
                        });
                    }
                };


                $scope.cancelaEdicao = function () {
                    $scope.Acao = "";
                    $scope.divprecaucaocontato = false;
                    $scope.precaucaocontatoForm.$setPristine();
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



                obterTodosOsPrecaucaoContatos();


            }
        ]);
}());