
(function () {
    'use strict';

    // ---/ Medico ---

    app.controller("medicoCtrl",
        ['$scope', 'medicoService', 'especialidadeService', '$filter',
            function ($scope, medicoService, especialidadeService, $filter) {

                $scope.divmedico = false;
                $scope.titulo = "Lista de Medicos";

                //Obter os médicos
                function obterTodosOsMedicos() {
                    var medicosData = medicoService.ObterOsMedicos();
                    medicosData.then(function (medico) {
                        $scope.medicos = medico.data;
                        $scope.Acao = "";
                    }, function () {
                        toastr["error"]("Erro ao obter medicos", "MedicalManagement-Sys");
                    }
                    );
                };
                obterTodosOsMedicos();


                //Obter as Especialidades
                function obterTodasAsEspecialidade() {
                    var especialidadesData = especialidadeService.ObterEspecialidades();
                    especialidadesData.then(function (especialidade) {
                        $scope.especialidades = especialidade.data;
                        $scope.Acao = "";
                    }, function () {
                        toastr["error"]("Erro ao obter Especialidades", "MedicalManagement-Sys");
                    }
                    );
                };
                obterTodasAsEspecialidade();



                // obter por id
                // Habilita DIV para Edição de registros
                $scope.obterPorId = function (medico) {
                    var medicoData = medicoService.GetMedicoPorId(medico.MedicoId);
                    medicoData.then(function (medico) {
                        $scope.medico = medico.data;

                        $scope.medico.DataNascimento = new Date(medico.data.DataNascimento);

                        $scope.Acao = "Atualizar";
                        $scope.divmedico = true;
                    }, function () {
                        toastr["error"]("Erro ao obter medico!", "MedicalManagement-Sys");
                    });
                };



                // Habilita DIV para Adição de registros
                $scope.incluirMedicoDiv = function () {
                    $scope.medico = {};
                    $scope.medicoForm.$setPristine();
                    $scope.Acao = "Adicionar";
                    $scope.divmedico = true;
                };



                $scope.ExcluirMedico = function (medico) {
                    var medicoData = medicoService.Excluir(medico.MedicoId);
                    medicoData.then(function (data) {
                        if (data.status === 200) {
                            toastr["warning"]("Medico excluído com sucesso!", "MedicalManagement-Sys");
                            obterTodosOsMedicos();
                        }
                    }, function () {
                        toastr["error"]("Erro ao excluir medico!", "MedicalManagement-Sys");
                    });
                };


                $scope.AdicionarEditarMedico = function () {
                    var medicoData = null;
                    //debugger;
                    var _medico = {
                        Nome: $scope.medico.Nome,
                        IdEspecialidade: $scope.medico.IdEspecialidade,
                        Crm: $scope.medico.Crm,
                        DataNascimento: $scope.medico.DataNascimento
                    };
                    var valorAcao = $scope.Acao;
                    if (valorAcao === "Atualizar") {
                        _medico.MedicoId = $scope.medico.MedicoId;
                        medicoData = medicoService.AtualizarMedico(_medico);
                        medicoData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("Medico alterado com sucesso!", "MedicalManagement-Sys");
                                obterTodosOsMedicos();
                                $scope.divmedico = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao editar medico!", "MedicalManagement-Sys");
                        });
                    } else if (valorAcao === "Adicionar") {
                        //debugger;
                        medicoData = medicoService.AdicionarMedico(_medico);
                        medicoData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("Medico Adicionado com sucesso!", "MedicalManagement-Sys");
                                obterTodosOsMedicos();
                                $scope.divmedico = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao Adicionar medico!", "MedicalManagement-Sys");
                        });
                    }
                };


                $scope.cancelaEdicao = function () {
                    $scope.Acao = "";
                    $scope.divmedico = false;
                    $scope.medicoForm.$setPristine();
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
}());