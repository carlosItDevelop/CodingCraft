
(function () {
    'use strict';

    // ----/ Bairro


    app.controller("bairroCtrl",
        ['$scope', 'bairroService', 'cidadeService',
            function ($scope, bairroService, cidadeService) {

        $scope.divbairro = false;
        $scope.titulo = "Lista de Bairros";


        /**
            Obter Descricoes auxiliares
         */


        function obterAsCidades() {
            var cidadesData = cidadeService.GetCidade();
            cidadesData.then(function (cidade) {
                $scope.cidades = cidade.data;
            }, function () {
                toastr["error"]("Erro ao obter Cidades", "MedicalManagement-Sys");
            }
            );
        };

        obterAsCidades();

        // ------/ -----------------------------------------------------------------/

        function obterTodosAsBairros() {
            var bairrosData = bairroService.ObterTodas();
            bairrosData.then(function (bairro) {
                $scope.bairros = bairro.data;
                $scope.Acao = "";
            }, function () {
                toastr["error"]("Erro ao obter bairros", "MedicalManagement-Sys");
            }
            );
        };


        // obter por id
        // Habilita DIV para Edição de registros
        $scope.obterPorId = function (bairro) {
            var bairroData = bairroService.GetBairroPorId(bairro.BairroId);
            bairroData.then(function (bairro) {
                $scope.bairro = bairro.data;

                $scope.Acao = "Atualizar";
                $scope.divbairro = true;
            }, function () {
                toastr["error"]("Erro ao obter bairro por id!", "MedicalManagement-Sys");
            });
        };



        // Habilita DIV para Adição de registros
        $scope.incluirBairroDiv = function () {
            $scope.bairro = {};
            $scope.bairroForm.$setPristine();
            $scope.Acao = "Adicionar";
            $scope.divbairro = true;
        };



        $scope.ExcluirBairro = function alert_it(bairro) {
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
                    apagarRegistro(bairro)
                    swal("EXCLUÍDO!", "O registro foi deletado com sucesso.", "success");
                });
        }


        var apagarRegistro = function (bairro) {
            var bairroData = bairroService.Excluir(bairro.BairroId);
            bairroData.then(function (data) {
                if (data.status === 200) {
                    toastr["warning"]("Bairro excluído com sucesso!", "MedicalManagement-Sys");
                    obterTodosAsBairros();
                }
            }, function () {
                toastr["error"]("Erro ao excluir bairro!", "MedicalManagement-Sys");
            });
        };


        $scope.AdicionarEditarBairro = function () {
            var bairroData = null;
            var _bairro = {
                IdCidade: $scope.bairro.IdCidade,
                Descricao: $scope.bairro.Descricao
            };
            var valorAcao = $scope.Acao;
            if (valorAcao === "Atualizar") {
                _bairro.BairroId = $scope.bairro.BairroId;
                bairroData = bairroService.AtualizarBairro(_bairro);
                bairroData.then(function (data) {
                    if (data.status === 200) {
                        toastr["success"]("Bairro alterado com sucesso!", "MedicalManagement-Sys");
                        obterTodosAsBairros();
                        $scope.divbairro = false;
                    }
                }, function () {
                    toastr["error"]("Erro ao editar bairro!", "MedicalManagement-Sys");
                });
            } else if (valorAcao === "Adicionar") {
                bairroData = bairroService.AddBairro(_bairro);
                bairroData.then(function (data) {
                    if (data.status === 200) {
                        toastr["success"]("Bairro Adicionado com sucesso!", "MedicalManagement-Sys");
                        obterTodosAsBairros();
                        $scope.divbairro = false;
                    }
                }, function () {
                    toastr["error"]("Erro ao Adicionar bairro!", "MedicalManagement-Sys");
                });
            }
        };


        $scope.cancelaEdicao = function () {
            $scope.Acao = "";
            $scope.divbairro = false;
            $scope.bairroForm.$setPristine();
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



        obterTodosAsBairros();


    }]);
})();