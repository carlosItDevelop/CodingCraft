(function () {
    'use strict';
    app.service("genericoService", ['$http', function ($http) {

        //Obter todos os regitros
        this.ObterGenericos = function () {
            return $http.get("/api/v1/evm/ObterGenericos");
        };

        //Obter os registros por id do genérico
        this.GetGenericoPorId = function (id) {
            return $http.get("/api/v1/evm/ObterGenericoPorId?id=" + id);
        };



        // Obter Generico Por Medicamento
        this.GetGenericoForMedicamentos = function (idmedicamento) {
            var response = $http({
                method: "GET",
                url: "/api/v1/evm/ObterGenericoPorMedicamento/",
                params: {
                    id: idmedicamento
                },
                dataType: "json"
            });
            return response;
        };



        // Atualizar os registros
        this.AtualizarGenerico = function (generico) {
            var response = $http({
                method: "put",
                url: "/api/v1/evm/AlterarGenerico",
                data: JSON.stringify(generico),
                dataType: "json"
            });
            return response;
        };


        // Adicionar registros
        this.AdicionarGenerico = function (generico) {
            var response = $http({
                method: "post",
                url: "/api/v1/evm/AdicionarGenerico",
                data: JSON.stringify(generico),
                dataType: "json"
            });
            return response;
        };


        // Excluir Registro
        this.Excluir = function (id) {
            var response = $http({
                method: "delete",
                url: "/api/v1/evm/ExcluirGenerico?id=" + id
            });
            return response;
        };


    }]);

})();