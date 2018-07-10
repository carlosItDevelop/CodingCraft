
(function () {
    'use strict';

    // Convenios

    app.controller("convenioCtrl", ['$scope', 'convenioService', function ($scope, convenioService) {

        $scope.divconvenio = false;
        $scope.titulo = "Lista de Convênios";


        function obterTodosOsConvenios() {
            var conveniosData = convenioService.ObterTodas();
            conveniosData.then(function (convenio) {
                $scope.convenios = convenio.data;
                $scope.Acao = "";
            }, function () {
                toastr["error"]("Erro ao obter convenios", "MedicalManagement-Sys");
            }
            );
        };


        // obter por id
        // Habilita DIV para Edição de registros
        $scope.obterPorId = function (convenio) {
            var convenioData = convenioService.GetConvenioPorId(convenio.ConvenioId);
            convenioData.then(function (convenio) {
                $scope.convenio = convenio.data;

                $scope.Acao = "Atualizar";
                $scope.divconvenio = true;
            }, function () {
                toastr["error"]("Erro ao obter convenio por id!", "MedicalManagement-Sys");
            });
        };



        // Habilita DIV para Adição de registros
        $scope.incluirConvenioDiv = function () {
            $scope.convenio = {};
            $scope.convenioForm.$setPristine();
            $scope.Acao = "Adicionar";
            $scope.divconvenio = true;
        };



        $scope.ExcluirConvenio = function alert_it(convenio) {
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
                    apagarRegistro(convenio)
                    swal("EXCLUÍDO!", "O registro foi deletado com sucesso.", "success");
                });
        }


        var apagarRegistro = function (convenio) {
            var convenioData = convenioService.Excluir(convenio.ConvenioId);
            convenioData.then(function (data) {
                if (data.status === 200) {
                    toastr["warning"]("Convenio excluído com sucesso!", "MedicalManagement-Sys");
                    obterTodosOsConvenios();
                }
            }, function () {
                toastr["error"]("Erro ao excluir convenio!", "MedicalManagement-Sys");
            });
        };





        $scope.AdicionarEditarConvenio = function () {
            var convenioData = null;
            var _convenio = {
                Descricao: $scope.convenio.Descricao
            };
            var valorAcao = $scope.Acao;
            if (valorAcao === "Atualizar") {
                _convenio.ConvenioId = $scope.convenio.ConvenioId;
                convenioData = convenioService.AtualizarConvenio(_convenio);
                convenioData.then(function (data) {
                    if (data.status === 200) {
                        toastr["success"]("Convenio alterado com sucesso!", "MedicalManagement-Sys");
                        obterTodosOsConvenios();
                        $scope.divconvenio = false;
                    }
                }, function (data) {
                    console.log(data);
                    toastr["error"](data.data, "MedicalManagement-Sys");
                });
            } else if (valorAcao === "Adicionar") {
                convenioData = convenioService.AdicionarConvenio(_convenio);
                //debugger;
                convenioData.then(function (data) {
                    if (data.status === 200) {
                        //console.log(data);
                        toastr["success"]("Convenio Adicionado com sucesso!", "MedicalManagement-Sys");
                        obterTodosOsConvenios();
                        $scope.divconvenio = false;
                    }
                }, function (data) {
                    if (data.status === 401) {
                        console.log(data);
                        toastr["error"](data.data, "MedicalManagement-Sys");
                    }
                    toastr["error"]("Erro ao Adicionar convenio!", "MedicalManagement-Sys");
                });
            }
        };


        $scope.cancelaEdicao = function () {
            $scope.Acao = "";
            $scope.divconvenio = false;
            $scope.convenioForm.$setPristine();
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



        obterTodosOsConvenios();


    }]);

})();