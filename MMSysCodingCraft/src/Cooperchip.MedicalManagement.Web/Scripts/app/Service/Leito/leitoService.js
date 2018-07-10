
(function () {


    app.service("leitoService", ['$http', function ($http) {

        //Obter todos os regitros
        this.ObterLeitos = function () {
            return $http.get("/api/v1/evm/GetLeitos");
        };

        //Obter os registros por id
        this.ObterLeitoPorId = function (id) {
            return $http.get("/api/v1/evm/GetLeitoPorId/" + id);
        };

        // Atualizar os registros
        this.AtualizarLeito = function (leito) {
            var response = $http({
                method: "put",
                url: "/api/v1/evm/PutLeito",
                data: JSON.stringify(leito),
                dataType: "json"
            });
            return response;
        };


        // Adicionar registros
        this.AdicionarLeito = function (leito) {
            var response = $http({
                method: "post",
                url: "/api/v1/evm/PostLeito",
                data: JSON.stringify(leito),
                dataType: "json"
            });
            return response;
        };


        // Excluir Registro
        this.ExcluirLeito = function (id) {
            var response = $http({
                method: "delete",
                url: "/api/v1/evm/DelLeito/" + JSON.stringify(id)
            });
            return response;
        };

    }]);

})();