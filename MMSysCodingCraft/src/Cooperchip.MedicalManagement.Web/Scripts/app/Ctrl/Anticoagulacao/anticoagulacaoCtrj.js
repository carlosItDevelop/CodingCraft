

(function () {
    'use strict';

    // Anticoagulacaos

    app.controller("anticoagulacaoCtrl", ['$scope', 'anticoagulacaoService', function ($scope, anticoagulacaoService) {

        $scope.divanticoagulacao = false;
        $scope.titulo = "Tabela de Anticoagulação";


        function obterTodosOsAnticoagulacaos() {
            var anticoagulacaosData = anticoagulacaoService.ObterTodas();
            anticoagulacaosData.then(function (anticoagulacao) {
                $scope.anticoagulacaos = anticoagulacao.data;
                $scope.Acao = "";
            }, function () {
                toastr["error"]("Erro ao obter anticoagulacaos", "MedicalManagement-Sys");
            }
            );
        };


        // obter por id
        // Habilita DIV para Edição de registros
        $scope.obterPorId = function (anticoagulacao) {
            var anticoagulacaoData = anticoagulacaoService.GetAnticoagulacaoPorId(anticoagulacao.AnticoagulacaoId);
            anticoagulacaoData.then(function (anticoagulacao) {
                $scope.anticoagulacao = anticoagulacao.data;

                $scope.Acao = "Atualizar";
                $scope.divanticoagulacao = true;
            }, function () {
                toastr["error"]("Erro ao obter anticoagulacao por id!", "MedicalManagement-Sys");
            });
        };



        // Habilita DIV para Adição de registros
        $scope.incluirAnticoagulacaoDiv = function () {
            $scope.anticoagulacao = {};
            $scope.anticoagulacaoForm.$setPristine();
            $scope.Acao = "Adicionar";
            $scope.divanticoagulacao = true;
        };

        $scope.ExcluirAnticoagulacao = function alert_it(anticoagulacao) {
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
                    apagarRegistro(anticoagulacao)
                    swal("EXCLUÍDO!", "O registro foi deletado com sucesso.", "success");
                });
        }

        var apagarRegistro = function (anticoagulacao) {
            var anticoagulacaoData = anticoagulacaoService.Excluir(anticoagulacao.AnticoagulacaoId);
            anticoagulacaoData.then(function (data) {
                if (data.status === 200) {
                    toastr["warning"]("Anticoagulacao excluído com sucesso!", "MedicalManagement-Sys");
                    obterTodosOsAnticoagulacaos();
                }
            }, function () {
                toastr["error"]("Erro ao excluir anticoagulacao!", "MedicalManagement-Sys");
            });
        };





        $scope.AdicionarEditarAnticoagulacao = function () {
            var anticoagulacaoData = null;
            var _anticoagulacao = {
                Descricao: $scope.anticoagulacao.Descricao
            };
            var valorAcao = $scope.Acao;
            if (valorAcao === "Atualizar") {
                _anticoagulacao.AnticoagulacaoId = $scope.anticoagulacao.AnticoagulacaoId;
                anticoagulacaoData = anticoagulacaoService.AtualizarAnticoagulacao(_anticoagulacao);
                anticoagulacaoData.then(function (data) {
                    if (data.status === 200) {
                        toastr["success"]("Anticoagulacao alterado com sucesso!", "MedicalManagement-Sys");
                        obterTodosOsAnticoagulacaos();
                        $scope.divanticoagulacao = false;
                    }
                }, function () {
                    toastr["error"]("Erro ao editar anticoagulacao!", "MedicalManagement-Sys");
                });
            } else if (valorAcao === "Adicionar") {
                anticoagulacaoData = anticoagulacaoService.AdicionarAnticoagulacao(_anticoagulacao);

                anticoagulacaoData.then(function (data) {
                    if (data.status === 200) {
                        toastr["success"]("Anticoagulacao Adicionado com sucesso!", "MedicalManagement-Sys");
                        obterTodosOsAnticoagulacaos();
                        $scope.divanticoagulacao = false;
                    }
                }, function () {
                    toastr["error"]("Erro ao Adicionar anticoagulacao!", "MedicalManagement-Sys");
                });
            }
        };


        $scope.cancelaEdicao = function () {
            $scope.Acao = "";
            $scope.divanticoagulacao = false;
            $scope.anticoagulacaoForm.$setPristine();
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



        obterTodosOsAnticoagulacaos();


    }]);

})();