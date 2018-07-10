
(function () {
    'use strict';

// ---/ AgendamentoAgenda ---

app.controller("agendamentoCtrl", ['$scope', 'agendamentoService', 'medicoService', 'pacienteService', '$filter', function ($scope, agendamentoService, medicoService, pacienteService, $filter) {

    $scope.divagendamento = false;
    $scope.titulo = "Lista de Agendamentos";
    $scope.agendamentos = [];
    $scope.agendamento = {};   

    function obterTodosOsAgendamentos() {
        var agendamentosData = agendamentoService.ObterAgendamentos();
        agendamentosData.then(function (agendamento) {
            $scope.agendamentos = agendamento.data;
            $scope.Acao = "";
        }, function () {
            toastr["error"]("Erro ao obter agendamentos", "MedicalManagement-Sys");
        }
        );
    };
    obterTodosOsAgendamentos();



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
    obterTodosOsMedicos(); // OBTER APENAS ID E NOME



    //ObterPacientes
    function obterTodosOsPacientes() {
        var pacientesData = pacienteService.srvcObterPacientes();
        pacientesData.then(function (paciente) {
            $scope.pacientes = paciente.data;
            $scope.Acao = "";
        }, function () {
            toastr["error"]("Erro ao obter pacientes", "MedicalManagement-Sys");
        }
        );
    };
    obterTodosOsPacientes(); // OBTER APENAS ID E NOME

    //function reformatDate(dateStr) {
    //    dArr = dateStr.split("-");  // ex input "2010-01-18"
    //    novaDate = dArr[2].substr(0, 2) + "/" + dArr[1] + "/" + dArr[0];
    //    return novaDate;
    //}

    // obter por id
    // Habilita DIV para Edição de registros
    $scope.obterPorId = function (agendamento) {
        var agendamentoData = agendamentoService.GetAgendamentoPorId(agendamento.AgendamentoId);
        agendamentoData.then(function (agendamento) {
            $scope.agendamento = agendamento.data;

            $scope.agendamento.Data = new Date(agendamento.data.Data);

            $scope.Acao = "Atualizar";
            $scope.divagendamento = true;
        }, function () {
            toastr["error"]("Erro ao obter agendamento por id!", "MedicalManagement-Sys");
        });
    };



    // Habilita DIV para Adição de registros
    $scope.incluirAgendamentoDiv = function () {
        $scope.agendamento = {};
        $scope.agendamentoForm.$setPristine();
        $scope.Acao = "Adicionar";
        $scope.divagendamento = true;
    };



    $scope.ExcluirAgendamento = function (agendamento) {
        var agendamentoData = agendamentoService.Excluir(agendamento.AgendamentoId);
        agendamentoData.then(function (data) {
            if (data.status === 200) {
                toastr["warning"]("Agendamento excluído com sucesso!", "MedicalManagement-Sys");
                obterTodosOsAgendamentos();
            }
        }, function () {
            toastr["error"]("Erro ao excluir agendamento!", "MedicalManagement-Sys");
        });
    };



    $scope.AdicionarEditarAgendamento = function () {
        var agendamentoData = null;
        //debugger;
        var _agendamento = {
            PacienteId: $scope.agendamento.PacienteId,
            Data: $scope.agendamento.Data,

            Hora: $scope.agendamento.Hora,
            IdMedico: $scope.agendamento.MedicoId,
            Exames: $scope.agendamento.Exames,
            Confirmado: $scope.agendamento.Confirmado
        };
        var valorAcao = $scope.Acao;
        if (valorAcao === "Atualizar") {
            _agendamento.AgendamentoId = $scope.agendamento.AgendamentoId;
            agendamentoData = agendamentoService.AtualizarAgendamento(_agendamento);
            agendamentoData.then(function (data) {
                if (data.status === 200) {
                    toastr["success"]("Agendamento alterado com sucesso!", "MedicalManagement-Sys");
                    obterTodosOsAgendamentos();
                    $scope.divagendamento = false;
                }
            }, function () {
                toastr["error"]("Erro ao editar agendamento!", "MedicalManagement-Sys");
            });
        } else if (valorAcao === "Adicionar") {
            //debugger;
            agendamentoData = agendamentoService.Adicionar(_agendamento);
            agendamentoData.then(function (data) {
                if (data.status === 200) {
                    toastr["success"]("Agendamento Adicionado com sucesso!", "MedicalManagement-Sys");
                    obterTodosOsAgendamentos();
                    $scope.divagendamento = false;
                }
            }, function () {
                toastr["error"]("Erro ao Adicionar agendamento!", "MedicalManagement-Sys");
            });
        }
    };


    $scope.cancelaEdicao = function () {
        $scope.Acao = "";
        $scope.divagendamento = false;
        $scope.agendamentoForm.$setPristine();
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


}]);

}());