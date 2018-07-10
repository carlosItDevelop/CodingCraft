(function () {
    'use strict';
    app.service("ufService", ['$http', function ($http) {

        //Obter todos os regitros
        this.GetUf = function () {
            return $http.get("/api/v1/evm/ObterUf");
        };

        //Obter os registros por id
        this.GetUfPorId = function (id) {
            return $http.get("/api/v1/evm/ObterUfPorId?id=" + id);
        };

        // Atualizar os registros
        this.AtualizarUf = function (uf) {
            var response = $http({
                method: "put",
                url: "/api/v1/evm/AlterarUf",
                data: JSON.stringify(uf),
                dataType: "json"
            });
            return response;
        };

        // Adicionar registros
        this.AdicionarUf = function (uf) {
            var response = $http({
                method: "post",
                url: "/api/v1/evm/AdicionarUf",
                data: JSON.stringify(uf),
                dataType: "json"
            });
            return response;
        };

        // Excluir Registro
        this.Excluir = function (id) {
            var response = $http({
                method: "delete",
                url: "/api/v1/evm/ExcluirUf?id=" + id
            });
            return response;
        };

    }]);

})();