angular.module("umbraco").controller("googlemap.grideditorcontroller", function ($scope, $sce, editorService) {

    $scope.init = function () {
        if (!$scope.control.value) {
            $scope.control.value = null;
        }
    }();

    $scope.openSettingsPanel = function () {
        var options = {
            title: 'Settings',
            value: $scope.control.value,
            view: '/App_Plugins/googlemap/editor-panel.html',
            size: 'small',
            submit: function (model) {
                $scope.control.value = model;
                editorService.close();
            },
            close: function () {
                editorService.close();
            }
        };
        editorService.open(options);
    };

    $scope.renderHtml = function () {
        if ($scope.control.value.src && typeof $scope.control.value.src === 'string') {
            return $sce.trustAsHtml($scope.control.value.src);
        }
        return '';
    };
});
