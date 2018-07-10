
(function () {

    'use strict';

    app.controller("PrescricaoCtrl",
        ['$rootScope', '$scope', '$filter', '$http', '$uibModal', '$log', 'prescricaoService', 'fisioterapiaService', 'pacienteService',
            function ($rootScope, $scope, $filter, $http, $uibModal, $log, prescricaoService, fisioterapiaService, pacienteService) {

                $scope.titulo = "Prescrição Médica";

                $scope.prescricoes = [];
                $scope.prescricao = {};
                $scope.Acao = '';
                $scope.divprescricao = false;


                var idprontuario;
                var idpaciente;
                // Evento click simulado em outra controller,
                // via javaScript, => ProntuarioCtrl.js.
                $("#idPaciente").click(function () {
                    idpaciente = $("#idPaciente").val();
                    idprontuario = $("#ProntuarioId").val();
                    if (idpaciente && idprontuario) {
                        $scope.prescricao.PacienteId = idpaciente;
                        $scope.prescricao.ProntuarioGuid = idprontuario;
                        carregaPrescricaoPorIdDePacienteEProntuario();
                    };
                });


                // Ouvir o evento disparado por ProntuarioCtrl aqui em PrescriaoCtrl;
                $scope.ProntuarioArquivar = {};
                $scope.$on('evArquivarProntuario', function (event, oProntuario) {
                    $scope.ProntuarioArquivar = oProntuario;
                    console.log('Objeto -> Id do Prontuario; ' + oProntuario.ProntuarioId);
                    console.log('Objeto -> Guid do Paciente; ' + oProntuario.PacienteId);
                    console.log('Objeto -> Paciente.Nome; ' + oProntuario.Paciente.Nome);
                    console.log('Scope -> prontuario.NumAtendimento; ' + $scope.ProntuarioArquivar.NumAtendimento);
                    console.log('Scope -> prontuario.Paciente.Sexo.Descricao; ' + $scope.ProntuarioArquivar.Paciente.Sexo.Descricao);
                });

                var carregaPrescricaoPorIdDePacienteEProntuario = function () {
                    var prescricaoData = prescricaoService.srvcGetPrescricaoPorIdDePacienteEProntuario(idpaciente, idprontuario);
                    prescricaoData.then(function (resultado) {
                        $scope.prescricoes = resultado.data;
                        $scope.Acao = "";
                        $scope.divprescricao = false;
                    }, function () {
                        toastr["error"]("Erro ao obter Prescrição por Paciente!", "MedicalManagement-Sys");
                    });
                };

                // Habilita DIV para Adição de registros
                $scope.incluirPrecricaoDiv = function () {
                    $scope.prescricao = {};
                    $scope.prescricao.PacienteId = idpaciente;
                    $scope.prescricao.ProntuarioGuid = idprontuario;
                    $scope.prescricaoForm.$setPristine();
                    $scope.Acao = "Adicionar";
                    $scope.divprescricao = true;
                };


                // obter por id
                // Habilita DIV para Edição de registros
                $scope.obterPorId = function (prescricao) {
                    var prescricaoData = prescricaoService.GetPrescricaoPorId(prescricao.PrescricaoId);
                    prescricaoData.then(function (prescricao) {
                        prescricao.data.DataPrescricao = new Date(prescricao.data.DataPrescricao);
                        $scope.prescricao = prescricao.data;
                        $scope.Acao = "Atualizar";
                        $scope.divprescricao = true;
                    }, function () {
                        toastr["error"]("Erro ao obter Prescrição por id!", "MedicalManagement-Sys");
                    });
                };



                // Botão salvar, que de acordo
                // com a flag Acao Add ou Updt;
                $scope.AdicionarEditarPrescricao = function () {

                    var prescricaoData = null;
                    var _prescricao = {};
                    _prescricao = {
                        PrescricaoId: $scope.prescricao.PrescricaoId,
                        PacienteId: $scope.prescricao.PacienteId,
                        ProntuarioGuid: $scope.prescricao.ProntuarioGuid,
                        DataPrescricao: $scope.prescricao.DataPrescricao,
                        Dieta: $scope.prescricao.Dieta,
                        DietaSondaGastrica: $scope.prescricao.DietaSondaGastrica,
                        DietaConsistencia: $scope.prescricao.DietaConsistencia,
                        DietaComorbidade: $scope.prescricao.DietaComorbidade,
                        DietaVolume: $scope.prescricao.DietaVolume,
                        Hidratacao: $scope.prescricao.Hidratacao,
                        HidratacaoVolume: $scope.prescricao.HidratacaoVolume,
                        NebulizacaoIntervalo: $scope.prescricao.NebulizacaoIntervalo,
                        Berotec: $scope.prescricao.Berotec,
                        BerotecGotas: $scope.prescricao.BerotecGotas,
                        Atrovent: $scope.prescricao.Atrovent,
                        AtroventGotas: $scope.prescricao.AtroventGotas,
                        Fluimucil: $scope.prescricao.Fluimucil,
                        FluimucilGotas: $scope.prescricao.FluimucilGotas,
                        Sf09: $scope.prescricao.Sf09,
                        Sf09Gotas: $scope.prescricao.Sf09Gotas,
                        Antiacido: $scope.prescricao.Antiacido,
                        AntiacidoPosologia: $scope.prescricao.AntiacidoPosologia,
                        Anticoagulacao: $scope.prescricao.Anticoagulacao,
                        AnticoagulacaoPosologia: $scope.prescricao.AnticoagulacaoPosologia,
                        Procinetico: $scope.prescricao.Procinetico,
                        ProcineticoIntervalo: $scope.prescricao.ProcineticoIntervalo,
                        Amiodarana: $scope.prescricao.Amiodarana,
                        Dobutamina: $scope.prescricao.Dobutamina,
                        Dopamina: $scope.prescricao.Dopamina,
                        Noradrenalina: $scope.prescricao.Noradrenalina,
                        Nitroprussiato: $scope.prescricao.Nitroprussiato,
                        Nitroglicerina: $scope.prescricao.Nitroglicerina,
                        Midazolam: $scope.prescricao.Midazolam,
                        Fentanil: $scope.prescricao.Fentanil,
                        GlicemiaCapilar: $scope.prescricao.GlicemiaCapilar,
                        InsulinaRegular: $scope.prescricao.InsulinaRegular,
                        Oxigenoterapia: $scope.prescricao.Oxigenoterapia,
                        Fisioterapia: $scope.prescricao.Fisioterapia,
                        FebreDor: $scope.prescricao.FebreDor,
                        Emese: $scope.prescricao.Emese,
                        Captopril: $scope.prescricao.Captopril
                    };
                    var valorAcao = $scope.Acao;
                    if (valorAcao === "Atualizar") {
                        prescricaoData = prescricaoService.UpdPrescricao(_prescricao);
                        prescricaoData.then(function (data, status) {
                            if (data.status === 200) {
                                carregaPrescricaoPorIdDePacienteEProntuario();
                                $scope.divprescricao = false;
                                toastr["success"]("Prescricao alterado com sucesso!", "MedicalManagement-Sys");
                            };
                        }, function (data) {
                            //console.log(data.data);
                            if (data.status === 400) {
                                toastr["warning"](data.data, "MedicalManagement-Sys");
                            };
                        });
                    } else if (valorAcao === "Adicionar") {
                        prescricaoData = prescricaoService.AddPrescricao(_prescricao);
                        prescricaoData.then(function (data) {
                            if (data.status === 200) {
                                carregaPrescricaoPorIdDePacienteEProntuario();
                                $scope.divprescricao = false;
                                toastr["success"]("Prescricao Adicionado com sucesso!", "MedicalManagement-Sys");
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


                $scope.inibeBtnAdicionar = function () {
                    if (($scope.Acao === "Atualizar") || ($scope.Acao === "Adicionar")) {
                        return true;
                    }
                    return false;
                };

                $scope.cancelaEdicao = function () {
                    $scope.Acao = "";
                    $scope.divprescricao = false;
                    $scope.prescricaoForm.$setPristine();
                };

                $scope.verificaAcao = function () {
                    if ($scope.Acao === 'Atualizar') {
                        return true;
                    } else {
                        return false;
                    }
                };

                //ArquivarPrescricao

                /* -----/ Objetos de Prescrição ------------------------------------ */
                /* -----/ Objetos de Prescrição ------------------------------------ */
                /* -----/ Objetos de Prescrição ------------------------------------ */
                /* -----/ Objetos de Prescrição ------------------------------------ */

                $scope.hidratacoes = [
                    { id: 1, Descricao: "Sem Acesso" },
                    { id: 2, Descricao: "Acesso Salinizado" },
                    { id: 3, Descricao: "Soro Fisiológico 0,9%" },
                    { id: 4, Descricao: "Salina 0,45%" },
                    { id: 5, Descricao: "Soro Glicosado 5%" },
                    { id: 6, Descricao: "Ringer Lactado" },
                    { id: 7, Descricao: "Ringer Simples" }
                ];

                $scope.nebulizacaointervalos = [
                    { id: 1, Descricao: "Horária" },
                    { id: 2, Descricao: "2 / 2 horas" },
                    { id: 3, Descricao: "4 / 4 horas" },
                    { id: 4, Descricao: "6 / 6 horas" },
                    { id: 5, Descricao: "8 / 8 horas" },
                    { id: 6, Descricao: "12 / 12 horas" },
                    { id: 7, Descricao: "Não fazer" }
                ];

                $scope.dietas = [];

                $scope.dietasvolumes = [
                    { id: 1, Descricao: "2000 ml pela BI em 24 horas" },
                    { id: 2, Descricao: "Líquida de Prova" },
                    { id: 3, Descricao: "500 ml pela BI em 24 horas" }
                ];

                $scope.dietasconsistencias = [
                    { id: 1, Descricao: "Livre" },
                    { id: 2, Descricao: "Branda" },
                    { id: 3, Descricao: "Leve sem resíduos" },
                    { id: 4, Descricao: "Líquida" },
                    { id: 5, Descricao: "Líquida pastosa" },
                    { id: 6, Descricao: "Líquida de prova" },
                    { id: 7, Descricao: "Pastosa" }
                ];

                $scope.dietassondagastricas = [
                    { "id": 1, "Descricao": "Até 2ª ordem" },
                    { "id": 2, "Descricao": "SNG em sinfonagem" },
                    { "id": 3, "Descricao": "SNG em gavagem" },
                    { "id": 4, "Descricao": "Sem sonda" }
                ];

                $scope.dietascomorbidades = [
                    { "id": 1, "Descricao": "HAS" },
                    { "id": 2, "Descricao": "Hiperprotéica" },
                    { "id": 3, "Descricao": "Nefropatia" },
                    { "id": 4, "Descricao": "Pneumopatia" },
                    { "id": 5, "Descricao": "Diarreia" },
                    { "id": 6, "Descricao": "Diabetes" },
                    { "id": 8, "Descricao": "Hipercalórica" },
                    { "id": 9, "Descricao": "Hepatopatia" },
                    { "id": 10, "Descricao": "Dislipidemia" },
                    { "id": 11, "Descricao": "Constipação" }
                ];

                $scope.hidratacaovolumes = [
                    { id: 1, Descricao: "1000 ml IV nas 24 horas" },
                    { id: 2, Descricao: "1500 ml IV nas 24 horas" },
                    { id: 3, Descricao: "2000 ml IV nas 24 horas" },
                    { id: 4, Descricao: "2500 ml IV nas 24 horas" },
                    { id: 5, Descricao: "3000 ml IV nas 24 horas" },
                    { id: 6, Descricao: "3500 ml IV nas 24 horas" },
                    { id: 7, Descricao: "4000 ml IV nas 24 horas" },
                    { id: 8, Descricao: "4500 ml IV nas 24 horas" }
                ];

                $scope.antiacidos = [
                    { id: 1, Descricao: "Ranitidina" },
                    { id: 2, Descricao: "Omeprazol" },
                    { id: 3, Descricao: "Não fazer" }
                ];

                $scope.procineticos = [
                    { id: 1, Descricao: "Bromoprida" },
                    { id: 2, Descricao: "Metoclopramina" },
                    { id: 3, Descricao: "Não fazer" }
                ];

                $scope.antiacidoposologias = [
                    { id: 1, Descricao: "8 / 8 horas" },
                    { id: 2, Descricao: "12 / 12 horas" },
                    { id: 3, Descricao: "Um vez ao dia" }
                ];

                $scope.anticoagulacoesprescricao = [
                    { id: 1, Descricao: "Enoxiparina" },
                    { id: 2, Descricao: "Heparina" },
                    { id: 3, Descricao: "Não fazer" }
                ];

                $scope.anticoagulacaoposologias = [
                    { id: 1, Descricao: "40 mg SC 1x ao dia" }
                ];

                $scope.procineticointervalos = [
                    { id: 1, Descricao: "4 / 4 horas" },
                    { id: 2, Descricao: "6 / 6 horas" },
                    { id: 3, Descricao: "8 / 8 horas" },
                    { id: 4, Descricao: "12 / 12 horas" },
                    { id: 5, Descricao: "Um vez ao dia" }
                ];

                // ---------------------------------------------------------------- //
                // ---------------------------------------------------------------- //
                // -----/ Prescricao->Outros  ------------------------------------- //

                $scope.insulinaregulares = [
                    { "id": 1, "Descricao": "Subcutânea" },
                    { "id": 2, "Descricao": "Dripping" }
                ];
                $scope.oxigenoterapias = [
                    { "id": 1, "Descricao": "Ar Ambiente" },
                    { "id": 2, "Descricao": "Macronebulização" },
                    { "id": 3, "Descricao": "Ventilação Mecânica" }
                ];


                $scope.sintomaticosfebreedor = [
                    { "id": 1, "Descricao": "Dipirona" },
                    { "id": 2, "Descricao": "Paracetamol" }
                ];
                $scope.sintomaticosemese = [
                    { "id": 1, "Descricao": "Metoclopramida" },
                    { "id": 2, "Descricao": "Bromoprida" },
                    { "id": 3, "Descricao": "Ondansetrona" }
                ];
                $scope.sintomaticoshipertensao = [{ "id": 1, "Descricao": "Captopril" }];


                // -----/ GlicemiaCapilar  ---------------------------------------- //
                $scope.glicemiascapilares = [
                    { id: 1, Descricao: "Um vez ao dia" },
                    { id: 2, Descricao: "2 / 2 horas" },
                    { id: 3, Descricao: "4 / 4 horas" },
                    { id: 4, Descricao: "6 / 6 horas" },
                    { id: 5, Descricao: "8 / 8 horas" },
                    { id: 6, Descricao: "12 / 12 horas" },
                    { id: 7, Descricao: "Nas refeições" },
                    { id: 8, Descricao: "Não fazer" }
                ];
                // -----/ Fim Prescricao->Outros  --------------------------------- //

                // -----/ Fisioterapia  ---------------------------------------------- //
                $scope.fisioterapias = [];
                function obterFisioterapias() {
                    var fisioterapiasData = fisioterapiaService.ObterTodas();
                    fisioterapiasData.then(function (fisioterapia) {
                        $scope.fisioterapias = fisioterapia.data;
                    }, function () {
                        toastr["error"]("Erro ao obter fisioterapias", "MedicalManagement-Sys");
                    }
                    );
                };
                obterFisioterapias();
                // -----/ Fisioterapia  ---------------------------------------------- //



                /* -----/ FIM: Objetos de Prescrição ------------------------------ */
                /* -----/ FIM: Objetos de Prescrição ------------------------------ */
                /* -----/ FIM: Objetos de Prescrição ------------------------------ */
                /* -----/ FIM: Objetos de Prescrição ------------------------------ */



                // -----------------------------------------------------------------
                // -----------------------------------------------------------------
                // ---- Genéricos 2 ------------------------------------------------


                // Generic optimized function
                $scope.getInibirData = function (onOff, optionSelected) {

                    var str = optionSelected.split(';');
                    var vIndex = optionSelected.indexOf(onOff);
                    if (vIndex > -1) {
                        return true;
                    } else {
                        return false;
                    }
                };


                $scope.isDisableCbo = function (chk) {
                    return !chk;
                }

                $scope.ordenarPor = function (campo) {
                    $scope.criterioDeOrdenacao = campo;
                    $scope.direcaoDaOrdenacao = !$scope.direcaoDaOrdenacao;
                };


            }
        ]);

})();