

(function () {
    'use strict';
    app.controller("notificacoesCtrl",
        ['$rootScope', '$scope', 'notificacoesService',
            function ($rootScope, $scope, notificacoesService) {

                $scope.titulo = "Evolução Médica - Notificações";

                /*
                    // Ouvir o evento disparado por ProntuarioCtrl aqui em PrescriaoCtrl;
                    $scope.ProntuarioArquivar = {};
                    $scope.$on('evArquivarProntuario', function (event, oProntuario) {
                        $scope.ProntuarioArquivar = oProntuario;
                        console.log('Objeto -> Id do Prontuario; ' + oProntuario.ProntuarioId);
                        console.log('Objeto -> Guid do Paciente; ' + oProntuario.PacienteId);
                        console.log('Objeto -> Paciente.Nome; ' + oProntuario.Paciente.Nome);
                        console.log('Scope -> prontuario.NumAtendimento; ' + $scope.ProntuarioArquivar.NumAtendimento);
                    });
                 */


                // Ouvir o evento disparado por $broadCast, onde for disparado;
                $scope.registroAddPaciente = {};
                $scope.$on('evAddPaciente', function (event, oAddPaciente) {
                    $scope.registroAddPaciente = oAddPaciente;
                });

                $scope.registroAddAtendimento = {};
                $scope.$on('evAddAtendimento', function (event, oAddAtendimento) {
                    $scope.registroAddAtendimento = oAddAtendimento;
                });

                $scope.registroAddProntuario = {};
                $scope.$on('evAddProntuario', function (event, oAddProntuario) {
                    $scope.registroAddProntuario = oAddProntuario;
                });

                //// exemplo de como deve ser chamado o disparo do evento
                //$scope.NotifyAddProntuario = function (oAddProntuario) {
                //    $rootScope.$broadcast('evAddProntuario', oAddProntuario)
                //};

            }
        ]);

})();