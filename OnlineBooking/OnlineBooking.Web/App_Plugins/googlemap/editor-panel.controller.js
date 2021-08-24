angular.module("umbraco").controller("my.googlemap.panel.grideditorcontroller", function ($scope) {

    $scope.submit = function () {
        if ($scope.model.submit) {
            $scope.model.submit($scope.model.value);
        }
    };

    $scope.close = function () {
        if ($scope.model.close) {
            $scope.model.close();
        }
    };
});
