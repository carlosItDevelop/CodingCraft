
// ---/ uiModal Full Calendar---
app.controller('ModalFullCalendarCtrl', [
    '$scope', '$uibModalInstance', 'NewEvent', function ($scope, $uibModalInstance, NewEvent) {
        $scope.NewEvent = NewEvent;
        $scope.Message = "";
        $scope.ok = function () {
            if ($scope.NewEvent.Title.trim() !== "") {
                $uibModalInstance.close({ event: $scope.NewEvent, operation: 'Save' });
            } else {
                $scope.Message = "O título do evento é requerido!";
            }
        }
        $scope.delete = function () {
            $uibModalInstance.close({ event: $scope.NewEvent, operation: 'Delete' });
        }
        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        }
    }
]);
