var app = angular.module("ApplicationModule", ["ngRoute"]);
debugger;
app.factory("ShareData", function () {
    return { value: 0 }
});

app.config(['$routeProvider', function ($routeProvider) {
    debugger

    $routeProvider.when('/showstudents',
                       {
                           templateUrl:'ManageStudentInfo/ShowStudents',
                           controller: 'ShowStudentsController'
                       });
    $routeProvider.otherwise(
                       {
                           redirectTo: '/showstudents'
                       });
   
}]);