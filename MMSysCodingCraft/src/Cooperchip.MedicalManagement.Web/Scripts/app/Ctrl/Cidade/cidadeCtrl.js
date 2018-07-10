
(function () {
    'use strict';

    // ----/ Cidade


    app.controller("cidadeCtrl",
        ['$scope', 'cidadeService', 'ufService',
            function ($scope, cidadeService, ufService) {

        $scope.divcidade = false;
        $scope.titulo = "Lista de Cidades";


        /**
            Obter Descricoes auxiliares
         */


        function obterAsUfs() {
            var ufsData = ufService.GetUf();
            ufsData.then(function (uf) {
                $scope.ufs = uf.data;
            }, function () {
                toastr["error"]("Erro ao obter ufs", "MedicalManagement-Sys");
            }
            );
        };



        obterAsUfs();



        // ------/ -----------------------------------------------------------------/




        function obterTodosAsCidades() {
            var cidadesData = cidadeService.GetCidade();
            cidadesData.then(function (cidade) {
                $scope.cidades = cidade.data;
                $scope.Acao = "";
            }, function () {
                toastr["error"]("Erro ao obter cidades", "MedicalManagement-Sys");
            }
            );
        };


        // obter por id
        // Habilita DIV para Edição de registros
        $scope.obterPorId = function (cidade) {
            var cidadeData = cidadeService.GetCidadePorId(cidade.CidadeId);
            cidadeData.then(function (cidade) {
                $scope.cidade = cidade.data;

                $scope.Acao = "Atualizar";
                $scope.divcidade = true;
            }, function () {
                toastr["error"]("Erro ao obter cidade por id!", "MedicalManagement-Sys");
            });
        };



        // Habilita DIV para Adição de registros
        $scope.incluirCidadeDiv = function () {
            $scope.cidade = {};
            $scope.cidadeForm.$setPristine();
            $scope.Acao = "Adicionar";
            $scope.divcidade = true;
        };


        $scope.ExcluirCidade = function alert_it(cidade) {
            swal({
                title: "Tem certeza que deseja excluir este registro?",
                text: "Após a exclusão não será possível recuperá-lo!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Sim, Pode excluir!",
                closeOnConfirm: false
            },
                function () {
                    apagarRegistro(cidade)
                    swal("EXCLUÍDO!", "O registro foi deletado com sucesso.", "success");
                });
        }


        var apagarRegistro = function (cidade) {
            var cidadeData = cidadeService.Excluir(cidade.CidadeId);
            cidadeData.then(function (data) {
                if (data.status === 200) {
                    toastr["warning"]("Cidade excluído com sucesso!", "MedicalManagement-Sys");
                    obterTodosAsCidades();
                }
            }, function () {
                toastr["error"]("Erro ao excluir cidade!", "MedicalManagement-Sys");
            });
        };


        $scope.AdicionarEditarCidade = function () {
            var cidadeData = null;
            var _cidade = {
                IdUf: $scope.cidade.IdUf,
                Descricao: $scope.cidade.Descricao
            };
            var valorAcao = $scope.Acao;
            if (valorAcao === "Atualizar") {
                _cidade.CidadeId = $scope.cidade.CidadeId;
                cidadeData = cidadeService.AtualizarCidade(_cidade);
                cidadeData.then(function (data) {
                    if (data.status === 200) {
                        toastr["success"]("Cidade alterado com sucesso!", "MedicalManagement-Sys");
                        obterTodosAsCidades();
                        $scope.divcidade = false;
                    }
                }, function () {
                    toastr["error"]("Erro ao editar cidade!", "MedicalManagement-Sys");
                });
            } else if (valorAcao === "Adicionar") {
                cidadeData = cidadeService.AddCidade(_cidade);
                cidadeData.then(function (data) {
                    if (data.status === 200) {
                        toastr["success"]("Cidade Adicionado com sucesso!", "MedicalManagement-Sys");
                        obterTodosAsCidades();
                        $scope.divcidade = false;
                    }
                }, function () {
                    toastr["error"]("Erro ao Adicionar cidade!", "MedicalManagement-Sys");
                });
            }
        };


        $scope.cancelaEdicao = function () {
            $scope.Acao = "";
            $scope.divcidade = false;
            $scope.cidadeForm.$setPristine();
        };

        //  ----/ Otimizar, tornando o mais genérico possível e tentar numa única função --- //
        $scope.inibeBtnAtualizar = function () {
            if (($scope.Acao === "Atualizar") || ($scope.Acao === "Adicionar")) {
                return true;
            }
            return false;
        };

        $scope.inibeBtnAdicionar = function () {
            if (($scope.Acao === "Atualizar") || ($scope.Acao === "Adicionar")) {
                return true;
            }
            return false;
        };


        $scope.inibeBtnExcluir = function () {
            if (($scope.Acao === "Atualizar") || ($scope.Acao === "Adicionar")) {
                return true;
            }
            return false;
        };
        //  ----/ Otimizar, tornando o mais genérico possível e tentar numa única função --- //

        $scope.ordenarPor = function (campo) {
            $scope.criterioDeOrdenacao = campo;
            $scope.direcaoDaOrdenacao = !$scope.direcaoDaOrdenacao;
        };

        obterTodosAsCidades();

    }]);
}());