
(function () {
    'use strict';

    // ---/  drenoCtrl


    app.controller('drenoCtrl',
        ['$scope', '$filter', 'drenoService',
            function ($scope, $filter, drenoService) {

                $scope.divdreno = false;

                $scope.titulo = "Lista de Drenos";
                $scope.drenos = [];
                $scope.tipodrenos = [];
                $scope.dreno = {};



                var idprontuario;
                var idpaciente;
                // Evento click simulado em outra controller,
                // via javaScript, => ProntuarioCtrl.js.
                $("#idPaciente").click(function () {
                    idpaciente = $("#idPaciente").val();
                    idprontuario = $("#ProntuarioId").val();
                    if (idpaciente && idprontuario) {
                        $scope.dreno.PacienteId = idpaciente;
                        $scope.dreno.ProntuarioGuid = idprontuario;
                        obterDrenoPorPacienteEProntuario();
                    };
                    $scope.Acao = "";
                    $scope.divdreno = false;
                });

                var obterDrenoPorPacienteEProntuario = function () {
                    var drenoData = drenoService.GetDrenoPorPacienteEProntuario(idpaciente, idprontuario);
                    drenoData.then(function (resultado) {
                        $scope.drenos = resultado.data;
                        $scope.Acao = "";
                        $scope.divdreno = false;
                    }, function () {
                        toastr["error"]("Erro ao obter Dreno por Paciente!", "MedicalManagement-Sys");
                    });
                };



                var carregaTipoDreno = function () {
                    var tipodrenoData = drenoService.GetTipoDeDrenos();
                    tipodrenoData.then(function (tipodreno) {
                        $scope.tipodrenos = tipodreno.data;
                        //toastr['success']('Tipo de Drenos carregados com sucesso!', 'MedicalManagement-Sys');
                    }, function () {
                        toastr['error']('Erro carregando os Tipo de Drenos...', 'MedicalManagement-Sys');
                    });
                };
                carregaTipoDreno();



                // obter por id
                // Habilita DIV para Edição de registros
                $scope.obterPorId = function (dreno) {
                    var drenoData = drenoService.GetDrenoPorId(dreno.DrenoId);
                    drenoData.then(function (dreno) {
                        dreno.data.DataInsercao = new Date(dreno.data.DataInsercao);
                        $scope.dreno = dreno.data;
                        //$scope.dreno.DataInsercao = new Date(dreno.data.DataInsercao);
                        $scope.Acao = "Atualizar";
                        $scope.divdreno = true;
                    }, function () {
                        toastr["error"]("Erro ao obter Dreno por id!", "MedicalManagement-Sys");
                    });
                };



                $scope.AdicionarEditarDreno = function () {
                    var drenoData = null;
                    var _dreno = {
                        IdTipoDreno: $scope.dreno.IdTipoDreno,
                        Local: $scope.dreno.Local,
                        DataInsercao: new Date($scope.dreno.DataInsercao),
                        PacienteId: idpaciente,
                        ProntuarioGuid: idprontuario
                    };
                    var valorAcao = $scope.Acao;
                    if (valorAcao === "Atualizar") {
                        _dreno.DrenoId = $scope.dreno.DrenoId;
                        drenoData = drenoService.AtualizarDreno(_dreno);
                        drenoData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("Dreno alterado com sucesso!", "MedicalManagement-Sys");
                                obterDrenoPorPacienteEProntuario();
                                $scope.divdreno = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao editar dreno!", "MedicalManagement-Sys");
                        });
                    } else if (valorAcao === "Adicionar") {
                        drenoData = drenoService.AddDreno(_dreno);
                        drenoData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("Dreno Adicionado com sucesso!", "MedicalManagement-Sys");
                                obterDrenoPorPacienteEProntuario();
                                $scope.divdreno = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao Adicionar dreno!", "MedicalManagement-Sys");
                        });
                    }
                };



                $scope.ExcluirDreno = function alert_it(dreno) {
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
                            apagarRegistro(dreno)
                            swal("EXCLUÍDO!", "O registro foi deletado com sucesso.", "success");
                        });
                }


                var apagarRegistro = function (dreno) {
                    var drenoData = drenoService.Excluir(dreno.DrenoId);
                    drenoData.then(function (data) {
                        if (data.status === 200) {
                            $scope.Acao = "";
                            $scope.divdreno = false;
                            toastr["warning"]("Dreno excluído com sucesso!", "MedicalManagement-Sys");
                            obterDrenoPorPacienteEProntuario();
                        }
                    }, function () {
                        toastr["error"]("Erro ao excluir dreno!", "MedicalManagement-Sys");
                    });
                };


                // Habilita DIV para Adição de registros
                $scope.incluirDrenoDiv = function () {
                    $scope.dreno = {};
                    $scope.drenoForm.$setPristine();
                    $scope.Acao = "Adicionar";
                    $scope.divdreno = true;
                };


                $scope.cancelaEdicao = function () {
                    $scope.Acao = "";
                    $scope.divdreno = false;
                    $scope.drenoForm.$setPristine();
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



                // Habilita o botão de adicionar apenas 
                // se o PacienteId estiver selecionado
                $scope.isIdPacienteInvalido = function () {
                    if (!idpaciente) {
                        return true;
                    } else {
                        return false;
                    }
                }


            }]);

}());


