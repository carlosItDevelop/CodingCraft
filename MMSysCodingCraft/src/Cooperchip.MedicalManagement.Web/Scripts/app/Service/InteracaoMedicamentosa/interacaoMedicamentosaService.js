(function () {
    'use strict';
    app.service("interacaoMedicamentosaService", ['$http', function ($http) {

        //Obter todos os regitros
        this.ObterTodas = function () {
            return $http.get("/api/v1/evm/ObterInteracaoMedicamentosas");
        };

        //Obter os registros por id
        this.GetInteracaoMedicamentosaPorId = function (id) {
            return $http.get("/api/v1/evm/ObterInteracaoMedicamentosaPorId?id=" + id);
        };

        // Atualizar os registros
        this.AtualizarInteracaoMedicamentosa = function (interacaoMedicamentosa) {
            var response = $http({
                method: "put",
                url: "/api/v1/evm/AlterarInteracaoMedicamentosa",
                data: JSON.stringify(interacaoMedicamentosa),
                dataType: "json"
            });
            return response;
        };


        // Adicionar registros
        this.AddInteracaoMedicamentosa = function (interacaoMedicamentosa) {
            var response = $http({
                method: "post",
                url: "/api/v1/evm/AdicionarInteracaoMedicamentosa",
                data: JSON.stringify(interacaoMedicamentosa),
                dataType: "json"
            });
            return response;
        };


        // Excluir Registro
        this.Excluir = function (id) {
            var response = $http({
                method: "delete",
                url: "/api/v1/evm/ExcluirInteracaoMedicamentosa?id=" + id
            });
            return response;
        };


    }]);

})();