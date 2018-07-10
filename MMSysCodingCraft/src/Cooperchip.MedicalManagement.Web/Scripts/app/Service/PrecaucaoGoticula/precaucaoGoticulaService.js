
(function () {
    'use strict';
    app.service("precaucaoGoticulaService", ['$http', function ($http) {

        //Obter todos os regitros
        this.ObterPrecaucaoGoticulas = function () {
            return $http.get("/api/v1/evm/GetPrecaucaoGoticulas");
        };

        //Obter os registros por id
        this.ObterPrecaucaoGoticulaPorId = function (id) {
            return $http.get("/api/v1/evm/GetPrecaucaoGoticulaPorId/" + id);
        };

        // Atualizar os registros
        this.AtualizarPrecaucaoGoticula = function (precaucaogoticula) {
            var response = $http({
                method: "put",
                url: "/api/v1/evm/PutPrecaucaoGoticula",
                data: JSON.stringify(precaucaogoticula),
                dataType: "json"
            });
            return response;
        };

        // Adicionar registros
        this.AdicionarPrecaucaoGoticula = function (precaucaogoticula) {
            var response = $http({
                method: "post",
                url: "/api/v1/evm/PostPrecaucaoGoticula",
                data: JSON.stringify(precaucaogoticula),
                dataType: "json"
            });
            return response;
        };

        // Excluir Registro
        this.ExcluirPrecaucaoGoticula = function (id) {
            var response = $http({
                method: "delete",
                url: "/api/v1/evm/DelPrecaucaoGoticula/" + JSON.stringify(id)
            });
            return response;
        };

    }]);

})();