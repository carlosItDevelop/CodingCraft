(function () {
    'use strict';
    app.service("especialidadeService", ['$http', function ($http) {

        //Obter todos os regitros
        this.ObterEspecialidades = function () {
            return $http.get("/api/v1/evm/ObterEspecialidade");
        };


        //Obter os registros por id
        this.GetEspecialidadePorId = function (id) {
            return $http.get("/api/v1/evm/ObterEspecialidadePorId?id=" + id);
        };


        // Atualizar os registros
        this.AtualizarEspecialidade = function (especialidade) {
            var response = $http({
                method: "put",
                url: "/api/v1/evm/AlterarEspecialidade",
                data: JSON.stringify(especialidade),
                dataType: "json"
            });
            return response;
        };


        // Adicionar registros
        this.AdicionarEspecialidade = function (especialidade) {
            var response = $http({
                method: "post",
                url: "/api/v1/evm/AdicionarEspecialidade",
                data: JSON.stringify(especialidade),
                dataType: "json"
            });
            return response;
        };


        // Excluir Registro
        this.Excluir = function (id) {
            var response = $http({
                method: "delete",
                url: "/api/v1/evm/ExcluirEspecialidade?id=" + id
            });
            return response;
        };

    }]);

})();