app.controller('ShowStudentsController', function ($scope, $location, SPACRUDService, ShareData) {
    loadAllStudentsRecords();
    debugger;
    function loadAllStudentsRecords() {
        var promiseGetStudent = SPACRUDService.getStudents();

        promiseGetStudent.then(function (pl) { $scope.Students = pl.data },
              function (errorPl) {
                  $scope.error = errorPl;
              });
    }

  
});