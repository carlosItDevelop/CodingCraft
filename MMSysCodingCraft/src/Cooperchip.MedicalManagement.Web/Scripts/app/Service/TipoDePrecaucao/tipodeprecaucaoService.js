(function () {
    'use strict';
    app.service("tipodeprecaucaoService", ['$http', function ($http) {

        //Obter todos os regitros
        this.ObterTiposPrecaucoes = function () {
            return $http.get("/api/v1/evm/ObterTiposDePrecaucoes");
        };

    }]);

})();