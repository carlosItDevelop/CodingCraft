(function () {
    'use strict';
    app.service("complicacaoService", ['$http', function ($http) {

        //Obter todos os regitros
        this.ObterTodas = function () {
            return $http.get("/api/v1/evm/ObterComplicacao");
        };

        //Obter os registros por id
        this.GetComplicacaoPorId = function (id) {
            return $http.get("/api/v1/evm/ObterComplicacaoPorId?id=" + id);
        };

        // Atualizar os registros
        this.AtualizarComplicacao = function (complicacao) {
            var response = $http({
                method: "put",
                url: "/api/v1/evm/AlterarComplicacao",
                data: JSON.stringify(complicacao),
                dataType: "json"
            });
            return response;
        };


        // Adicionar registros
        this.AdicionarComplicacao = function (complicacao) {
            var response = $http({
                method: "post",
                url: "/api/v1/evm/AdicionarComplicacao",
                data: JSON.stringify(complicacao),
                dataType: "json"
            });
            return response;
        };


        // Excluir Registro
        this.Excluir = function (id) {
            var response = $http({
                method: "delete",
                url: "/api/v1/evm/ExcluirComplicacao?id=" + id
            });
            return response;
        };

    }]);

})();