
(function () {
    'use strict';

    // --/ Endereco ---

    app.controller("enderecoCtrl",
        ['$scope', 'enderecoService', 'ufService',
            function ($scope, enderecoService, ufService) {

                $scope.divendereco = false;
                $scope.titulo = "Lista de Endereços";


                /**
                    Obter Descricoes auxiliares
                 */

                function obterOsPacientes() {
                    var pacientesData = enderecoService.GetDescricaoPaciente();
                    pacientesData.then(function (paciente) {
                        $scope.pacientes = paciente.data;
                    }, function () {
                        toastr["error"]("Erro ao obter pacientes", "MedicalManagement-Sys");
                    }
                    );
                };


                function obterAsUfs() {
                    var ufsData = ufService.GetUf();
                    ufsData.then(function (uf) {
                        $scope.ufs = uf.data;
                    }, function () {
                        toastr["error"]("Erro ao obter ufs", "MedicalManagement-Sys");
                    }
                    );
                };


                function obterOsBairros() {
                    var bairrosData = enderecoService.GetBairro();
                    bairrosData.then(function (bairro) {
                        $scope.bairros = bairro.data;
                    }, function () {
                        toastr["error"]("Erro ao obter bairros", "MedicalManagement-Sys");
                    }
                    );
                };


                function obterAsCidades() {
                    var cidadesData = enderecoService.GetCidade();
                    cidadesData.then(function (cidade) {
                        $scope.cidades = cidade.data;
                    }, function () {
                        toastr["error"]("Erro ao obter cidades", "MedicalManagement-Sys");
                    }
                    );
                };

                obterOsPacientes();
                obterAsUfs();
                //obterOsBairros();
                //obterAsCidades();



                // ------/ -----------------------------------------/

                function obterTodosOsEnderecos() {
                    var enderecosData = enderecoService.ObterTodas();
                    enderecosData.then(function (endereco) {
                        $scope.enderecos = endereco.data;
                        $scope.Acao = "";
                    }, function () {
                        toastr["error"]("Erro ao obter enderecos", "MedicalManagement-Sys");
                    }
                    );
                };


                // obter por id
                // Habilita DIV para Edição de registros
                $scope.obterPorId = function (endereco) {
                    var enderecoData = enderecoService.GetEnderecoPorId(endereco.EnderecoId);
                    enderecoData.then(function (endereco) {
                        $scope.endereco = endereco.data;

                        $scope.Acao = "Atualizar";
                        $scope.divendereco = true;
                    }, function () {
                        toastr["error"]("Erro ao obter endereco por id!", "MedicalManagement-Sys");
                    });
                };



                // Habilita DIV para Adição de registros
                $scope.incluirEnderecoDiv = function () {
                    $scope.endereco = {};
                    $scope.enderecoForm.$setPristine();
                    $scope.Acao = "Adicionar";
                    $scope.divendereco = true;
                };


                $scope.ExcluirEndereco = function alert_it(endereco) {
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
                            apagarRegistro(endereco)
                            swal("EXCLUÍDO!", "O registro foi deletado com sucesso.", "success");
                        });
                }

                var apagarRegistro = function (endereco) {
                    var enderecoData = enderecoService.Excluir(endereco.EnderecoId);
                    enderecoData.then(function (data) {
                        if (data.status === 200) {
                            toastr["warning"]("Endereco excluído com sucesso!", "MedicalManagement-Sys");
                            obterTodosOsEnderecos();
                        }
                    }, function () {
                        toastr["error"]("Erro ao excluir endereco!", "MedicalManagement-Sys");
                    });
                };


                $scope.AdicionarEditarEndereco = function () {
                    var enderecoData = null;
                    var _endereco = {
                        PacienteId: $scope.endereco.PacienteId,
                        IdUf: $scope.endereco.IdUf,
                        IdBairro: $scope.endereco.IdBairro,
                        IdCidade: $scope.endereco.IdCidade,
                        Local: $scope.endereco.Local,
                        Numero: $scope.endereco.Numero,
                        Complemento: $scope.endereco.Complemento,
                        Referencia: $scope.endereco.Referencia,
                        Cep: $scope.endereco.Cep
                    };
                    var valorAcao = $scope.Acao;
                    if (valorAcao === "Atualizar") {
                        _endereco.EnderecoId = $scope.endereco.EnderecoId;
                        enderecoData = enderecoService.AtualizarEndereco(_endereco);
                        enderecoData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("Endereco alterado com sucesso!", "MedicalManagement-Sys");
                                obterTodosOsEnderecos();
                                $scope.divendereco = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao editar endereco!", "MedicalManagement-Sys");
                        });
                    } else if (valorAcao === "Adicionar") {
                        enderecoData = enderecoService.AddEndereco(_endereco);
                        enderecoData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("Endereco Adicionado com sucesso!", "MedicalManagement-Sys");
                                obterTodosOsEnderecos();
                                $scope.divendereco = false;
                            }
                        }, function () {
                            toastr["error"]("Erro ao Adicionar endereco!", "MedicalManagement-Sys");
                        });
                    }
                };


                $scope.cancelaEdicao = function () {
                    $scope.Acao = "";
                    $scope.divendereco = false;
                    $scope.enderecoForm.$setPristine();
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



                obterTodosOsEnderecos();


            }]);
}());