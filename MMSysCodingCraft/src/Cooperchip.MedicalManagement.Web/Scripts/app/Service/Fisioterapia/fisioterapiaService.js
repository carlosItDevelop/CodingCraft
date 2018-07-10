(function () {
    'use strict';
    app.service("fisioterapiaService", ['$http', function ($http) {

        //Obter todos os regitros
        this.ObterTodas = function () {
            return $http.get("/api/v1/evm/ObterFisioterapia");
        };

        //Obter os registros por id
        this.GetFisioterapiaPorId = function (id) {
            return $http.get("/api/v1/evm/ObterFisioterapiaPorId?id=" + id);
        };

        // Atualizar os registros
        this.AtualizarFisioterapia = function (fisioterapia) {
            var response = $http({
                method: "put",
                url: "/api/v1/evm/AlterarFisioterapia",
                data: JSON.stringify(fisioterapia),
                dataType: "json"
            });
            return response;
        };


        // Adicionar registros
        this.AdicionarFisioterapia = function (fisioterapia) {
            var response = $http({
                method: "post",
                url: "/api/v1/evm/AdicionarFisioterapia",
                data: JSON.stringify(fisioterapia),
                dataType: "json"
            });
            return response;
        };


        // Excluir Registro
        this.Excluir = function (id) {
            var response = $http({
                method: "delete",
                url: "/api/v1/evm/ExcluirFisioterapia?id=" + id
            });
            return response;
        };



    }]);

})();