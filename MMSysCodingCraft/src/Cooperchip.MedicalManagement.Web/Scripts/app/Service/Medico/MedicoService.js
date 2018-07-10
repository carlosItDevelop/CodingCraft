(function () {
    'use strict';
    app.service("medicoService", ['$http', function ($http) {

        //Obter todos os regitros
        this.ObterOsMedicos = function () {
            return $http.get("/api/v1/evm/ObterMedicos");
        };

        //Obter os registros por id
        this.GetMedicoPorId = function (id) {
            return $http.get("/api/v1/evm/ObterMedicoPorId?id=" + id);
        };

        // Atualizar os registros
        this.AtualizarMedico = function (medico) {
            var response = $http({
                method: "put",
                url: "/api/v1/evm/AlterarMedico",
                data: JSON.stringify(medico),
                dataType: "json"
            });
            return response;
        };


        // Adicionar registros
        this.AdicionarMedico = function (medico) {
            var response = $http({
                method: "post",
                url: "/api/v1/evm/AdicionarMedico",
                data: JSON.stringify(medico),
                dataType: "json"
            });
            return response;
        };


        // Excluir Registro
        this.Excluir = function (id) {
            var response = $http({
                method: "delete",
                url: "/api/v1/evm/ExcluirMedico?id=" + id
            });
            return response;
        };



    }]);

})();