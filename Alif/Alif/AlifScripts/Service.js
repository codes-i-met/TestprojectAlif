app.service("SPACRUDService", function ($http) {
    debugger;
    //Read all Students
    this.getStudents = function () {

        return $http.get("api/Students");
    };
});