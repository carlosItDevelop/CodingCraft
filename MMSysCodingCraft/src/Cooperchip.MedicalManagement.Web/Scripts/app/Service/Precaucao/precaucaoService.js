(function () {
    'use strict';
    app.service("precaucaoService", ['$http', function ($http) {

        //Obter todos os regitros
        this.ObterPrecaucoes = function () {
            return $http.get("/api/v1/evm/ObterPrecaucaos");
        };

        //Obter os registros por id
        this.ObterPrecaucaoPorId = function (id) {
            return $http.get("/api/v1/evm/ObterPrecaucaoPorId?id=" + id);
        };

        // Atualizar os registros
        this.AtualizarPrecaucao = function (precaucao) {
            var response = $http({
                method: "put",
                url: "/api/v1/evm/AlterarPrecaucao",
                data: JSON.stringify(precaucao),
                dataType: "json"
            });
            return response;
        };


        // Adicionar registros
        this.AdicionarPrecaucao = function (precaucao) {
            var response = $http({
                method: "post",
                url: "/api/v1/evm/AdicionarPrecaucao",
                data: JSON.stringify(precaucao),
                dataType: "json"
            });
            return response;
        };


        // Excluir Registro
        this.Excluir = function (id) {
            var response = $http({
                method: "delete",
                url: "/api/v1/evm/ExcluirPrecaucao?id=" + id
            });
            return response;
        };



    }]);

})();