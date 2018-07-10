(function () {
    'use strict';
    app.service("precaucaoAerozolService", ['$http', function ($http) {

        //Obter todos os regitros
        this.ObterPrecaucaoAerozols = function () {
            return $http.get("/api/v1/evm/GetPrecaucaoAerozols");
        };

        //Obter os registros por id
        this.ObterPrecaucaoAerozolPorId = function (id) {
            return $http.get("/api/v1/evm/GetPrecaucaoAerozolPorId/" + id);
        };

        // Atualizar os registros
        this.AtualizarPrecaucaoAerozol = function (precaucaoaerozol) {
            var response = $http({
                method: "put",
                url: "/api/v1/evm/PutPrecaucaoAerozol",
                data: JSON.stringify(precaucaoaerozol),
                dataType: "json"
            });
            return response;
        };

        // Adicionar registros
        this.AdicionarPrecaucaoAerozol = function (precaucaoaerozol) {
            var response = $http({
                method: "post",
                url: "/api/v1/evm/PostPrecaucaoAerozol",
                data: JSON.stringify(precaucaoaerozol),
                dataType: "json"
            });
            return response;
        };

        // Excluir Registro
        this.ExcluirPrecaucaoAerozol = function (id) {
            var response = $http({
                method: "delete",
                url: "/api/v1/evm/DelPrecaucaoAerozol/" + JSON.stringify(id)
            });
            return response;
        };

    }]);

})();

