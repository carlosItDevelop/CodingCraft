(function () {
    'use strict';
    app.service("cidAdaptadaService", ['$http', function ($http) {

        //Obter todos os regitros
        this.ObterCidAdaptadas = function () {
            return $http.get("/api/v1/evm/ObterCidAdaptadas");
        };

        //Obter os registros por id
        this.GetCidAdaptadaPorId = function (id) {
            return $http.get("/api/v1/evm/ObterCidAdaptadaPorId?id=" + id);
        };

        // Atualizar os registros
        this.AtualizarCidAdaptada = function (cidadaptada) {
            var response = $http({
                method: "put",
                url: "/api/v1/evm/AlterarCidAdaptada",
                data: JSON.stringify(cidadaptada),
                dataType: "json"
            });
            return response;
        };


        // Adicionar CidAdaptadas
        this.Adicionar = function (cidadaptada) {
            var response = $http({
                method: "post",
                url: "/api/v1/evm/AdicionarCidAdaptada",
                data: JSON.stringify(cidadaptada),
                dataType: "json"
            });
            return response;
        };


        // Excluir Registro
        this.Excluir = function (id) {
            var response = $http({
                method: "delete",
                url: "/api/v1/evm/ExcluirCidAdaptada?id=" + id
            });
            return response;
        };

    }]);

})();