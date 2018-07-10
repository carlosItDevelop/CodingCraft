
(function () {
    'use strict';

    // Estado do Paciente

    app.controller("estadoDoPacienteCtrl",
        ['$scope', 'estadoDoPacienteService',
            function ($scope, estadoDoPacienteService) {

                $scope.divestadoDoPaciente = false;
                $scope.titulo = "Lista de Estados dos Pacientes";


                function obterTodosOsEstadoDoPacientes() {
                    var estadoDoPacientesData = estadoDoPacienteService.ObterTodas();
                    estadoDoPacientesData.then(function (estadoDoPaciente) {
                        $scope.estadoDoPacientes = estadoDoPaciente.data;
                        $scope.Acao = "";
                    }, function () {
                        toastr["error"]("Erro ao obter estadoDoPacientes", "MedicalManagement-Sys");
                    }
                    );
                };


                // obter por id
                // Habilita DIV para Edição de registros
                $scope.obterPorId = function (estadoDoPaciente) {
                    var estadoDoPacienteData = estadoDoPacienteService.GetEstadoDoPacientePorId(estadoDoPaciente.EstadoDoPacienteId);
                    estadoDoPacienteData.then(function (estadoDoPaciente) {
                        $scope.estadoDoPaciente = estadoDoPaciente.data;

                        $scope.Acao = "Atualizar";
                        $scope.divestadoDoPaciente = true;
                    }, function () {
                        toastr["error"]("Erro ao obter estadoDoPaciente por id!", "MedicalManagement-Sys");
                    });
                };



                // Habilita DIV para Adição de registros
                $scope.incluirEstadoDoPacienteDiv = function () {
                    $scope.estadoDoPaciente = {};
                    $scope.estadoDoPacienteForm.$setPristine();
                    $scope.Acao = "Adicionar";
                    $scope.divestadoDoPaciente = true;
                };



                $scope.ExcluirEstadoDoPaciente = function (estadoDoPaciente) {
                    var estadoDoPacienteData = estadoDoPacienteService.Excluir(estadoDoPaciente.EstadoDoPacienteId);
                    estadoDoPacienteData.then(function (data) {
                        if (data.status === 200) {
                            toastr["warning"]("EstadoDoPaciente excluído com sucesso!", "MedicalManagement-Sys");
                            obterTodosOsEstadoDoPacientes();
                        }
                    }, function () {
                        toastr["error"]("Erro ao excluir estadoDoPaciente!", "MedicalManagement-Sys");
                    });
                };





                $scope.AdicionarEditarEstadoDoPaciente = function () {
                    var estadoDoPacienteData = null;
                    var _estadoDoPaciente = {
                        Descricao: $scope.estadoDoPaciente.Descricao
                    };
                    var valorAcao = $scope.Acao;
                    if (valorAcao === "Atualizar") {
                        _estadoDoPaciente.EstadoDoPacienteId = $scope.estadoDoPaciente.EstadoDoPacienteId;
                        estadoDoPacienteData = estadoDoPacienteService.AtualizarEstadoDoPaciente(_estadoDoPaciente);
                        estadoDoPacienteData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("EstadoDoPaciente alterado com sucesso!", "MedicalManagement-Sys");
                                obterTodosOsEstadoDoPacientes();
                                $scope.divestadoDoPaciente = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao editar estadoDoPaciente!", "MedicalManagement-Sys");
                        });
                    } else if (valorAcao === "Adicionar") {
                        estadoDoPacienteData = estadoDoPacienteService.AdicionarEstadoDoPaciente(_estadoDoPaciente);

                        estadoDoPacienteData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("EstadoDoPaciente Adicionado com sucesso!", "MedicalManagement-Sys");
                                obterTodosOsEstadoDoPacientes();
                                $scope.divestadoDoPaciente = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao Adicionar estadoDoPaciente!", "MedicalManagement-Sys");
                        });
                    }
                };


                $scope.cancelaEdicao = function () {
                    $scope.Acao = "";
                    $scope.divestadoDoPaciente = false;
                    $scope.estadoDoPacienteForm.$setPristine();
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



                obterTodosOsEstadoDoPacientes();


            }]);
}());