(function () {
    'use strict';
    app.service("dietaService", ['$http', function ($http) {

        //Obter todos os regitros
        this.ObterTodas = function () {
            return $http.get("/api/v1/evm/ObterDietas");
        };

        //Obter os registros por id
        this.GetDietaPorId = function (id) {
            return $http.get("/api/v1/evm/ObterDietaPorId?id=" + id);
        };

        // Atualizar os registros
        this.AtualizarDieta = function (dieta) {
            var response = $http({
                method: "put",
                url: "/api/v1/evm/AlterarDieta",
                data: JSON.stringify(dieta),
                dataType: "json"
            });
            return response;
        };


        // Adicionar registros
        this.AdicionarDieta = function (dieta) {
            var response = $http({
                method: "post",
                url: "/api/v1/evm/AdicionarDieta",
                data: JSON.stringify(dieta),
                dataType: "json"
            });
            return response;
        };


        // Excluir Registro
        this.Excluir = function (id) {
            var response = $http({
                method: "delete",
                url: "/api/v1/evm/ExcluirDieta?id=" + id
            });
            return response;
        };

    }]);

})();