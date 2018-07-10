

(function () {

    'use strict';

    // Service AtbEmUso
    app.service("atbemusoService", ['$http', function ($http) {

        //GetAtbEmUsoPorPacienteEProntuario
        this.GetAtbEmUsoPorPacienteEProntuario = function (pc, pt) {
            var response = $http({
                method: "GET",
                url: "/api/v1/evm/ObterAtbEmUsoPorPacienteEProntuario/",
                params: {
                    idpc: pc,
                    idpt: pt
                },
                dataType: "json"
            });
            return response;
        };

        // ObterAtbEmUsoPorId
        //Obter os registros por id
        this.GetAtbEmUsoPorId = function (id) {
            return $http.get("/api/v1/evm/ObterAtbEmUsoPorId?id=" + id);
        };


        // Atualizar os registros
        this.AtualizarAtbEmUso = function (atbemuso) {
            var response = $http({
                method: "put",
                url: "/api/v1/evm/AlterarAtbEmUso",
                data: JSON.stringify(atbemuso),
                dataType: "json"
            });
            return response;
        };


        // Adicionar registros
        this.AddAtbEmUso = function (atbemuso) {
            var response = $http({
                method: "post",
                url: "/api/v1/evm/AdicionarAtbEmUso",
                data: JSON.stringify(atbemuso),
                dataType: "json"
            });
            return response;
        };


        // Excluir Registro
        this.DelAtbEmUso = function (id) {
            var response = $http({
                method: "delete",
                url: "/api/v1/evm/DeletarAtbEmUso?id=" + id
            });
            return response;
        };


    }]);

})();