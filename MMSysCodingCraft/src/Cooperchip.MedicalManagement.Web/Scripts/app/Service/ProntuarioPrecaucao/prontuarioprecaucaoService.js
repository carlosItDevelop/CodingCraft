
(function () {
    'use strict';
    app.service("prontuarioprecaucaoService", ['$http', function ($http) {

        //Obter os registros por id
        this.ObterPrecaucaoPorId = function (id) {
            return $http.get("/api/v1/evm/ObterPrecaucaoPorId?id=" + id);
        };


        //getProntuarioPrecaucaoPorId
        this.getProntuarioPrecaucaoPorId = function (id) {
            return $http.get("/api/v1/evm/ObterUmProntuarioPrecaucaoPorId?id=" + id);
        };

        // Obtem por id de Paciente e Prontuário simultaneamente!        
        this.getProntuarioPrecaucaoPorIdPacienteEProntuario = function (pc, pt) {
            var response = $http({
                method: "GET",
                url: "/api/v1/evm/ObterProntuarioPrecaucaoPorIdPacienteEProntuario/",
                params: {
                    idpc: pc,
                    idpt: pt
                },
                dataType: "json"
            });
            return response;
        };

        // Atualizar os registros
        this.AtualizarProntuarioPrecaucao = function (prontuarioprecaucao) {
            var response = $http({
                method: "put",
                url: "/api/v1/evm/AlterarProntuarioPrecaucao",
                data: JSON.stringify(prontuarioprecaucao),
                dataType: "json"
            });
            return response;
        };

        // Adicionar registros
        this.PostProntuarioPrecaucao = function (prontuarioprecaucao) {
            var response = $http({
                method: "post",
                url: "/api/v1/evm/AdicionarProntuarioPrecaucao",
                data: JSON.stringify(prontuarioprecaucao),
                dataType: "json"
            });
            return response;
        };

        // Excluir Registro
        this.Excluir = function (id) {
            var response = $http({
                method: "delete",
                url: "/api/v1/evm/ExcluirProntuarioPrecaucao?id=" + id
            });
            return response;
        };

    }]);

})();
