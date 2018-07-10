
(function () {
    'use strict';

    // TipoDreno

    app.controller("tipodrenoCtrl",
        ['$scope', 'tipodrenoService',
            function ($scope, tipodrenoService) {

                $scope.divtipodreno = false;
                $scope.titulo = "Lista de Tipo de Drenos";

                $scope.tipodrenos = [];

                function ctrlGetTipoDreno() {
                    var tipodrenosData = tipodrenoService.srvcObterTipoDrenos();
                    tipodrenosData.then(function (tipodreno) {
                        $scope.tipodrenos = tipodreno.data;
                        $scope.Acao = "";
                        //toastr["success"]("TipoDrenos carregados com sucesso!", "MedicalManagement-Sys");
                    }, function () {
                        toastr["error"]("Erro ao obter tipo de drenos", "MedicalManagement-Sys");
                    }
                    );
                };
                ctrlGetTipoDreno();


                // obter por id
                // Habilita DIV para Edição de registros
                $scope.ctrlObterPorId = function (tipodreno) {
                    //debugger;
                    //$scope.tipodreno = {};
                    var tipodrenoData = tipodrenoService.srvcGetTipoDrenoPorId(tipodreno.TipoDrenoId);
                    tipodrenoData.then(function (tipodreno) {


                        $scope.tipodreno = tipodreno.data;

                        $scope.Acao = "Atualizar";
                        $scope.divtipodreno = true;
                        toastr["warning"]("Tipo de Dreno carregado para edição!", "MedicalManagement-Sys");

                    }, function () {
                        toastr["error"]("Erro ao obter Tipode Dreno por id!", "MedicalManagement-Sys");
                    });
                };



                // Habilita DIV para Adição de registros
                $scope.incluirTipoDrenoDiv = function () {
                    $scope.tipodreno = {};
                    $scope.tipodrenoForm.$setPristine();
                    $scope.Acao = "Adicionar";
                    $scope.divtipodreno = true;
                };




                $scope.ExcluirTipoDreno = function alert_it(tipodreno) {
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
                            apagarRegistro(tipodreno)
                            swal("EXCLUÍDO!", "O registro foi deletado com sucesso.", "success");
                        });
                }



                var apagarRegistro = function (tipodreno) {
                    var tipodrenoData = tipodrenoService.Excluir(tipodreno.TipoDrenoId);
                    tipodrenoData.then(function (data) {
                        if (data.status === 200) {
                            toastr["warning"]("Tipo de Dreno excluído com sucesso!", "MedicalManagement-Sys");
                            ctrlGetTipoDreno();
                        }
                    }, function () {
                        toastr["error"]("Erro ao excluir Tipo de dreno!", "MedicalManagement-Sys");
                    });
                };



                /* Idade, calculado pela data de nascimento; */
                $scope.AdicionarEditarTipoDreno = function () {
                    var tipodrenoData = null;
                    var _tipodreno = {};
                    _tipodreno = {
                        Descricao: $scope.tipodreno.Descricao
                    };
                    var valorAcao = $scope.Acao;
                    if (valorAcao === "Atualizar") {
                        _tipodreno.TipoDrenoId = $scope.tipodreno.TipoDrenoId;
                        tipodrenoData = tipodrenoService.AtualizarTipoDreno(_tipodreno);
                        tipodrenoData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("Tipo de Dreno alterado com sucesso!", "MedicalManagement-Sys");
                                ctrlGetTipoDreno();
                                $scope.divtipodreno = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao editar Tipo de dreno!", "MedicalManagement-Sys");
                        });
                    } else if (valorAcao === "Adicionar") {
                        tipodrenoData = tipodrenoService.AdicionarTipoDreno(_tipodreno);

                        tipodrenoData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("Tipo de Dreno Adicionado com sucesso!", "MedicalManagement-Sys");
                                ctrlGetTipoDreno();
                                $scope.divtipodreno = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao Adicionar Tipo Dreno!", "MedicalManagement-Sys");
                        });
                    }
                };


                $scope.cancelaEdicao = function () {
                    $scope.Acao = "";
                    $scope.divtipodreno = false;
                    $scope.tipodrenoForm.$setPristine();
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


            }
        ]);
})();