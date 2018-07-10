
(function () {
    'use strict';
    // Especialidades

    app.controller("especialidadeCtrl",
        ['$scope', 'especialidadeService',
            function ($scope, especialidadeService) {

        $scope.divespecialidade = false;
        $scope.titulo = "Lista de Especialidades";


        function obterTodosOsEspecialidades() {
            var especialidadesData = especialidadeService.ObterEspecialidades();
            especialidadesData.then(function (especialidade) {
                $scope.especialidades = especialidade.data;
                $scope.Acao = "";
            }, function () {
                toastr["error"]("Erro ao obter especialidades", "MedicalManagement-Sys");
            });
        };


        // obter por id
        // Habilita DIV para Edição de registros
        $scope.obterPorId = function (especialidade) {
            var especialidadeData = especialidadeService.GetEspecialidadePorId(especialidade.EspecialidadeId);
            especialidadeData.then(function (especialidade) {
                $scope.especialidade = especialidade.data;

                $scope.Acao = "Atualizar";
                $scope.divespecialidade = true;
            }, function () {
                toastr["error"]("Erro ao obter especialidade por id!", "MedicalManagement-Sys");
            });
        };



        // Habilita DIV para Adição de registros
        $scope.incluirEspecialidadeDiv = function () {
            $scope.especialidade = {};
            $scope.especialidadeForm.$setPristine();
            $scope.Acao = "Adicionar";
            $scope.divespecialidade = true;
        };



        $scope.ExcluirEspecialidade = function alert_it(especialidade) {
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
                    apagarRegistro(especialidade)
                    swal("EXCLUÍDO!", "O registro foi deletado com sucesso.", "success");
                });
        }


        var apagarRegistro = function (especialidade) {
            var especialidadeData = especialidadeService.Excluir(especialidade.EspecialidadeId);
            especialidadeData.then(function (data) {
                if (data.status === 200) {
                    toastr["warning"]("Especialidade excluído com sucesso!", "MedicalManagement-Sys");
                    obterTodosOsEspecialidades();
                }
            }, function () {
                toastr["error"]("Erro ao excluir especialidade!", "MedicalManagement-Sys");
            });
        };





        $scope.AdicionarEditarEspecialidade = function () {
            var especialidadeData = null;
            var _especialidade = {
                Descricao: $scope.especialidade.Descricao
            };
            var valorAcao = $scope.Acao;
            if (valorAcao === "Atualizar") {
                _especialidade.EspecialidadeId = $scope.especialidade.EspecialidadeId;
                especialidadeData = especialidadeService.AtualizarEspecialidade(_especialidade);
                especialidadeData.then(function (data) {
                    if (data.status === 200) {
                        toastr["success"]("Especialidade alterado com sucesso!", "MedicalManagement-Sys");
                        obterTodosOsEspecialidades();
                        $scope.divespecialidade = false;
                    }
                }, function () {
                    toastr["error"]("Erro ao editar especialidade!", "MedicalManagement-Sys");
                });
            } else if (valorAcao === "Adicionar") {
                especialidadeData = especialidadeService.AdicionarEspecialidade(_especialidade);

                especialidadeData.then(function (data) {
                    if (data.status === 200) {
                        toastr["success"]("Especialidade Adicionado com sucesso!", "MedicalManagement-Sys");
                        obterTodosOsEspecialidades();
                        $scope.divespecialidade = false;
                    }
                }, function () {
                    toastr["error"]("Erro ao Adicionar especialidade!", "MedicalManagement-Sys");
                });
            }
        };


        $scope.cancelaEdicao = function () {
            $scope.Acao = "";
            $scope.divespecialidade = false;
            $scope.especialidadeForm.$setPristine();
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



        obterTodosOsEspecialidades();


    }]);

}());