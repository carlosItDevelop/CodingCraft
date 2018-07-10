

(function () {
    'use strict';
    app.controller('prontuarioBaseCtrl', ['$rootScope', '$scope', '$location', '$filter', '$http', 'prontuarioService', 'pacienteService',
        function ($rootScope, $scope, $location, $filter, $http, prontuarioService, pacienteService) {
            var vm = this;
            $scope.titulo = "Prontuário Eletrônico - MedicalManagement-Sys"

            $scope.prontuarios = [];
            $scope.pacientes = [];
            $scope.enderecos = [];
            $scope.paciente = {};

            $scope.prontuario = {};
            $scope.endereco = {};

            $scope.Acao = '';


            $scope.init = function (prontuarios) {
                if (prontuarios && prontuarios.length > 0) {
                    $scope.prontuarios = prontuarios;
                } else {
                    carregaProntuarios();
                }
            }

            /*=====/
             * Aqui devem ser listados os prontuários do paciente selecionado
             * não importanto se foi para adição ou atualização, pois estamos
             * lidando com os dados deste paciente apenas, quando o selecionamos!
              ======*/
            var atualizaListaDeProntuarios = function (id) {
                if (id) {
                    carregaProntuarios(id);
                } else {
                    carregaProntuarios();
                };
            };


            /* ----------------------------------------------------------------- */
            var carregaProntuarios = function () {
                var prontuariosData = prontuarioService.srvcObterProntuariosBase();
                prontuariosData.then(function (results, status) {
                    var dados = results.data;
                    $scope.prontuarios = dados;
                }, function (results, status) {
                    toastr["error"](results.data, "MedicalManagement-Sys");
                });
            };


            var carregaProntuarios = function (id) {
                var prontuariosData = prontuarioService.srvcObterProntuariosBase(id);
                prontuariosData.then(function (results, status) {
                    var dados = results.data;
                    $scope.prontuarios = dados;
                }, function (results, status) {
                    toastr["error"](results.data, "MedicalManagement-Sys");
                });
            };
            /* ----------------------------------------------------------------- */




            /*=====/ liga/desliga botoes de adicionar, editar e arquivar
                * na medida em que faz a função inversa em savar e cancelar
                ======*/
            $scope.inibeBtnEdicao = function () {
                if (($scope.Acao === "Atualizar") || ($scope.Acao === "Adicionar")) {
                    return true;
                }
                return false;
            };

            $scope.cancelaEdicao = function () {
                $scope.Acao = "";
                $scope.divprontuario = false;
                $scope.prontuarioForm.$setPristine();
            };

            $scope.verificaAcao = function () {
                if ($scope.Acao === 'Atualizar') {
                    return true;
                } else {
                    return false;
                }
            };

            $scope.mostrarAcao = function () {
                if ($scope.Acao === 'Atualizar') {
                    return 'Editando Prontuário';
                } else {
                    return 'Adicionando Prontuário';
                }
            }
            /* ====/ ========================================================= */

            // -----------------------------------------------------------------
            // ---- Genéricos 1 ------------------------------------------------


            // Excluir após todas os processos usarem a implementação com 3 params;


            // Generic optimized function
            $scope.getInibirEAnularData = function (optons, optionSelected, campo) {
                var str = optionSelected.split(';');
                var vIndex = optionSelected.indexOf(optons);
                if (vIndex > -1) {
                    switch (campo) {
                        case 'AcessoVenosoData':
                            $scope.prontuario.AcessoVenosoData = null;
                            break;
                        case 'HemodialiseData':
                            $scope.prontuario.HemodialiseData = null;
                            break;
                        case 'PamData':
                            $scope.prontuario.PamData = null;
                            break;
                        case 'PiaData':
                            $scope.prontuario.PiaData = null;
                            break;
                        case 'PicData':
                            $scope.prontuario.PicData = null;
                            break;
                        case 'ViaAereaData':
                            $scope.prontuario.ViaAereaData = null;
                            break;
                        case 'ViaUrinariaData':
                            $scope.prontuario.ViaUrinariaData = null;
                            break;
                        case 'MarcapassoData':
                            $scope.prontuario.MarcapassoData = null;
                            break;
                        default:
                            break;
                    }
                    return true;
                } else {
                    return false;
                }
            };


            // -----------------------------------------------------------------
            // ---- Genéricos 2 ------------------------------------------------

            $scope.isDisableCbo = function (chk) {
                return !chk;
            }

            $scope.ordenarPor = function (campo) {
                $scope.criterioDeOrdenacao = campo;
                $scope.direcaoDaOrdenacao = !$scope.direcaoDaOrdenacao;
            };




            $scope.piachecado = "naochecado";

            $scope.isProntuarioPiaChecado = function () {
                if ($scope.prontuario.Pia === "Sim") {
                    $scope.piachecado = "checado";
                } else {
                    $scope.piachecado = "naochecado";
                }
            };


        }
    ]);
})();