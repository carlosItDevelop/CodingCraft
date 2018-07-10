(function () {
    'use strict';
    app.service("bairroService", ['$http', function ($http) {

    //Obter todos os regitros
    this.ObterTodas = function () {
        return $http.get("/api/v1/evm/ObterBairros");
    };

    //Obter os registros por id
    this.GetBairroPorId = function (id) {
        return $http.get("/api/v1/evm/ObterBairroPorId?id=" + id);
    };

    // Atualizar os registros
    this.AtualizarBairro = function (bairro) {
        var response = $http({
            method: "put",
            url: "/api/v1/evm/AlterarBairro",
            data: JSON.stringify(bairro),
            dataType: "json"
        });
        return response;
    };


    // Adicionar registros
    this.AddBairro = function (bairro) {
        var response = $http({
            method: "post",
            url: "/api/v1/evm/AdicionarBairro",
            data: JSON.stringify(bairro),
            dataType: "json"
        });
        return response;
    };


    // Excluir Registro
    this.Excluir = function (id) {
        var response = $http({
            method: "delete",
            url: "/api/v1/evm/ExcluirBairro?id=" + id
        });
        return response;
    };


}]);

})();
