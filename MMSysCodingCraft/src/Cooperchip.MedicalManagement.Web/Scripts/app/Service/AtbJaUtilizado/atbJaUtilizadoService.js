



(function () {

    'use strict';

    // Service AtbJaUtilizado
    app.service("atbJaUtilizadoService", ['$http', function ($http) {


        //GetAtbJaUtilizadoPorPacienteEProntuario
        this.GetAtbJaUtilizadoPorPacienteEProntuario = function (pc, pt) {
            var response = $http({
                method: "GET",
                url: "/api/v1/evm/ObterAtbJaUtilizadoPorPacienteEProntuario/",
                params: {
                    idpc: pc,
                    idpt: pt
                },
                dataType: "json"
            });
            return response;
        };

        // ObterAtbJaUtilizadoPorId
        //Obter os registros por id
        this.GetAtbJaUtilizadoPorId = function (id) {
            return $http.get("/api/v1/evm/ObterAtbJaUtilizadoPorId?id=" + id);
        };


        // Atualizar os registros
        this.AtualizarAtbJaUtilizado = function (atbjautilizado) {
            var response = $http({
                method: "put",
                url: "/api/v1/evm/AlterarAtbJaUtilizado",
                data: JSON.stringify(atbjautilizado),
                dataType: "json"
            });
            return response;
        };


        // Adicionar registros
        this.AddAtbJaUtilizado = function (atbjautilizado) {
            var response = $http({
                method: "post",
                url: "/api/v1/evm/AdicionarAtbJaUtilizado",
                data: JSON.stringify(atbjautilizado),
                dataType: "json"
            });
            return response;
        };


        // Excluir Registro
        this.DelAtbJaUtilizado = function (id) {
            var response = $http({
                method: "delete",
                url: "/api/v1/evm/DeletarAtbJaUtilizado?id=" + id
            });
            return response;
        };

    }]);

})();