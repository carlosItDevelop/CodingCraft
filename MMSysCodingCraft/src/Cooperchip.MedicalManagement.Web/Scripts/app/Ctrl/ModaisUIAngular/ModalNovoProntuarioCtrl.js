(function () {

    app.controller('ModalNovoProntuarioCtrl',
        ['$scope', '$uibModalInstance', 'oProntuario', '$http',
            function ($scope, $uibModalInstance, oProntuario, $http) {
                $scope.oProntuario = oProntuario;
                $scope.fechar = function () {
                    $uibModalInstance.close();
                };

                $scope.gerarNovoProntuario = function (pront, newAtdto) {
                    var prontuarioData = null;
                    var _prontuario = {};
                    _prontuario = {
                        ProntuarioId: pront.ProntuarioId,
                        PacienteId: pront.Paciente.PacienteId,
                        NumAtendimento: newAtdto,
                        DataProntuario: pront.DataProntuario
                    };
                    prontuarioData = AddProntuarioBase(_prontuario);
                    prontuarioData.then(function (data) {
                        if (data.status === 200) {
                            toastr["success"]("Prontuário Adicionado com sucesso!", "MedicalManagement-Sys");

                            // AddNotifyAtendimento => Lançar esse evento;

                            //atualizaListaDeProntuarios(_prontuario.PacienteId);
                            $uibModalInstance.close(data);
                        }
                    }, function (data) {
                        //console.log(data.data);
                        if (data.status === 400) {
                            toastr["warning"](data.data, "MedicalManagement-Sys");
                        };
                    });
                };

                //AdicionarProntuarioBase
                var AddProntuarioBase = function (prontuario) {
                    var response = $http({
                        method: "post",
                        url: "/api/v1/evm/AdicionarProntuarioBase",
                        data: JSON.stringify(prontuario),
                        dataType: "json"
                    });
                    return response;
                };

            }
        ]);

})();