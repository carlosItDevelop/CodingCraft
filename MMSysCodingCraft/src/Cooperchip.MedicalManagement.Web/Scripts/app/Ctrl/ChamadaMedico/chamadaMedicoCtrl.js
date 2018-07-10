
(function () {
    'use strict';

    // --------/ chamadaMedicoCtrl  ----------------------- //

    app.controller("chamadaMedicoCtrl",
        ['$scope', 'chamadaMedicoService',
            function ($scope, chamadaMedicoService) {

        $scope.divchamadaMedico = false;
        $scope.titulo = "Lista de Chamada Médicos";


        function obterTodosAsChamadaMedicos() {
            var chamadaMedicosData = chamadaMedicoService.ObterChamadaMedicos();
            chamadaMedicosData.then(function (chamadamedico) {
                $scope.chamadaMedicos = chamadamedico.data;
                $scope.Acao = "";
            }, function () {
                toastr["error"]("Erro ao obter chamadaMedicos", "MedicalManagement-Sys");
            }
            );
        };


        // obter por id
        // Habilita DIV para Edição de registros
        $scope.obterPorId = function (chamadamedico) {
            var chamadaMedicoData = chamadaMedicoService.ObterChamadaMedicoPorId(chamadamedico.ChamadaMedicoId);
            chamadaMedicoData.then(function (chamadamedico) {
                $scope.chamadamedico = chamadamedico.data;
                $scope.chamadamedico.DataChamada = new Date(chamadamedico.data.DataChamada);
                //console.log($scope.chamadamedico);
                $scope.Acao = "Atualizar";
                $scope.divchamadaMedico = true;
            }, function () {
                toastr["error"]("Erro ao obter chamadamedico por id!", "MedicalManagement-Sys");
            });
        };



        // Habilita DIV para Adição de registros
        $scope.incluirChamadamedicoDiv = function () {
            $scope.chamadamedico = {};
            $scope.chamadamedicoForm.$setPristine();
            $scope.Acao = "Adicionar";
            $scope.divchamadaMedico = true;
        };



        $scope.ExcluirChamadaMedico = function (chamadamedico) {
            var chamadaMedicoData = chamadaMedicoService.ExcluirChamadaMedico(chamadamedico.ChamadaMedicoId);
            chamadaMedicoData.then(function (data) {
                if (data.status === 200) {
                    toastr["warning"]("ChamadaMedico excluído com sucesso!", "MedicalManagement-Sys");
                    obterTodosAsChamadaMedicos();
                }
            }, function () {
                toastr["error"]("Erro ao excluir chamadamedico!", "MedicalManagement-Sys");
            });
        };

        $scope.AdicionarEditarChamadamedico = function () {
            var chamadaMedicoData = null;
            var _chamadaMedico = {
                Leito: $scope.chamadamedico.Leito,
                Medico: $scope.chamadamedico.Medico,
                Mensagem: $scope.chamadamedico.Mensagem,
                DataChamada: new Date($scope.chamadamedico.DataChamada)
            };
            var valorAcao = $scope.Acao;
            if (valorAcao === "Atualizar") {
                _chamadaMedico.ChamadaMedicoId = $scope.chamadamedico.ChamadaMedicoId;
                chamadaMedicoData = chamadaMedicoService.AtualizarChamadaMedico(_chamadaMedico);
                chamadaMedicoData.then(function (data) {
                    if (data.status === 200) {
                        toastr["success"]("ChamadaMedico alterado com sucesso!", "MedicalManagement-Sys");
                        obterTodosAsChamadaMedicos();
                        $scope.divchamadaMedico = false;
                    }
                }, function () {
                    toastr["error"]("Erro ao editar chamadamedico!", "MedicalManagement-Sys");
                });
            } else if (valorAcao === "Adicionar") {
                chamadaMedicoData = chamadaMedicoService.AdicionarChamadaMedico(_chamadaMedico);
                chamadaMedicoData.then(function (data) {
                    if (data.status === 200) {
                        toastr["success"]("ChamadaMedico Adicionado com sucesso!", "MedicalManagement-Sys");
                        obterTodosAsChamadaMedicos();
                        $scope.divchamadaMedico = false;
                    }
                }, function () {
                    toastr["error"]("Erro ao Adicionar chamadamedico!", "MedicalManagement-Sys");
                });
            }
        };


        // -------------------------------------------------------------------  //

        function obterTodosOsMedicos() {
            $scope.medicos = [];
            var medicosData = chamadaMedicoService.ObterMedicos();
            medicosData.then(function (result) {
                $scope.medicos = result.data;
                //console.log($scope.medicos);
            }, function () {
                toastr["error"]("Erro ao obter Medicos", "MedicalManagement-Sys");
            });
        };
        obterTodosOsMedicos();


        function obterTodosOsLeitos() {
            $scope.leitos = [];
            var leitosData = chamadaMedicoService.ObterLeitos();
            leitosData.then(function (result) {
                $scope.leitos = result.data;
                //console.log($scope.leitos);
            }, function () {
                toastr["error"]("Erro ao obter Leitos", "MedicalManagement-Sys");
            });
        };
        obterTodosOsLeitos();

        // -------------------------------------------------------------------  //




        $scope.cancelaEdicao = function () {
            $scope.Acao = "";
            $scope.divchamadaMedico = false;
            $scope.chamadamedicoForm.$setPristine();
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



        obterTodosAsChamadaMedicos();


    }]);
}());