
(function () {
    'use strict';

    // Fisioterapias

    app.controller("fisioterapiaCtrl",
        ['$scope', 'fisioterapiaService',
            function ($scope, fisioterapiaService) {

                $scope.divfisioterapia = false;
                $scope.titulo = "Tabela de Fisioterapia";


                function obterTodosOsFisioterapias() {
                    var fisioterapiasData = fisioterapiaService.ObterTodas();
                    fisioterapiasData.then(function (fisioterapia) {
                        $scope.fisioterapias = fisioterapia.data;
                        $scope.Acao = "";
                    }, function () {
                        toastr["error"]("Erro ao obter fisioterapias", "MedicalManagement-Sys");
                    }
                    );
                };


                // obter por id
                // Habilita DIV para Edição de registros
                $scope.obterPorId = function (fisioterapia) {
                    var fisioterapiaData = fisioterapiaService.GetFisioterapiaPorId(fisioterapia.FisioterapiaId);
                    fisioterapiaData.then(function (fisioterapia) {
                        $scope.fisioterapia = fisioterapia.data;

                        $scope.Acao = "Atualizar";
                        $scope.divfisioterapia = true;
                    }, function () {
                        toastr["error"]("Erro ao obter fisioterapia por id!", "MedicalManagement-Sys");
                    });
                };



                // Habilita DIV para Adição de registros
                $scope.incluirFisioterapiaDiv = function () {
                    $scope.fisioterapia = {};
                    $scope.fisioterapiaForm.$setPristine();
                    $scope.Acao = "Adicionar";
                    $scope.divfisioterapia = true;
                };



                $scope.ExcluirFisioterapia = function alert_it(fisioterapia) {
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
                            apagarRegistro(fisioterapia)
                            swal("EXCLUÍDO!", "O registro foi deletado com sucesso.", "success");
                        });
                }



                var apagarRegistro = function (fisioterapia) {
                    var fisioterapiaData = fisioterapiaService.Excluir(fisioterapia.FisioterapiaId);
                    fisioterapiaData.then(function (data) {
                        if (data.status === 200) {
                            obterTodosOsFisioterapias();
                        }
                    }, function () {
                        toastr["error"]("Erro ao excluir fisioterapia!", "MedicalManagement-Sys");
                    });
                };





                $scope.AdicionarEditarFisioterapia = function () {
                    var fisioterapiaData = null;
                    var _fisioterapia = {
                        Descricao: $scope.fisioterapia.Descricao
                    };
                    var valorAcao = $scope.Acao;
                    if (valorAcao === "Atualizar") {
                        _fisioterapia.FisioterapiaId = $scope.fisioterapia.FisioterapiaId;
                        fisioterapiaData = fisioterapiaService.AtualizarFisioterapia(_fisioterapia);
                        fisioterapiaData.then(function (data) {
                            if (data.status === 200) {
                                //toastr["success"]("Fisioterapia alterado com sucesso!", "MedicalManagement-Sys");
                                obterTodosOsFisioterapias();
                                $scope.divfisioterapia = false;

                                swal({
                                    title: "Sucesso!",
                                    text: "Registro atualizado com sucesso!",
                                    imageUrl: "/images/thumbs-up.jpg"
                                });

                            }
                        }, function () {
                            toastr["error"]("Erro ao editar fisioterapia!", "MedicalManagement-Sys");
                        });
                    } else if (valorAcao === "Adicionar") {
                        fisioterapiaData = fisioterapiaService.AdicionarFisioterapia(_fisioterapia);

                        fisioterapiaData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("Fisioterapia Adicionado com sucesso!", "MedicalManagement-Sys");
                                obterTodosOsFisioterapias();
                                $scope.divfisioterapia = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao Adicionar fisioterapia!", "MedicalManagement-Sys");
                        });
                    }
                };


                $scope.cancelaEdicao = function () {
                    $scope.Acao = "";
                    $scope.divfisioterapia = false;
                    $scope.fisioterapiaForm.$setPristine();
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



                obterTodosOsFisioterapias();


            }
        ]
    );
}());