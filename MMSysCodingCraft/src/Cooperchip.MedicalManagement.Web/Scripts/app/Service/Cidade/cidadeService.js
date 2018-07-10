(function () {
    'use strict';
    app.service("cidadeService", ['$http', function ($http) {


        // --/ -------------------------------------------------


        //Obter todos os regitros
        this.GetCidade = function () {
            return $http.get("/api/v1/evm/ObterCidades");
        };

        //Obter os registros por id
        this.GetCidadePorId = function (id) {
            return $http.get("/api/v1/evm/ObterCidadePorId?id=" + id);
        };

        // Atualizar os registros
        this.AtualizarCidade = function (cidade) {
            var response = $http({
                method: "put",
                url: "/api/v1/evm/AlterarCidade",
                data: JSON.stringify(cidade),
                dataType: "json"
            });
            return response;
        };


        // Adicionar registros
        this.AddCidade = function (cidade) {
            var response = $http({
                method: "post",
                url: "/api/v1/evm/AdicionarCidade",
                data: JSON.stringify(cidade),
                dataType: "json"
            });
            return response;
        };


        // Excluir Registro
        this.Excluir = function (id) {
            var response = $http({
                method: "delete",
                url: "/api/v1/evm/ExcluirCidade?id=" + id
            });
            return response;
        };

    }]);

})();