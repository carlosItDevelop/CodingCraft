
(function () {
    'use strict';
    app.service("alergiaService", ['$http', function ($http) {
        return $http.get("/Alergia/GetAlergias");
    }]);

})();