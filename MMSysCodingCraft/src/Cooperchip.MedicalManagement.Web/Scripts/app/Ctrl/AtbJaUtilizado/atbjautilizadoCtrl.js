


// ----/ AtbJaUtilizadoCtrl -------------- //

(function () {

    'use strict';

    app.controller("AtbJaUtilizadoCtrl",
        ['$scope', '$filter', '$http', 'atbJaUtilizadoService',
            function ($scope, $filter, $http, atbJaUtilizadoService) {

                $scope.titulo = "Antibióticos Já Utilizados";
                $scope.atbjautilizados = [];
                $scope.atbjautilizado = {};
                $scope.divatbjautilizado = false;

                var idprontuario;
                var idpaciente;
                // Evento click simulado em outra controller,
                // via javaScript, => ProntuarioCtrl.js.
                $("#idPaciente").click(function () {
                    idpaciente = $("#idPaciente").val();
                    idprontuario = $("#ProntuarioId").val();
                    if (idpaciente && idprontuario) {
                        $scope.atbjautilizado.PacienteId = idpaciente;
                        $scope.atbjautilizado.ProntuarioGuid = idprontuario;
                        obterAtbJaUtilizadoPorPacienteEProntuario();
                    };
                    $scope.Acao = "";
                    $scope.divatbjautilizado = false;
                });


                var obterAtbJaUtilizadoPorPacienteEProntuario = function () {
                    var atbjautilizadoData = atbJaUtilizadoService.GetAtbJaUtilizadoPorPacienteEProntuario(idpaciente, idprontuario);
                    atbjautilizadoData.then(function (resultado) {
                        $scope.atbjautilizados = resultado.data;
                        $scope.Acao = "";
                        $scope.divatbjautilizado = false;
                    }, function () {
                        toastr["error"]("Erro ao obter AtbJaUtilizado por Paciente!", "MedicalManagement-Sys");
                    });
                };


                // obter por id
                // Habilita DIV para Edição de registros
                $scope.obterPorId = function (atbjautilizado) {
                    var atbjautilizadoData = atbJaUtilizadoService.GetAtbJaUtilizadoPorId(atbjautilizado.AtbJaUtilizadoId);
                    atbjautilizadoData.then(function (atbjautilizado) {
                        $scope.atbjautilizado = atbjautilizado.data;
                        $scope.Acao = "Atualizar";
                        $scope.divatbjautilizado = true;
                    }, function () {
                        toastr["error"]("Erro ao obter AtbJaUtilizado por id!", "MedicalManagement-Sys");
                    });
                };


                $scope.AdicionarEditarAtbJaUtilizado = function () {
                    var atbjautilizadoData = null;
                    var _atbjautilizado = {
                        Descricao: $scope.atbjautilizado.Descricao,
                        PacienteId: idpaciente,
                        ProntuarioGuid: idprontuario
                    };
                    var valorAcao = $scope.Acao;
                    if (valorAcao === "Atualizar") {
                        _atbjautilizado.AtbJaUtilizadoId = $scope.atbjautilizado.AtbJaUtilizadoId;
                        atbjautilizadoData = atbJaUtilizadoService.AtualizarAtbJaUtilizado(_atbjautilizado);
                        atbjautilizadoData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("AtbJaUtilizado alterado com sucesso!", "MedicalManagement-Sys");
                                obterAtbJaUtilizadoPorPacienteEProntuario();
                                $scope.divatbjautilizado = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao editar AtbJaUtilizado!", "MedicalManagement-Sys");
                        });
                    } else if (valorAcao === "Adicionar") {
                        atbjautilizadoData = atbJaUtilizadoService.AddAtbJaUtilizado(_atbjautilizado);
                        atbjautilizadoData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("AtbJaUtilizado Adicionado com sucesso!", "MedicalManagement-Sys");
                                obterAtbJaUtilizadoPorPacienteEProntuario();
                                $scope.divatbjautilizado = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao Adicionar AtbJaUtilizado!", "MedicalManagement-Sys");
                        });
                    }
                };



                $scope.ExcluirAtbJaUtilizado = function alert_it(atbjautilizado) {
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
                            DeletarAtbJaUtilizado(atbjautilizado)
                            swal("EXCLUÍDO!", "O registro foi deletado com sucesso.", "success");
                        });
                }

                var DeletarAtbJaUtilizado = function (atbjautilizado) {
                    var atbjautilizadoData = atbJaUtilizadoService.DelAtbJaUtilizado(atbjautilizado.AtbJaUtilizadoId);
                    atbjautilizadoData.then(function (data) {
                        if (data.status === 200) {
                            $scope.Acao = "";
                            $scope.divatbjautilizado = false;
                            toastr["warning"]("AtbJaUtilizado excluído com sucesso!", "MedicalManagement-Sys");
                            obterAtbJaUtilizadoPorPacienteEProntuario();
                        }
                    }, function () {
                        toastr["error"]("Erro ao excluir AtbJaUtilizado!", "MedicalManagement-Sys");
                    });
                };


                /* ---------------------------------------------------------------- */

                // Habilita DIV para Adição de registros
                $scope.incluirAtbJaUtilizadoDiv = function () {
                    $scope.atbjautilizado = {};
                    $scope.AtbJaUtilizadoForm.$setPristine();
                    $scope.Acao = "Adicionar";
                    $scope.divatbjautilizado = true;
                };


                $scope.cancelaEdicao = function () {
                    $scope.Acao = "";
                    $scope.divatbjautilizado = false;
                    $scope.AtbJaUtilizadoForm.$setPristine();
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

                /* ---------------------------------------------------------------- */

                $scope.isEditando = function () {
                    if (($scope.Acao === "Atualizar")) {
                        return true;
                    }
                    return false;
                };




            }]);

})();
