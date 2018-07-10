(function () {
    'use strict';
    app.service("causaprecaucaoService", ['$http', function ($http) {

        //Obter todos os regitros
        this.ObterCausasPrecaucoes = function (id) {
            return $http.get("/api/v1/evm/ObterCausasPrecaucoes?id=" + id);
        };
    }]);
})();