

// ----/  Setor ---
(function () {

    'use strict';

    app.service("setorService", ['$http', function ($http) {

        //Obter todos os regitros
        this.ObterSetores = function () {
            return $http.get("/api/v1/evm/ObterSetor");
        };

        //Obter os registros por id
        this.GetPorId = function (id) {
            return $http.get("/api/v1/evm/ObterSetorPorId?id=" + id);
        };

        // Atualizar os registros
        this.Atualizar = function (setor) {
            var response = $http({
                method: "put",
                url: "/api/v1/evm/AlterarSetor",
                data: JSON.stringify(setor),
                dataType: "json"
            });
            return response;
        };


        // Adicionar registros
        this.Add = function (setor) {
            var response = $http({
                method: "post",
                url: "/api/v1/evm/AdicionarSetor",
                data: JSON.stringify(setor),
                dataType: "json"
            });
            return response;
        };


        // Excluir Registro
        this.DelSetorService = function (id) {
            var response = $http({
                method: "delete",
                url: "/api/v1/evm/ExcluirSetor?id=" + id
            });
            return response;
        };

    }]);

})();