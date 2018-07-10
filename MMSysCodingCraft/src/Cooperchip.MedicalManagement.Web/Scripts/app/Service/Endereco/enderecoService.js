(function () {
    'use strict';
    app.service("enderecoService", ['$http', function ($http) {

        //Obter todos os regitros
        this.GetDescricaoPaciente = function () {
            return $http.get("/api/v1/evm/ObterNomePacientes");
        };

        this.GetCidade = function () {
            return $http.get("/api/v1/evm/ObterCidadesParaEndereco");
        };

        this.GetBairro = function () {
            return $http.get("/api/v1/evm/ObterBairrosParaEndereco");
        };

        // --/ -------------------------------------------------

        //Obter todos os regitros
        this.ObterTodas = function () {
            return $http.get("/api/v1/evm/ObterEnderecos");
        };

        //Obter os registros por id
        this.GetEnderecoPorId = function (id) {
            return $http.get("/api/v1/evm/ObterEnderecoPorId?id=" + id);
        };

        // Atualizar os registros
        this.AtualizarEndereco = function (endereco) {
            var response = $http({
                method: "put",
                url: "/api/v1/evm/AlterarEndereco",
                data: JSON.stringify(endereco),
                dataType: "json"
            });
            return response;
        };

        // Adicionar registros
        this.AddEndereco = function (endereco) {
            var response = $http({
                method: "post",
                url: "/api/v1/evm/AdicionarEndereco",
                data: JSON.stringify(endereco),
                dataType: "json"
            });
            return response;
        };

        // Excluir Registro
        this.Excluir = function (id) {
            var response = $http({
                method: "delete",
                url: "/api/v1/evm/ExcluirEndereco?id=" + id
            });
            return response;
        };

    }]);

})();