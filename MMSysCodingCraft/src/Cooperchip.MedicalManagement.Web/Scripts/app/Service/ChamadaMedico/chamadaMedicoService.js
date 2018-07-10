(function () {
    'use strict';
    app.service("chamadaMedicoService", ['$http', function ($http) {

        //Obter todos os regitros
        this.ObterChamadaMedicos = function () {
            return $http.get("/api/v1/evm/GetChamadaMedicos");
        };

        //Obter todos os Medicos
        this.ObterMedicos = function () {
            return $http.get("/api/v1/evm/GetMedicosEmChamadaMedico");
        };

        //Obter todos os Leitos
        this.ObterLeitos = function () {
            return $http.get("/api/v1/evm/GetLeitosEmChamadaMedico");
        };

        //Obter os registros por id
        this.ObterChamadaMedicoPorId = function (id) {
            return $http.get("/api/v1/evm/GetChamadaMedicoPorId/" + id);
        };

        // Atualizar os registros
        this.AtualizarChamadaMedico = function (chamadaMedico) {
            var response = $http({
                method: "put",
                url: "/api/v1/evm/PutChamadaMedico",
                data: JSON.stringify(chamadaMedico),
                dataType: "json"
            });
            return response;
        };

        // Adicionar registros
        this.AdicionarChamadaMedico = function (chamadaMedico) {
            var response = $http({
                method: "post",
                url: "/api/v1/evm/PostChamadaMedico",
                data: JSON.stringify(chamadaMedico),
                dataType: "json"
            });
            return response;
        };

        // Excluir Registro
        this.ExcluirChamadaMedico = function (id) {
            var response = $http({
                method: "delete",
                url: "/api/v1/evm/DelChamadaMedico/" + JSON.stringify(id)
            });
            return response;
        };

    }]);
})();