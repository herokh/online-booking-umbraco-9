angular.module("umbraco").controller("my.notecontroller", function ($scope, assetsService) {

    $scope.init = function () {
        assetsService.loadCss("~/App_Plugins/note/editor.css");
    };

    $scope.init();
});
