
(function () {
    'use strict';


    // Classes

    app.controller("classeCtrl",
        ['$scope', 'classeService',
            function ($scope, classeService) {

        $scope.divclasse = false;
        $scope.titulo = "Lista de Classes";


        function obterTodosOsClasses() {
            var classesData = classeService.ObterTodas();
            classesData.then(function (classe) {
                $scope.classes = classe.data;
                $scope.Acao = "";
            }, function () {
                toastr["error"]("Erro ao obter classes", "MedicalManagement-Sys");
            }
            );
        };


        // obter por id
        // Habilita DIV para Edição de registros
        $scope.obterPorId = function (classe) {
            var classeData = classeService.GetClassePorId(classe.ClasseId);
            classeData.then(function (classe) {
                $scope.classe = classe.data;

                $scope.Acao = "Atualizar";
                $scope.divclasse = true;
            }, function () {
                toastr["error"]("Erro ao obter classe por id!", "MedicalManagement-Sys");
            });
        };



        // Habilita DIV para Adição de registros
        $scope.incluirClasseDiv = function () {
            $scope.classe = {};
            $scope.classeForm.$setPristine();
            $scope.Acao = "Adicionar";
            $scope.divclasse = true;
        };



        $scope.ExcluirClasse = function (classe) {
            var classeData = classeService.Excluir(classe.ClasseId);
            classeData.then(function (data) {
                if (data.status === 200) {
                    toastr["warning"]("Classe excluído com sucesso!", "MedicalManagement-Sys");
                    obterTodosOsClasses();
                }
            }, function () {
                toastr["error"]("Erro ao excluir classe!", "MedicalManagement-Sys");
            });
        };





        $scope.AdicionarEditarClasse = function () {
            var classeData = null;
            var _classe = {
                Descricao: $scope.classe.Descricao
            };
            var valorAcao = $scope.Acao;
            if (valorAcao === "Atualizar") {
                _classe.ClasseId = $scope.classe.ClasseId;
                classeData = classeService.AtualizarClasse(_classe);
                classeData.then(function (data) {
                    if (data.status === 200) {
                        toastr["success"]("Classe alterado com sucesso!", "MedicalManagement-Sys");
                        obterTodosOsClasses();
                        $scope.divclasse = false;
                    }
                }, function () {
                    toastr["error"]("Erro ao editar classe!", "MedicalManagement-Sys");
                });
            } else if (valorAcao === "Adicionar") {
                classeData = classeService.AdicionarClasse(_classe);

                classeData.then(function (data) {
                    if (data.status === 200) {
                        toastr["success"]("Classe Adicionado com sucesso!", "MedicalManagement-Sys");
                        obterTodosOsClasses();
                        $scope.divclasse = false;
                    }
                }, function () {
                    toastr["error"]("Erro ao Adicionar classe!", "MedicalManagement-Sys");
                });
            }
        };


        $scope.cancelaEdicao = function () {
            $scope.Acao = "";
            $scope.divclasse = false;
            $scope.classeForm.$setPristine();
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



        obterTodosOsClasses();


    }]);

})();