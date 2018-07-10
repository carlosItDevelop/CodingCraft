(function () {
    'use strict';
    app.service("precaucaoContatoService", ['$http', function ($http) {

        //Obter todos os regitros
        this.ObterPrecaucaoContatos = function () {
            return $http.get("/api/v1/evm/GetPrecaucaoContatos");
        };

        //Obter os registros por id
        this.ObterPrecaucaoContatoPorId = function (id) {
            return $http.get("/api/v1/evm/GetPrecaucaoContatoPorId/" + id);
        };

        // Atualizar os registros
        this.AtualizarPrecaucaoContato = function (precaucaocontato) {
            var response = $http({
                method: "put",
                url: "/api/v1/evm/PutPrecaucaoContato",
                data: JSON.stringify(precaucaocontato),
                dataType: "json"
            });
            return response;
        };

        // Adicionar registros
        this.AdicionarPrecaucaoContato = function (precaucaocontato) {
            var response = $http({
                method: "post",
                url: "/api/v1/evm/PostPrecaucaoContato",
                data: JSON.stringify(precaucaocontato),
                dataType: "json"
            });
            return response;
        };

        // Excluir Registro
        this.ExcluirPrecaucaoContato = function (id) {
            var response = $http({
                method: "delete",
                url: "/api/v1/evm/DelPrecaucaoContato/" + JSON.stringify(id)
            });
            return response;
        };

    }]);

})();