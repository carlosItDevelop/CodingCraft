
(function () {

    'use strict';

    app.service("convenioService", ['$http', function ($http) {

        //Obter todos os regitros
        this.ObterTodas = function () {
            return $http.get("/api/v1/evm/ObterConvenio");
        };

        //Obter os registros por id
        this.GetConvenioPorId = function (id) {
            return $http.get("/api/v1/evm/ObterConvenioPorId?id=" + id);
        };

        // Atualizar os registros
        this.AtualizarConvenio = function (convenio) {
            var response = $http({
                method: "put",
                url: "/api/v1/evm/AlterarConvenio",
                data: JSON.stringify(convenio),
                dataType: "json"
            });
            return response;
        };


        // Adicionar registros
        this.AdicionarConvenio = function (convenio) {
            var response = $http({
                method: "post",
                url: "/api/v1/evm/AdicionarConvenio",
                data: JSON.stringify(convenio),
                dataType: "json"
            });
            return response;
        };


        // Excluir Registro
        this.Excluir = function (id) {
            var response = $http({
                method: "delete",
                url: "/api/v1/evm/ExcluirConvenio?id=" + id
            });
            return response;
        };

    }]);

})();