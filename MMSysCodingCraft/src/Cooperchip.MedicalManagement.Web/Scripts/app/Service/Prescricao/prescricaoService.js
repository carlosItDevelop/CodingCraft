(function () {
    'use strict';
    app.service("prescricaoService", ['$http', function ($http) {


        this.GetPrescricaoPorId = function (idprescricao) {
            var response = $http({
                method: "GET",
                url: "/api/v1/evm/ObterPrescricaoPorId/",
                params: {
                    id: idprescricao
                },
                dataType: "json"
            });
            return response;
        };

        this.srvcGetPrescricaoPorIdDePacienteEProntuario = function (pc, pt) {
            var response = $http({
                method: "GET",
                url: "/api/v1/evm/ObterPrescricaoPorIdDePacienteEProntuario/",
                params: {
                    idpc: pc,
                    idpt: pt
                },
                dataType: "json"
            });
            return response;
        };


        // Atualizar os registros
        this.UpdPrescricao = function (prescricao) {
            var response = $http({
                method: "put",
                url: "/api/v1/evm/AlterarPrescricao",
                data: JSON.stringify(prescricao),
                dataType: "json"
            });
            return response;
        };


        // Adicionar registros
        this.AddPrescricao = function (prescricao) {
            var response = $http({
                method: "post",
                url: "/api/v1/evm/AdicionarPrescricao",
                data: JSON.stringify(prescricao),
                dataType: "json"
            });
            return response;
        };


    }]);

})();