(function () {
    'use strict';
    app.service("drenoService", ['$http', function ($http) {

        //Obter drenos por paciente
        this.GetTipoDeDrenos = function () {
            return $http.get("/api/v1/evm/ObterTipoDeDreno");
        };

        //Obter os registros por id
        this.GetDrenoPorId = function (id) {
            return $http.get("/api/v1/evm/ObterDrenoPorId?id=" + id);
        };

        //GetDrenoPorPacienteEProntuario
        this.GetDrenoPorPacienteEProntuario = function (pc, pt) {
            var response = $http({
                method: "GET",
                url: "/api/v1/evm/ObterDrenoPorPacienteEProntuario/",
                params: {
                    idpc: pc,
                    idpt: pt
                },
                dataType: "json"
            });
            return response;
        };

        // Atualizar os registros
        this.AtualizarDreno = function (dreno) {
            var response = $http({
                method: "put",
                url: "/api/v1/evm/AlterarDreno",
                data: JSON.stringify(dreno),
                dataType: "json"
            });
            return response;
        };

        // Adicionar registros
        this.AddDreno = function (dreno) {
            var response = $http({
                method: "post",
                url: "/api/v1/evm/AdicionarDreno",
                data: JSON.stringify(dreno),
                dataType: "json"
            });
            return response;
        };

        // Excluir Registro
        this.Excluir = function (id) {
            var response = $http({
                method: "delete",
                url: "/api/v1/evm/ExcluirDreno?id=" + id
            });
            return response;
        };

    }]);
})();