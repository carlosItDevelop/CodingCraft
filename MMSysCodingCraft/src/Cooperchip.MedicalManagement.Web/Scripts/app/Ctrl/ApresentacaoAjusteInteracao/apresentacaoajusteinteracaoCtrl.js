
(function () {
    'use strict';

    app.controller("apresentacaoajusteinteracaoCtrl", ['$scope', '$filter', '$http', '$uibModal', 'pacienteService', 'genericoService', function ($scope, $filter, $http, $uibModal, pacienteService, genericoService) {

        $scope.apresentacaoajusteinteracaos = [];
        $scope.apresentacaoajusteinteracao = {};
        $scope.titulo = 'Apresentação, Ajustes e Interações Medicamentosas';

        var idprontuario;
        var idpaciente;
        // Evento click simulado em outra controller,
        // via javaScript, => ProntuarioCtrl.js.
        $("#idPaciente").click(function () {
            idpaciente = $("#idPaciente").val();
            idprontuario = $("#ProntuarioId").val();
            if (idpaciente && idprontuario) {
                carregaApresentacaoAjusteInteracaoPorIdPacienteProntuario();
            }
        });


        // GetApresentacaoAjusteInteracaoPorId  Por id Paciente e id Prontuario
        var carregaApresentacaoAjusteInteracaoPorIdPacienteProntuario = function () {
            $http({
                url: '/Prontuario/GetApresentacaoAjusteInteracaoPorId/',
                method: 'GET',
                params: {
                    idpc: idpaciente,
                    idpt: idprontuario
                }
            }).success(function (data) {
                $scope.apresentacaoajusteinteracaos = data;
            }).error(function (data, status) {
                toastr['error']('Erro carregando os dados...', 'MedicalManagement-Sys');
            });
        };


        $scope.alterarApresentacaoAjusteInteracao = function (apresentacaoajusteinteracao) {
            $http.post("/Prontuario/UdtApresentacaoAjusteInteracao/", apresentacaoajusteinteracao.ApresentacaoAjusteInteracaoId).success(function (data) {
                delete $scope.apresentacaoajusteinteracao;
                $scope.ApresAjInterForm.$setPristine();
                carregaApresentacaoAjusteInteracaoPorIdPacienteProntuario();
            }).error(function (data, status) {
                toastr["error"]("Erro ao Atualizar dados!", "Medical Management - Sys");
            });
        };

        $scope.apagarApresentacaoAjusteInteracaos = function (apresentacaoajusteinteracaos) {
            $scope.apresentacaoajusteinteracaos = apresentacaoajusteinteracaos.filter(function (apresentacaoajusteinteracao) {
                if (apresentacaoajusteinteracao.selecionado) {
                    $http.post("/Prontuario/DelApresentacaoAjusteInteracao/" + apresentacaoajusteinteracao.ApresentacaoAjusteInteracaoId).success(function (data) {
                        toastr["warning"]("Dado(s) Excluído(s) com sucesso!", "Medical Management - Sys");
                    }).error(function (data, status) {
                        toastr["error"]("Erro ao remover registro!", "Medical Management - Sys");
                    });
                }
                if (!apresentacaoajusteinteracao.selecionado) return apresentacaoajusteinteracao;
            });
        };


        // ------------------------------ //
        $scope.apresentacaoajusteinteracao.IdGenerico = null;
        // ------------------------------ //
        var carregaPosologia = function (idmed) {
            $http.get("/Prontuario/GetPosologiaPorMedicamento/" + idmed).success(function (data) {
                $scope.medicamentosposologias = data;
            }).error(function (data, status) {
                if (status === 404) {
                    toastr["warning"]("Erro ao carregar Posologia!", "MedicalManagement-Sys");
                } else {
                    toastr["error"]("Erro ao carregar posologia do medicamento!", "MedicalManagement-Sys");
                }
            });
        };


        $scope.generico = {};

        var carregaGenericoPorMedicamento = function (idmdct) {
            var genericoData = genericoService.GetGenericoForMedicamentos(idmdct);
            genericoData.then(function (resultado) {
                $scope.genericos = resultado.data;
                //$scope.Acao = "";
                //$scope.divatbemuso = false;
            }, function () {
                toastr["error"]("Erro ao obter Genéricos por Medicamento!", "MedicalManagement-Sys");
            });
        };


        var obterAtbEmUsoPorPacienteEProntuario = function () {
            var atbemusoData = atbemusoService.GetAtbEmUsoPorPacienteEProntuario(idpaciente, idprontuario);
            atbemusoData.then(function (resultado) {
                $scope.atbemusos = resultado.data;
                $scope.Acao = "";
                $scope.divatbemuso = false;
            }, function () {
                toastr["error"]("Erro ao obter AtbEmUso por Paciente!", "MedicalManagement-Sys");
            });
        };




        // ------------------------------------------------------------------------------------- //
        $("#medicamentoajusteapresentacaoparaposologia").on('click', function () {
            $scope.medicamentosposologias = [];
            var idmdct = $scope.apresentacaoajusteinteracao.IdMedicamento;
            if (idmdct) {
                carregaPosologia(idmdct);
                carregaGenericoPorMedicamento(idmdct);
            }
        });

        // ------------------------------------------------------------------------------------- //
        // ------------------------------------------------------------------------------------- //



        //// -------------------------------------------------- //
        //// ----/ Início do contexto de controles de Interação //

        ///*
        //     #. Verificar se as variáveis NÃO são nulas - Ok
        //     #. Verificar se NÃO são undefined - Ok
        //     #. Me restringir às linhas selecionadas para pegar os valores - Ok - Descontinuada...
        //     #. Pegar o length da variavel;
        //     #. Se for menor que 5, por tantos ZEROS quanto a diferença - Ok
        //     #. Ao gravar o medicamento prescrito voltar o value da selectlist para "" em Medicamento e Posologia - Ok
        //     #. NÃO pode haver mais de uma seleção para o mesmo medicamento.... - Ok
        //     #. Ao "barrar" a inserção de um novo elemento no array de medicamentos, zerar a option...
        //     #. Avisar ao usuário sobre as repetições para não passarem despercebidas. Ok
        //  ===>   10. Comparar com a base de dados de Interação;
        //            10.a.
        //            10.b.
        //            10.c.
        //            .....
        //*/



        // Mesmo quando não grava, pois estou controlando o ModelState no controller MVC
        // a mensgame é de gravação com sucesso, ainda que com repetidas (e não grava)
        // Transformar essa chamada em serviço com http e o controller passar para ApiResources!
        $scope.adicionarApresentacaoAjusteInteracao = function (apresentacaoajusteinteracao) {
            apresentacaoajusteinteracao.IdMedicamento = parseInt(apresentacaoajusteinteracao.IdMedicamento);
            apresentacaoajusteinteracao.IdGenerico = $scope.generico.IdGenerico;
            apresentacaoajusteinteracao.PacienteId = idpaciente;
            apresentacaoajusteinteracao.ProntuarioGuid = idprontuario;

            $http.post("/Prontuario/AddApresentacaoAjusteInteracao", apresentacaoajusteinteracao).success(function (data) {
                delete $scope.apresentacaoajusteinteracao;
                $scope.ApresAjInterForm.$setPristine();
                carregaApresentacaoAjusteInteracaoPorIdPacienteProntuario();
                zeraOption();
                toastr["success"]("Dados Adicionada com sucesso!", "Medical Management - Sys");
            }).error(function (data, status) {
                toastr["error"]("Erro ao Adicionar Antibiótico!", "Medical Management - Sys");
            });
        };

        // ------------------------------------------------------------------------------ //
        // ------------------------------------------------------------------------------ //



        /*
            Criar uma nova coleção que combine de 2 em 2 os elementos selecionados
            para testar se há interações medicamentosas entres os medicamentos escolhidos.
        */
        // Criar função aqui...

        /*
            Ao gravar voltar o valor da Option para Empty.
            Não esquecer de por Empty na DropDrownList de medicamento e, também, de posologia.
        */
        var zeraOption = function () {
            $("#medicamentoajusteapresentacaoparaposologia").val($("#medicamentoajusteapresentacaoparaposologia option:first").val());
            $("#posologia").val($("#posologia option:first").val());
        };

        // ------------------------------------------------------------------------------------- //
        // ------------------------------------------------------------------------------------- //
        // ------------------------------------------------------------------------------------- //



        $scope.isApresentacaoAjusteInteracaoSelecionado = function (apresentacaoajusteinteracaos) {
            return apresentacaoajusteinteracaos.some(function (apresentacaoajusteinteracao) {
                return apresentacaoajusteinteracao.selecionado;
            });
        };

        $scope.ordenarPor = function (campo) {
            $scope.criterioDeOrdenacao = campo;
            $scope.direcaoDaOrdenacao = !$scope.direcaoDaOrdenacao;
        };



        // ------------------------------------------------------------------------------------- //
        // -----/ Controle do Modal de Apresentação -------------------------------------------- //

        $scope.mdctos = [];
        $scope.animationsEnabled = true;

        var openApresentacao = function (size, idm) {

            $http.get("/Prontuario/GetApresentacoesPorId/" + idm).success(function (data) {
                $scope.mdctos = data;
                var modalInstance = $uibModal.open({
                    animation: $scope.animationsEnabled,
                    templateUrl: 'modalApresentacao.html',
                    controller: 'modalApresentacaoCtrl',
                    size: size,
                    resolve: {
                        vMdct: function () {
                            return $scope.mdctos;
                        }
                    }
                });

                modalInstance.result.then(function () {
                    toastr["success"]("Retorno do modal com Ok!", "MedicalManagement-Sys");
                }, function () {
                    toastr["error"]("Retorno do modal com ESC!", "MedicalManagement-Sys");
                });

            }).error(function (data, status) {
                toastr["error"]("Erro na busca de medicamentos apresentação!", "MedicalManagement-Sys");
            });

        };
        // -----/ Fim Controle do Modal Apresentacao ------------------------------------------- //


        // -----------------------------------------------------  //
        $("#modalapresentacaoInteracao").on('click', function () {
            var id = $scope.apresentacaoajusteinteracao.IdMedicamento;
            if (id) {
                openApresentacao('lg', parseInt(id));
            }
        });

        //// -------/ Fim do contexto de controle de Interação ---//
        //// ---------------------------------------------------- //

    }]);
})();