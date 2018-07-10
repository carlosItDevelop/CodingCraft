(function () {
    'use strict';
    app.service("sexoService", ['$http', function ($http) {

        //Obter todos os regitros
        this.ObterTodas = function () {
            return $http.get("/api/v1/evm/ObterSexo");
        };

        //Obter os registros por id
        this.GetSexoPorId = function (id) {
            return $http.get("/api/v1/evm/ObterSexoPorId?id=" + id);
        };

    }]);

})();