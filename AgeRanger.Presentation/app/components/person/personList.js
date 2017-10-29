(function () {
    var app = angular.module("app");
    app.controller("personListController", ["dataService",
        function (dataService) {
            var vm = this;

            dataService.getPeople().then(function (response) {
                vm.people = response.data;
            });
            

        }]);

}());
