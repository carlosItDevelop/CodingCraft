
// Prontuario ProntuarioPrecaucao

(function () {

    'use strict';

    app.controller("prontuarioprecaucaoCtrl",
        ['$scope', 'prontuarioprecaucaoService', 'tipodeprecaucaoService', 'causaprecaucaoService',
            function ($scope, prontuarioprecaucaoService, tipodeprecaucaoService, causaprecaucaoService) {

                $scope.divprontuarioprecaucao = false;
                $scope.titulo = "Lista de Precaucões";
                $scope.Acao = "";

                $scope.prontuarioprecaucaos = [];
                $scope.pacientes = [];

                $scope.precaucaos = [];
                $scope.precaucao = {};


                $scope.prontuarioprecaucao = {};
                $scope.prontuarioprecaucao.PacienteId = 0;

                /* -----/ ----------------------------------------------------------------------------------------------- */
                /* -----/ Carrega lista de Prontuario Precaução por Paciente e Prontuário ------------- */

                var idprontuario;
                var idpaciente;
                // Evento click simulado em outra controller,
                // via javaScript, => ProntuarioCtrl.js.
                $("#idPaciente").click(function () {
                    idpaciente = $("#idPaciente").val();
                    idprontuario = $("#ProntuarioId").val();
                    if (idpaciente && idprontuario) {
                        $scope.prontuarioprecaucao.PacienteId = idpaciente;
                        $scope.prontuarioprecaucao.ProntuarioGuid = idprontuario;
                        obterPorIdPacienteEProntuario();
                    };
                });

                function obterPorIdPacienteEProntuario() {
                    var prontuarioprecaucaoData = prontuarioprecaucaoService.getProntuarioPrecaucaoPorIdPacienteEProntuario(idpaciente, idprontuario);
                    prontuarioprecaucaoData.then(function (resultado) {
                        $scope.prontuarioprecaucaos = resultado.data;
                        $scope.Acao = "";
                        $scope.divprontuarioprecaucao = false;
                    }, function () {
                        toastr["error"]("Erro ao obter prontuarioprecaucao por Paciente!", "MedicalManagement-Sys");
                    });
                };

                /* -----/ ----------------------------------------------------------------------------------------------- */
                /* -----/ ----------------------------------------------------------------------------------------------- */



                $scope.tipoprecaucaos = [];
                function obterTiposDePrecaucao() {
                    var tipoprecaucaosData = tipodeprecaucaoService.ObterTiposPrecaucoes();
                    tipoprecaucaosData.then(function (tipoprecaucao) {
                        $scope.tipoprecaucaos = tipoprecaucao.data;
                    }, function () {
                        toastr["error"]("Erro ao obter tipos de precauções", "MedicalManagement-Sys");
                    });
                };
                obterTiposDePrecaucao();



                // ----/ ------------------------------------------------------------------------- //
                $("#tipodeprecaucao").blur(function () {
                    $scope.precaucaos = [];
                    if ($scope.prontuarioprecaucao.IdTipoPrecaucao) obterCausasPorPrecaucao($scope.prontuarioprecaucao.IdTipoPrecaucao);
                });

                function obterCausasPorPrecaucao(idtpprecaucao) {
                    var causasprecaucaoData = causaprecaucaoService.ObterCausasPrecaucoes(idtpprecaucao);
                    causasprecaucaoData.then(function (resultado) {
                        $scope.precaucaos = resultado.data;
                    }, function () {
                        toastr["error"]("Erro ao obter causas de precauções", "MedicalManagement-Sys");
                    }
                    );
                };
                // ----/ ------------------------------------------------------------------------- //



                // obter por id
                // Para o botão editar do formulário;
                // Habilita DIV para Edição de registros
                $scope.obterPorId = function (prontuarioprecaucao) {
                    var prontuarioprecaucaoData = prontuarioprecaucaoService.getProntuarioPrecaucaoPorId(prontuarioprecaucao.ProntuarioPrecaucaoId);
                    prontuarioprecaucaoData.then(function (prontuarioprecaucao) {
                        $scope.prontuarioprecaucao = prontuarioprecaucao.data;
                        if ($scope.prontuarioprecaucao.IdTipoPrecaucao) obterCausasPorPrecaucao($scope.prontuarioprecaucao.IdTipoPrecaucao);
                        $scope.Acao = "Atualizar";
                        $scope.divprontuarioprecaucao = true;
                    }, function () {
                        toastr["error"]("Erro ao obter prontuarioprecaucao por id!", "MedicalManagement-Sys");
                    });
                };



                // Habilita DIV para Adição de registros
                $scope.incluirProntuarioPrecaucaoDiv = function () {
                    $scope.prontuarioprecaucao = {};
                    $scope.prontuarioprecaucaoForm.$setPristine();
                    $scope.Acao = "Adicionar";
                    $scope.divprontuarioprecaucao = true;
                };


                // ---/ Até aqui ok ----------------------------------------------- //



                $scope.AdicionarEditarProntuarioPrecaucao = function () {
                    var prontuarioprecaucaoData = null;
                    var _prontuarioprecaucao = {
                        IdPrecaucao: $scope.prontuarioprecaucao.IdPrecaucao,
                        IdTipoPrecaucao: $scope.prontuarioprecaucao.IdTipoPrecaucao,
                        PacienteId: idpaciente,
                        ProntuarioGuid: idprontuario
                    };
                    var valorAcao = $scope.Acao;
                    if (valorAcao === "Atualizar") {
                        _prontuarioprecaucao.ProntuarioPrecaucaoId = $scope.prontuarioprecaucao.ProntuarioPrecaucaoId;
                        prontuarioprecaucaoData = prontuarioprecaucaoService.AtualizarProntuarioPrecaucao(_prontuarioprecaucao);
                        prontuarioprecaucaoData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("ProntuarioPrecaucao alterado com sucesso!", "MedicalManagement-Sys");
                                obterPorIdPacienteEProntuario();
                                $scope.divprontuarioprecaucao = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao editar prontuarioprecaucao!", "MedicalManagement-Sys");
                        });
                    } else if (valorAcao === "Adicionar") {
                        prontuarioprecaucaoData = prontuarioprecaucaoService.PostProntuarioPrecaucao(_prontuarioprecaucao);

                        prontuarioprecaucaoData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("ProntuarioPrecaucao Adicionado com sucesso!", "MedicalManagement-Sys");

                                obterPorIdPacienteEProntuario();
                                $scope.divprontuarioprecaucao = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao Adicionar prontuarioprecaucao!", "MedicalManagement-Sys");
                        });
                    }
                };


                $scope.ExcluirProntuarioPrecaucao = function (prontuarioprecaucao) {
                    var prontuarioprecaucaoData = prontuarioprecaucaoService.Excluir(prontuarioprecaucao.ProntuarioPrecaucaoId);
                    prontuarioprecaucaoData.then(function (data) {
                        if (data.status === 200) {
                            toastr["warning"]("ProntuarioPrecaucao excluído com sucesso!", "MedicalManagement-Sys");
                            obterPorIdPacienteEProntuario();
                        }
                    }, function () {
                        toastr["error"]("Erro ao excluir prontuarioprecaucao!", "MedicalManagement-Sys");
                    });
                };



                $scope.cancelaEdicao = function () {
                    $scope.Acao = "";
                    $scope.divprontuarioprecaucao = false;
                    $scope.prontuarioprecaucaoForm.$setPristine();
                };

                //  ----/ Otimizar, tornando o mais genérico possível e tentar numa única função --- //
                $scope.inibeBtnAtualizar = function () {
                    if (($scope.Acao === "Atualizar") || ($scope.Acao === "Adicionar")) {
                        return true;
                    }
                    return false;
                };

                $scope.inibeBtnAdicionar = function () {
                    if (($scope.Acao === "Atualizar") || ($scope.Acao === "Adicionar") || !idpaciente) {
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