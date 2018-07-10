(function () {
    'use strict';
    app.service("exameDescricaoService", ['$http', function ($http) {

        //Obter todos os regitros
        this.ObterDescricoes = function () {
            return $http.get("/api/v1/evm/ObterExameDescricaos");
        };

        //Obter os registros por id
        this.ObterExamesPorId = function (id) {
            return $http.get("/api/v1/evm/ObterExameDescricaoPorId?id=" + id);
        };

        // Atualizar os registros
        this.AtualizarExames = function (examedescricao) {
            var response = $http({
                method: "put",
                url: "/api/v1/evm/AlterarExameDescricao",
                data: JSON.stringify(examedescricao),
                dataType: "json"
            });
            return response;
        };


        // Adicionar registros
        this.AdicionarExames = function (examedescricao) {
            var response = $http({
                method: "post",
                url: "/api/v1/evm/AdicionarExameDescricao",
                data: JSON.stringify(examedescricao),
                dataType: "json"
            });
            return response;
        };


        // Excluir Registro
        this.ExcluirExames = function (id) {
            var response = $http({
                method: "delete",
                url: "/api/v1/evm/ExcluirExameDescricao/" + JSON.stringify(id)
            });
            return response;
        };



    }]);

})();