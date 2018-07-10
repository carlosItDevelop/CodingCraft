
(function () {
    'use strict';

// ----/  Agendamento ---


app.service("agendamentoService", ['$http', function ($http) {

    //Obter todos os regitros
    this.ObterAgendamentos = function () {
        return $http.get("/api/v1/evm/ObterAgendamentos");
    };

    //Obter os registros por id
    this.GetAgendamentoPorId = function (id) {
        return $http.get("/api/v1/evm/ObterAgendamentoPorId?id=" + id);
    };

    // Atualizar os registros
    this.AtualizarAgendamento = function (agendamento) {
        var response = $http({
            method: "put",
            url: "/api/v1/evm/AlterarAgendamento",
            data: JSON.stringify(agendamento),
            dataType: "json"
        });
        return response;
    };


    // Adicionar Agendamentos
    this.Adicionar = function (agendamento) {
        var response = $http({
            method: "post",
            url: "/api/v1/evm/AdicionarAgendamento",
            data: JSON.stringify(agendamento),
            dataType: "json"
        });
        return response;
    };


    // Excluir Registro
    this.Excluir = function (id) {
        var response = $http({
            method: "delete",
            url: "/api/v1/evm/ExcluirAgendamento?id=" + id
        });
        return response;
    };



}
]);
}());

