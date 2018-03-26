app = angular.module('ClientApp', ['textAngular']); 
 
app.controller('MyController', ['$scope', function($scope){
    $scope.sample = 'Shout out from the javascript!';
}]);