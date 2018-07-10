(function () {

    'use strict';

    // $routeParams Usar quando apropriado;
    app.controller("pacienteCtrl",
        ['$rootScope',
        '$uibModal',
        '$scope',
        '$http',
        '$filter',
        'pacienteService',
        '$location',
        'convenioService',
        'leitoService',
        'estadoDoPacienteService',
        'setorService',
        function ($rootScope, $uibModal, $scope, $http, $filter, pacienteService, $location, convenioService, leitoService, estadoDoPacienteService, setorService) {



        // -----------------------------------------------------  //
        // -----/ Modal Novo Prontuario -------------------- //
        $scope.CriarNovoProntuario = function (paciente) {
            openNewprontuario('lg', paciente);
        };
        $scope.animationsEnabled = true;
        var openNewprontuario = function (size, paciente) {
            $scope.oProntuario = {};
            $http.get("/Prontuario/MakeNewProntuario/").success(function (data) {
                $scope.oProntuario = data;
                $scope.oProntuario.Paciente = paciente;
                $scope.oProntuario.PacienteId = $scope.oProntuario.Paciente.PacienteId;
                //$scope.oProntuario.DataProntuario = new Date($scope.oProntuario.DataProntuario);
                var modalInstance = $uibModal.open({
                    animation: $scope.animationsEnabled,
                    templateUrl: 'novoprontuario.html',
                    controller: 'ModalNovoProntuarioCtrl',
                    size: size,
                    resolve: {
                        oProntuario: function () {
                            return $scope.oProntuario;
                        }
                    }
                });
                modalInstance.result.then(function (resultado) {
                    console.log("Retorno do Modal: " + resultado);

                    // Chamo o AddNotifyAtendimento
                    

                }, function (data) {
                    console.log("Saída sem gravar. \nMensagem: " + data);
                });
            }).error(function (data, status) {
                toastr["error"]("Erro ao carregar form para novo Prontuário!", "MedicalManagement-Sys");
            });
        };
        // -----/ Modal Novo Prontuario -------------------- //
        // -------------------------------------------------------  //

        //-------------------------------------------------------------------------------------------------     //
        // Quando usar na base de dados trazer apenas top(n) em ordem cronológica (de chegada/registro);        //
        $scope.prontuarioPendentes = [                                                                          //
            { "prontuarioId": 125, "nomePaciente": "Elisa Mariana", "PacienteId": 555, "NumAtd":"2586578" },    //                    
            { "prontuarioId": 547, "nomePaciente": "Elenita Gomes", "PacienteId": 888, "NumAtd":"5870012" },    //
            { "prontuarioId": 126, "nomePaciente": "Lucio Flavio", "PacienteId": 120, "NumAtd": "3233011" },    //
            { "prontuarioId": 135, "nomePaciente": "Marcos Souza", "PacienteId": 158, "NumAtd": "1200009" },    //    
            { "prontuarioId": 225, "nomePaciente": "Mariana Licheski", "PacienteId":658,"NumAtd":"2586578"},    //
            { "prontuarioId": 195, "nomePaciente": "Apollo Sardinha", "PacienteId": 784, "NumAtd": "2586000" }, //
            { "prontuarioId": 128, "nomePaciente": "Leila Moreno", "PacienteId": 987, "NumAtd": "2500078" },    //
            { "prontuarioId": 144, "nomePaciente": "Walfrido Canavieira", "PacienteId": 121,"NumAtd":"2586578"} //
        ];                                                                                                      //
                                                                                                                //
        $scope.numChangeNotify = $scope.prontuarioPendentes.length;                                             //
        //console.log($scope.numChangeNotify);                                                                  //
                                                                                                                //
        // Estou usando este listener provisoriamente, pois só                                                  //
        // queria testar a incrementação de numChangeNotify.                                                    //
        // O evento lançado será o de quando houver Add, Del or Update                                          //
        // Na tabela ProntuarioBase, ou quando o prontuario                                                     //
        // for gravado / editado / salvo em ListaProntuario                                                     //
        $scope.$on('evArquivarProntuario', function (event, oProntuario) {                                      //
                $scope.numChangeNotify++;
        });                                                                                                     //
                                                                                                                //
        //MostraPaciente(prontuarioPendentes)                                                                   //
        $scope.MostraPaciente = function (atendimento) {                                                        //
            console.log(atendimento);                                                                           //
            $scope.numChangeNotify--;
        };                                                                                                      //
        //-------------------------------------------------------------------------------------------------     //


        // ----/ Usando o ngRoute --------------------------- //
        $scope.PrescreverEvoluir = function (paciente) {
            // To usando href e ng-click juntos. 
            // O href chama o ProntuarioBase e
            // o ng-click executa esta função, onde
            // pretendo usar $broadcast para levar
            // os dados do prontuario/paciente ou só paciente;
            $scope.pct = {};
            $scope.pct = paciente;
            console.log($scope.pct);
            //$location.path('/ListaProntuarioBase/' + $scope.pct.PacienteId);
        };
        // -------------------------------------------------------  //




        // Este $http só está aqui provisoriamente,
        // até  eu conseguir  uma  solução  melhor,
        // pois estou trabalhando com serviços.

        $scope.divpaciente = false;
        $scope.titulo = "Lista de Pacientes";
        $scope.cidadaptadas = [];
        $scope.cidadaptada = {};

        // -- Outras Complicações --- //
        $scope.paciente = {};
        if ($scope.Acao === "Atualizar") {
            $scope.paciente = {
                Hepatopatia: false,
                Gravidez: false,
                Amamentacao: false
            };
        };


        //$scope.paciente = {"Ativo": null};
        //$scope.convenio = {};
        //$scope.leito = {};
        //$scope.estadoDoPaciente = {};
        //$scope.sexo = {};
        //$scope.setor = {};




        /* ------------------------------------------------------------ */
        /* ------------------------------------------------------------ */
        // Preenchi a DDList
        $scope.hppregressas = [];
        var getHppregressa = function () {
            $http.get("/HistoriaPatologicaPregressa/getHPPregressa").success(function (data) {
                $scope.hppregressas = data;
            }).error(function (data, status) {
                toastr["error"]("Erro ao carregar Hist. Patol. Pregressa!", "MedicalManagement-Sys");
            });
        };
        getHppregressa();
        /* ------------------------------------------------------------ */
        $scope.complicacoes = [];
        var getComplicacoes = function () {
            $http.get("/Complicacao/getComplicacao").success(function (data) {
                $scope.complicacoes = data;
            }).error(function (data, status) {
                toastr["error"]("Erro ao carregar Complicação!", "MedicalManagement-Sys");
            });
        };
        getComplicacoes();
        /* ------------------------------------------------------------ */
        $scope.alergias = [];
        var GetAlergia = function () {
            $http.get("/Alergia/GetAlergia").success(function (data) {
                $scope.alergias = data;
            }).error(function (data, status) {
                toastr["error"]("Erro ao carregar Alergias!", "MedicalManagement-Sys");
            });
        };
        GetAlergia();
        /* ------------------------------------------------------------ */
        /* ------------------------------------------------------------ */


        /* ------------------------------------------------------------ */
        /* ------------------------------------------------------------ */
        /* ------------------------------------------------------------ */
        /*
            Verificar a possibilidade de deixar
            genérico os dois códigos abaixo!
        */

        /* Implementação das TagInputs Hpp - By Jean */
        const getValues = (obj, i) => obj['Descricao'];
        const mapToValues = (arr) => arr.map(getValues);
        $scope.$watch('vetorHppregressa', function (newValue, oldValue) {
            if (newValue) {
                const result = mapToValues(newValue).join(', ')
                //console.log('values: ', result);
                $scope.paciente.HistoriaPatologicaPregressa = result;
            }
        });
        /* ------------------------------------------------------------ */

        /* Implementação das TagInputs - By Carlos  */
        const getValuesComplicacao = (obj, i) => obj['Descricao'];
        const mapToValuesComplicacao = (arr) => arr.map(getValuesComplicacao);
        $scope.$watch('vetorComplicacao', function (newValue, oldValue) {
            if (newValue) {
                const result = mapToValuesComplicacao(newValue).join(', ')
                $scope.paciente.Complicacao = result;
            }
        });

        /* ------------------------------------------------------------ */
        const getValuesAlergia = (obj, i) => obj['Descricao'];
        const mapToValuesAlergia = (arr) => arr.map(getValuesAlergia);
        $scope.$watch('vetorAlergia', function (newValue, oldValue) {
            if (newValue) {
                const result = mapToValuesAlergia(newValue).join(', ')
                $scope.paciente.Alergia = result;
            }
        });

        /* ------------------------------------------------------------ */
        /* ------------------------------------------------------------ */
        /* ------------------------------------------------------------ */


        $scope.sexos = [
            { SexoId: 1, Descricao: "Feminino" },
            { SexoId: 2, Descricao: "Masculino" }
        ];


        function obterTodosOsLeitos() {
            var leitosData = leitoService.ObterLeitos();
            leitosData.then(function (leito) {
                $scope.leitos = leito.data;
            }, function () {
                toastr["error"]("Erro ao obter leitos", "MedicalManagement-Sys");
            }
            );
        };
        obterTodosOsLeitos();



        function obterTodosOsConvenios() {
            var conveniosData = convenioService.ObterTodas();
            conveniosData.then(function (convenio) {
                $scope.convenios = convenio.data;
            }, function () {
                toastr["error"]("Erro ao obter convenios", "MedicalManagement-Sys");
            }
            );
        };
        obterTodosOsConvenios();


        function obterTodosOsSetores() {
            var setorsData = setorService.ObterSetores();
            setorsData.then(function (setor) {
                $scope.setors = setor.data;
            }, function () {
                toastr["error"]("Erro ao obter setores", "MedicalManagement-Sys");
            }
            );
        };
        obterTodosOsSetores();


        function obterTodosOsEstadoDoPacientes() {
            var estadoDoPacientesData = estadoDoPacienteService.ObterTodas();
            estadoDoPacientesData.then(function (estadoDoPaciente) {
                $scope.estadoDoPacientes = estadoDoPaciente.data;
            }, function () {
                toastr["error"]("Erro ao obter estadoDoPacientes", "MedicalManagement-Sys");
            }
            );
        };
        obterTodosOsEstadoDoPacientes();



        function ctrlGetPaciente() {
            var pacientesData = pacienteService.srvcObterPacientes();
            pacientesData.then(function (paciente) {
                $scope.pacientes = paciente.data;
                $scope.Acao = "";
            }, function () {
                toastr["error"]("Erro ao obter pacientes", "MedicalManagement-Sys");
            }
            );
        };
        ctrlGetPaciente();


        // obter por id
        // Habilita DIV para Edição de registros
        $scope.ctrlObterPorId = function (paciente) {
            //debugger;
            //$scope.paciente = {};
            var pacienteData = pacienteService.srvcGetPacientePorId(paciente.PacienteId);
            pacienteData.then(function (paciente) {

                $scope.paciente = paciente.data;

                $scope.paciente.RgDataEmissao = new Date(paciente.data.RgDataEmissao);
                $scope.paciente.DataInternacao = new Date(paciente.data.DataInternacao);
                $scope.paciente.DataNascimento = new Date(paciente.data.DataNascimento);


                var nascimento = new Date(paciente.data.DataNascimento).getFullYear();
                var dataatual = new Date().getFullYear();
                var diff = dataatual - nascimento;

                $scope.Idade = diff;


                $scope.Acao = "Atualizar";
                $scope.divpaciente = true;
                //toastr["warning"]("Paciente carregado para edição!", "MedicalManagement-Sys");

            }, function () {
                toastr["error"]("Erro ao obter paciente por id!", "MedicalManagement-Sys");
            });
        };



        // Habilita DIV para Adição de registros
        $scope.incluirPacienteDiv = function () {
            $scope.paciente = {};
            $scope.pacienteForm.$setPristine();

            var pacienteData = pacienteService.novoPaciente();
            pacienteData.then(function (result) {
                $scope.paciente = result.data;
                $scope.paciente.DataInternacao = new Date(result.data.DataInternacao);
            }, function () {
                toastr["error"]("Erro ao Criar novo paciente!", "MedicalManagement-Sys");
            });

            //console.log($scope.paciente);
            $scope.Acao = "Adicionar";
            $scope.divpaciente = true;
        };



        $scope.ExcluirPaciente = function alert_it(paciente) {
            swal({
                title: "Tem certeza que deseja excluir este registro?",
                text: "Após a exclusão não será possível recuperá-lo!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Sim, Pode excluir!",
                closeOnConfirm: false
            }, function () {
                apagarRegistro(paciente)
            });
        }



        var apagarRegistro = function (paciente) {
            var pacienteData = pacienteService.Excluir(paciente.PacienteId);
            pacienteData.then(function (data, status) {
                if (data.status === 200) {
                    toastr["warning"]("Paciente excluído com sucesso!", "MedicalManagement-Sys");
                    ctrlGetPaciente();
                }
            }, function (data) {
                console.log(data.data);
                if (data.status === 400) {
                    toastr["warning"](data.data, "MedicalManagement-Sys");
                };
            });
        };



        /* Idade, calculado pela data de nascimento; */
        $scope.AdicionarEditarPaciente = function () {
            var pacienteData = null;
            var _paciente = {};
            //debugger;
            _paciente = {
                Nome: $scope.paciente.Nome,
                Peso: $scope.paciente.Peso,
                DataInternacao: $scope.paciente.DataInternacao,
                Cpf: $scope.paciente.Cpf,
                Rg: $scope.paciente.Rg,
                RgOrgao: $scope.paciente.RgOrgao,
                RgDataEmissao: $scope.paciente.RgDataEmissao,
                Email: $scope.paciente.Email,
                DataNascimento: $scope.paciente.DataNascimento,
                idConvenio: $scope.paciente.idConvenio,
                IdLeito: $scope.paciente.IdLeito,
                Alergia: $scope.paciente.Alergia,
                idSexo: $scope.paciente.idSexo,
                EstadoPacienteId: $scope.paciente.EstadoPacienteId,
                IdSetor: $scope.paciente.IdSetor,
                Ativo: $scope.paciente.Ativo,
                Hepatopatia: $scope.paciente.Hepatopatia,
                Gravidez: $scope.paciente.Gravidez,
                Amamentacao: $scope.paciente.Amamentacao,
                PacienteId: $scope.paciente.PacienteId,
                HistoriaPatologicaPregressa: $scope.paciente.HistoriaPatologicaPregressa,
                Complicacao: $scope.paciente.Complicacao,
                CodigoCid: $scope.paciente.CodigoCid
            };
            var valorAcao = $scope.Acao;
            if (_paciente.idSexo === 2 && (_paciente.Gravidez || _paciente.Amamentacao)) {
                toastr["error"]("Paciente Masculino Incompatível com Gravidez e/ou Amamentação!", "MedicalManagement-Sys");
            } else {
                if (valorAcao === "Atualizar") {
                    _paciente.PacienteId = $scope.paciente.PacienteId;

                    pacienteData = pacienteService.AtualizarPaciente(_paciente);
                    pacienteData.then(function (data, status) {
                        if (data.status === 200) {
                            toastr["success"]("Paciente alterado com sucesso!", "MedicalManagement-Sys");
                            ctrlGetPaciente();
                            $scope.divpaciente = false;
                        };
                    }, function (data) {
                        console.log(data.data);
                        if (data.status === 400) {
                            toastr["warning"](data.data, "MedicalManagement-Sys");
                        };
                        //toastr["warning"]("Erro ao Alterar Paciente", "MedicalManagement-Sys");
                    });

                } else if (valorAcao === "Adicionar") {

                    pacienteData = pacienteService.AdicionarPaciente(_paciente);
                    pacienteData.then(function (data) {
                        if (data.status === 200) {
                            toastr["success"]("Paciente Adicionado com sucesso!", "MedicalManagement-Sys");
                            ctrlGetPaciente();
                            $scope.divpaciente = false;
                        }
                    }, function () {
                        toastr["error"]("Erro ao Adicionar paciente!", "MedicalManagement-Sys");
                    });
                }
            }
        };



        $scope.cancelaEdicao = function () {
            $scope.Acao = "";
            $scope.divpaciente = false;
            $scope.pacienteForm.$setPristine();
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


    }]);

})();