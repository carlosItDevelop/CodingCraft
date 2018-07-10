
(function () {

    'use strict';

    app.service("baseDeConhecimentoService", ['$http', function ($http) {

        //Obter todos os regitros
        this.ObterTodas = function () {
            return $http.get("/api/v1/evm/ObterBaseDeConhecimento");
        };

        //Obter os registros por id
        this.GetBaseDeConhecimentoPorId = function (id) {
            return $http.get("/api/v1/evm/ObterBaseDeConhecimentoPorId?id=" + id);
        };

        // Atualizar os registros
        this.AtualizarBaseDeConhecimento = function (baseDeConhecimento) {
            var response = $http({
                method: "put",
                url: "/api/v1/evm/AlterarBaseDeConhecimento",
                data: JSON.stringify(baseDeConhecimento),
                dataType: "json"
            });
            return response;
        };


        // Adicionar registros
        this.AdicionarBaseDeConhecimento = function (baseDeConhecimento) {
            var response = $http({
                method: "post",
                url: "/api/v1/evm/AdicionarBaseDeConhecimento",
                data: JSON.stringify(baseDeConhecimento),
                dataType: "json"
            });
            return response;
        };


        // Excluir Registro
        this.Excluir = function (id) {
            var response = $http({
                method: "delete",
                url: "/api/v1/evm/ExcluirBaseDeConhecimento?id=" + id
            });
            return response;
        };

    }]);

})();