(function () {
    'use strict';

    app.service("estadoDoPacienteService", ['$http', function ($http) {

        //Obter todos os regitros
        this.ObterTodas = function () {
            return $http.get("/api/v1/evm/ObterEstadoDoPaciente");
        };

        //Obter os registros por id
        this.GetEstadoDoPacientePorId = function (id) {
            return $http.get("/api/v1/evm/ObterEstadoDoPacientePorId?id=" + id);
        };

        // Atualizar os registros
        this.AtualizarEstadoDoPaciente = function (estadoDoPaciente) {
            var response = $http({
                method: "put",
                url: "/api/v1/evm/AlterarEstadoDoPaciente",
                data: JSON.stringify(estadoDoPaciente),
                dataType: "json"
            });
            return response;
        };


        // Adicionar registros
        this.AdicionarEstadoDoPaciente = function (estadoDoPaciente) {
            var response = $http({
                method: "post",
                url: "/api/v1/evm/AdicionarEstadoDoPaciente",
                data: JSON.stringify(estadoDoPaciente),
                dataType: "json"
            });
            return response;
        };


        // Excluir Registro
        this.Excluir = function (id) {
            var response = $http({
                method: "delete",
                url: "/api/v1/evm/ExcluirEstadoDoPaciente?id=" + id
            });
            return response;
        };

    }]);

})();
