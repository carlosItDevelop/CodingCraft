(function () {
    'use strict';

    app.service("anticoagulacaoService", ['$http', function ($http) {

        //Obter todos os regitros
        this.ObterTodas = function () {
            return $http.get("/api/v1/evm/ObterAnticoagulacao");
        };

        //Obter os registros por id
        this.GetAnticoagulacaoPorId = function (id) {
            return $http.get("/api/v1/evm/ObterAnticoagulacaoPorId?id=" + id);
        };

        // Atualizar os registros
        this.AtualizarAnticoagulacao = function (anticoagulacao) {
            var response = $http({
                method: "put",
                url: "/api/v1/evm/AlterarAnticoagulacao",
                data: JSON.stringify(anticoagulacao),
                dataType: "json"
            });
            return response;
        };


        // Adicionar registros
        this.AdicionarAnticoagulacao = function (anticoagulacao) {
            var response = $http({
                method: "post",
                url: "/api/v1/evm/AdicionarAnticoagulacao",
                data: JSON.stringify(anticoagulacao),
                dataType: "json"
            });
            return response;
        };


        // Excluir Registro
        this.Excluir = function (id) {
            var response = $http({
                method: "delete",
                url: "/api/v1/evm/ExcluirAnticoagulacao?id=" + id
            });
            return response;
        };



    }]);

})();

