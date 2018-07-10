(function () {
    'use strict';
    app.service("tipodrenoService", ['$http', function ($http) {

        //Obter todos os regitros
        this.srvcObterTipoDrenos = function () {
            return $http.get("/api/v1/evm/ApiObeterTodosOsTipoDrenos");
        };

        //Obter os registros por id
        this.srvcGetTipoDrenoPorId = function (id) {
            return $http.get("/api/v1/evm/ApiObterTipoDrenoPorId?id=" + id);
        };

        // Atualizar os registros
        this.AtualizarTipoDreno = function (tipodreno) {
            var response = $http({
                method: "put",
                url: "/api/v1/evm/AlterarTipoDreno",
                data: JSON.stringify(tipodreno),
                dataType: "json"
            });
            return response;
        };

        // Adicionar registros
        this.AdicionarTipoDreno = function (tipodreno) {
            var response = $http({
                method: "post",
                url: "/api/v1/evm/AdicionarUmTipoDreno",
                data: JSON.stringify(tipodreno),
                dataType: "json"
            });
            return response;
        };

        // Excluir Registro
        this.Excluir = function (id) {
            var response = $http({
                method: "delete",
                url: "/api/v1/evm/ExcluirTipoDreno?id=" + id
            });
            return response;
        };


    }]);

})();