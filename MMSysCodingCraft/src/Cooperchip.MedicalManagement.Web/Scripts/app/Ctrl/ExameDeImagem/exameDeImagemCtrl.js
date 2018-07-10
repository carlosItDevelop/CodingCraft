// ---------------------------------------------------- //
(function () {

    'use strict';

    app.controller("exameDeImagemCtrl",
        ['$scope', '$filter', '$http', 'exameDescricaoService', 'pacienteService',
            function ($scope, $filter, $http, exameDescricaoService, pacienteService) {

                $scope.titulo = "Exame de Imagem";
                $scope.examesdescricoes = [];
                $scope.examedeimagens = [];
                $scope.examedeimagem = {};

                var idprontuario;
                var idpaciente;
                // Evento click simulado em outra controller,
                // via javaScript, => ProntuarioCtrl.js.
                $("#idPaciente").click(function () {
                    idpaciente = $("#idPaciente").val();
                    idprontuario = $("#ProntuarioId").val();
                    if (idpaciente && idprontuario) {
                        $scope.examedeimagem.PacienteId = idpaciente;
                        $scope.examedeimagem.ProntuarioGuid = idprontuario;
                        carregaExameDeImagemPorId();
                    };
                });


                var carregaExameDeImagemPorId = function () {
                    $http({
                        url: '/ExameDeImagem/GetExameDeImagemPorId/',
                        method: 'GET',
                        params: {
                            idpc: idpaciente,
                            idpt: idprontuario
                        }
                    }).success(function (data) {
                        //console.log("Dados: " + data);
                        //console.log("Id Paciente: "+idpaciente);
                        //console.log("Id Prontuario: " + idprontuario);
                        $scope.examedeimagens = data;
                    }).error(function (data, status) {
                        toastr["error"]("Erro ao carregar Exame de Imagem!", "MedicalManagement-Sys");
                    });
                };

                $scope.adicionarExameDeImagem = function (examedeimagem) {
                    examedeimagem.PacienteId = idpaciente;
                    examedeimagem.ProntuarioGuid = idprontuario;
                    $http.post("/ExameDeImagem/AddExameDeImagem", examedeimagem).success(function (data) {
                        delete $scope.examedeimagem;
                        $scope.exameDeImagemForm.$setPristine();
                        carregaExameDeImagemPorId();
                        toastr["success"]("Exame de Imagem Adicionada com sucesso!", "Medical Management - Sys");
                    }).error(function (data, status) {
                        $scope.message = "Aconteceu um erro: " + data;
                    });
                };


                $scope.alterarExameDeImagem = function (examedeimagem) {
                    examedeimagem.data = new Date();
                    $http.post("/ExameDeImagem/UdtExameDeImagem/", examedeimagem.ExameDeImagemId).success(function (data) {

                    }).error(function (data, status) {
                        $scope.message = "Aconteceu um erro: " + data;
                    });
                };



                $scope.apagarExameDeImagens = function alert_it(examedeimagens) {
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
                            DeletarExameDeImagens(examedeimagens)
                            swal("EXCLUÍDO!", "O registro foi deletado com sucesso.", "success");
                        });
                }

                var DeletarExameDeImagens = function (examedeimagens) {
                    $scope.examedeimagens = examedeimagens.filter(function (examedeimagem) {
                        if (examedeimagem.selecionado) {
                            $http.post("/ExameDeImagem/DelExameDeImagem/" + examedeimagem.ExameDeImagemId).success(function (data) {
                                toastr["warning"]("Exame de Imagem Excluída com sucesso!", "Medical Management - Sys");
                            }).error(function (data, status) {
                                $scope.message = "Aconteceu um erro: " + data;
                                toastr["error"]("Erro ao remover registro!", "Medical Management - Sys");
                            });
                        };
                        if (!examedeimagem.selecionado) return examedeimagem;
                    });
                };


                function obterTodosOsExameDescricaos() {
                    var examedescricaosData = exameDescricaoService.ObterDescricoes();
                    examedescricaosData.then(function (examedescricao) {
                        $scope.examesdescricaos = examedescricao.data;
                    }, function () {
                        toastr["error"]("Erro ao obter examedescricaos", "MedicalManagement-Sys");
                    }
                    );
                };
                obterTodosOsExameDescricaos();

                /*
                Retirei o carregamento de pacientes daqui
                */

                $scope.isExameDeImagemSelecionado = function (examedeimagens) {
                    return examedeimagens.some(function (examedeimagem) {
                        return examedeimagem.selecionado;
                    });
                };

                $scope.ordenarPor = function (campo) {
                    $scope.criterioDeOrdenacao = campo;
                    $scope.direcaoDaOrdenacao = !$scope.direcaoDaOrdenacao;
                };

            }]);
})();