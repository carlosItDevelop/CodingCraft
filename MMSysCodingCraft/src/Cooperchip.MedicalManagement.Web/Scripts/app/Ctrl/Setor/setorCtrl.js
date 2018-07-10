
(function () {
    'use strict';

    //--/ Setor Ctrl

    app.controller("setorCtrl",
        ['$scope', 'setorService',
            function ($scope, setorService) {

                $scope.divsetor = false;
                $scope.titulo = "Lista de Setores";


                function obterTodosOsSetores() {
                    var setorData = setorService.ObterSetores();
                    setorData.then(function (setor) {
                        $scope.setores = setor.data;
                        $scope.Acao = "";
                    }, function () {
                        toastr["error"]("Erro ao obter setores", "MedicalManagement-Sys");
                    }
                    );
                };


                // obter por id
                // Habilita DIV para Edição de registros
                $scope.obterPorId = function (setor) {
                    var setorData = setorService.GetPorId(setor.SetorId);
                    setorData.then(function (setor) {
                        $scope.setor = setor.data;

                        $scope.Acao = "Atualizar";
                        $scope.divsetor = true;
                    }, function () {
                        toastr["error"]("Erro ao obter setor por id!", "MedicalManagement-Sys");
                    });
                };


                // Habilita DIV para Adição de registros
                $scope.incluirSetorDiv = function () {
                    $scope.setor = {};
                    $scope.setorForm.$setPristine();
                    $scope.Acao = "Adicionar";
                    $scope.divsetor = true;
                };



                $scope.DelSetor = function alert_it(setor) {
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
                            apagarRegistro(setor)
                            swal("EXCLUÍDO!", "O registro foi deletado com sucesso.", "success");
                        });
                }


                var apagarRegistro = function (setor) {
                    var setorData = setorService.DelSetorService(setor.SetorId);
                    setorData.then(function (data) {
                        if (data.status === 200) {
                            toastr["warning"]("Setor excluído com sucesso!", "MedicalManagement-Sys");
                            obterTodosOsSetores();
                        }
                    }, function () {
                        toastr["error"]("Erro ao excluir setor!", "MedicalManagement-Sys");
                    });
                };





                $scope.AdicionarEditarSetor = function () {
                    var setorData = null;
                    var _setor = {
                        Sigla: $scope.setor.Sigla,
                        Descricao: $scope.setor.Descricao
                    };
                    var valorAcao = $scope.Acao;
                    if (valorAcao === "Atualizar") {
                        _setor.SetorId = $scope.setor.SetorId;
                        setorData = setorService.Atualizar(_setor);
                        setorData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("Setor alterado com sucesso!", "MedicalManagement-Sys");
                                obterTodosOsSetores();
                                $scope.divsetor = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao editar setor!", "MedicalManagement-Sys");
                        });
                    } else if (valorAcao === "Adicionar") {
                        setorData = setorService.Add(_setor);
                        setorData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("Setor Adicionado com sucesso!", "MedicalManagement-Sys");
                                obterTodosOsSetores();
                                $scope.divsetor = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao Adicionar setor!", "MedicalManagement-Sys");
                        });
                    }
                };


                $scope.cancelaEdicao = function () {
                    $scope.Acao = "";
                    $scope.divsetor = false;
                    $scope.setorForm.$setPristine();
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



                obterTodosOsSetores();


            }
        ]);

}());