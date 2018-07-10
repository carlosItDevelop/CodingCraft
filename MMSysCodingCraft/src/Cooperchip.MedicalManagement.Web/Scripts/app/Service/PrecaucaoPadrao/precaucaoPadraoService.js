
(function () {
    'use strict';
    app.service("precaucaoPadraoService", ['$http', function ($http) {

        //Obter todos os regitros
        this.ObterPrecaucaoPadraos = function () {
            return $http.get("/api/v1/evm/GetPrecaucaoPadraos");
        };

        //Obter os registros por id
        this.ObterPrecaucaoPadraoPorId = function (id) {
            return $http.get("/api/v1/evm/GetPrecaucaoPadraoPorId/" + id);
        };

        // Atualizar os registros
        this.AtualizarPrecaucaoPadrao = function (precaucaopadrao) {
            var response = $http({
                method: "put",
                url: "/api/v1/evm/PutPrecaucaoPadrao",
                data: JSON.stringify(precaucaopadrao),
                dataType: "json"
            });
            return response;
        };

        // Adicionar registros
        this.AdicionarPrecaucaoPadrao = function (precaucaopadrao) {
            var response = $http({
                method: "post",
                url: "/api/v1/evm/PostPrecaucaoPadrao",
                data: JSON.stringify(precaucaopadrao),
                dataType: "json"
            });
            return response;
        };

        // Excluir Registro
        this.ExcluirPrecaucaoPadrao = function (id) {
            var response = $http({
                method: "delete",
                url: "/api/v1/evm/DelPrecaucaoPadrao/" + JSON.stringify(id)
            });
            return response;
        };

    }]);

})();