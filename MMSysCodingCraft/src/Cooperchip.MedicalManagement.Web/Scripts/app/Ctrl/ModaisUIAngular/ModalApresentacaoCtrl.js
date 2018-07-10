// Please note that $uibModalInstance represents a modal window (instance) dependency.
// It is not the same as the $uibModal service used above.

(function () {

    app.controller('modalApresentacaoCtrl', function ($scope, $uibModalInstance, vMdct) {

        $scope.vMdct = vMdct;
        $scope.ok = function () {
            $uibModalInstance.close();
        };

    });

})();

