
(function () {

    'use strict';

    app.controller("AtbEmUsoCtrl", ['$scope', '$filter', '$http', 'atbemusoService', function ($scope, $filter, $http, atbemusoService) {

        $scope.titulo = "Antibióticos em Uso";
        $scope.atbemusos = [];
        $scope.atbemuso = {};
        $scope.divatbemuso = false;


        var idprontuario;
        var idpaciente;
        // Evento click simulado em outra controller,
        // via javaScript, => ProntuarioCtrl.js.
        $("#idPaciente").click(function () {
            idpaciente = $("#idPaciente").val();
            idprontuario = $("#ProntuarioId").val();
            if (idpaciente && idprontuario) {
                $scope.atbemuso.PacienteId = idpaciente;
                $scope.atbemuso.ProntuarioGuid = idprontuario;
                obterAtbEmUsoPorPacienteEProntuario();
            };
            $scope.Acao = "";
            $scope.divatbemuso = false;
        });


        var obterAtbEmUsoPorPacienteEProntuario = function () {
            var atbemusoData = atbemusoService.GetAtbEmUsoPorPacienteEProntuario(idpaciente, idprontuario);
            atbemusoData.then(function (resultado) {
                $scope.atbemusos = resultado.data;
                $scope.Acao = "";
                $scope.divatbemuso = false;
            }, function () {
                toastr["error"]("Erro ao obter AtbEmUso por Paciente!", "MedicalManagement-Sys");
            });
        };

        // obter por id
        // Habilita DIV para Edição de registros
        $scope.obterPorId = function (atbemuso) {
            var atbemusoData = atbemusoService.GetAtbEmUsoPorId(atbemuso.AtbEmUsoId);
            atbemusoData.then(function (atbemuso) {
                atbemuso.data.DataInicio = new Date(atbemuso.data.DataInicio);
                $scope.atbemuso = atbemuso.data;
                $scope.Acao = "Atualizar";
                $scope.divatbemuso = true;
            }, function () {
                toastr["error"]("Erro ao obter AtbEmUso por id!", "MedicalManagement-Sys");
            });
        };


        $scope.AdicionarEditarAtbEmUso = function () {
            var atbemusoData = null;
            var _atbemuso = {
                Descricao: $scope.atbemuso.Descricao,
                DataInicio: new Date($scope.atbemuso.DataInicio),
                PacienteId: idpaciente,
                ProntuarioGuid: idprontuario
            };
            var valorAcao = $scope.Acao;
            if (valorAcao === "Atualizar") {
                _atbemuso.AtbEmUsoId = $scope.atbemuso.AtbEmUsoId;
                atbemusoData = atbemusoService.AtualizarAtbEmUso(_atbemuso);
                atbemusoData.then(function (data) {
                    if (data.status === 200) {
                        toastr["success"]("AtbEmUso alterado com sucesso!", "MedicalManagement-Sys");
                        obterAtbEmUsoPorPacienteEProntuario();
                        $scope.divatbemuso = false;
                    }
                }, function () {
                    toastr["error"]("Erro ao editar AtbEmUso!", "MedicalManagement-Sys");
                });
            } else if (valorAcao === "Adicionar") {
                atbemusoData = atbemusoService.AddAtbEmUso(_atbemuso);
                atbemusoData.then(function (data) {
                    if (data.status === 200) {
                        toastr["success"]("AtbEmUso Adicionado com sucesso!", "MedicalManagement-Sys");
                        obterAtbEmUsoPorPacienteEProntuario();
                        $scope.divatbemuso = false;
                    }
                }, function () {
                    toastr["error"]("Erro ao Adicionar AtbEmUso!", "MedicalManagement-Sys");
                });
            }
        };

        //ExcluirAtbEmUso
        $scope.ExcluirAtbEmUso = function alert_it(atbemuso) {
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
                    DeletarAtbEmUso(atbemuso)
                    swal("EXCLUÍDO!", "O registro foi deletado com sucesso.", "success");
                });
        }

        var DeletarAtbEmUso = function (atbemuso) {
            var atbemusoData = atbemusoService.DelAtbEmUso(atbemuso.AtbEmUsoId);
            atbemusoData.then(function (data) {
                if (data.status === 200) {
                    $scope.Acao = "";
                    $scope.divatbemuso = false;
                    toastr["warning"]("AtbEmUso excluído com sucesso!", "MedicalManagement-Sys");
                    obterAtbEmUsoPorPacienteEProntuario();
                }
            }, function () {
                toastr["error"]("Erro ao excluir AtbEmUso!", "MedicalManagement-Sys");
            });
        };


        /* ---------------------------------------------------------------- */

        // Habilita DIV para Adição de registros
        $scope.incluirAtbEmUsoDiv = function () {
            $scope.atbemuso = {};
            $scope.AtbEmUsoForm.$setPristine();
            $scope.Acao = "Adicionar";
            $scope.divatbemuso = true;
        };


        $scope.cancelaEdicao = function () {
            $scope.Acao = "";
            $scope.divatbemuso = false;
            $scope.AtbEmUsoForm.$setPristine();
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

        $scope.isEditando = function(){
            if (($scope.Acao === "Atualizar")) {
                return true;
            }
            return false;
        };



    }]);

})();