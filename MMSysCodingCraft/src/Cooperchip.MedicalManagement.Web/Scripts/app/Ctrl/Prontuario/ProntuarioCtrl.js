
(function () {

    'use strict';

    app.controller("prontuarioCtrl",
        ['$rootScope', '$scope', '$location', '$filter', '$http', 'prontuarioService', 'pacienteService',
            function ($rootScope, $scope, $location, $filter, $http, prontuarioService, pacienteService) {

                var vm = this;

                //$scope.parametro = $location.search();

                $scope.titulo = "Evolução Médica"

                $scope.init = function (prontuarios) {
                    if (prontuarios && prontuarios.length > 0) {
                        $scope.prontuarios = prontuarios;
                    } else {
                        carregaProntuarios();
                    }
                }


                $scope.prontuarios = [];
                $scope.pacientes = [];
                $scope.enderecos = [];
                $scope.paciente = {};

                $scope.prontuario = {};
                $scope.endereco = {};

                $scope.Acao = '';





                /*=====/
                 * Aqui devem ser listados os prontuários do paciente selecionado
                 * não importanto se foi para adição ou atualização, pois estamos
                 * lidando com os dados deste paciente apenas, quando o selecionamos!
                  ======*/
                var atualizaListaDeProntuarios = function (id) {
                    if (id) {
                        carregaProntuarios(id);
                    } else {
                        carregaProntuarios();
                    };
                };


                /* ----------------------------------------------------------------- */
                var carregaProntuarios = function () {
                    var prontuariosData = prontuarioService.srvcObterProntuarios();
                    prontuariosData.then(function (results, status) {
                        var dados = results.data;
                        $scope.prontuarios = dados;
                    }, function (results, status) {
                        toastr["error"](results.data, "MedicalManagement-Sys");
                    });
                };


                var carregaProntuarios = function (id) {
                    var prontuariosData = prontuarioService.srvcObterProntuarios(id);
                    prontuariosData.then(function (results, status) {
                        var dados = results.data;
                        $scope.prontuarios = dados;
                    }, function (results, status) {
                        toastr["error"](results.data, "MedicalManagement-Sys");
                    });
                };
                /* ----------------------------------------------------------------- */



                /* ----------------------------------------------------------------- */
                // Carrega dados de endereço do paciente para o prontuario;
                var buscaEnderecoPaciente = function (dados) {
                    $http.get('/Home/getEndereco/' + dados.PacienteId).success(function (result) {
                        $scope.endereco = result;
                    }).error(function (result, status) {
                        toastr["error"](result.data, "MedicalManagement-Sys");
                    });
                };


                // Carrega dados pessoais do paciente para o prontuario;
                var ObterPacientePorId = function (idpaciente) {
                    var pacienteData = pacienteService.srvcGetPacientePorId(idpaciente);
                    pacienteData.then(function (result) {

                        $scope.prontuario.Paciente = result.data;

                        // Idade
                        var nascimento = new Date(result.data.DataNascimento).getFullYear();
                        var dataatual = new Date().getFullYear();
                        var diff = dataatual - nascimento;
                        $scope.Idade = diff;

                    }, function () {
                        toastr["error"]("Erro ao obter paciente por id!", "MedicalManagement-Sys");
                    });
                };
                /* ----------------------------------------------------------------- */


                // Disparo de eventos da camada app 
                // para todos os controllers ouvintes;
                $scope.ArquivarProntuario = function (oProntuario) {
                    $rootScope.$broadcast('evArquivarProntuario', oProntuario)
                };

                /* ----------------------------------------------------------------- */
                // Habilita DIV para Adição de registros
                // e carrega dados do paciente e endereço.
                $scope.incluirProntuarioDiv = function (idpaciente) {
                    debugger;
                    //srvcCriarNovoProntuarioPorId
                    var prontuarioData = prontuarioService.srvcCriarNovoProntuarioPorId(idpaciente);
                    prontuarioData.then(function (result) {

                        $scope.prontuario = {};
                        $scope.prontuarioForm.$setPristine();

                        var dados = result.data;
                        $scope.prontuario = dados;

                        $scope.prontuario.PacienteId = idpaciente;
                        $scope.prontuario.DataProntuario = new Date(dados.DataProntuario);
                        $scope.prontuario.ProntuarioId = dados.ProntuarioId;

                        buscaEnderecoPaciente($scope.prontuario);

                        // ----/ simulaClique Paciente ------------------------------------------ /
                        $(document).on('simularClique', function () {
                            document.getElementById('idPaciente').value = $scope.prontuario.PacienteId;
                            document.getElementById('ProntuarioId').value = $scope.prontuario.ProntuarioId;
                            var filtroIdPaciente = $('#idPaciente');
                            filtroIdPaciente.click();
                        });
                        $(document).trigger('simularClique');
                        // ----/ simulaClique --------------------------------------------------- /

                        $scope.Acao = "Adicionar";
                        $scope.divprontuario = true;

                    }, function () {
                        toastr["error"]("Erro ao Criar novo prontuario!", "MedicalManagement-Sys");
                    });


                };
                /* ----------------------------------------------------------------- */



                /* ----------------------------------------------------------------- */
                // Carrega prontuario por seu id
                $scope.carregaProntuarioPorId = function (prontuario) {

                    var prontuarioData = prontuarioService.srvcGetProntuarioPorId(prontuario.ProntuarioId);
                    prontuarioData.then(function (prontuario) {

                        var dados = prontuario.data;
                        $scope.prontuario = dados;


                        $scope.prontuario.DataProntuario ? $scope.prontuario.DataProntuario = new Date(dados.DataProntuario) : null;
                        $scope.prontuario.PamData ? $scope.prontuario.PamData = new Date(dados.PamData) : null;
                        $scope.prontuario.HemodialiseData ? $scope.prontuario.HemodialiseData = new Date(dados.HemodialiseData) : null;
                        $scope.prontuario.MarcapassoData ? $scope.prontuario.MarcapassoData = new Date(dados.MarcapassoData) : null;
                        $scope.prontuario.AcessoVenosoData ? $scope.prontuario.AcessoVenosoData = new Date(dados.AcessoVenosoData) : null;
                        $scope.prontuario.ViaDigestivaData ? $scope.prontuario.ViaDigestivaData = new Date(dados.ViaDigestivaData) : null;
                        $scope.prontuario.ViaAereaData ? $scope.prontuario.ViaAereaData = new Date(dados.ViaAereaData) : null;
                        $scope.prontuario.ViaUrinariaData ? $scope.prontuario.ViaUrinariaData = new Date(dados.ViaUrinariaData) : null;
                        $scope.prontuario.PicData ? $scope.prontuario.PicData = new Date(dados.PicData) : null;
                        $scope.prontuario.PiaData ? $scope.prontuario.PiaData = new Date(dados.PiaData) : null;


                        // Calcula Idade
                        var nascimento = new Date(dados.Paciente.DataNascimento).getFullYear();
                        var dataatual = new Date().getFullYear();
                        var diff = dataatual - nascimento;
                        $scope.Idade = diff;
                        // Calcula Idade


                        $scope.Acao = 'Atualizar';
                        $scope.divprontuario = true;

                        toastr["info"]("Prontuário Carregado para Edição!", "MedicalManagement-Sys");

                        // Preenche dados de endereço do paciente selecionado!
                        buscaEnderecoPaciente(dados);

                        // Simulando evento click() para disparar carregamento
                        // dos processos que ficam esperando a alteração do ID do Paciente.
                        // ----/ simulaClique --------------------------------------------------- /
                        $(document).on('simularClique', function () {
                            document.getElementById('idPaciente').value = $scope.prontuario.PacienteId;
                            document.getElementById('ProntuarioId').value = $scope.prontuario.ProntuarioId;
                            var filtroIdPaciente = $('#idPaciente');
                            filtroIdPaciente.click();
                        });
                        // Chama a função de clique através do trigger
                        $(document).trigger('simularClique');
                        // ----/ simulaClique --------------------------------------------------- /

                    }, function () {
                        toastr["error"]("Erro ao carregar prontuario para edição!", "MedicalManagement-Sys");
                    });
                };
                /* ----------------------------------------------------------------- */


                // Botão salvar, que de acordo
                // com a flag Acao Add ou Updt;
                $scope.AdicionarEditarProntuario = function () {

                    var prontuarioData = null;
                    var _prontuario = {};
                    _prontuario = {
                        ProntuarioId: $scope.prontuario.ProntuarioId,
                        PacienteId: $scope.prontuario.PacienteId,
                        NumAtendimento: $scope.prontuario.NumAtendimento,
                        DataProntuario: $scope.prontuario.DataProntuario,
                        Pam: $scope.prontuario.Pam,
                        PamData: $scope.prontuario.PamData,
                        Hemodialise: $scope.prontuario.Hemodialise,
                        HemodialiseData: $scope.prontuario.HemodialiseData,
                        ViaAerea: $scope.prontuario.ViaAerea,
                        ViaAereaData: $scope.prontuario.ViaAereaData,
                        ViaDigestiva: $scope.prontuario.ViaDigestiva,
                        ViaDigestivaData: $scope.prontuario.ViaDigestivaData,
                        AcessoVenoso: $scope.prontuario.AcessoVenoso,
                        AcessoVenosoData: $scope.prontuario.AcessoVenosoData,
                        Marcapasso: $scope.prontuario.Marcapasso,
                        MarcapassoData: $scope.prontuario.MarcapassoData,
                        ViaUrinaria: $scope.prontuario.ViaUrinaria,
                        ViaUrinariaData: $scope.prontuario.ViaUrinariaData,
                        Pic: $scope.prontuario.Pic,
                        PicData: $scope.prontuario.PicData,
                        Pia: $scope.prontuario.Pia,
                        PiaData: $scope.prontuario.PiaData,
                        Anticoagulacao: $scope.prontuario.Anticoagulacao
                    };
                    var valorAcao = $scope.Acao;
                    if (valorAcao === "Atualizar") {
                        //_prontuario.ProntuarioId = $scope.prontuario.ProntuarioId;
                        prontuarioData = prontuarioService.AtualizarProntuario(_prontuario);
                        prontuarioData.then(function (data, status) {
                            if (data.status === 200) {
                                toastr["success"]("Prontuário alterado com sucesso!", "MedicalManagement-Sys");
                                atualizaListaDeProntuarios(_prontuario.PacienteId);
                                $scope.Acao = '';
                                $scope.divprontuario = false;
                            };
                        }, function (data) {
                            //console.log(data.data);
                            if (data.status === 400) {
                                toastr["warning"](data.data, "MedicalManagement-Sys");
                            };
                        });
                    } else if (valorAcao === "Adicionar") {
                        //_prontuario.PacienteId = $scope.prontuario.PacienteId;
                        prontuarioData = prontuarioService.AdicionarProntuario(_prontuario);
                        prontuarioData.then(function (data) {
                            if (data.status === 200) {
                                toastr["success"]("Prontuário Adicionado com sucesso!", "MedicalManagement-Sys");
                                atualizaListaDeProntuarios(_prontuario.PacienteId);
                                $scope.Acao = '';
                                $scope.divprontuario = false;
                            }
                        }, function (data) {
                            //console.log(data.data);
                            if (data.status === 400) {
                                toastr["warning"](data.data, "MedicalManagement-Sys");
                            };
                        });

                    };
                };





                /*=====/ liga/desliga botoes de adicionar, editar e arquivar
                    * na medida em que faz a função inversa em savar e cancelar
                    ======*/
                $scope.inibeBtnEdicao = function () {
                    if (($scope.Acao === "Atualizar") || ($scope.Acao === "Adicionar")) {
                        return true;
                    }
                    return false;
                };

                $scope.cancelaEdicao = function () {
                    $scope.Acao = "";
                    $scope.divprontuario = false;
                    $scope.prontuarioForm.$setPristine();
                };

                $scope.verificaAcao = function () {
                    if ($scope.Acao === 'Atualizar') {
                        return true;
                    } else {
                        return false;
                    }
                };

                $scope.mostrarAcao = function () {
                    if ($scope.Acao === 'Atualizar') {
                        return 'Editando Prontuário';
                    } else {
                        return 'Adicionando Prontuário';
                    }
                }
                /* ====/ ========================================================= */



                // ------ Marcapasso --------------------------------------------- //
                $scope.marcapassos = [
                    { id: 1, Descricao: "Não" },
                    { id: 2, Descricao: "Sim, em SCD" },
                    { id: 3, Descricao: "Sim, em SCE" },
                    { id: 4, Descricao: "Sim, em JID" },
                    { id: 5, Descricao: "Sim, em JIE" },
                    { id: 6, Descricao: "Definitivo" }
                ];

                // ------ Pam --------------------------------------------------- //
                $scope.pams = [
                    { id: 1, Descricao: "Radial D" },
                    { id: 2, Descricao: "Radial E" },
                    { id: 3, Descricao: "Femural D" },
                    { id: 4, Descricao: "Femural E" },
                    { id: 5, Descricao: "PNI" },
                    { id: 6, Descricao: "Não Medida" }
                ];


                // ------ Vias Aereas ------------------------------------------- //
                $scope.viasaereas = [
                    { id: 1, Descricao: "Tubo" },
                    { id: 2, Descricao: "Traqueo" },
                    { id: 3, Descricao: "TQT em Macro" },
                    { id: 4, Descricao: "Macro" },
                    { id: 5, Descricao: "Ar Ambiente" },
                    { id: 6, Descricao: "Sem Tubo" }
                ];


                // ------ Via Digestiva ----------------------------------------- //
                $scope.viasdigestivas = [
                    { id: 1, Descricao: "Oral" },
                    { id: 2, Descricao: "Enteral" },
                    { id: 3, Descricao: "Gástrica" },
                    { id: 4, Descricao: "Gastrostomia" },
                    { id: 5, Descricao: "Jejunostomia" }
                ];

                // ------ Via Urinária ------------------------------------------ //
                $scope.viasurinarias = [
                    { id: 1, Descricao: "Espontânea" },
                    { id: 2, Descricao: "Fralda" },
                    { id: 3, Descricao: "Jontex" },
                    { id: 4, Descricao: "Cateter Foley" },
                    { id: 5, Descricao: "Cistostomia" }
                ];

                // ------ Hemodiálise ------------------------------------------- //
                $scope.hemodialises = [
                    { id: 1, Descricao: "Não" },
                    { id: 2, Descricao: "Sim, em FD" },
                    { id: 3, Descricao: "Sim, em FE" },
                    { id: 4, Descricao: "Sim, em SCD" },
                    { id: 5, Descricao: "Sim, em SCE" },
                    { id: 6, Descricao: "Sim, em JID" },
                    { id: 7, Descricao: "Sim, em JIE" },
                    { id: 8, Descricao: "Sim, FAV MSD" },
                    { id: 9, Descricao: "Sim, FAV MSE" },
                    { id: 10, Descricao: "Peritonial" }
                ];


                // ------ Acesso Venoso ----------------------------------------- //
                $scope.acessosvenosos = [
                    { id: 1, Descricao: "Subclávia D" },
                    { id: 2, Descricao: "Subclávia E" },
                    { id: 3, Descricao: "Jugular Int D" },
                    { id: 4, Descricao: "Jugular Int E" },
                    { id: 5, Descricao: "Femural D" },
                    { id: 6, Descricao: "Femural E" },
                    { id: 7, Descricao: "Dissecção D" },
                    { id: 8, Descricao: "Dissecção E" },
                    { id: 9, Descricao: "Periférico" },
                    { id: 10, Descricao: "Sem Acesso" }
                ];


                // ------ Anticoagulacao Prontuario ---------------------------- //
                $scope.anticoagulacoesprontuario = [
                    { id: 1, Descricao: "Sem Anticoagulante" },
                    { id: 2, Descricao: "Clexane Profilática" },
                    { id: 3, Descricao: "Clexane Plena" },
                    { id: 4, Descricao: "Heparina Profilática" },
                    { id: 5, Descricao: "Heparina Plena" }
                ];



                // -----------------------------------------------------------------
                // ---- Genéricos 1 ------------------------------------------------


                // Excluir após todas os processos usarem a implementação com 3 params;


                // Generic optimized function
                $scope.getInibirEAnularData = function (optons, optionSelected, campo) {
                    var str = optionSelected.split(';');
                    var vIndex = optionSelected.indexOf(optons);
                    if (vIndex > -1) {
                        switch (campo) {
                            case 'AcessoVenosoData':
                                $scope.prontuario.AcessoVenosoData = null;
                                break;
                            case 'HemodialiseData':
                                $scope.prontuario.HemodialiseData = null;
                                break;
                            case 'PamData':
                                $scope.prontuario.PamData = null;
                                break;
                            case 'PiaData':
                                $scope.prontuario.PiaData = null;
                                break;
                            case 'PicData':
                                $scope.prontuario.PicData = null;
                                break;
                            case 'ViaAereaData':
                                $scope.prontuario.ViaAereaData = null;
                                break;
                            case 'ViaUrinariaData':
                                $scope.prontuario.ViaUrinariaData = null;
                                break;
                            case 'MarcapassoData':
                                $scope.prontuario.MarcapassoData = null;
                                break;
                            default:
                                break;
                        }
                        return true;
                    } else {
                        return false;
                    }
                };



                // -----------------------------------------------------------------
                // -----------------------------------------------------------------
                // -----------------------------------------------------------------
                // ---- Genéricos 2 ------------------------------------------------

                $scope.isDisableCbo = function (chk) {
                    return !chk;
                }

                $scope.ordenarPor = function (campo) {
                    $scope.criterioDeOrdenacao = campo;
                    $scope.direcaoDaOrdenacao = !$scope.direcaoDaOrdenacao;
                };




                $scope.piachecado = "naochecado";

                $scope.isProntuarioPiaChecado = function () {
                    if ($scope.prontuario.Pia === "Sim") {
                        $scope.piachecado = "checado";
                    } else {
                        $scope.piachecado = "naochecado";
                    }
                };

            }
        ]);
})();
