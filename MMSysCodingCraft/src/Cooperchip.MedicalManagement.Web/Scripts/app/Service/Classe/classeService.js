(function () {
    'use strict';
    app.service("classeService", ['$http', function ($http) {

        //Obter todos os regitros
        this.ObterTodas = function () {
            return $http.get("/api/v1/evm/ObterClasse");
        };

        //Obter os registros por id
        this.GetClassePorId = function (id) {
            return $http.get("/api/v1/evm/ObterClassePorId?id=" + id);
        };

        // Atualizar os registros
        this.AtualizarClasse = function (classe) {
            var response = $http({
                method: "put",
                url: "/api/v1/evm/AlterarClasse",
                data: JSON.stringify(classe),
                dataType: "json"
            });
            return response;
        };


        // Adicionar registros
        this.AdicionarClasse = function (classe) {
            var response = $http({
                method: "post",
                url: "/api/v1/evm/AdicionarClasse",
                data: JSON.stringify(classe),
                dataType: "json"
            });
            return response;
        };


        // Excluir Registro
        this.Excluir = function (id) {
            var response = $http({
                method: "delete",
                url: "/api/v1/evm/ExcluirClasse?id=" + id
            });
            return response;
        };

    }]);

})();